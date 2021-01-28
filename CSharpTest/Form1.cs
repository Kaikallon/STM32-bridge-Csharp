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
using Kvaser.KvadbLib;

namespace CSharpTest
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEnumerate_Click(null, null);
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
                    wrapper.InitBridge(deviceInfo);
            }
        }
    }
}
