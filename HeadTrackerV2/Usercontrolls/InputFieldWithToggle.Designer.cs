namespace HeadTrackerV2
{
    partial class InputFieldWithToggle
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
            this.commonTextBox = new System.Windows.Forms.TextBox();
            this.rollTextBox = new System.Windows.Forms.TextBox();
            this.yawTextBox = new System.Windows.Forms.TextBox();
            this.pitchTextBox = new System.Windows.Forms.TextBox();
            this.toggleCommon = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // commonTextBox
            // 
            this.commonTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commonTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commonTextBox.Location = new System.Drawing.Point(24, 24);
            this.commonTextBox.MaxLength = 6;
            this.commonTextBox.Name = "commonTextBox";
            this.commonTextBox.PlaceholderText = "TMP";
            this.commonTextBox.Size = new System.Drawing.Size(355, 35);
            this.commonTextBox.TabIndex = 5;
            this.commonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.commonTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateInput);
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
            this.rollTextBox.TabIndex = 4;
            this.rollTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateInput);
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
            this.yawTextBox.TabIndex = 3;
            this.yawTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateInput);
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
            this.pitchTextBox.TabIndex = 2;
            this.pitchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateInput);
            // 
            // toggleCommon
            // 
            this.toggleCommon.AutoSize = true;
            this.toggleCommon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleCommon.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toggleCommon.Location = new System.Drawing.Point(2, 17);
            this.toggleCommon.Margin = new System.Windows.Forms.Padding(4);
            this.toggleCommon.Name = "toggleCommon";
            this.toggleCommon.Size = new System.Drawing.Size(15, 14);
            this.toggleCommon.TabIndex = 1;
            this.toggleCommon.UseVisualStyleBackColor = true;
            this.toggleCommon.CheckedChanged += new System.EventHandler(this.toggleCommon_CheckedChanged);
            // 
            // InputFieldWithToggle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.commonTextBox);
            this.Controls.Add(this.rollTextBox);
            this.Controls.Add(this.yawTextBox);
            this.Controls.Add(this.pitchTextBox);
            this.Controls.Add(this.toggleCommon);
            this.Name = "InputFieldWithToggle";
            this.Controls.SetChildIndex(this.toggleCommon, 0);
            this.Controls.SetChildIndex(this.pitchTextBox, 0);
            this.Controls.SetChildIndex(this.yawTextBox, 0);
            this.Controls.SetChildIndex(this.rollTextBox, 0);
            this.Controls.SetChildIndex(this.commonTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox commonTextBox;
        private TextBox rollTextBox;
        private TextBox yawTextBox;
        private TextBox pitchTextBox;
        private CheckBox toggleCommon;
    }
}
