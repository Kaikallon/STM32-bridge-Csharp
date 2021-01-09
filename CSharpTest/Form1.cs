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

namespace CSharpTest
{
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
            Wrapper wrapper = new Wrapper();
            List<DeviceInfo> devices = new List<DeviceInfo>();
            STLinkIf_StatusT status = wrapper.EnumerateDevices(out devices);
            dgv_stLinks.DataSource = devices;


        }

        private void btn_OpenBridge_Click(object sender, EventArgs e)
        {
            Wrapper wrapper = new Wrapper();
            if (dgv_stLinks.CurrentRow != null)
            {
                var deviceInfo = dgv_stLinks.CurrentRow.DataBoundItem as DeviceInfo;
                if (deviceInfo != null)
                    wrapper.InitBridge(deviceInfo);
            }
        }
    }
}
