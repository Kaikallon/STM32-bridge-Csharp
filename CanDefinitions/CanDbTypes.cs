using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDefinitions
{
    public enum SignalEncoding
    {
        Intel = 0,
        Motorola = 1
    }
    public enum SignalType
    {
        Invalid = 0,
        Signed = 1,
        Unsigned = 2,
        Float = 3,
        Double = 4
    }
    public class CanDatabaseType
    {
        public string Name { get; set; } = "";
        public Dictionary<int, CanMessageType> CanMessageTypes { get; private set; } = new Dictionary<int, CanMessageType>();
        public HashSet<string> Nodes { get; private set; } = new HashSet<string>();
        public HashSet<string> Buses { get; private set; } = new HashSet<string>();
    }
    public class CanMessageType
    {
        public CanMessageType()
        {

        }
        public CanMessageType(List<CanSignalType> canSignals)
        {
            foreach (var canSignal in canSignals)
            {
                this.Signals.Add(canSignal.Name, canSignal);
            }
        }
        public string Name { get; set; } = "";
        public string QualifiedName { get; set; } = "";
        public string Comment { get; set; } = "";
        public int Id { get; set; }
        //public MESSAGE Flags { get; set; }
        public int DLC { get; set; }

        public string SendingNode { get; set; } = "";

        public Dictionary<string, CanSignalType> Signals { get; private set; } = new Dictionary<string, CanSignalType>();
    }

    public class CanSignalType
    {
        public CanSignalType()
        {

        }

        public CanSignalType(List<string> ReceivingNodes)
        {
            this.ReceivingNodes = ReceivingNodes;
        }
        public string Name { get; set; } = "";
        public string QualifiedName { get; set; } = "";
        public string Comment { get; set; } = "";
        public string Unit { get; set; } = "";
        public SignalEncoding Encoding { get; set; }
        public SignalType Type { get; set; }
        public int StartBit { get; set; }
        public int Length { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double ScaleFactor { get; set; }
        public double Offset { get; set; }
        public List<string> ReceivingNodes { get; private set; } = new List<string>();
        public UInt64 BitMask { get; private set; } = 0;
        public void CalculateBitMask()
        {
            for (int i = StartBit; i < StartBit + Length; i++)
            {
                // Set the bits between StartBit and StartBit+Length to one
                BitMask = BitMask | ((UInt64)1 << i);
            }
        }

        /// <summary>
        /// This function calculated the minimum number of bits needed to represent a signal in a 
        /// native type (16, 32 or 64). Let's say you have a signal that uses 12 bits and is signed. To convert 
        /// this into a usable form it needs to be cast into Int16, but this would not retain
        /// the two's complement bits for negative numbers. With this information you can 
        /// compensate for that. 
        /// </summary>
        /// <returns>Minimum number of bits needed to represent a signal in a native type.</returns>
        //private int GetLeastNumberOfBitsForNativeRepresentation()
        //{
        //    var temp = 64 / this.Length;

        //    if (temp == 0)
        //        throw new Exception($"Property Length is more than 64 for signal {this.QualifiedName}.");

        //    if (temp > 4)
        //        return 8;
        //    else if (temp > 2)
        //        return 16;
        //    else if (temp == 2)
        //        return 32;
        //    if (temp == 1)
        //        return 64;

        //    throw new Exception("Unexpected error in function GetLeastNumberOfBitsForNativeRepresentation");
        //}
    }
}
