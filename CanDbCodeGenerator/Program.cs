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

        private static string GenerateCanMessageTypesCode(Dictionary<int, CanMessageType> canMessageTypes, string nameSpace)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;

namespace {nameSpace}
{{
    static class CanMessageTypes
    {{
        static CanMessageTypes()
        {{
{new Func<string>(() => { return "hello"; })()}
");
            foreach (var canMessageType in canMessageTypes.Values)
            {
                stringBuilder.Append($@"
            AllCanMessageTypes.Add({canMessageType.Name}); ");
            }
            stringBuilder.Append(@"

        }
        static List<CanMessageType> AllCanMessageTypes = new List<CanMessageType>();
");
            foreach (var canMessageType in canMessageTypes.Values)
            {
                stringBuilder.AppendLine($@"
        public static CanMessageType {canMessageType.Name} = new CanMessageType
        (
            new List<CanSignalType>
            {{");

                foreach (var signal in canMessageType.Signals.Values)
                {
                    stringBuilder.Append($@"
                CanSignalTypes.{signal.QualifiedName.Replace(".", "__")},");
                }
                stringBuilder.Append($@"
            }}
        )
        {{
            Comment       = ""{canMessageType.Comment         }"",
            DLC           = {canMessageType.DLC.ToString()  },
            ID            = {canMessageType.ID.ToString()   },
            Name          = ""{canMessageType.Name            }"",
            QualifiedName = ""{canMessageType.QualifiedName   }"",
            SendingNode   = ""{canMessageType.SendingNode}"",
        }};");

            }

            stringBuilder.Append(@"
    }








    static class CanSignalTypes
    {
        static CanSignalTypes()
        {
");
            IEnumerable<CanSignalType> allSignals = canMessageTypes.Values.SelectMany(x => x.Signals.Values);
            foreach (var signal in allSignals)
            {
                stringBuilder.Append($@"
            AllCanSignalTypes.Add({signal.QualifiedName.Replace(".", "__")}); ");
            }
            stringBuilder.Append(@"

        }
        static List<CanSignalType> AllCanSignalTypes = new List<CanSignalType>();
");
            foreach (var signal in allSignals)
            {
                stringBuilder.Append($@"
        public static CanSignalType {signal.QualifiedName.Replace(".", "__")} = new CanSignalType
        {{
            Encoding      = SignalEncoding.{signal.Encoding},
            Type          = SignalType.{signal.Type        },
            Length        = {signal.Length                 },
            MaxValue      = {signal.MaxValue               },
            MinValue      = {signal.MinValue               },
            Offset        = {signal.Offset                 },
            ScaleFactor   = {signal.ScaleFactor            },
            StartBit      = {signal.StartBit               },
            Comment       = ""{signal.Comment              }"",
            Name          = ""{signal.Name                 }"",
            QualifiedName = ""{signal.QualifiedName        }"",
            Unit          = ""{signal.Unit                 }"",
        }};");
            }
            stringBuilder.Append($@"
    }}
    {GenerateCanExtractionAndInsertionCode(canMessageTypes)}
}}");
            
            return stringBuilder.ToString();

        }

        private static string GenerateCanExtractionAndInsertionCode(Dictionary<int, CanMessageType> canMessageTypes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var CanMessageType in canMessageTypes.Values)
            {


                stringBuilder.Append(
                $@"
    public class {CanMessageType.Name }Message : CanMessage
    {{
        
        public {CanMessageType.Name }Message()
        {{
            MessageType = CanMessageTypes.{CanMessageType.Name};
        }}");
                foreach (var CanSignalType in CanMessageType.Signals.Values)
                {
                    stringBuilder.Append($@"

        public static readonly CanSignalType {CanSignalType.Name} = CanSignalTypes.{CanSignalType.QualifiedName.Replace(".", "__")};

        public {CanSignalType.GetTypeName()} Get{CanSignalType.Name}()
        {{
            // Get bits from raw data storage and cast
            {CanSignalType.GetTypeName()} tempValue = ({CanSignalType.GetTypeName()})ExtractBits({CanSignalType.Name});

            // Apply inverse transform to restore actual value
             
            tempValue  {CanSignalType.GetSubtractionOperator()};
            tempValue  {CanSignalType.GetDivisionOperator()};
            return tempValue;
        }}
        public void Set{CanSignalType.Name}({CanSignalType.GetTypeName()} value)
        {{
            // Scale and offset value according to signal secification
            value {CanSignalType.GetMultiplierOperator()};
            value {CanSignalType.GetSubtractionOperator()};

            // Cats to integer and prepare for sending
            this.InsertBits({CanSignalType.Name}, (UInt64)value);

        }}"
                    );
                }
                stringBuilder.Append("\n    }");

            }
            //stringBuilder.Append("\n}");
            string test = new Func<string>(() => { return "hello"; })();
            return stringBuilder.ToString();
        }
    }

}
