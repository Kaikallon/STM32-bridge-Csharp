using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanDB;
using STLinkBridgeWrapper;
using System.Diagnostics;
using System.Reflection;

namespace WinFormsControls
{
    public partial class CanBridgeControl: UserControl
    {
        #region Storage

        readonly Dictionary<int, CanActivityDisplayData> ReceivedDataSummary = new Dictionary<int, CanActivityDisplayData>();
        public Dictionary<int, CanMessageType> CanMessagesDatabase { get; set; }
        public STLinkBridgeWrapper.STLinkBridgeWrapper StLinkBridge { get; private set; }

        /// <summary>
        /// The amount of time inbetween updates of the activity indicator in milli seconds
        /// </summary>
        public Int64 RefreshTime { get; set; } = 300;
        #endregion

        public CanBridgeControl()
        {
            InitializeComponent();
            StLinkBridge = new STLinkBridgeWrapper.STLinkBridgeWrapper();
            cbSpeed.DataSource = new List<uint> { 1000, 750, 500, 250, 125, 100 };
            cbSpeed.SelectedIndex = 0;
            StLinkBridge.CanTransmissionStatusChanged += StLinkBridge_CanTransmissionStatusChanged;
            dgv_stLinks.SelectionChanged += dgv_stLinks_SelectionChanged;
            StLinkBridge.CanMessageReceived += StLinkBridge_CanMessageReceived;


            // Populate datagrid
            btnEnumerate_Click(this, null);
        }

        public void PerformPeriodicUiUpdate()
        {
            // Perform thread safe UI update
            SetControlPropertyThreadSafe(dgv_stLinks, "DataSource", ReceivedDataSummary.Values.ToList());
            //dgvActivityIndicator.DataSource = ReceivedDataSummary.Values.ToList();

            SetControlPropertyThreadSafe(nudPollTime, "Value", (decimal)StLinkBridge.CurrentPollInterval);
            //nudPollTime.Value = (decimal)StLinkBridge.CurrentPollInterval;
        }

        private void AddMessageToActivityIndicator(CanBridgeMessageRx receivedMessage)
        {
            int id = (int)receivedMessage.ID;
            if (ReceivedDataSummary.ContainsKey(id))
            {
                CanActivityDisplayData temp = ReceivedDataSummary[id];
                temp.Count++;
                temp.Data = receivedMessage.data;
                temp.Length = receivedMessage.DLC;
                temp.RcvTime = new DateTime(receivedMessage.TimeStamp);
            }
            else
            {
                ReceivedDataSummary.Add(id, new CanActivityDisplayData
                {
                    Id = id,
                    Type = CanMessagesDatabase[id]?.Name,
                    Data = receivedMessage.data,
                    Length = receivedMessage.DLC,
                    RcvTime = new DateTime(receivedMessage.TimeStamp),
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

            StLinkBridge.CanInit(baudrate, false);
            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

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
            if (!StLinkBridge.TransmissionRunning)
            {
                ReceivedDataSummary.Clear();
                // Open bridge
                if (dgv_stLinks.CurrentRow != null)
                {
                    var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                    if (deviceInfo != null)
                    {
                        var baudrate = (uint)cbSpeed.SelectedItem * 1000;
                        var polltime = nudPollTime.Value;
                        InitializeCAN(deviceInfo, baudrate, (double)polltime);

                    }
                }
            }
            else
            {
                // Close bridge
                StLinkBridge.StopTransmission();
                System.Threading.Thread.Sleep(100); // TODO: This is a bit hacky, but seems to be enough to ensure that any ongoing polling is finished. Better would be to wait for a flag or something
                StLinkBridge.CloseBridge();
            }
            
        }

        private void StLinkBridge_CanTransmissionStatusChanged(object sender, EventArgs e)
        {
            if (StLinkBridge.TransmissionRunning)
            {
                cbSpeed.Enabled = false;
                nudPollTime.Enabled = false;
                btnEnumerate.Enabled = false;
                btn_OpenBridge.Text = "Close Bridge";
                timerUiUpdate.Start();
            }
            else
            {
                cbSpeed.Enabled = true;
                nudPollTime.Enabled = false;
                btnEnumerate.Enabled = true;
                btn_OpenBridge.Text = "Open Bridge";
                timerUiUpdate.Stop();
                btnEnumerate_Click(this, null);

            }
        }

        private void timerUiUpdate_Tick(object sender, EventArgs e)
        {
            PerformPeriodicUiUpdate();
            // TODO: Implement showing target voltage
            // TODO: Consider enumerating devices periodically
        }

        private void dgv_stLinks_SelectionChanged(object sender, EventArgs e)
        {
            if (!StLinkBridge.TransmissionRunning)
            {
                if (dgv_stLinks.SelectedRows.Count > 0)
                    btn_OpenBridge.Enabled = true;
                else
                    btn_OpenBridge.Enabled = false;
            }
        }
        #endregion
    }

    public class CanActivityDisplayData
    {
        public int Id { get; set; }
        public string Type { get; set; }      = "";
        public int Length { get; set; }       = 0;
        public int Count { get; set; }        = 1;
        public DateTime RcvTime { get; set; } = DateTime.Now;
        public UInt64 Data { get; set; }      = 0;
    }
}
