namespace WinFormsControls
{
    partial class CanBridgeControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_OpenBridge = new System.Windows.Forms.Button();
            this.dgv_stLinks = new System.Windows.Forms.DataGridView();
            this.btnEnumerate = new System.Windows.Forms.Button();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTargetVoltage = new System.Windows.Forms.TextBox();
            this.lblTargetVoltage = new System.Windows.Forms.Label();
            this.nudPollTime = new System.Windows.Forms.NumericUpDown();
            this.lblPollTime = new System.Windows.Forms.Label();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timerUiUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stLinks)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPollTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OpenBridge
            // 
            this.btn_OpenBridge.Enabled = false;
            this.btn_OpenBridge.Location = new System.Drawing.Point(338, 3);
            this.btn_OpenBridge.Name = "btn_OpenBridge";
            this.btn_OpenBridge.Size = new System.Drawing.Size(75, 48);
            this.btn_OpenBridge.TabIndex = 5;
            this.btn_OpenBridge.Text = "Open Bridge";
            this.btn_OpenBridge.UseVisualStyleBackColor = true;
            this.btn_OpenBridge.Click += new System.EventHandler(this.btn_OpenBridge_Click);
            // 
            // dgv_stLinks
            // 
            this.dgv_stLinks.AllowUserToAddRows = false;
            this.dgv_stLinks.AllowUserToDeleteRows = false;
            this.dgv_stLinks.AllowUserToResizeRows = false;
            this.dgv_stLinks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_stLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_stLinks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_stLinks.Location = new System.Drawing.Point(3, 200);
            this.dgv_stLinks.MultiSelect = false;
            this.dgv_stLinks.Name = "dgv_stLinks";
            this.dgv_stLinks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_stLinks.Size = new System.Drawing.Size(418, 14);
            this.dgv_stLinks.TabIndex = 4;
            // 
            // btnEnumerate
            // 
            this.btnEnumerate.Location = new System.Drawing.Point(257, 3);
            this.btnEnumerate.Name = "btnEnumerate";
            this.btnEnumerate.Size = new System.Drawing.Size(75, 48);
            this.btnEnumerate.TabIndex = 3;
            this.btnEnumerate.Text = "Enumerate ST-Link devices";
            this.btnEnumerate.UseVisualStyleBackColor = true;
            this.btnEnumerate.Click += new System.EventHandler(this.btnEnumerate_Click);
            // 
            // cbSpeed
            // 
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Location = new System.Drawing.Point(6, 19);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(87, 21);
            this.cbSpeed.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 236);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_stLinks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 217);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxTargetVoltage);
            this.panel1.Controls.Add(this.lblTargetVoltage);
            this.panel1.Controls.Add(this.btn_OpenBridge);
            this.panel1.Controls.Add(this.nudPollTime);
            this.panel1.Controls.Add(this.btnEnumerate);
            this.panel1.Controls.Add(this.lblPollTime);
            this.panel1.Controls.Add(this.lblBaudrate);
            this.panel1.Controls.Add(this.cbSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 54);
            this.panel1.TabIndex = 5;
            // 
            // textBoxTargetVoltage
            // 
            this.textBoxTargetVoltage.Location = new System.Drawing.Point(174, 19);
            this.textBoxTargetVoltage.Name = "textBoxTargetVoltage";
            this.textBoxTargetVoltage.ReadOnly = true;
            this.textBoxTargetVoltage.Size = new System.Drawing.Size(77, 20);
            this.textBoxTargetVoltage.TabIndex = 11;
            this.textBoxTargetVoltage.WordWrap = false;
            // 
            // lblTargetVoltage
            // 
            this.lblTargetVoltage.AutoSize = true;
            this.lblTargetVoltage.Location = new System.Drawing.Point(174, 3);
            this.lblTargetVoltage.Name = "lblTargetVoltage";
            this.lblTargetVoltage.Size = new System.Drawing.Size(77, 13);
            this.lblTargetVoltage.TabIndex = 10;
            this.lblTargetVoltage.Text = "Target Voltage";
            // 
            // nudPollTime
            // 
            this.nudPollTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPollTime.Location = new System.Drawing.Point(99, 19);
            this.nudPollTime.Name = "nudPollTime";
            this.nudPollTime.Size = new System.Drawing.Size(69, 20);
            this.nudPollTime.TabIndex = 9;
            this.nudPollTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblPollTime
            // 
            this.lblPollTime.AutoSize = true;
            this.lblPollTime.Location = new System.Drawing.Point(96, 3);
            this.lblPollTime.Name = "lblPollTime";
            this.lblPollTime.Size = new System.Drawing.Size(72, 13);
            this.lblPollTime.TabIndex = 7;
            this.lblPollTime.Text = "Poll Time [ms]";
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Location = new System.Drawing.Point(3, 3);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(86, 13);
            this.lblBaudrate.TabIndex = 7;
            this.lblBaudrate.Text = "Baudrate [kbit/s]";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(418, 131);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.WordWrap = false;
            // 
            // timerUiUpdate
            // 
            this.timerUiUpdate.Interval = 500;
            this.timerUiUpdate.Tick += new System.EventHandler(this.timerUiUpdate_Tick);
            // 
            // CanBridgeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(430, 0);
            this.Name = "CanBridgeControl";
            this.Size = new System.Drawing.Size(430, 236);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stLinks)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPollTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_OpenBridge;
        private System.Windows.Forms.DataGridView dgv_stLinks;
        private System.Windows.Forms.Button btnEnumerate;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPollTime;
        private System.Windows.Forms.Label lblBaudrate;
        private System.Windows.Forms.NumericUpDown nudPollTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerUiUpdate;
        private System.Windows.Forms.TextBox textBoxTargetVoltage;
        private System.Windows.Forms.Label lblTargetVoltage;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
