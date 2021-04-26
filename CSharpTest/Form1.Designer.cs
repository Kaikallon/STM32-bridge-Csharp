namespace CSharpTest
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.canBridgeControl = new WinFormsControls.CanBridgeControl();
            this.SuspendLayout();
            // 
            // canBridgeControl
            // 
            this.canBridgeControl.CanMessagesDatabase = null;
            this.canBridgeControl.Location = new System.Drawing.Point(12, 12);
            this.canBridgeControl.MinimumSize = new System.Drawing.Size(360, 0);
            this.canBridgeControl.Name = "canBridgeControl";
            this.canBridgeControl.RefreshTime = ((long)(300));
            this.canBridgeControl.Size = new System.Drawing.Size(544, 305);
            this.canBridgeControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 683);
            this.Controls.Add(this.canBridgeControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WinFormsControls.CanBridgeControl canBridgeControl;
    }
}

