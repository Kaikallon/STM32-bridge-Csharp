using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STLinkCLRWrapper;
using Kvaser.KvadbLib;

namespace CSharpTest
{
    public static class CanDBHelper
    {
        public static List<CanMessage> OpenCanDB(string fullFilePath)
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


            List<CanMessage> Messages = new List<CanMessage>();
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

                CanMessage tempCanMessage = new CanMessage
                {
                    Comment = tempMessageComment,
                    DLC = tempMessageDlc,
                    Flags = tempFlags,
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

                    CanSignal tempCanSignal = new CanSignal
                    {
                        Comment = tempSignalComment,
                        Encoding = tempSignalEncoding,
                        Length = tempLength,
                        MaxValue = tempMaxval,
                        MinValue = tempMinval,
                        Name = tempSignalName,
                        Offset = tempOffset,
                        QualifiedName = tempSignalQualifiedName,
                        ScaleFactor = tempScaleFactor,
                        StartBit = tempStartbit,
                        Type = tempSignalType,
                        Unit = tempSignalUnit,
                    };
                    tempCanMessage.Signals.Add(tempCanSignal);

                    status = Kvadblib.GetNextSignal(messageHandle, out signalHandle);
                }
                status = Kvadblib.GetNextMsg(db_handle, out messageHandle);
            }

            // All done; close database
            Kvadblib.Close(db_handle);
            return Messages;
        }
    }
    public class CanMessage
    {
        public string Name { get; set; }
        public string QualifiedName { get; set; }
        public string Comment { get; set; }
        public int ID { get; set; }
        public Kvadblib.MESSAGE Flags { get; set; }
        public int DLC { get; set; }

        public List<CanSignal> Signals { get; } = new List<CanSignal>();
    }

    public class CanSignal
    {
        public string Name { get; set; }
        public string QualifiedName { get; set; }
        public string Comment { get; set; }
        public string Unit { get; set; }
        public Kvadblib.SignalEncoding Encoding { get; set; }
        public Kvadblib.SignalType Type { get; set; }
        public int StartBit { get; set; }
        public int Length { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double ScaleFactor { get; set; }
        public double Offset { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEnumerate_Click(null, null);

        }

        //clrTest1.Class1 Class1 = new Class1();
        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            //if (!Class1.IsLibraryLoaded())
            //{
            //    Console.WriteLine("Class1.LoadStlinkLibrary():" + Class1.LoadStlinkLibrary(""));
            //    Console.WriteLine("Class1.IsLibraryLoaded(): " + Class1.IsLibraryLoaded());
            //    Console.WriteLine("GetPathOfProcess(): " + Class1.GetPathOfProcess().ToString());
            //}
            //
            //if (Class1.IsLibraryLoaded())
            //{
            //    uint num = 0;
            //    bool clear = false;
            //    Console.WriteLine("Class1.EnumDevices(out num, clear): " + Class1.EnumDevices(out num, clear).ToString());
            //    Console.WriteLine("num: " + num.ToString());
            //}
            List<DeviceInfo> devices = new List<DeviceInfo>();
            STLinkIf_StatusT status = wrapper.EnumerateDevices(out devices);
            dgv_stLinks.DataSource = devices;


        }
        Wrapper wrapper = new Wrapper();

        private void btn_OpenBridge_Click(object sender, EventArgs e)
        {
            if (dgv_stLinks.CurrentRow != null)
            {
                var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                if (deviceInfo != null)
                    wrapper.InitBridge(deviceInfo);
            }
        }
    }
}
