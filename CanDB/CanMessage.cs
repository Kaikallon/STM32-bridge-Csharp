using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDB
{
    public abstract class CanMessage
    {
        public UInt64         Data                { get; set; }
        public UInt16         CanTimeStamp        { get; set; }
        public Int64          SystemTimeStamp     { get; set; } = DateTime.Now.Ticks;
        public static CanMessageType MessageType         { get; protected set; } 

        public void InsertBits(CanSignalType signal, UInt64 bits)
        {
            // Get the bits, trim and shift according to specification
            bits <<= signal.StartBit;
            bits &= signal.BitMask; // Trim

            // Add to payload
            Data |= bits;
        }

        public UInt64 ExtractBits(CanSignalType signal)
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

    public class TestMessage : CanMessage
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
                ID = 305419896,
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
