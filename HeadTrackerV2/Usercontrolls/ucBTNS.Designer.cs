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
            this.useExp = new System.Windows.Forms.CheckBox();
            this.zeroHotkey = new System.Windows.Forms.ComboBox();
            this.smoothness = new System.Windows.Forms.CheckBox();
            this.recalibrateGyro = new System.Windows.Forms.Button();
            this.recenterGyro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // useExp
            // 
            this.useExp.AutoSize = true;
            this.useExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.useExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.useExp.Location = new System.Drawing.Point(199, 65);
            this.useExp.Margin = new System.Windows.Forms.Padding(4);
            this.useExp.Name = "useExp";
            this.useExp.Size = new System.Drawing.Size(251, 31);
            this.useExp.TabIndex = 73;
            this.useExp.Text = "USE EXPONENTIAL";
            this.useExp.UseVisualStyleBackColor = true;
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
            // smoothness
            // 
            this.smoothness.AutoSize = true;
            this.smoothness.Cursor = System.Windows.Forms.Cursors.Hand;
            this.smoothness.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.smoothness.Location = new System.Drawing.Point(199, 15);
            this.smoothness.Margin = new System.Windows.Forms.Padding(4);
            this.smoothness.Name = "smoothness";
            this.smoothness.Size = new System.Drawing.Size(200, 31);
            this.smoothness.TabIndex = 71;
            this.smoothness.Text = "SMOOTHNESS";
            this.smoothness.UseVisualStyleBackColor = true;
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
            // ucBTNS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.useExp);
            this.Controls.Add(this.zeroHotkey);
            this.Controls.Add(this.smoothness);
            this.Controls.Add(this.recalibrateGyro);
            this.Controls.Add(this.recenterGyro);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ucBTNS";
            this.Size = new System.Drawing.Size(479, 151);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CheckBox useExp;
        private ComboBox zeroHotkey;
        private CheckBox smoothness;
        private Button recalibrateGyro;
        private Button recenterGyro;
        private Button button1;
    }
}
