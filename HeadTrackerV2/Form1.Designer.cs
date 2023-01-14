namespace HeadTrackerV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serialOutput = new System.Windows.Forms.RichTextBox();
            this.connectToSerial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.individualSens = new System.Windows.Forms.CheckBox();
            this.individualExp = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ports = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.recenterGyro = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.scanPorts = new System.Windows.Forms.Button();
            this.disconnectSerial = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox7 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox8 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox9 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox10 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox11 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox12 = new System.Windows.Forms.MaskedTextBox();
            this.commonExp = new System.Windows.Forms.MaskedTextBox();
            this.commonSens = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // serialOutput
            // 
            this.serialOutput.Location = new System.Drawing.Point(13, 13);
            this.serialOutput.Margin = new System.Windows.Forms.Padding(4);
            this.serialOutput.Name = "serialOutput";
            this.serialOutput.Size = new System.Drawing.Size(390, 218);
            this.serialOutput.TabIndex = 0;
            this.serialOutput.Text = "";
            this.serialOutput.TextChanged += new System.EventHandler(this.serialOutput_TextChanged);
            // 
            // connectToSerial
            // 
            this.connectToSerial.Location = new System.Drawing.Point(289, 239);
            this.connectToSerial.Margin = new System.Windows.Forms.Padding(4);
            this.connectToSerial.Name = "connectToSerial";
            this.connectToSerial.Size = new System.Drawing.Size(114, 35);
            this.connectToSerial.TabIndex = 2;
            this.connectToSerial.Text = "CONNECT";
            this.connectToSerial.UseVisualStyleBackColor = true;
            this.connectToSerial.Click += new System.EventHandler(this.connectToSerial_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(423, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "PITCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(549, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 31);
            this.label2.TabIndex = 17;
            this.label2.Text = "YAW";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(673, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "ROLL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // individualSens
            // 
            this.individualSens.AutoSize = true;
            this.individualSens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.individualSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.individualSens.Location = new System.Drawing.Point(796, 50);
            this.individualSens.Margin = new System.Windows.Forms.Padding(4);
            this.individualSens.Name = "individualSens";
            this.individualSens.Size = new System.Drawing.Size(160, 31);
            this.individualSens.TabIndex = 19;
            this.individualSens.Text = "INDIVIDUAL";
            this.individualSens.UseVisualStyleBackColor = true;
            this.individualSens.CheckedChanged += new System.EventHandler(this.individualSens_CheckedChanged);
            // 
            // individualExp
            // 
            this.individualExp.AutoSize = true;
            this.individualExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.individualExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.individualExp.Location = new System.Drawing.Point(796, 111);
            this.individualExp.Margin = new System.Windows.Forms.Padding(4);
            this.individualExp.Name = "individualExp";
            this.individualExp.Size = new System.Drawing.Size(195, 31);
            this.individualExp.TabIndex = 20;
            this.individualExp.Text = "EXPONENTIAL";
            this.individualExp.UseVisualStyleBackColor = true;
            this.individualExp.CheckedChanged += new System.EventHandler(this.individualExp_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(796, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 31);
            this.label4.TabIndex = 21;
            this.label4.Text = "OFFSETS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(796, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 31);
            this.label5.TabIndex = 22;
            this.label5.Text = "ANGLE LIMITS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ports
            // 
            this.ports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ports.FormattingEnabled = true;
            this.ports.Location = new System.Drawing.Point(13, 245);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(150, 25);
            this.ports.TabIndex = 23;
            this.ports.Text = "Choose COM Port";
            this.ports.SelectedValueChanged += new System.EventHandler(this.ports_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(806, 406);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 42);
            this.button2.TabIndex = 24;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // recenterGyro
            // 
            this.recenterGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recenterGyro.Location = new System.Drawing.Point(806, 308);
            this.recenterGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recenterGyro.Name = "recenterGyro";
            this.recenterGyro.Size = new System.Drawing.Size(165, 42);
            this.recenterGyro.TabIndex = 25;
            this.recenterGyro.Text = "RE-CENTER";
            this.recenterGyro.UseVisualStyleBackColor = true;
            this.recenterGyro.Click += new System.EventHandler(this.recenterGyro_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(580, 308);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 42);
            this.button4.TabIndex = 26;
            this.button4.Text = "RECALIBRATE";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox3.Location = new System.Drawing.Point(580, 364);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(200, 31);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "SMOOTHNESS";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(806, 364);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(165, 25);
            this.comboBox2.TabIndex = 28;
            // 
            // scanPorts
            // 
            this.scanPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanPorts.Location = new System.Drawing.Point(170, 239);
            this.scanPorts.Margin = new System.Windows.Forms.Padding(4);
            this.scanPorts.Name = "scanPorts";
            this.scanPorts.Size = new System.Drawing.Size(111, 35);
            this.scanPorts.TabIndex = 29;
            this.scanPorts.Text = "SCAN";
            this.scanPorts.UseVisualStyleBackColor = true;
            this.scanPorts.Click += new System.EventHandler(this.scanPorts_Click);
            // 
            // disconnectSerial
            // 
            this.disconnectSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disconnectSerial.Location = new System.Drawing.Point(289, 239);
            this.disconnectSerial.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectSerial.Name = "disconnectSerial";
            this.disconnectSerial.Size = new System.Drawing.Size(114, 35);
            this.disconnectSerial.TabIndex = 30;
            this.disconnectSerial.Text = "DISCONNECT";
            this.disconnectSerial.UseVisualStyleBackColor = true;
            this.disconnectSerial.Visible = false;
            this.disconnectSerial.Click += new System.EventHandler(this.disconnectSerial_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(580, 406);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 42);
            this.button1.TabIndex = 31;
            this.button1.Text = "TURN OFF";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox1.Location = new System.Drawing.Point(423, 48);
            this.maskedTextBox1.Mask = "0000.0";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = '0';
            this.maskedTextBox1.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox1.TabIndex = 33;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox2.Location = new System.Drawing.Point(549, 48);
            this.maskedTextBox2.Mask = "0000.0";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PromptChar = '0';
            this.maskedTextBox2.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox2.TabIndex = 34;
            this.maskedTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox3.Location = new System.Drawing.Point(673, 48);
            this.maskedTextBox3.Mask = "0000.0";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.PromptChar = '0';
            this.maskedTextBox3.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox3.TabIndex = 35;
            this.maskedTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox4.Location = new System.Drawing.Point(423, 109);
            this.maskedTextBox4.Mask = "0000.0";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.PromptChar = '0';
            this.maskedTextBox4.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox4.TabIndex = 36;
            this.maskedTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox5
            // 
            this.maskedTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox5.Location = new System.Drawing.Point(423, 176);
            this.maskedTextBox5.Mask = "0000.0";
            this.maskedTextBox5.Name = "maskedTextBox5";
            this.maskedTextBox5.PromptChar = '0';
            this.maskedTextBox5.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox5.TabIndex = 37;
            this.maskedTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox6
            // 
            this.maskedTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox6.Location = new System.Drawing.Point(423, 239);
            this.maskedTextBox6.Mask = "0000.0";
            this.maskedTextBox6.Name = "maskedTextBox6";
            this.maskedTextBox6.PromptChar = '0';
            this.maskedTextBox6.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox6.TabIndex = 38;
            this.maskedTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox7
            // 
            this.maskedTextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox7.Location = new System.Drawing.Point(549, 109);
            this.maskedTextBox7.Mask = "0000.0";
            this.maskedTextBox7.Name = "maskedTextBox7";
            this.maskedTextBox7.PromptChar = '0';
            this.maskedTextBox7.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox7.TabIndex = 39;
            this.maskedTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox8
            // 
            this.maskedTextBox8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox8.Location = new System.Drawing.Point(673, 109);
            this.maskedTextBox8.Mask = "0000.0";
            this.maskedTextBox8.Name = "maskedTextBox8";
            this.maskedTextBox8.PromptChar = '0';
            this.maskedTextBox8.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox8.TabIndex = 40;
            this.maskedTextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox9
            // 
            this.maskedTextBox9.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox9.Location = new System.Drawing.Point(549, 176);
            this.maskedTextBox9.Mask = "0000.0";
            this.maskedTextBox9.Name = "maskedTextBox9";
            this.maskedTextBox9.PromptChar = '0';
            this.maskedTextBox9.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox9.TabIndex = 41;
            this.maskedTextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox10
            // 
            this.maskedTextBox10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox10.Location = new System.Drawing.Point(673, 176);
            this.maskedTextBox10.Mask = "0000.0";
            this.maskedTextBox10.Name = "maskedTextBox10";
            this.maskedTextBox10.PromptChar = '0';
            this.maskedTextBox10.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox10.TabIndex = 42;
            this.maskedTextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox11
            // 
            this.maskedTextBox11.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox11.Location = new System.Drawing.Point(549, 239);
            this.maskedTextBox11.Mask = "0000.0";
            this.maskedTextBox11.Name = "maskedTextBox11";
            this.maskedTextBox11.PromptChar = '0';
            this.maskedTextBox11.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox11.TabIndex = 43;
            this.maskedTextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox12
            // 
            this.maskedTextBox12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox12.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maskedTextBox12.Location = new System.Drawing.Point(673, 239);
            this.maskedTextBox12.Mask = "0000.0";
            this.maskedTextBox12.Name = "maskedTextBox12";
            this.maskedTextBox12.PromptChar = '0';
            this.maskedTextBox12.Size = new System.Drawing.Size(105, 35);
            this.maskedTextBox12.TabIndex = 44;
            this.maskedTextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // commonExp
            // 
            this.commonExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commonExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commonExp.Location = new System.Drawing.Point(423, 135);
            this.commonExp.Mask = "0000.0";
            this.commonExp.Name = "commonExp";
            this.commonExp.PromptChar = '0';
            this.commonExp.Size = new System.Drawing.Size(357, 35);
            this.commonExp.TabIndex = 45;
            this.commonExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // commonSens
            // 
            this.commonSens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commonSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commonSens.Location = new System.Drawing.Point(423, 68);
            this.commonSens.Mask = "0000.0";
            this.commonSens.Name = "commonSens";
            this.commonSens.PromptChar = '0';
            this.commonSens.Size = new System.Drawing.Size(357, 35);
            this.commonSens.TabIndex = 46;
            this.commonSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.commonSens);
            this.Controls.Add(this.commonExp);
            this.Controls.Add(this.maskedTextBox12);
            this.Controls.Add(this.maskedTextBox11);
            this.Controls.Add(this.maskedTextBox10);
            this.Controls.Add(this.maskedTextBox9);
            this.Controls.Add(this.maskedTextBox8);
            this.Controls.Add(this.maskedTextBox7);
            this.Controls.Add(this.maskedTextBox6);
            this.Controls.Add(this.maskedTextBox5);
            this.Controls.Add(this.maskedTextBox4);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.disconnectSerial);
            this.Controls.Add(this.scanPorts);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.recenterGyro);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ports);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.individualExp);
            this.Controls.Add(this.individualSens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectToSerial);
            this.Controls.Add(this.serialOutput);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox serialOutput;
        private Button connectToSerial;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox individualSens;
        private CheckBox individualExp;
        private Label label4;
        private Label label5;
        private ComboBox ports;
        private Button button2;
        private Button recenterGyro;
        private Button button4;
        private CheckBox checkBox3;
        private ComboBox comboBox2;
        private Button scanPorts;
        private Button disconnectSerial;
        private Button button1;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox3;
        private MaskedTextBox maskedTextBox4;
        private MaskedTextBox maskedTextBox5;
        private MaskedTextBox maskedTextBox6;
        private MaskedTextBox maskedTextBox7;
        private MaskedTextBox maskedTextBox8;
        private MaskedTextBox maskedTextBox9;
        private MaskedTextBox maskedTextBox10;
        private MaskedTextBox maskedTextBox11;
        private MaskedTextBox maskedTextBox12;
        private MaskedTextBox commonExp;
        private MaskedTextBox commonSens;
    }
}