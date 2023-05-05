namespace HeadTrackerV2
{
    partial class InputField
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
            this.rollTextBox = new System.Windows.Forms.TextBox();
            this.yawTextBox = new System.Windows.Forms.TextBox();
            this.pitchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rollTextBox
            // 
            this.rollTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rollTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rollTextBox.Location = new System.Drawing.Point(274, 7);
            this.rollTextBox.MaxLength = 6;
            this.rollTextBox.Name = "rollTextBox";
            this.rollTextBox.PlaceholderText = "TMP";
            this.rollTextBox.Size = new System.Drawing.Size(105, 35);
            this.rollTextBox.TabIndex = 3;
            this.rollTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollTextBox.Leave += new System.EventHandler(this.validateInput);
            // 
            // yawTextBox
            // 
            this.yawTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.yawTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yawTextBox.Location = new System.Drawing.Point(150, 7);
            this.yawTextBox.MaxLength = 6;
            this.yawTextBox.Name = "yawTextBox";
            this.yawTextBox.PlaceholderText = "TMP";
            this.yawTextBox.Size = new System.Drawing.Size(105, 35);
            this.yawTextBox.TabIndex = 2;
            this.yawTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawTextBox.Leave += new System.EventHandler(this.validateInput);
            // 
            // pitchTextBox
            // 
            this.pitchTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pitchTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitchTextBox.Location = new System.Drawing.Point(24, 7);
            this.pitchTextBox.MaxLength = 6;
            this.pitchTextBox.Name = "pitchTextBox";
            this.pitchTextBox.PlaceholderText = "TMP";
            this.pitchTextBox.Size = new System.Drawing.Size(105, 35);
            this.pitchTextBox.TabIndex = 1;
            this.pitchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchTextBox.Leave += new System.EventHandler(this.validateInput);
            // 
            // InputField
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.rollTextBox);
            this.Controls.Add(this.yawTextBox);
            this.Controls.Add(this.pitchTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InputField";
            this.Size = new System.Drawing.Size(385, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox rollTextBox;
        private TextBox yawTextBox;
        private TextBox pitchTextBox;
    }
}
