using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// In this namespace are a number of extensions methods that are useful for 
/// generating code.
/// </summary>
namespace CanDB.CodeGenerationExtensions
{
    public static class CanDbCSharpCodeGeneration
    {

        public static string GenerateMessageCode(CanMessageType canMessageType, int o, int n = 4)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(n * (0 + o), $"");

            stringBuilder.AppendLine(n * (0 + o), $"public class {canMessageType.Name }Message : CanMessage<{canMessageType.Name }Message>");
            stringBuilder.AppendLine(n * (0 + o), $"{{");
            stringBuilder.AppendLine(n * (1 + o), $"public {canMessageType.Name }Message()");
            stringBuilder.AppendLine(n * (1 + o), $"{{");
            stringBuilder.AppendLine(n * (2 + o), $"MessageType = CanMessageTypes.{canMessageType.Name};");
            stringBuilder.AppendLine(n * (2 + o), $"ID = {canMessageType.ID};");
            stringBuilder.AppendLine(n * (1 + o), $"}}");

            foreach (var CanSignalType in canMessageType.Signals.Values)
            {
                string floatException = ""; // This is used to append 'f' for float literals
                if (CanSignalType.Type == SignalType.Float)
                    floatException = "f";

                stringBuilder.AppendLine(n * (1 + o), $"public static readonly CanSignalType {CanSignalType.Name} = CanSignalTypes.{CanSignalType.QualifiedName.Replace(".", "__")};");
                stringBuilder.AppendLine(n * (1 + o), $"public {CanSignalType.GetTypeName()} Get{CanSignalType.Name}()");
                stringBuilder.AppendLine(n * (1 + o), $"{{");
                stringBuilder.AppendLine(n * (2 + o), $"// Get bits from raw data storage and cast");
                stringBuilder.AppendLine(n * (2 + o), $"{CanSignalType.GetTypeName()} tempValue = ({CanSignalType.GetTypeName()})ExtractBits({CanSignalType.Name});");
                stringBuilder.AppendLine(n * (2 + o), $"// Apply inverse transform to restore actual value");
                stringBuilder.AppendLine(n * (2 + o), $"tempValue  {CanSignalType.GetMultiplierOperator() + floatException};");
                stringBuilder.AppendLine(n * (2 + o), $"tempValue  {CanSignalType.GetAdditionOperator() + floatException};");
                stringBuilder.AppendLine(n * (2 + o), $"return tempValue;");
                stringBuilder.AppendLine(n * (1 + o), $"}}");
                stringBuilder.AppendLine(n * (1 + o), $"");
                stringBuilder.AppendLine(n * (1 + o), $"public void Set{CanSignalType.Name}({CanSignalType.GetTypeName()} value)");
                stringBuilder.AppendLine(n * (1 + o), $"{{");
                stringBuilder.AppendLine(n * (2 + o), $"// Scale and offset value according to signal specification");
                stringBuilder.AppendLine(n * (2 + o), $"value {CanSignalType.GetSubtractionOperator() + floatException};");
                stringBuilder.AppendLine(n * (2 + o), $"value {CanSignalType.GetDivisionOperator() + floatException};");
                stringBuilder.AppendLine(n * (2 + o), $"// Cats to integer and prepare for sending");
                stringBuilder.AppendLine(n * (2 + o), $"this.InsertBits({CanSignalType.Name}, (UInt64)value);");
                stringBuilder.AppendLine(n * (1 + o), $"}}");
            }
            //stringBuilder.AppendLine(n * (1 + o), $"");


            stringBuilder.AppendLine(n * (0 + o), $"}}");
            stringBuilder.AppendLine(n * (0 + o), $"");

            return stringBuilder.ToString();
        }

        public static string GenerateCanSignalTypeCode(CanSignalType canSignalType, int o, int n = 4)
        {
            var signal = canSignalType;
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine(n * (0 + o), $"");
            stringBuilder.AppendLine(n * (0 + o), $"public static readonly CanSignalType {signal.QualifiedName.Replace(".", "__")} = new CanSignalType");
            stringBuilder.AppendLine(n * (0 + o), $"{{");
            stringBuilder.AppendLine(n * (1 + o), $"Encoding      = SignalEncoding.{signal.Encoding},");
            stringBuilder.AppendLine(n * (1 + o), $"Type          = SignalType.{signal.Type        },");
            stringBuilder.AppendLine(n * (1 + o), $"Length        = {signal.Length                 },");
            stringBuilder.AppendLine(n * (1 + o), $"MaxValue      = {signal.MaxValue               },");
            stringBuilder.AppendLine(n * (1 + o), $"MinValue      = {signal.MinValue               },");
            stringBuilder.AppendLine(n * (1 + o), $"Offset        = {signal.Offset                 },");
            stringBuilder.AppendLine(n * (1 + o), $"ScaleFactor   = {signal.ScaleFactor            },");
            stringBuilder.AppendLine(n * (1 + o), $"StartBit      = {signal.StartBit               },");
            stringBuilder.AppendLine(n * (1 + o), $"Comment       = \"{signal.Comment              }\",");
            stringBuilder.AppendLine(n * (1 + o), $"Name          = \"{signal.Name                 }\",");
            stringBuilder.AppendLine(n * (1 + o), $"QualifiedName = \"{signal.QualifiedName        }\",");
            stringBuilder.AppendLine(n * (1 + o), $"Unit          = \"{signal.Unit                 }\",");
            stringBuilder.AppendLine(n * (0 + o), $"}};");
            stringBuilder.AppendLine(n * (0 + o), $"");


            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canMessageType">The CAN message type that you want to generate code for</param>
        /// <param name="n">Number of spaces per indent</param>
        /// <param name="o">Indent offset</param>
        /// <returns></returns>
        public static string GenerateCanMessageTypeCode(CanMessageType canMessageType, int o, int n = 4)
        {
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine(n * (0 + o), $"");
            stringBuilder.AppendLine(n * (0 + o), $"public static CanMessageType {canMessageType.Name} = new CanMessageType(new List<CanSignalType>{{");
            foreach (var signal in canMessageType.Signals.Values)
            {
                stringBuilder.AppendLine(n * (2 + o), $"CanSignalTypes.{ signal.QualifiedName.Replace(".", "__")},");
            }
            stringBuilder.AppendLine(n * (1 + o), $"}})");

            stringBuilder.AppendLine(n * (0 + o), $"{{");
            stringBuilder.AppendLine(n * (1 + o), $"Comment       = \"{canMessageType.Comment        }\",");
            stringBuilder.AppendLine(n * (1 + o), $"DLC           =   {canMessageType.DLC.ToString() },");
            stringBuilder.AppendLine(n * (1 + o), $"ID            =   {canMessageType.ID.ToString()  },");
            stringBuilder.AppendLine(n * (1 + o), $"Name          = \"{canMessageType.Name           }\",");
            stringBuilder.AppendLine(n * (1 + o), $"QualifiedName = \"{canMessageType.QualifiedName  }\",");
            stringBuilder.AppendLine(n * (1 + o), $"SendingNode   = \"{canMessageType.SendingNode    }\",");
            stringBuilder.AppendLine(n * (0 + o), $"}};");
            stringBuilder.AppendLine(n * (0 + o), $"");


            return stringBuilder.ToString();
        }

        public static string GenerateNameSpace(string namespaceName, IEnumerable<string> classes, int o = 0, int n = 4)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(n * (0 + o), $"namespace {namespaceName}");
            stringBuilder.AppendLine(n * (0 + o), $"{{");
            stringBuilder.AppendLine(n * (0 + o), $"");
            foreach (string Class in classes)
            {
                stringBuilder.Append(Class);
                stringBuilder.AppendLine("");
            }
            stringBuilder.AppendLine(n * (0 + o), $"}}");

            return stringBuilder.ToString();
        }

        public static string GenerateClass(string qualifiers, string className, string content, int o = 1, int n = 4)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(n * (0 + o), $"{qualifiers} class {className}");
            stringBuilder.AppendLine(n * (0 + o), $"{{");
            stringBuilder.AppendLine(n * (0 + o), $"");
            stringBuilder.Append(content);
            stringBuilder.AppendLine(n * (0 + o), $"}}");

            return stringBuilder.ToString();
        }

    }

    public static class CanSignalCodeGenerationExtensionMethods
    {
        public static void AppendLine(this StringBuilder stringBuilder, int indentLevel, string value)
        {
            stringBuilder.AppendLine(new string(' ', indentLevel) + value);

        }

        public static string GetTypeName(this CanSignalType canSignalType)
        {
            int numberOfBits = canSignalType.Length;

            switch (canSignalType.Type)
            {
                case SignalType.Invalid:
                    throw new NotImplementedException();
                    break;

                case SignalType.Signed: // TODO: Add support for booleans
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
