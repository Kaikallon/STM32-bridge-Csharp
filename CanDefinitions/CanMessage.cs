using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    public interface ICanSignal
    {
        UInt64 ExtractBits(CanSignalType signal);

        UInt64 Data { get; set; }


        //public sbyte GetFN_WaterR()
        //{
        //    // Get bits from raw data storage and cast
        //    sbyte tempValue = (sbyte)ExtractBits(FN_WaterR);
        //    // Apply inverse transform to restore actual value
        //    tempValue += -5;
        //    tempValue *= 2;
        //    return tempValue;
        //}
    }
    public interface ICanSignal<T> : ICanSignal
    {
        T Get();
        void Set(T value);
    }

    public abstract class ACanSignal<T> : ICanSignal<T>
    {
        public UInt64         Data                      { get; set; }
        public CanSignalType  SignalType                { get; protected set; } 


        public abstract T Get();
        public abstract void Set(T value);
        public ulong ExtractBits(CanSignalType signal)
        {
            if (signal.Encoding == SignalEncoding.Motorola)
            {
                throw new Exception("Motorola byte order not supported");
            }
            // TODO: Check if the bitmask has been calculated
            // Isolate relevant bits using precalculated bitmask
            UInt64 bits = Data;
            bits &= signal.BitMask;

            // Shift back to original state according to specification
            bits >>= signal.StartBit;

            return bits;
        }

    }

    public class CanSignalTestDouble : ACanSignal<double>
    {
        public override double Get()
        {
            // Get bits from raw data storage and cast
            double tempValue = (double)ExtractBits(SignalType);
            // Apply inverse transform to restore actual value
            tempValue -= SignalType.Offset;
            tempValue /= SignalType.ScaleFactor;
            return tempValue;
        }

        override public void Set(double value)
        {
            throw new NotImplementedException();
        }
    }


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
        abstract public void NotifySubscribers();

        public static CanMessageType MessageType { get; protected set; }

        public UInt64 ExtractBits(CanSignalType signal)
        {
            if (signal.Encoding == SignalEncoding.Motorola)
            {
                throw new Exception("Motorola byte order not supported");
            }
            return ExtractBits(signal.StartBit, signal.BitMask);
        }

        public void InsertBits(CanSignalType signal, UInt64 bits)
        {
            InsertBits(signal.StartBit, signal.BitMask, bits);
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

    public class CanMessageReceivedEventArgs : EventArgs
    {
        public List<CanMessage> ReceivedMessages { get; set; } = new List<CanMessage>();
        public bool BufferOverrunDetected { get; set; } = false;
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
