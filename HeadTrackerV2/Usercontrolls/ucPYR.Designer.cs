namespace HeadTrackerV2.Usercontrolls
{
    partial class ucPYR
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
            this.ifAng = new HeadTrackerV2.InputField();
            this.ifOff = new HeadTrackerV2.InputField();
            this.ifExp = new HeadTrackerV2.InputFieldWithToggle();
            this.ifSens = new HeadTrackerV2.InputFieldWithToggle();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pitch = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.useExp = new System.Windows.Forms.CheckBox();
            this.smoothness = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ifAng
            // 
            this.ifAng.Location = new System.Drawing.Point(182, 193);
            this.ifAng.Margin = new System.Windows.Forms.Padding(0);
            this.ifAng.Name = "ifAng";
            this.ifAng.Size = new System.Drawing.Size(385, 45);
            this.ifAng.TabIndex = 7;
            // 
            // ifOff
            // 
            this.ifOff.Location = new System.Drawing.Point(182, 138);
            this.ifOff.Margin = new System.Windows.Forms.Padding(0);
            this.ifOff.Name = "ifOff";
            this.ifOff.Size = new System.Drawing.Size(385, 45);
            this.ifOff.TabIndex = 6;
            // 
            // ifExp
            // 
            this.ifExp.Location = new System.Drawing.Point(182, 83);
            this.ifExp.Margin = new System.Windows.Forms.Padding(0);
            this.ifExp.Name = "ifExp";
            this.ifExp.Size = new System.Drawing.Size(385, 45);
            this.ifExp.TabIndex = 5;
            // 
            // ifSens
            // 
            this.ifSens.Location = new System.Drawing.Point(182, 28);
            this.ifSens.Margin = new System.Windows.Forms.Padding(0);
            this.ifSens.Name = "ifSens";
            this.ifSens.Size = new System.Drawing.Size(385, 45);
            this.ifSens.TabIndex = 4;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox2.Location = new System.Drawing.Point(465, 2);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(93, 31);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "ROLL";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(347, 2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 31);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "YAW";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pitch
            // 
            this.pitch.AutoSize = true;
            this.pitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pitch.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitch.Location = new System.Drawing.Point(213, 2);
            this.pitch.Margin = new System.Windows.Forms.Padding(4);
            this.pitch.Name = "pitch";
            this.pitch.Size = new System.Drawing.Size(101, 31);
            this.pitch.TabIndex = 1;
            this.pitch.Text = "PITCH";
            this.pitch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 31);
            this.label4.TabIndex = 46;
            this.label4.Text = "ANGLE LIMITS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 31);
            this.label3.TabIndex = 45;
            this.label3.Text = "OFFSETS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 31);
            this.label2.TabIndex = 44;
            this.label2.Text = "EXPONENTIAL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 31);
            this.label5.TabIndex = 43;
            this.label5.Text = "SENSITIVITY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useExp
            // 
            this.useExp.AutoSize = true;
            this.useExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.useExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.useExp.Location = new System.Drawing.Point(307, 242);
            this.useExp.Margin = new System.Windows.Forms.Padding(4);
            this.useExp.Name = "useExp";
            this.useExp.Size = new System.Drawing.Size(251, 31);
            this.useExp.TabIndex = 75;
            this.useExp.Text = "USE EXPONENTIAL";
            this.useExp.UseVisualStyleBackColor = true;
            this.useExp.Click += new System.EventHandler(this.useExp_Click);
            // 
            // smoothness
            // 
            this.smoothness.AutoSize = true;
            this.smoothness.Cursor = System.Windows.Forms.Cursors.Hand;
            this.smoothness.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.smoothness.Location = new System.Drawing.Point(99, 242);
            this.smoothness.Margin = new System.Windows.Forms.Padding(4);
            this.smoothness.Name = "smoothness";
            this.smoothness.Size = new System.Drawing.Size(200, 31);
            this.smoothness.TabIndex = 74;
            this.smoothness.Text = "SMOOTHNESS";
            this.smoothness.UseVisualStyleBackColor = true;
            this.smoothness.Click += new System.EventHandler(this.smoothness_Click);
            // 
            // ucPYR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.useExp);
            this.Controls.Add(this.smoothness);
            this.Controls.Add(this.ifAng);
            this.Controls.Add(this.ifOff);
            this.Controls.Add(this.ifExp);
            this.Controls.Add(this.ifSens);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pitch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Name = "ucPYR";
            this.Size = new System.Drawing.Size(570, 270);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private InputField inputField2;
        private InputField inputField1;
        private InputFieldWithToggle ifExp;
        private InputFieldWithToggle ifSens;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox pitch;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private InputField ifAng;
        private InputField ifOff;
        private CheckBox useExp;
        private CheckBox smoothness;
    }
}
