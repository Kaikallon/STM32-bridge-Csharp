namespace WinFormsControls
{
    partial class SendManualMessage
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nnudID = new WinFormsControls.NakedNumericUpDown();
            this.nudDLC = new System.Windows.Forms.NumericUpDown();
            this.tableDataFields = new System.Windows.Forms.TableLayoutPanel();
            this.label90 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label89 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnudID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDLC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nnudID);
            this.groupBox4.Controls.Add(this.nudDLC);
            this.groupBox4.Controls.Add(this.tableDataFields);
            this.groupBox4.Controls.Add(this.label90);
            this.groupBox4.Controls.Add(this.btnSend);
            this.groupBox4.Controls.Add(this.label89);
            this.groupBox4.Controls.Add(this.label87);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(261, 103);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Manual";
            // 
            // nnudID
            // 
            this.nnudID.Location = new System.Drawing.Point(7, 31);
            this.nnudID.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nnudID.Name = "nnudID";
            this.nnudID.Size = new System.Drawing.Size(83, 20);
            this.nnudID.TabIndex = 0;
            // 
            // nudDLC
            // 
            this.nudDLC.Location = new System.Drawing.Point(96, 31);
            this.nudDLC.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudDLC.Name = "nudDLC";
            this.nudDLC.Size = new System.Drawing.Size(69, 20);
            this.nudDLC.TabIndex = 1;
            // 
            // tableDataFields
            // 
            this.tableDataFields.ColumnCount = 8;
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableDataFields.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableDataFields.Location = new System.Drawing.Point(2, 69);
            this.tableDataFields.Name = "tableDataFields";
            this.tableDataFields.RowCount = 1;
            this.tableDataFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDataFields.Size = new System.Drawing.Size(257, 32);
            this.tableDataFields.TabIndex = 2;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(4, 52);
            this.label90.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(74, 13);
            this.label90.TabIndex = 83;
            this.label90.Text = "Payload (hex):";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(170, 17);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 36);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(93, 15);
            this.label89.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(73, 13);
            this.label89.TabIndex = 74;
            this.label89.Text = "Length (DLC):";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(4, 15);
            this.label87.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(67, 13);
            this.label87.TabIndex = 70;
            this.label87.Text = "Message ID:";
            // 
            // SendManualMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.MaximumSize = new System.Drawing.Size(0, 103);
            this.MinimumSize = new System.Drawing.Size(261, 103);
            this.Name = "SendManualMessage";
            this.Size = new System.Drawing.Size(261, 103);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnudID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableDataFields;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.NumericUpDown nudDLC;
        private NakedNumericUpDown nnudID;
    }
}
