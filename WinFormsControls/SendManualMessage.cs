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

namespace WinFormsControls
{
    public partial class SendManualMessage : UserControl
    {
        private readonly NakedNumericUpDown[] dataFields = new NakedNumericUpDown[8];
        public SendManualMessage()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                dataFields[i] = new NakedNumericUpDown
                {
                    Dock = DockStyle.Fill,
                    Hexadecimal = true,
                    Maximum = 255,
                    Minimum = 0,
                    DecimalPlaces = 0,
                    TabIndex = i + 2,
                    
                };
                tableDataFields.Controls.Add(dataFields[i], 7-i, 0);
            }
        }

        private ICanNetworkConnection _canNetworkConnection;

        public ICanNetworkConnection CanNetworkConnection
        {
            get { return _canNetworkConnection; }
            set
            {
                if (_canNetworkConnection != null)
                {
                    // Clean up
                    _canNetworkConnection.CanConnectionStatusChanged -= _canNetworkConnection_CanConnectionStatusChanged;
                    this.btnSend.Enabled = false;
                }

                // Store value
                _canNetworkConnection = value;

                if (_canNetworkConnection != null)
                {
                    // Set up
                    _canNetworkConnection.CanConnectionStatusChanged += _canNetworkConnection_CanConnectionStatusChanged;
                    if (_canNetworkConnection.CanConnectionRunning)
                    {
                        btnSend.Enabled = true;
                    }
                    else
                    {
                        btnSend.Enabled = false;
                    }
                }
            }
        }

        private void _canNetworkConnection_CanConnectionStatusChanged(object sender, CanConnectionChangedEventArgs e)
        {
            if (_canNetworkConnection.CanConnectionRunning)
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            TrySendMessage();
        }

        private bool TrySendMessage()
        {
            if (this._canNetworkConnection == null)
                return false;

            if (this._canNetworkConnection.CanConnectionRunning == false)
                return false;

            byte[] databytes = new byte[8];
            for(int i = 0; i < 8; i++)
            {
                databytes[i] = (byte)dataFields[i].Value;
            }
            UInt64 data = BitConverter.ToUInt64(databytes, 0);

            _canNetworkConnection.WriteMessage(new CanMessage
            {
                DLC = (byte)this.nudDLC.Value,
                Id = (uint)this.nnudID.Value,
                Data = data,

                
            });
            return true;
        }
    }

    public class NakedNumericUpDown : NumericUpDown
    {
        public NakedNumericUpDown() : base()
        {
            Controls[0].Hide();
        }

        protected override void OnTextBoxResize(object source, EventArgs e)
        {
            base.OnTextBoxResize(source, e);
            this.Controls[1].Resize -= OnTextBoxResize;
            Controls[1].Width = Width - 4;
            this.Controls[1].Resize += OnTextBoxResize;

        }



        bool selectByMouse = false;
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Select(0, this.Text.Length);
            if (MouseButtons == MouseButtons.Left)
            {
                selectByMouse = true;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (selectByMouse)
            {
                Select(0, Text.Length);
                selectByMouse = false;
            }
        }
    }
}
