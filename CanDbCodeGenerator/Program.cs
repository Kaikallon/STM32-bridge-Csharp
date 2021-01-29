using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;

namespace CanDbCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                throw new Exception("Not enough arguments!");

            string canDbcLocation  = args[0];
            string fileNameAndPath = args[1];
            string nameSpace       = args[2];

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

            var canMessageTypes = CanDB.CanDB.OpenCanDB(canDbcLocation);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameAndPath))
            {
                string code = GenerateCode(canMessageTypes, nameSpace);
                file.Write(code);
            }
        }

        private static string GenerateCode(HashSet<CanMessageType> canMessageTypes, string nameSpace)
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
");
            foreach (var canMessageType in canMessageTypes)
            {
                stringBuilder.Append($@"
            AllCanMessageTypes.Add({canMessageType.Name}); ");
            }
            stringBuilder.Append(@"

        }
        static List<CanMessageType> AllCanMessageTypes = new List<CanMessageType>();
");
            foreach (var canMessageType in canMessageTypes)
            {
                stringBuilder.AppendLine($@"
        static CanMessageType {canMessageType.Name} = new CanMessageType
        {{
            Comment       = ""{canMessageType.Comment         }"",
            DLC           = {canMessageType.DLC.ToString()  },
            ID            = {canMessageType.ID.ToString()   },
            Name          = ""{canMessageType.Name            }"",
            QualifiedName = ""{canMessageType.QualifiedName   }"",
            Signals       = new List<CanSignalType>
            {{");
            
                foreach (var signal in canMessageType.Signals)
                {
                    stringBuilder.Append($@"
                new CanSignalType
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
                }},");
                }
                stringBuilder.Append(@"
            }
        };");

            }

            stringBuilder.Append(@"
    }








    static class CanSignalTypes
    {
        static CanSignalTypes()
        {
");
            IEnumerable<CanSignalType> allSignals = canMessageTypes.SelectMany(x => x.Signals);
            foreach(var signal in allSignals)
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
        static CanSignalType {signal.QualifiedName.Replace(".", "__")} = new CanSignalType
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
                stringBuilder.Append(@"
    }
}");

            return stringBuilder.ToString();

        }
    }
}
