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
            this.button1 = new System.Windows.Forms.Button();
            this.getGyroDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zeroHotkey
            // 
            this.zeroHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zeroHotkey.FormattingEnabled = true;
            this.zeroHotkey.Location = new System.Drawing.Point(199, 121);
            this.zeroHotkey.Name = "zeroHotkey";
            this.zeroHotkey.Size = new System.Drawing.Size(165, 25);
            this.zeroHotkey.TabIndex = 72;
            // 
            // recalibrateGyro
            // 
            this.recalibrateGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recalibrateGyro.Location = new System.Drawing.Point(4, 54);
            this.recalibrateGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recalibrateGyro.Name = "recalibrateGyro";
            this.recalibrateGyro.Size = new System.Drawing.Size(165, 42);
            this.recalibrateGyro.TabIndex = 70;
            this.recalibrateGyro.Text = "RECALIBRATE";
            this.recalibrateGyro.UseVisualStyleBackColor = true;
            // 
            // recenterGyro
            // 
            this.recenterGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recenterGyro.Location = new System.Drawing.Point(4, 4);
            this.recenterGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recenterGyro.Name = "recenterGyro";
            this.recenterGyro.Size = new System.Drawing.Size(165, 42);
            this.recenterGyro.TabIndex = 69;
            this.recenterGyro.Text = "RE-CENTER";
            this.recenterGyro.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(4, 104);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 42);
            this.button1.TabIndex = 75;
            this.button1.Text = "TURN OFF";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // getGyroDataBtn
            // 
            this.getGyroDataBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getGyroDataBtn.Location = new System.Drawing.Point(199, 4);
            this.getGyroDataBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getGyroDataBtn.Name = "getGyroDataBtn";
            this.getGyroDataBtn.Size = new System.Drawing.Size(165, 42);
            this.getGyroDataBtn.TabIndex = 76;
            this.getGyroDataBtn.Text = "GET GYRO DATA";
            this.getGyroDataBtn.UseVisualStyleBackColor = true;
            // 
            // ucBTNS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.getGyroDataBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zeroHotkey);
            this.Controls.Add(this.recalibrateGyro);
            this.Controls.Add(this.recenterGyro);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ucBTNS";
            this.Size = new System.Drawing.Size(371, 151);
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox zeroHotkey;
        private Button recalibrateGyro;
        private Button recenterGyro;
        private Button button1;
        private Button getGyroDataBtn;
    }
}
