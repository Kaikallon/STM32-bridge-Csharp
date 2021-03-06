﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CanDefinitions;


namespace CanDbCodeGenerator
{
    // Note: This library does not provide any special support for signal multiplexing

    public class CanDbcParser
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
                    canDatabaseType.CanMessageTypes.Add(temp.Id, temp);
                }
                if (enumerator.Current.StartsWith("CM_"))
                    ParseDbcCommentField(enumerator.Current, canDatabaseType.CanMessageTypes);
                if (enumerator.Current.StartsWith("BA_DEF_"))
                    ParseDbcAttributeDefinition(enumerator.Current, canDatabaseType);
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
                canMessageType.Id = id;
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
                CanSignalType temp = ParseDcbSignalDefinition(enumerator.Current);
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
        protected static CanSignalType ParseDcbSignalDefinition(string line)
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

        protected static void ParseDbcAttributeDefinition(string line, CanDatabaseType canDatabaseType)
        {
            var segments = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (segments[1])
            {
                case "BU_":
                    break;
                case "BO_":
                    if (segments[2] == "\"Bus\"" && segments[3] == "ENUM")
                    {
                        var buses = segments[4].Replace(";", "") // Filter semi-colons
                            .Replace("\"", "") // Filter quoute marks
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); // Split on comma
                        foreach (var bus in buses)
                        {
                            canDatabaseType.Buses.Add(bus);
                        }
                    }
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
                CanMessageType message;
                if (!canMessageTypes.TryGetValue(id, out message))
                {
                    // TODO: Notify user of unexpected input
                    return;
                }
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
    }
}
