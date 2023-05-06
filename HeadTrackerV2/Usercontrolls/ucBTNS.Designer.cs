namespace HeadTrackerV2.Usercontrolls
{
    partial class ucBTNS
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
            this.zeroHotkey = new System.Windows.Forms.ComboBox();
            this.recalibrateGyro = new System.Windows.Forms.Button();
            this.recenterGyro = new System.Windows.Forms.Button();
            this.turnOffGyro = new System.Windows.Forms.Button();
            this.getGyroDataBtn = new System.Windows.Forms.Button();
            this.turnOnGyro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zeroHotkey
            // 
            this.zeroHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zeroHotkey.FormattingEnabled = true;
            this.zeroHotkey.Location = new System.Drawing.Point(296, 114);
            this.zeroHotkey.Name = "zeroHotkey";
            this.zeroHotkey.Size = new System.Drawing.Size(270, 25);
            this.zeroHotkey.TabIndex = 6;
            // 
            // recalibrateGyro
            // 
            this.recalibrateGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recalibrateGyro.Location = new System.Drawing.Point(4, 54);
            this.recalibrateGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recalibrateGyro.Name = "recalibrateGyro";
            this.recalibrateGyro.Size = new System.Drawing.Size(270, 42);
            this.recalibrateGyro.TabIndex = 3;
            this.recalibrateGyro.Text = "RECALIBRATE";
            this.recalibrateGyro.UseVisualStyleBackColor = true;
            this.recalibrateGyro.Click += new System.EventHandler(this.recalibrateGyro_Click);
            // 
            // recenterGyro
            // 
            this.recenterGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recenterGyro.Location = new System.Drawing.Point(4, 4);
            this.recenterGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recenterGyro.Name = "recenterGyro";
            this.recenterGyro.Size = new System.Drawing.Size(270, 42);
            this.recenterGyro.TabIndex = 1;
            this.recenterGyro.Text = "RE-CENTER";
            this.recenterGyro.UseVisualStyleBackColor = true;
            this.recenterGyro.Click += new System.EventHandler(this.recenterGyro_Click);
            // 
            // turnOffGyro
            // 
            this.turnOffGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turnOffGyro.Location = new System.Drawing.Point(4, 104);
            this.turnOffGyro.Margin = new System.Windows.Forms.Padding(4);
            this.turnOffGyro.Name = "turnOffGyro";
            this.turnOffGyro.Size = new System.Drawing.Size(270, 42);
            this.turnOffGyro.TabIndex = 5;
            this.turnOffGyro.Text = "TURN OFF";
            this.turnOffGyro.UseVisualStyleBackColor = true;
            this.turnOffGyro.Click += new System.EventHandler(this.turnOffGyro_Click);
            // 
            // getGyroDataBtn
            // 
            this.getGyroDataBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getGyroDataBtn.Location = new System.Drawing.Point(296, 4);
            this.getGyroDataBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getGyroDataBtn.Name = "getGyroDataBtn";
            this.getGyroDataBtn.Size = new System.Drawing.Size(270, 42);
            this.getGyroDataBtn.TabIndex = 2;
            this.getGyroDataBtn.Text = "GET GYRO DATA";
            this.getGyroDataBtn.UseVisualStyleBackColor = true;
            this.getGyroDataBtn.Click += new System.EventHandler(this.getGyroDataBtn_Click);
            // 
            // turnOnGyro
            // 
            this.turnOnGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turnOnGyro.Location = new System.Drawing.Point(4, 104);
            this.turnOnGyro.Margin = new System.Windows.Forms.Padding(4);
            this.turnOnGyro.Name = "turnOnGyro";
            this.turnOnGyro.Size = new System.Drawing.Size(270, 42);
            this.turnOnGyro.TabIndex = 4;
            this.turnOnGyro.Text = "TURN ON";
            this.turnOnGyro.UseVisualStyleBackColor = true;
            this.turnOnGyro.Click += new System.EventHandler(this.turnOnGyro_Click);
            // 
            // ucBTNS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.turnOnGyro);
            this.Controls.Add(this.getGyroDataBtn);
            this.Controls.Add(this.turnOffGyro);
            this.Controls.Add(this.zeroHotkey);
            this.Controls.Add(this.recalibrateGyro);
            this.Controls.Add(this.recenterGyro);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ucBTNS";
            this.Size = new System.Drawing.Size(570, 210);
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox zeroHotkey;
        private Button recalibrateGyro;
        private Button recenterGyro;
        private Button turnOffGyro;
        private Button getGyroDataBtn;
        private Button turnOnGyro;
    }
}
