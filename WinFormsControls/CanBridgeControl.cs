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

namespace WinFormsControls
{
    public partial class CanBridgeControl: UserControl
    {
        #region Storage

        readonly Dictionary<int, CanActivityDisplayData> ReceivedDataSummary = new Dictionary<int, CanActivityDisplayData>();
        public Dictionary<int, CanMessageType> CanMessagesDatabase { get; set; }
        public STLinkBridgeWrapper.STLinkBridgeWrapper StLinkBridge { get; private set; }
        private Int64 canMessageReceivedPreviousTimeStamp;

        /// <summary>
        /// The amount of time inbetween updates of the activity indicator in milli seconds
        /// </summary>
        public Int64 RefreshTime { get; set; } = 300;
        #endregion

        public CanBridgeControl()
        {
            InitializeComponent();
            StLinkBridge = new STLinkBridgeWrapper.STLinkBridgeWrapper();
            cbSpeed.DataSource = new List<uint> { 1000, 800, 500, 250, 125, 100 };
            cbSpeed.SelectedIndex = 0;
            StLinkBridge.CanTransmissionStatusChanged += StLinkBridge_CanTransmissionStatusChanged;
            btnEnumerate_Click(null, null);
        }



        public void UpdateActivityIndicator()
        {
            dgvActivityIndicator.DataSource = ReceivedDataSummary.Values.ToList();
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
            //wrapper.CanMessageReceived += Wrapper_CanMessageReceived;
            //wrapper.CanMessageReceived += testNS.CanMessageReceiver.CanMessageReceivedCallback;
            StLinkBridge.CanMessageReceived += StLinkBridge_CanMessageReceived;

            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            // TODO: Selectable speed
            StLinkBridge.CanInit(baudrate, false);
            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);

            // TODO: Selectable pollrate
            StLinkBridge.StartTransmission(polltime);
            Debug.Assert(StLinkBridge.GetBridgeStatus() == Brg_StatusT.BRG_NO_ERR);
        }

        private void StLinkBridge_CanMessageReceived(object sender, CanMessageReceivedEventArgs e)
        {
            if ((DateTime.Now.Ticks - canMessageReceivedPreviousTimeStamp) < RefreshTime*10000)
            {
                UpdateActivityIndicator();
                canMessageReceivedPreviousTimeStamp = DateTime.Now.Ticks;
            }
        }
        #endregion

        #region EventHandlers
        private void btnEnumerate_Click(object sender, EventArgs e)
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            STLinkIf_StatusT status = StLinkBridge.EnumerateDevices(out devices);
            dgv_stLinks.DataSource = devices;
        }

        private void btn_OpenBridge_Click(object sender, EventArgs e)
        {
            if (dgv_stLinks.CurrentRow != null)
            {
                var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                if (deviceInfo != null)
                {
                    var baudrate = (uint)cbSpeed.SelectedItem;
                    var polltime = nudPollTime.Value;
                    InitializeCAN(deviceInfo, baudrate, (double)polltime);

                }
            }
        }

        private void StLinkBridge_CanTransmissionStatusChanged(object sender, EventArgs e)
        {
            if (StLinkBridge.TransmissionRunning)
            {
                cbSpeed.Enabled = false;
                nudPollTime.Enabled = false;
            }
            else
            {
                cbSpeed.Enabled = true;
                nudPollTime.Enabled = false;

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
