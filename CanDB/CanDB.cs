using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STLinkBridgeWrapper;
using System.Diagnostics;

namespace CanDB
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

    // Note: This library does not support signal multiplexing

    public class CanDB
    {

        /// <summary>
        /// Use this function to read a .dbc CAN database file.
        /// </summary>
        /// <param name="fullFilePath">Fulle path to the .dbc file</param>
        /// <returns>CanDataBasType object with all the relevant information from the .dbc file</returns>
        public static CanDatabaseType OpenCanDB(string fullFilePath)
        {

            CanDatabaseType canDatabaseType = new CanDatabaseType();
            canDatabaseType.Name = Path.GetFileNameWithoutExtension(fullFilePath);

            // Read the file line by line.  
            //System.IO.StreamReader file = new System.IO.StreamReader(fullFilePath);
            var canDbFile = File.ReadAllLines(fullFilePath).ToList();
            List<String>.Enumerator enumerator = canDbFile.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.StartsWith("BU_"))
                {
                    var nodes = ParseDbcNodeDefinition(enumerator.Current);
                    foreach (var node in nodes)
                    {
                        canDatabaseType.Nodes.Add(node);
                    }
                }

                if (enumerator.Current.StartsWith("BO_"))
                {
                    CanMessageType temp = ParseDbcMessageDefinition(enumerator);
                    canDatabaseType.CanMessageTypes.Add(temp.ID, temp);
                }
                if (enumerator.Current.StartsWith("CM_"))
                    ParseDbcCommentField(enumerator.Current, canDatabaseType.CanMessageTypes);
                if (enumerator.Current.StartsWith("BA_DEF_"))
                    ParseDbcAttributeDefinition(enumerator.Current, canDatabaseType.CanMessageTypes);
                if (enumerator.Current.StartsWith("SIG_VALTYPE_"))
                    ParseDbcTypeDefinition(enumerator.Current, canDatabaseType.CanMessageTypes);

            }

            foreach (var message in canDatabaseType.CanMessageTypes.Values)
            {
                message.QualifiedName = message.Name;
                //message.QualifiedName = canDatabaseType.Name + "." + message.Name;
                foreach (var signal in message.Signals.Values)
                {
                    //signal.QualifiedName = canDatabaseType.Name + "." + signal.QualifiedName;
                }
            }

            return canDatabaseType;
        }

        /// <summary>
        /// This function will parse the a line that starts with "BU_" and return a list of 
        /// all node names in the database file
        /// </summary>
        /// <param name="line">One line from the .dbc file that starts with "BU_"</param>
        /// <returns>List of all nodes in .dbc file</returns>
        protected static IEnumerable<string> ParseDbcNodeDefinition(string line)
        {
            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return segments.Skip(1);
        }

        /// <summary>
        /// Handles one CAN message definitioni line from a .dbc file and recursively 
        /// calls ParseDbcMessageDefinition to handle CAN signal definition, which will 
        /// cause the enumerator to advance.
        /// </summary>
        /// <param name="enumerator">An enumerators that is used to step through the 
        /// .dbc file line by line.</param>
        /// <returns>A new CanMessageType object with most fields and all signals populated.</returns>
        protected static CanMessageType ParseDbcMessageDefinition(List<String>.Enumerator enumerator)
        {
            // Field to be populated and returned
            CanMessageType canMessageType = new CanMessageType();

            string line = enumerator.Current;
            var segments = line.Split(' ');
            Debug.Assert(segments.Length == 5);

            int id;
            if (Int32.TryParse(segments[1], out id))
                canMessageType.ID = id;
            // TODO: Handle the else-part. What should we do if the parsing fails?

            string name = segments[2].TrimEnd(':');
            canMessageType.Name = name;

            int DLC;
            if (Int32.TryParse(segments[3], out DLC))
                canMessageType.DLC = DLC;
            // TODO: Handle the else-part. What should we do if the parsing fails?

            string SendingNode = segments[4];
            canMessageType.SendingNode = SendingNode;

            while (enumerator.MoveNext())
            {
                if (!enumerator.Current.TrimStart(' ').StartsWith("SG_"))
                    break;
                CanSignalType temp = HandleDcbSignalDefinition(enumerator.Current);
                canMessageType.Signals.Add(temp.Name, temp);
            }

            foreach (var signal in canMessageType.Signals.Values)
            {
                signal.QualifiedName = canMessageType.Name + "." + signal.Name;
            }

            return canMessageType;
        }

        /// <summary>
        /// Handles one signal definition line from a .dbc file and returns a new CanSignalType 
        /// object with multiple fields populated. Not all information if available in one line, 
        /// which is why not all fields are populated at once.
        /// </summary>
        /// <param name="line">The line from a .dbc file to be parsed.</param>
        /// <returns>CanSignalType object with multiple fields populated.</returns>
        protected static CanSignalType HandleDcbSignalDefinition(string line)
        {
            // Field to be populated and returned
            CanSignalType canSignalType = new CanSignalType();

            // Split at white space
            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(segments.Length == 8 || segments.Length == 9);

            string name = segments[1];
            canSignalType.Name = name;

            // Skip signal multiplexing definition, if any
            var elementsAfterColon = segments.SkipWhile(word => !word.Equals(":"));

            // This enumerator is used to handle the different 
            var signalDefinitionEnumerator = elementsAfterColon.GetEnumerator();
            // Skip first element sing it contains the colon character
            signalDefinitionEnumerator.MoveNext();
            signalDefinitionEnumerator.MoveNext();

            // Parse bit definition
            // <StartBit>|<Length>@<Endianness><Signed>
            // Example: 40|8@1+
            {
                var bitDefinition = signalDefinitionEnumerator.Current;
                var segments2 = bitDefinition.Split(new char[] { '|', '@' });
                Debug.Assert(segments2.Length == 3);

                int startBit;
                if (Int32.TryParse(segments2[0], out startBit))
                    canSignalType.StartBit = startBit;

                int numberOfBits;
                if (Int32.TryParse(segments2[1], out numberOfBits))
                    canSignalType.Length = numberOfBits;

                bool littleEndian = true;
                bool signed = false;
                switch (segments2[2])
                {
                    case "0-":
                        littleEndian = false; // aka Motorola
                        signed = true;
                        break;

                    case "0+":
                        littleEndian = false; // aka Motorola
                        signed = false;
                        break;

                    case "1-":
                        littleEndian = true; // aka Intel
                        signed = true;
                        break;

                    case "1+":
                        littleEndian = true; // aka Intel
                        signed = false;
                        break;
                }
                canSignalType.Encoding = littleEndian ? SignalEncoding.Intel : SignalEncoding.Motorola;
                canSignalType.Type = signed ? SignalType.Signed : SignalType.Unsigned;
            }

            signalDefinitionEnumerator.MoveNext();
            // Parse scale factor and offset
            // Format: (<Factor>,<Offset>)
            // Example: (0.5,5)
            {
                var scaleOffset = signalDefinitionEnumerator.Current
                    .TrimStart('(')
                    .TrimEnd(')')
                    .Split(',');
                Debug.Assert(scaleOffset.Length == 2);

                double scale;
                if (Double.TryParse(scaleOffset[0], out scale))
                    canSignalType.ScaleFactor = scale;
                // TODO: Handle the else-part. What should we do if the parsing fails?

                double offset;
                if (Double.TryParse(scaleOffset[1], out offset))
                    canSignalType.Offset = offset;
                // TODO: Handle the else-part. What should we do if the parsing fails?

            }

            signalDefinitionEnumerator.MoveNext();
            // Parse minimum and maximum value
            // Format: [<Min>|<Max>]
            // Example: [5|132.5]
            {
                var minMax = signalDefinitionEnumerator.Current
                    .TrimStart('[')
                    .TrimEnd(']')
                    .Split('|');
                Debug.Assert(minMax.Length == 2);

                double minimum;
                if (Double.TryParse(minMax[0], out minimum))
                    canSignalType.MinValue = minimum;
                // TODO: Handle the else-part. What should we do if the parsing fails?

                double maximum;
                if (Double.TryParse(minMax[1], out maximum))
                    canSignalType.MaxValue = maximum;
                // TODO: Handle the else-part. What should we do if the parsing fails?
            }

            signalDefinitionEnumerator.MoveNext();
            // Parse unit
            // Format: "<Unit>"
            // Example: "degC"
            {
                string unit = signalDefinitionEnumerator.Current
                    .Trim('\"');
                canSignalType.Unit = unit;
            }

            signalDefinitionEnumerator.MoveNext();
            // Parse receiving nodes
            // Format: [ReceivingNodes]
            // Example: Front_Node,AMS,Rear_Node
            {
                var nodes = signalDefinitionEnumerator.Current.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                canSignalType.ReceivingNodes.AddRange(nodes);
            }

            canSignalType.CalculateBitMask();
            return canSignalType;
        }

        protected static void ParseDbcCommentField(string line, Dictionary<int, CanMessageType> canMessageTypes)
        {
            // Format: CM_ [<BU_|BO_|SG_> [CAN-ID] [SignalName]] "<CommentText>";
            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string comment;
            int messageId;
            switch (segments[1])
            {
                case "BU_":
                    string node = segments[2];
                    comment = segments[3].TrimEnd(';').Trim('\"');
                    // TODO: Implement node collection and add this information
                    break;
                case "BO_":
                    comment = segments[3].TrimEnd(';').Trim('\"');
                    if (Int32.TryParse(segments[2], out messageId))
                    {
                        CanMessageType canMessage = canMessageTypes[messageId];
                        canMessage.Comment = comment;
                    }
                    break;
                case "SG_":
                    string signalName = segments[3];
                    comment = segments[4].TrimEnd(';').Trim('\"');
                    if (Int32.TryParse(segments[2], out messageId))
                    {
                        CanMessageType canMessage = canMessageTypes[messageId];
                        CanSignalType canSignal = canMessage.Signals[signalName];
                        canSignal.Comment = comment;
                    }
                    break;
            }

        }

        protected static void ParseDbcAttributeDefinition(string line, Dictionary<int, CanMessageType> canMessageTypes)
        {
            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.None);
            switch (segments[1])
            {
                case "BU_":
                    break;
                case "BO_":
                    break;
                case "SG_":
                    break;
                case "EV_":
                    break;
                case "":
                    break;
            }
        }

        protected static void ParseDbcTypeDefinition(string line, Dictionary<int, CanMessageType> canMessageTypes)
        {
            // Format: SIG_VALTYPE_ <MessageID> <SignalName> : [1,2];
            // where 1 means float and 2 means double
            // Example: SIG_VALTYPE_ 519 RN_PE_RL_Error_Reset : 2;  

            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.None);
            int id;

            if (Int32.TryParse(segments[1], out id))
            {
                var message = canMessageTypes[id];
                var signal = message.Signals[segments[2]];
                switch (segments[4])
                {
                    case "2;":
                        signal.Type = SignalType.Double;
                        break;
                    case "1;":
                        signal.Type = SignalType.Float;
                        break;
                    default:
                        // TODO: Notify user of unexpected input
                        break;
                }

            }
        }

        public static List<DataPoint> ParseReceivedCanMessagesRx(List<CanBridgeMessageRx> receivedMessages, SortedList<uint, CanMessageType> canMessageTypes)
        {
            List<DataPoint> values = new List<DataPoint>();

            foreach (var message in receivedMessages)
            {
                CanMessageType canMessage = canMessageTypes[message.ID];
                if (canMessage == null)
                {
                    continue;
                }

                if (canMessage.DLC != message.DLC)
                {
                    throw new Exception("Error: DLC of received message did not match expected DLC from database."); // TODO: Handle more gracefully
                }

                foreach (var signalType in canMessage.Signals.Values)
                {
                    if (signalType.Encoding == SignalEncoding.Motorola)
                    {
                        throw new Exception("Motorola byte order not supported");
                    }
                    // TODO: Check if the bitmask has been calculated
                    // Isolate relevant bits using precalculated bitmask
                    UInt64 bits = message.data;
                    bits &= signalType.BitMask;

                    // Shift back to original state according to specification
                    bits >>= signalType.StartBit;


                    double tempValue = (double)bits;

                    // Apply inverse transform to restore actual value
                    tempValue -= signalType.Offset;
                    tempValue /= signalType.ScaleFactor;

                    values.Add(new DataPoint
                    {
                        Ticks = message.TimeStamp,
                        CanTimeStamp = message.CanTimeStamp,
                        data = tempValue,
                        SignalType = signalType,
                    });

                }
            }

            return values;
        }

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
        public int ID { get; set; }
        //public MESSAGE Flags { get; set; }
        public int DLC { get; set; }

        public string SendingNode { get; set; } = "";

        public Dictionary<string, CanSignalType> Signals { get; private set; } = new Dictionary<string, CanSignalType>();

        public CanBridgeMessageTx GenerateCanMessageTx(params (CanSignalType, double)[] signalsAndData)
        {
            if (signalsAndData.Length != Signals.Count)
            {
                throw new Exception("Wrong number of paramteres in parameter list.");
            }

            foreach (var signal in Signals.Values)
            {
                if (!signalsAndData.Any((x => x.Item1 == signal)))
                {
                    throw new Exception("Parameter list must contain exatcly the same signals as in this can message.");
                }
            }

            CanBridgeMessageTx message = new CanBridgeMessageTx
            {
                ID = (uint)this.ID,
                //IdExtended = this.Flags == MESSAGE.EXT,
                IdExtended = true, // TODO: Figure out how this works!
                RTR = false,
                DLC = (byte)this.DLC,
            };

            UInt64 payload = 0;
            foreach (var tuple in signalsAndData)
            {
                var signal = tuple.Item1;
                var data = tuple.Item2;
                // Scale and offset value according to signal secification
                double tranformedValue = data * signal.ScaleFactor;
                tranformedValue += signal.Offset;

                // Cast to integer. The scaling should have been chosen such that this casting is okay.
                var bits = (UInt64)tranformedValue;

                // Get the bits, trim and shift according to specification
                bits <<= signal.StartBit;
                bits &= signal.BitMask; // Trim

                // Add to payload
                payload |= bits;
            }
            message.data = payload;

            return message;
        }
    }

    public class CanSignalType
    {
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

    public struct DataPoint
    {
        public double data               {get;set;}
        public UInt16 CanTimeStamp       {get;set;}
        public Int64  Ticks              {get;set;}
        public CanSignalType SignalType  {get;set;}
    }
}








/// <summary>
/// In this namespace are a number of extensions methods that are useful for 
/// generating code.
/// </summary>
namespace CanDB.CodeGenerationExtensions
{
    public static class CanSignalCodeGenerationExtensionMethods
    {
        public static string GetTypeName(this CanSignalType canSignalType)
        {
            int numberOfBits = canSignalType.Length;

            switch (canSignalType.Type)
            {
                case SignalType.Invalid:
                    throw new NotImplementedException();
                    break;

                case SignalType.Signed:
                    if (numberOfBits <= 8)
                        return "byte";
                    else if (numberOfBits <= 16)
                        return "Int16";
                    else if (numberOfBits <= 32)
                        return "Int32";
                    else if (numberOfBits <= 64)
                        return "Int64";
                    throw new Exception($"Too many bits in {canSignalType.QualifiedName}: {canSignalType.ToString()}");
                    break;

                case SignalType.Unsigned:
                    if (numberOfBits <= 8)
                        return "sbyte";
                    else if (numberOfBits <= 16)
                        return "UInt16";
                    else if (numberOfBits <= 32)
                        return "UInt32";
                    else if (numberOfBits <= 64)
                        return "UInt64";
                    throw new Exception($"Too many bits in {canSignalType.QualifiedName}: {canSignalType.ToString()}");
                    break;
                case SignalType.Float:
                    return "float";
                    break;
                case SignalType.Double:
                    return "double";
                    break;
            }

            throw new Exception($"Type not identifyable in {canSignalType.QualifiedName}");
        }




        public static string GetMultiplierOperator(this CanSignalType canSignalType)
        {
            if (canSignalType.ScaleFactor < 1)
                return "/= " + (1 / canSignalType.ScaleFactor).ToString();

            return "*= " + canSignalType.ScaleFactor.ToString();
        }

        public static string GetDivisionOperator(this CanSignalType canSignalType)
        {
            if (canSignalType.ScaleFactor < 1)
                return "*= " + (1 / canSignalType.ScaleFactor).ToString();

            return "/= " + canSignalType.ScaleFactor.ToString();
        }

        public static string GetAdditionOperator(this CanSignalType canSignalType)
        {
            if (canSignalType.ScaleFactor < 1)
                return "-= " + (-canSignalType.Offset).ToString();

            return "+= " + canSignalType.Offset.ToString();
        }
        public static string GetSubtractionOperator(this CanSignalType canSignalType)
        {
            if (canSignalType.ScaleFactor < 1)
                return "+= " + (-canSignalType.Offset).ToString();

            return "-= " + canSignalType.Offset.ToString();
        }
    }
}

