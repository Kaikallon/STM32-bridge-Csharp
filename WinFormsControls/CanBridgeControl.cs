using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanDefinitions;
using STLinkBridgeWrapper;
using System.Diagnostics;
using System.Reflection;

namespace WinFormsControls
{
    public partial class CanBridgeControl: UserControl
    {
        #region Storage

        readonly Dictionary<UInt32, CanActivityDisplayData> ReceivedDataSummary = new Dictionary<UInt32, CanActivityDisplayData>();
        public Dictionary<UInt32, CanMessageType> CanMessagesDatabase { get; set; }
        public STLinkBridgeWrapper.STLinkBridgeWrapper StLinkBridge { get; private set; }

        /// <summary>
        /// The amount of time inbetween updates of the activity indicator in milli seconds
        /// </summary>
        public Int64 RefreshTime { get; set; } = 300;
        #endregion

        public CanBridgeControl() : base()
        {
            InitializeComponent();
            StLinkBridge = new STLinkBridgeWrapper.STLinkBridgeWrapper();
            cbSpeed.DataSource = new List<uint> { 1000, 750, 500, 250, 125, 100 };
            cbSpeed.SelectedIndex = 0;
            StLinkBridge.CanConnectionStatusChanged += StLinkBridge_CanConnectionStatusChanged;
            dgv_stLinks.SelectionChanged += dgv_stLinks_SelectionChanged;
            StLinkBridge.CanMessageReceived += StLinkBridge_CanMessageReceived;


            // Populate datagrid
            btnEnumerate_Click(this, null);
        }


        public void PerformPeriodicUiUpdate()
        {
            // Perform thread safe UI update
            //SetControlPropertyThreadSafe(dgv_stLinks, "DataSource", ReceivedDataSummary.Values.ToList());
            var table = CanActivityDisplayDatas2StringTable(ReceivedDataSummary.Values);
            SetControlPropertyThreadSafe(richTextBox1, "Text", table);
            //dgvActivityIndicator.DataSource = ReceivedDataSummary.Values.ToList();

            SetControlPropertyThreadSafe(nudPollTime, "Value", (decimal)StLinkBridge.CurrentPollInterval);
            //nudPollTime.Value = (decimal)StLinkBridge.CurrentPollInterval;

            float voltage = 0;
            StLinkBridge.GetTargetVoltage(out voltage);
            SetControlPropertyThreadSafe(textBoxTargetVoltage, "Text", voltage.ToString("0.00") + " V");

        }

        private void AddMessageToActivityIndicator(CanMessage receivedMessage)
        {
            UInt32 id = receivedMessage.Id;
            CanActivityDisplayData temp;
            if (ReceivedDataSummary.TryGetValue(id, out temp))
            {
                temp.Count++;
                temp.Data = receivedMessage.Data;
                temp.Length = receivedMessage.DLC;
                temp.RcvTime = new DateTime(receivedMessage.SystemTimeStamp);
            }
            else
            {
                string name = "Unknown type";
                CanMessageType canMessageType;
                if (CanMessagesDatabase.TryGetValue(id, out canMessageType))
                    name = canMessageType.Name;

                ReceivedDataSummary.Add(id, new CanActivityDisplayData
                {
                    Id = id,
                    Type = name,
                    Data = receivedMessage.Data,
                    Length = receivedMessage.DLC,
                    RcvTime = new DateTime(receivedMessage.SystemTimeStamp),
                });
            }
        }

        #region CAN
        private void InitializeCAN(DeviceInfo selectedDevice, uint baudrate, double polltime)
        {
            if (selectedDevice == null)
                throw new Exception("No STLink device found");
            Brg_StatusT bridgeStatus = StLinkBridge.OpenBridge(selectedDevice);
            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            try
            {
                StLinkBridge.CanInit(baudrate, false);
                Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}\n\n{e.StackTrace}", 
                    e.Message, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            // TODO: Handle the other errors in a similar manner

            StLinkBridge.StartTransmission(polltime);
            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
        }

        private void StLinkBridge_CanMessageReceived(object sender, CanMessageReceivedEventArgs e)
        {
            foreach (var message in e.ReceivedMessages)
            {
                AddMessageToActivityIndicator(message);
            }
        }
        #endregion

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


        #region EventHandlers
        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            STLinkIf_StatusT status = StLinkBridge.EnumerateDevices(out devices);
            dgv_stLinks.DataSource = devices;
        }

        private void btn_OpenBridge_Click(object sender, EventArgs e)
        {
            if (!StLinkBridge.CanConnectionRunning)
            {
                ReceivedDataSummary.Clear();
                // Open bridge
                if (dgv_stLinks.CurrentRow == null)
                    return;
                var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                if (deviceInfo == null)
                    return;

                var baudrate = (uint)cbSpeed.SelectedItem * 1000;
                var polltime = nudPollTime.Value;

                InitializeCAN(deviceInfo, baudrate, (double)polltime);

            }
            else
            {
                // Close bridge
                StLinkBridge.CloseConnection();
            }
            
        }

        private void StLinkBridge_CanConnectionStatusChanged(object sender, CanConnectionChangedEventArgs e)
        {
            if (e.CanConnectionRunning)
            {
                cbSpeed.Enabled = false;
                nudPollTime.Enabled = false;
                btnEnumerate.Enabled = false;
                btn_OpenBridge.Text = "Close Bridge";
                timerUiUpdate.Start();
                richTextBox1.Visible = true;
                dgv_stLinks.Visible = false;
            }
            else
            {
                cbSpeed.Enabled = true;
                nudPollTime.Enabled = true;
                btnEnumerate.Enabled = true;
                btn_OpenBridge.Text = "Open Bridge";
                timerUiUpdate.Stop();
                btnEnumerate_Click(this, null);
                richTextBox1.Visible = false;
                dgv_stLinks.Visible = true;
            }
        }

        private void timerUiUpdate_Tick(object sender, EventArgs e)
        {
            PerformPeriodicUiUpdate();
            // TODO: Consider enumerating devices periodically
        }

        private void dgv_stLinks_SelectionChanged(object sender, EventArgs e)
        {
            if (!StLinkBridge.CanConnectionRunning)
            {
                if (dgv_stLinks.SelectedRows.Count > 0)
                    btn_OpenBridge.Enabled = true;
                else
                    btn_OpenBridge.Enabled = false;
            }
        }

        private string CanActivityDisplayDatas2StringTable(IEnumerable<CanActivityDisplayData> canActivityDisplayDatas)
        {
            StringBuilder sb = new StringBuilder();
            var linePattern = "{0,-5} {1,-30} {2,-3} {3,-8} {4,-8} {5, -16}";

            var header = String.Format(linePattern,
                "Id",
                "Type",
                "DLC",
                "Count",
                "RcvTime",
                "Data");
            sb.AppendLine(header);


            foreach (var canActivityDisplayData in canActivityDisplayDatas)
            {
                var line = String.Format(linePattern,
                    canActivityDisplayData.Id,
                    canActivityDisplayData.Type,
                canActivityDisplayData.Length,
                canActivityDisplayData.Count,
                canActivityDisplayData.RcvTime.ToShortTimeString(),
                canActivityDisplayData.Data.ToString("X16"));
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
        #endregion
    }


    class CanActivityDisplayData
    {
        public UInt32 Id { get; set; }
        public string Type { get; set; }      = "";
        public int Length { get; set; }       = 0;
        public int Count { get; set; }        = 1;
        public DateTime RcvTime { get; set; } = DateTime.Now;
        public UInt64 Data { get; set; }      = 0;
    }
}
