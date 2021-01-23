using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kvaser.KvadbLib;

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
    public enum MESSAGE
    {
        EXT = int.MinValue,
        J1939 = 1,
        WAKEUP = 2
    }

    public class CanDB
    {
        public static HashSet<CanMessageType> OpenCanDB(string fullFilePath)
        {
            Kvadblib.Hnd db_handle;
            Kvadblib.Status status;


            status = Kvadblib.Open(out db_handle);
            status = Kvadblib.Create(db_handle, "MyTestDB", fullFilePath);

            if (status == Kvadblib.Status.Err_DbFileOpen)
                throw new Exception("Could not open CAN database file"); // TODO: Handle more gracefully
            if (status == Kvadblib.Status.Err_DbFileParse)
            {
                string errorMessage;
                status = Kvadblib.GetLastParseError(out errorMessage);
                throw new Exception("Could not parse file. Error: \n" + errorMessage);
            }


            HashSet<CanMessageType> Messages = new HashSet<CanMessageType>();
            // Get the first message in the database
            Kvadblib.MessageHnd messageHandle;
            status = Kvadblib.GetFirstMsg(db_handle, out messageHandle);
            if (status != Kvadblib.Status.OK)
                throw new Exception("kvaDbGetFirstMsg failed: " + status.ToString()); // TODO: Handle more gracefully

            // Go through all messages in the database
            while (status == Kvadblib.Status.OK)
            {
                string tempMessageName;
                string tempMessageQualifiedName;
                string tempMessageComment;
                int tempMessageID;
                Kvadblib.MESSAGE tempFlags;
                int tempMessageDlc;

                // Get the properties for each message
                status = Kvadblib.GetMsgName(messageHandle, out tempMessageName);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("kvaDbGetMsgName failed: " + status.ToString()); // TODO: Handle more gracefully

                status = Kvadblib.GetMsgQualifiedName(messageHandle, out tempMessageQualifiedName);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("kvaDbGetMsgQualifiedName failed: " + status.ToString());

                status = Kvadblib.GetMsgComment(messageHandle, out tempMessageComment);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("kvaDbGetMsgComment failed: " + status.ToString()); // TODO: Handle more gracefully

                status = Kvadblib.GetMsgIdEx(messageHandle, out tempMessageID);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("kvaDbGetMsgId failed: " + status.ToString()); // TODO: Handle more gracefully

                status = Kvadblib.GetMsgFlags(messageHandle, out tempFlags);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("GetMsgFlags failed: " + status.ToString()); // TODO: Handle more gracefully

                status = Kvadblib.GetMsgDlc(messageHandle, out tempMessageDlc);
                if (status != Kvadblib.Status.OK)
                    throw new Exception("kvaDbGetMsgDlc failed: " + status.ToString()); // TODO: Handle more gracefully

                CanMessageType tempCanMessage = new CanMessageType
                {
                    Comment = tempMessageComment,
                    DLC = tempMessageDlc,
                    Flags = (MESSAGE)tempFlags,
                    ID = tempMessageID,
                    Name = tempMessageName,
                    QualifiedName = tempMessageQualifiedName,
                };
                Messages.Add(tempCanMessage);

                // Go through all signals for this message
                Kvadblib.SignalHnd signalHandle;
                status = Kvadblib.GetFirstSignal(messageHandle, out signalHandle);
                while (status == Kvadblib.Status.OK)
                {
                    string tempSignalName;
                    string tempSignalQualifiedName;
                    string tempSignalComment;
                    string tempSignalUnit;
                    Kvadblib.SignalEncoding tempSignalEncoding;
                    Kvadblib.SignalType tempSignalType;
                    int tempStartbit = 0;
                    int tempLength = 0;
                    double tempMinval = 0;
                    double tempMaxval = 0;
                    double tempScaleFactor = 0;
                    double tempOffset = 0;

                    // Get the properties for each signal.
                    status = Kvadblib.GetSignalName(signalHandle, out tempSignalName);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalName failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalQualifiedName(signalHandle, out tempSignalQualifiedName);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalQualifiedName failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalComment(signalHandle, out tempSignalComment);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalComment failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalUnit(signalHandle, out tempSignalUnit);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalUnit failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalEncoding(signalHandle, out tempSignalEncoding);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalEncoding failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalRepresentationType(signalHandle, out tempSignalType);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalRepresentationType failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalValueLimits(signalHandle, out tempMinval, out tempMaxval);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalValueLimits failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalValueScaling(signalHandle, out tempScaleFactor, out tempOffset);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalValueScaling failed: " + status.ToString()); // TODO: Handle more gracefully

                    status = Kvadblib.GetSignalValueSize(signalHandle, out tempStartbit, out tempLength);
                    if (status != Kvadblib.Status.OK)
                        throw new Exception("kvaDbGetSignalValueSize failed: " + status.ToString()); // TODO: Handle more gracefully

                    CanSignalType tempCanSignal = new CanSignalType
                    {
                        Comment = tempSignalComment,
                        Encoding = (SignalEncoding)tempSignalEncoding,
                        Length = tempLength,
                        MaxValue = tempMaxval,
                        MinValue = tempMinval,
                        Name = tempSignalName,
                        Offset = tempOffset,
                        QualifiedName = tempSignalQualifiedName,
                        ScaleFactor = tempScaleFactor,
                        StartBit = tempStartbit,
                        Type = (SignalType)tempSignalType,
                        Unit = tempSignalUnit,
                    };
                    tempCanSignal.CalculateBitMask();
                    tempCanMessage.Signals.Add(tempCanSignal);

                    status = Kvadblib.GetNextSignal(messageHandle, out signalHandle);
                }
                status = Kvadblib.GetNextMsg(db_handle, out messageHandle);
            }

            // All done; close database
            Kvadblib.Close(db_handle);
            return Messages;
        }
        public static double ConvertFromCanToDouble(CanSignalType signalType, BitArray bitArray)
        {
            // Isolate relevant bits using precalculated bitmask
            UInt64[] bits = new UInt64[1];
            bitArray.And(signalType.BitMask).CopyTo(bits, 0);
            double value = bits[0];

            // Apply inverse transform to restore actual value
            value -= signalType.Offset;
            value /= signalType.ScaleFactor;
            return value;
        }

        public static UInt64 ConvertFromDoubleToCan(CanSignalType signalType, double value)
        {
            // Apply transform in preparation for sending value on bus
            value *= signalType.ScaleFactor;
            value += signalType.Offset;


            throw new NotImplementedException();
        }
    }
    public class CanMessageType
    {
        public string Name { get; set; }
        public string QualifiedName { get; set; }
        public string Comment { get; set; }
        public int ID { get; set; }
        public MESSAGE Flags { get; set; }
        public int DLC { get; set; }

        public List<CanSignalType> Signals { get; } = new List<CanSignalType>();
    }

    public class CanSignalType
    {
        public string Name { get; set; }
        public string QualifiedName { get; set; }
        public string Comment { get; set; }
        public string Unit { get; set; }
        public SignalEncoding Encoding { get; set; }
        public SignalType Type { get; set; }
        public int StartBit { get; set; }
        public int Length { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double ScaleFactor { get; set; }
        public double Offset { get; set; }
        public List<DataPoint> DataPoints { get; } = new List<DataPoint>();
        public BitArray BitMask { get; private set; }
        public void CalculateBitMask()
        {
            bool[] tempMask = new bool[64];
            for(int i = 0; i<Length; i++)
            {
                tempMask[i + StartBit] = true;
            }
            BitMask = new BitArray(tempMask);
        }
    }

    public struct DataPoint
    {
        public double data         {get;set;}
        public UInt16 CanTimeStamp {get;set;}
        public Int64  Ticks        {get;set;}
    }

}
