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
            this.nudPollTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btn_OpenBridge.Location = new System.Drawing.Point(270, 3);
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
            this.dgv_stLinks.Location = new System.Drawing.Point(3, 63);
            this.dgv_stLinks.MultiSelect = false;
            this.dgv_stLinks.Name = "dgv_stLinks";
            this.dgv_stLinks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_stLinks.Size = new System.Drawing.Size(348, 151);
            this.dgv_stLinks.TabIndex = 4;
            // 
            // btnEnumerate
            // 
            this.btnEnumerate.Location = new System.Drawing.Point(189, 3);
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
            this.groupBox1.Size = new System.Drawing.Size(360, 236);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 217);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_OpenBridge);
            this.panel1.Controls.Add(this.nudPollTime);
            this.panel1.Controls.Add(this.btnEnumerate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 54);
            this.panel1.TabIndex = 5;
            // 
            // nudPollTime
            // 
            this.nudPollTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPollTime.Location = new System.Drawing.Point(114, 20);
            this.nudPollTime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPollTime.Name = "nudPollTime";
            this.nudPollTime.Size = new System.Drawing.Size(69, 20);
            this.nudPollTime.TabIndex = 9;
            this.nudPollTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Poll Time [ms]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Baudrate [kbit/s]";
            // 
            // timerUiUpdate
            // 
            this.timerUiUpdate.Tick += new System.EventHandler(this.timerUiUpdate_Tick);
            // 
            // CanBridgeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(360, 0);
            this.Name = "CanBridgeControl";
            this.Size = new System.Drawing.Size(360, 236);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPollTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerUiUpdate;
    }
}
