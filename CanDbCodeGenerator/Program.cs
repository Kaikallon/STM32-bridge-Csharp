﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CanDefinitions;
using CanDbCodeGenerator.CodeGenerationExtensions;

namespace CanDbCodeGenerator
{
    public class Program
    {
        /// <summary>
        /// Crteates a static library from DBC file
        /// </summary>
        /// <param name="args">1: Full path to dbc-file. 2: Output path and name. 3: Given namespace for the resulting code</param>
        public static void Main(string[] args)
        {
            if (args.Length < 3)
                throw new Exception("Not enough arguments!");

            string canDbcLocation = args[0];
            string fileNameAndPath = args[1];
            string nameSpace = args[2];
            string receivingNode = "";
            if (args.Length > 3)
                receivingNode = args[3];

            System.IO.FileInfo fileInfo = null;
            try
            {
                fileInfo = new System.IO.FileInfo(fileNameAndPath);
            }
            catch (ArgumentException) { }
            catch (System.IO.PathTooLongException) { }
            catch (NotSupportedException) { }
            if (fileInfo == null)
                throw new Exception("Filename invalid");

            Directory.SetCurrentDirectory(@"..\..");

            // Set culture info to invariant. This is important for handling decimal separators as dots
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var canDatabase = CanDbcParser.OpenCanDB(canDbcLocation);
            var canMessageTypes = new List<CanMessageType>();
            if (receivingNode != "")
            {
                // Filter our CanMessageTypes that are relevant for this receiveing node
                foreach (var canMessageType in canDatabase.CanMessageTypes.Values)
                {
                    if (canMessageType.SendingNode == receivingNode)
                    {
                        canMessageTypes.Add(canMessageType);
                    }
                    else if (canMessageType.Signals.Any(x => x.Value.ReceivingNodes.Contains(receivingNode)))
                    {
                        canMessageTypes.Add(canMessageType);
                    }
                }
            }
            else
            {
                canMessageTypes = canDatabase.CanMessageTypes.Values.ToList();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameAndPath))
            {
                string code = GenerateCanMessageTypesCode(canMessageTypes, nameSpace);
                file.Write(code);
            }
        }
        // TODO: Modify code such that the CanMessageReceiver class is not static. 
        // The constructor should enforce setting the event listener
        // TODO: Make generated classes partial such that they can be extended
        private static string GenerateCanMessageTypesCode(IEnumerable<CanMessageType> canMessageTypes, string namespaceName)
        {
            const int n = 4;
            int o = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"
// This file was generated automatically by the program {Assembly.GetExecutingAssembly().GetName().Name}
// Manual modification is certanly possible, but is disencouraged.
// For manual additions to the database it is better to use the fact the all 
// classes are defined as partial to extend them.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDefinitions;

");

            string canMessageReceiverBody = GenerateMessageReceiverBody(canMessageTypes);
            string canMessageReceiverClass = CanDbCSharpCodeGeneration.GenerateClass("public static partial", "CanMessageReceiver", canMessageReceiverBody);

            string canMessageTypesBody = GenerateCanMessageTypesBody(canMessageTypes);
            string canMessageTypesClass = CanDbCSharpCodeGeneration.GenerateClass("public static partial", "CanMessageTypes", canMessageTypesBody);

            IEnumerable<CanSignalType> allSignals = canMessageTypes.SelectMany(x => x.Signals.Values);
            string canSignalTypesBody = GenerateCanSignalTypesTypesBody(allSignals);
            string canSignalTypesClass = CanDbCSharpCodeGeneration.GenerateClass("public static partial", "CanSignalTypes", canSignalTypesBody);

            var classes = new List<string>
            {
                canMessageReceiverClass,
                canMessageTypesClass,
                canSignalTypesClass,
                
            };
            string nameSpaceBase = CanDbCSharpCodeGeneration.GenerateNameSpace(namespaceName, classes);
            string nameSpaceMessages = CanDbCSharpCodeGeneration.GenerateNameSpace(namespaceName + ".Messages", 
                new List<string> { GenerateCanExtractionAndInsertionCode(canMessageTypes) });


            stringBuilder.Append(nameSpaceBase);
            stringBuilder.Append(nameSpaceMessages);


            return stringBuilder.ToString();
        }




        private static string GenerateCanExtractionAndInsertionCode(IEnumerable<CanMessageType> canMessageTypes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var CanMessageType in canMessageTypes)
            {
                stringBuilder.Append(CanDbCSharpCodeGeneration.GenerateMessageCode(CanMessageType, 1));
            }

            return stringBuilder.ToString();
        }

        private static string GenerateCanSignalTypesTypesBody(IEnumerable<CanSignalType> canSignalTypes)
        {
            int n = 4;
            int o = 2;
            StringBuilder canSignalsTypesBody = new StringBuilder();

            canSignalsTypesBody.AppendLine(n * (0 + o), $"// Generated by GenerateCanSignalTypesTypesBody()");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"static List<CanSignalType> AllCanSignalTypes = new List<CanSignalType>();");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"static CanSignalTypes()");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"{{");

            foreach (var signal in canSignalTypes)
            {
                canSignalsTypesBody.AppendLine(n * (1 + o), $"AllCanSignalTypes.Add({signal.QualifiedName.Replace(".", "__")}); ");
            }

            canSignalsTypesBody.AppendLine(n * (1 + o), $"foreach (var signal in AllCanSignalTypes)");
            canSignalsTypesBody.AppendLine(n * (1 + o), $"{{");
            canSignalsTypesBody.AppendLine(n * (2 + o), $"signal.CalculateBitMask();");
            canSignalsTypesBody.AppendLine(n * (1 + o), $"}}");

            canSignalsTypesBody.AppendLine(n * (0 + o), $"}}");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"");

            foreach (var signal in canSignalTypes)
            {
                canSignalsTypesBody.AppendLine(n * (0 + o), $"public static CanSignalType {signal.QualifiedName.Replace(".", "__")} = new CanSignalType(new List<string>{{");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"{signal.ReceivingNodes.Aggregate("", (x,next) => x + "\"" + next + "\", ")}");
                canSignalsTypesBody.AppendLine(n * (0 + o), $"}})");
                canSignalsTypesBody.AppendLine(n * (0 + o), $"{{");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Encoding      = SignalEncoding.{signal.Encoding},");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Type          = SignalType.{signal.Type        },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Length        = {signal.Length                 },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"MaxValue      = {signal.MaxValue               },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"MinValue      = {signal.MinValue               },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Offset        = {signal.Offset                 },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"ScaleFactor   = {signal.ScaleFactor            },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"StartBit      = {signal.StartBit               },");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Comment       = \"{signal.Comment              }\",");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Name          = \"{signal.Name                 }\",");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"QualifiedName = \"{signal.QualifiedName        }\",");
                canSignalsTypesBody.AppendLine(n * (1 + o), $"Unit          = \"{signal.Unit                 }\",");
                canSignalsTypesBody.AppendLine(n * (0 + o), $"}};");
                canSignalsTypesBody.AppendLine(n * (0 + o), $"");

            }


            return canSignalsTypesBody.ToString();
        }

        private static string GenerateMessageReceiverBody(IEnumerable<CanMessageType> canMessageTypes)
        {
            int n = 4;
            int o = 2;
            StringBuilder canMessageReceiverBody = new StringBuilder();
            canMessageReceiverBody.AppendLine(n * (0 + o), $"// Generated by GenerateMessageReceiverBody()");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"public static void CanMessageReceivedCallback(object sender, CanMessageReceivedEventArgs e)");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"{{");
            canMessageReceiverBody.AppendLine(n * (1 + o), $"foreach(var canMessage in e.ReceivedMessages)");
            canMessageReceiverBody.AppendLine(n * (1 + o), $"{{");

            bool first = true;
            foreach (var canMessageType in canMessageTypes)
            {
                if (!first)
                    canMessageReceiverBody.AppendLine(n * (2 + o), "else ");
                canMessageReceiverBody.Append(GenerateNotificationCode(canMessageType));

                first = false;
            }

            canMessageReceiverBody.AppendLine(n * (1 + o), $"}}");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"}}");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"");
            canMessageReceiverBody.AppendLine(n * (0 + o), $"");

            return canMessageReceiverBody.ToString();
            

            string GenerateNotificationCode(CanMessageType canMessageType)
            {
                StringBuilder canMessageNotification = new StringBuilder();
                canMessageNotification.AppendLine(n * (2 + o), $"if (canMessage.Id == CanMessageTypes.{canMessageType.Name}.Id)");
                canMessageNotification.AppendLine(n * (2 + o), $"{{");
                canMessageNotification.AppendLine(n * (3 + o), $"Messages.{canMessageType.Name}Message message = new Messages.{canMessageType.Name}Message();");
                canMessageNotification.AppendLine(n * (3 + o), $"message.Data = canMessage.Data;");
                canMessageNotification.AppendLine(n * (3 + o), $"message.NotifySubscribers();");
                canMessageNotification.AppendLine(n * (2 + o), $"}}");

                return canMessageNotification.ToString();
            }
        }

        private static string GenerateCanMessageTypesBody(IEnumerable<CanMessageType> canMessageTypes)
        {
            int n = 4;
            int o = 2;
            StringBuilder canMessageTypesBody = new StringBuilder();
            canMessageTypesBody.AppendLine(n * (0 + o), $"// Generated by GenerateCanMessageTypesBody()");
            canMessageTypesBody.AppendLine(n * (0 + o), $"");
            canMessageTypesBody.AppendLine(n * (0 + o), $"static CanMessageTypes()");
            canMessageTypesBody.AppendLine(n * (0 + o), $"{{");
            foreach (var canMessageType in canMessageTypes)
            {
                canMessageTypesBody.AppendLine(n * (1 + o), $"AllCanMessageTypes.Add({canMessageType.Id}, {canMessageType.Name});");
            }
            canMessageTypesBody.AppendLine(n * (0 + o), $"}}");
            canMessageTypesBody.AppendLine(n * (0 + o), $"");
            canMessageTypesBody.AppendLine(n * (0 + o), $"public static Dictionary<UInt32, CanMessageType> AllCanMessageTypes = new Dictionary<UInt32, CanMessageType>();");
            canMessageTypesBody.AppendLine(n * (0 + o), $"");


            foreach (var canMessageType in canMessageTypes)
            {
                canMessageTypesBody.Append(CanDbCSharpCodeGeneration.GenerateCanMessageTypeCode(canMessageType, 2, 4));
            }
            return canMessageTypesBody.ToString();
        }

        
    }

}
