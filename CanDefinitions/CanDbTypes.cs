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
        //public HashSet<string> Buses { get; private set; } = new HashSet<string>();
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

        //public CanBridgeMessageTx GenerateCanMessageTx(params (CanSignalType, double)[] signalsAndData)
        //{
        //    if (signalsAndData.Length != Signals.Count)
        //    {
        //        throw new Exception("Wrong number of paramteres in parameter list.");
        //    }
        //
        //    foreach (var signal in Signals.Values)
        //    {
        //        if (!signalsAndData.Any((x => x.Item1 == signal)))
        //        {
        //            throw new Exception("Parameter list must contain exatcly the same signals as in this can message.");
        //        }
        //    }
        //
        //    CanBridgeMessageTx message = new CanBridgeMessageTx
        //    {
        //        ID = (uint)this.ID,
        //        //IdExtended = this.Flags == MESSAGE.EXT,
        //        IdExtended = true, // TODO: Figure out how this works!
        //        RTR = false,
        //        DLC = (byte)this.DLC,
        //    };
        //
        //    UInt64 payload = 0;
        //    foreach (var tuple in signalsAndData)
        //    {
        //        var signal = tuple.Item1;
        //        var data = tuple.Item2;
        //        // Scale and offset value according to signal secification
        //        double tranformedValue = data * signal.ScaleFactor;
        //        tranformedValue += signal.Offset;
        //
        //        // Cast to integer. The scaling should have been chosen such that this casting is okay.
        //        var bits = (UInt64)tranformedValue;
        //
        //        // Get the bits, trim and shift according to specification
        //        bits <<= signal.StartBit;
        //        bits &= signal.BitMask; // Trim
        //
        //        // Add to payload
        //        payload |= bits;
        //    }
        //    message.data = payload;
        //
        //    return message;
        //}
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
    }
}
