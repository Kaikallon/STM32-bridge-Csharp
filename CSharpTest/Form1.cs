using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STLinkBridgeWrapper;
using System.Diagnostics;
using System.Reflection;

namespace CSharpTest
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEnumerate_Click(null, null);
            testNS.IVT_Msg_Result_U1Message.CanMessageReceived += IVT_Msg_Result_U1Message_CanMessageReceived;
            testNS.IVT_Msg_Result_U2Message.CanMessageReceived += IVT_Msg_Result_U2Message_CanMessageReceived;
            testNS.IVT_Msg_Result_U3Message.CanMessageReceived += IVT_Msg_Result_U3Message_CanMessageReceived;
        }

        private void IVT_Msg_Result_U3Message_CanMessageReceived(object sender, CanDB.CanMessageReceivedEventArgs<testNS.IVT_Msg_Result_U3Message> e)
        {
            SetControlPropertyThreadSafe(richTextBox1, "Text", e.ReceivedMessage.GetIVT_Result_U3().ToString());
            //Console.WriteLine($"Result: {e.ReceivedMessage.GetIVT_Result_U3()}");
            //Console.WriteLine($"Mux   : {e.ReceivedMessage.GetIVT_MuxID_U3()}");
            //Console.WriteLine($"Count : {e.ReceivedMessage.GetIVT_ResultState_And_MsgCount_U3()}");
        }

        private void IVT_Msg_Result_U2Message_CanMessageReceived(object sender, CanDB.CanMessageReceivedEventArgs<testNS.IVT_Msg_Result_U2Message> e)
        {
            //SetControlPropertyThreadSafe(richTextBox1, "Text", e.ReceivedMessage.GetIVT_Result_U2().ToString());
            //Console.WriteLine($"U2: {e.ReceivedMessage.Data}");

        }

        private void IVT_Msg_Result_U1Message_CanMessageReceived(object sender, CanDB.CanMessageReceivedEventArgs<testNS.IVT_Msg_Result_U1Message> e)
        {
            //SetControlPropertyThreadSafe(richTextBox1, "Text", e.ReceivedMessage.GetIVT_Result_U1().ToString());
            //Console.WriteLine($"U1: {e.ReceivedMessage.Data}");

        }

        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            STLinkIf_StatusT status = wrapper.EnumerateDevices(out devices);
            dgv_stLinks.DataSource = devices;
        }
        STLinkBridgeWrapper.STLinkBridgeWrapper wrapper = new STLinkBridgeWrapper.STLinkBridgeWrapper();

        private void btn_OpenBridge_Click(object sender, EventArgs e)
        {
            if (dgv_stLinks.CurrentRow != null)
            {
                var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                if (deviceInfo != null)
                    InitializeCAN(deviceInfo);
            }
        }


        private void InitializeCAN(DeviceInfo selectedDevice)
        {
            if (selectedDevice == null)
                throw new Exception("No STLink device found");

            Brg_StatusT bridgeStatus = wrapper.OpenBridge(selectedDevice);
            //wrapper.CanMessageReceived += Wrapper_CanMessageReceived; //TODO: Investigate why it isn't possible to have multiple subscribers
            wrapper.CanMessageReceived += testNS.CanMessageReceiver.CanMessageReceivedCallback;

            Debug.Assert(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            wrapper.CanInit(1000000, false);
            Debug.Assert(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            wrapper.StartTransmission(100);
            Debug.Assert(wrapper.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
        }

        private void Wrapper_CanMessageReceived(object sender, CanMessageReceivedEventArgs e)
        {
            //var ReceivedMessages = wrapper.CanRead();
            // thread-safe equivalent of
            // myLabel.Text = status;
            SetControlPropertyThreadSafe(richTextBox1, "Text", e.ReceivedMessages.Count.ToString());

            //richTextBox1.AppendText(ReceivedMessages.Count.ToString());

        }

        private delegate void SetControlPropertyThreadSafeDelegate(
            Control control,
            string propertyName,
            object propertyValue);

        public static void SetControlPropertyThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }

        private void btn_CloseBridge_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //wrapper.CloseBridge();
        }
    }
}
