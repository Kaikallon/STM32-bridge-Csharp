﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    public class CanMessage
    {
        public bool           IdExtended         { get; set; }     // Specifies if ID is standard (11-bit) or extended (29-bit) identifier.

        public UInt32         Id                 { get; set; }     // Identifier of the message (11bit or 29bit according to IDE).
        public bool           RTR                { get; set; }     // Remote Frame Request or data frame message type.
        public byte           DLC                { get; set; }     // Data Length Code is the number of data bytes in the received message 
                                                                   // or number of data bytes requested by RTR.
        public bool           Fifo               { get; set; }     // Fifo in which the message was received (according to Filter initialization)
        public UInt64         Data               { get; set; }     // Raw data for transport on the bus
        public Int64          SystemTimeStamp    { get; set; } = DateTime.Now.Ticks; // Computer time at receival

        public void InsertBits(int startBit, UInt64 bitmask, UInt64 bits)
        {
            // Get the bits, trim and shift according to specification
            bits <<= startBit;
            bits &= bitmask; // Trim

            // Add to payload
            Data |= bits;
        }

        public UInt64 ExtractBits(int startBit, UInt64 bitmask)
        {
            // TODO: Check if the bitmask has been calculated
            // Isolate relevant bits using precalculated bitmask
            UInt64 bits = Data;
            bits &= bitmask;

            // Shift back to original state according to specification
            bits >>= startBit;

            return bits;
        }
    }

    public abstract class CanMessageExtended : CanMessage
    {
        //public CanMessageExtended(CanMessage canMessage)
        //{
        //    this.Data            = canMessage.Data;
        //    this.DLC             = canMessage.DLC;
        //    this.Fifo            = canMessage.Fifo;
        //    this.Id              = canMessage.Id;
        //    this.RTR             = canMessage.RTR;
        //    this.SystemTimeStamp = canMessage.SystemTimeStamp;
        //}

        public void SetFields(CanMessage canMessage)
        {
            this.Data            = canMessage.Data;
            this.DLC             = canMessage.DLC;
            this.Fifo            = canMessage.Fifo;
            this.Id              = canMessage.Id;
            this.RTR             = canMessage.RTR;
            this.SystemTimeStamp = canMessage.SystemTimeStamp;
        }

        abstract public void NotifySubscribers();

        public static CanMessageType MessageType { get; protected set; }

        public UInt64 ExtractBits(CanSignalType signal)
        {
            if (signal.Encoding == SignalEncoding.Motorola)
            {
                throw new Exception("Motorola byte order not supported");
            }

            var bits = ExtractBits(signal.StartBit, signal.BitMask);

            if (signal.Type == SignalType.Signed)
                bits = TwosComplementCompensation(bits, signal.Length);
                
            return bits;
        }

        public void InsertBits(CanSignalType signal, UInt64 bits)
        {
            InsertBits(signal.StartBit, signal.BitMask, bits);
        }

        private UInt64 TwosComplementCompensation(UInt64 bits, int Length)
        {
            int shift = 64 - Length;
            // Exploit arithmetic shift to fill MSBs with ones
            return (UInt64)(((Int64)bits << shift) >> shift);
        }


        private float BitsToFloat(UInt64 data)
        {
            UInt32 temp = (UInt32)data;
            unsafe
            {
                return *(float*)(&temp);

            }
        }

        private UInt64 floatToBits(float data)
        {
            unsafe
            {
                UInt32 temp = *(UInt32*)(&data);
                return (UInt64)temp;
            }
        }
    }

    public abstract class CanMessageExtended<T> : CanMessageExtended where T : CanMessageExtended<T>
    {
        public static event EventHandler<CanMessageReceivedEventArgs<T>> CanMessageReceived;
        override public void NotifySubscribers()
        {
            CanMessageReceivedEventArgs<T> canMessageReceivedEventArgs = new CanMessageReceivedEventArgs<T>();
            canMessageReceivedEventArgs.ReceivedMessage = (T)this;

            CanMessageReceived?.Invoke(this, canMessageReceivedEventArgs); // TODO: Consider changing to BeginInvoke to utilize multiple threads
            //CanMessageReceived?.BeginInvoke(this, canMessageReceivedEventArgs, CanMessageReceivedEndAsyncEvent, null);
        }

        // TODO: Investigate if something like this should be implemented
        //protected void CanMessageReceivedEndAsyncEvent(IAsyncResult iar)
        //{
        //    var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
        //    var invokedMethod = (CanMessageReceivedHandler)ar.AsyncDelegate;
        //    try
        //    {
        //        invokedMethod.EndInvoke(iar);
        //    }
        //    catch (Exception e)
        //    {
        //        // Handle any exceptions that were thrown by the invoked method
        //        Console.WriteLine("An event listener went kaboom!");
        //        // TODO: Handle this?
        //    }
        //}
    }


    public class CanMessageReceivedEventArgs<T> where T : CanMessage
    {
        public T ReceivedMessage { get; set; }
    }

    class TestMessage : CanMessageExtended<TestMessage>
    {
        public readonly CanSignalType CanSignal = new CanSignalType
        {
            StartBit = 0,
            Length = 8,
            Offset = 50,
            ScaleFactor = 10,
            Name = "TestSignal1",
        };

        public TestMessage()
        {
            MessageType = new CanMessageType
            {
                Id = 305419896,
                DLC = 4,
                //Flags = MESSAGE.EXT,
                Name = "TestMessage1",
            };

            MessageType.Signals.Add(CanSignal.Name, CanSignal);
        }


        public double GetTestSignal1()
        {
            // Get bits from raw data storage and cast
            double tempValue = (double)ExtractBits(CanSignal);

            // Apply inverse transform to restore actual value
            tempValue -= CanSignal.Offset;
            tempValue /= CanSignal.ScaleFactor;
            return tempValue;
        }

        public void SetTestSignal1(double value)
        {
            // Scale and offset value according to signal secification
            double tranformedValue = value * CanSignal.ScaleFactor;
            tranformedValue += CanSignal.Offset;

            // Cats to integer and prepare for sending
            this.InsertBits(CanSignal, (UInt64)tranformedValue);

        }
    }
}
