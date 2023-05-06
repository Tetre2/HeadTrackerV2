namespace HeadTrackerV2.Usercontrolls
{
    partial class ucCOM
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
            this.disconnectSerial = new System.Windows.Forms.Button();
            this.scanPorts = new System.Windows.Forms.Button();
            this.ports = new System.Windows.Forms.ComboBox();
            this.connectToSerial = new System.Windows.Forms.Button();
            this.serialOutput = new System.Windows.Forms.RichTextBox();
            this.getGyroDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // disconnectSerial
            // 
            this.disconnectSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disconnectSerial.Location = new System.Drawing.Point(280, 230);
            this.disconnectSerial.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectSerial.Name = "disconnectSerial";
            this.disconnectSerial.Size = new System.Drawing.Size(114, 35);
            this.disconnectSerial.TabIndex = 3;
            this.disconnectSerial.Text = "DISCONNECT";
            this.disconnectSerial.UseVisualStyleBackColor = true;
            this.disconnectSerial.Visible = false;
            // 
            // scanPorts
            // 
            this.scanPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanPorts.Location = new System.Drawing.Point(161, 230);
            this.scanPorts.Margin = new System.Windows.Forms.Padding(4);
            this.scanPorts.Name = "scanPorts";
            this.scanPorts.Size = new System.Drawing.Size(111, 35);
            this.scanPorts.TabIndex = 2;
            this.scanPorts.Text = "SCAN";
            this.scanPorts.UseVisualStyleBackColor = true;
            // 
            // ports
            // 
            this.ports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ports.FormattingEnabled = true;
            this.ports.Location = new System.Drawing.Point(4, 236);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(150, 25);
            this.ports.TabIndex = 1;
            this.ports.Text = "Choose COM Port";
            // 
            // connectToSerial
            // 
            this.connectToSerial.Location = new System.Drawing.Point(280, 230);
            this.connectToSerial.Margin = new System.Windows.Forms.Padding(4);
            this.connectToSerial.Name = "connectToSerial";
            this.connectToSerial.Size = new System.Drawing.Size(114, 35);
            this.connectToSerial.TabIndex = 32;
            this.connectToSerial.Text = "CONNECT";
            this.connectToSerial.UseVisualStyleBackColor = true;
            // 
            // serialOutput
            // 
            this.serialOutput.Location = new System.Drawing.Point(4, 4);
            this.serialOutput.Margin = new System.Windows.Forms.Padding(4);
            this.serialOutput.Name = "serialOutput";
            this.serialOutput.Size = new System.Drawing.Size(390, 218);
            this.serialOutput.TabIndex = 31;
            this.serialOutput.Text = "";
            // 
            // getGyroDataBtn
            // 
            this.getGyroDataBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getGyroDataBtn.Location = new System.Drawing.Point(229, 273);
            this.getGyroDataBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getGyroDataBtn.Name = "getGyroDataBtn";
            this.getGyroDataBtn.Size = new System.Drawing.Size(165, 42);
            this.getGyroDataBtn.TabIndex = 4;
            this.getGyroDataBtn.Text = "GET GYRO DATA";
            this.getGyroDataBtn.UseVisualStyleBackColor = true;
            // 
            // ucCOM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.getGyroDataBtn);
            this.Controls.Add(this.disconnectSerial);
            this.Controls.Add(this.scanPorts);
            this.Controls.Add(this.ports);
            this.Controls.Add(this.connectToSerial);
            this.Controls.Add(this.serialOutput);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ucCOM";
            this.Size = new System.Drawing.Size(400, 500);
            this.Load += new System.EventHandler(this.ucCOM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button disconnectSerial;
        private Button scanPorts;
        private ComboBox ports;
        private Button connectToSerial;
        private RichTextBox serialOutput;
        private Button getGyroDataBtn;
    }
}
