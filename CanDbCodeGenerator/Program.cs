using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;
using CanDB.CodeGenerationExtensions;

namespace CanDbCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                throw new Exception("Not enough arguments!");

            string canDbcLocation = args[0];
            string fileNameAndPath = args[1];
            string nameSpace = args[2];

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

            var canDatabase = CanDB.CanDB.OpenCanDB(canDbcLocation);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameAndPath))
            {
                string code = GenerateCanMessageTypesCode(canDatabase.CanMessageTypes, nameSpace);
                file.Write(code);
            }
        }

        private static string GenerateCanMessageTypesCode(Dictionary<int, CanMessageType> canMessageTypes, string namespaceName)
        {
            const int n = 4;
            int o = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;

");


            string canMessageTypesBody = GenerateCanMessageTypesBody(canMessageTypes.Values);
            string canMessageTypesClass = CanDbCSharpCodeGeneration.GenerateClass("public static", "CanMessageTypes", canMessageTypesBody);

            IEnumerable<CanSignalType> allSignals = canMessageTypes.Values.SelectMany(x => x.Signals.Values);
            string canSignalTypesBody = GenerateCanSignalTypesTypesBody(allSignals);
            string canSignalTypesClass = CanDbCSharpCodeGeneration.GenerateClass("public static", "CanSignalTypes", canSignalTypesBody);

            var classes = new List<string>
            {
                canMessageTypesClass,
                canSignalTypesClass,
                GenerateCanExtractionAndInsertionCode(canMessageTypes)
            };
            string nameSpace = CanDbCSharpCodeGeneration.GenerateNameSpace(namespaceName, classes);

            stringBuilder.Append(nameSpace);

   
            foreach (var canMessageType in canMessageTypes.Values)
            {
                //stringBuilder.Append(CanDbCSharpCodeGeneration.GenerateCanMessageTypeCode(canMessageType, 2, 4));
            }

            
            
            return stringBuilder.ToString();

        }

        private static string GenerateCanExtractionAndInsertionCode(Dictionary<int, CanMessageType> canMessageTypes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var CanMessageType in canMessageTypes.Values)
            {
                stringBuilder.Append(CanDbCSharpCodeGeneration.GenerateMessageCode(CanMessageType, 1));
            }

            //string test = new Func<string>(() => { return "hello"; })();
            return stringBuilder.ToString();
        }

        private static string GenerateCanSignalTypesTypesBody(IEnumerable<CanSignalType> canSignalTypes)
        {
            int n = 4;
            int o = 2;
            StringBuilder canSignalsTypesBody = new StringBuilder();

            canSignalsTypesBody.AppendLine(n * (0 + o), $"static List<CanSignalType> AllCanSignalTypes = new List<CanSignalType>();");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"static CanSignalTypes()");
            canSignalsTypesBody.AppendLine(n * (0 + o), $"{{");

            foreach (var signal in canSignalTypes)
            {
                canSignalsTypesBody.AppendLine(n * (1 + o), $"AllCanSignalTypes.Add({signal.QualifiedName.Replace(".", "__")}); ");
            }
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


        private static string GenerateCanMessageTypesBody(IEnumerable<CanMessageType> canMessageTypes)
        {
            int n = 4;
            int o = 2;
            StringBuilder canMessageTypesBody = new StringBuilder();
            canMessageTypesBody.AppendLine(n * (0 + o), $"");
            canMessageTypesBody.AppendLine(n * (0 + o), $"static CanMessageTypes()");
            canMessageTypesBody.AppendLine(n * (0 + o), $"{{");
            foreach (var canMessageType in canMessageTypes)
            {
                canMessageTypesBody.AppendLine(n * (1 + o), $"AllCanMessageTypes.Add({canMessageType.Name});");
            }
            canMessageTypesBody.AppendLine(n * (0 + o), $"}}");
            canMessageTypesBody.AppendLine(n * (0 + o), $"");
            canMessageTypesBody.AppendLine(n * (0 + o), $"static List<CanMessageType> AllCanMessageTypes = new List<CanMessageType>();");
            canMessageTypesBody.AppendLine(n * (0 + o), $"");


            foreach (var canMessageType in canMessageTypes)
            {
                canMessageTypesBody.Append(CanDbCSharpCodeGeneration.GenerateCanMessageTypeCode(canMessageType, 2, 4));
            }
            return canMessageTypesBody.ToString();
        }

        
    }

}
