﻿namespace HeadTrackerV2
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
            this.getGyroDataBtn = new System.Windows.Forms.Button();
            this.recenterGyro = new System.Windows.Forms.Button();
            this.recalibrateGyro = new System.Windows.Forms.Button();
            this.smoothness = new System.Windows.Forms.CheckBox();
            this.zeroHotkey = new System.Windows.Forms.ComboBox();
            this.scanPorts = new System.Windows.Forms.Button();
            this.disconnectSerial = new System.Windows.Forms.Button();
            this.pitchSens = new System.Windows.Forms.TextBox();
            this.yawSens = new System.Windows.Forms.TextBox();
            this.rollSens = new System.Windows.Forms.TextBox();
            this.commonSens = new System.Windows.Forms.TextBox();
            this.pitchExp = new System.Windows.Forms.TextBox();
            this.yawOffset = new System.Windows.Forms.TextBox();
            this.rollOffset = new System.Windows.Forms.TextBox();
            this.pitchLimit = new System.Windows.Forms.TextBox();
            this.yawLimit = new System.Windows.Forms.TextBox();
            this.rollLimit = new System.Windows.Forms.TextBox();
            this.yawExp = new System.Windows.Forms.TextBox();
            this.rollExp = new System.Windows.Forms.TextBox();
            this.pitchOffset = new System.Windows.Forms.TextBox();
            this.commonExp = new System.Windows.Forms.TextBox();
            this.useExp = new System.Windows.Forms.CheckBox();
            this.updateSens = new System.Windows.Forms.Button();
            this.updateExp = new System.Windows.Forms.Button();
            this.updateOffset = new System.Windows.Forms.Button();
            this.updateLimits = new System.Windows.Forms.Button();
            this.enableGyro = new System.Windows.Forms.CheckBox();
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
            this.label1.Location = new System.Drawing.Point(597, 13);
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
            this.label2.Location = new System.Drawing.Point(723, 13);
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
            this.label3.Location = new System.Drawing.Point(847, 13);
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
            this.individualSens.Location = new System.Drawing.Point(425, 53);
            this.individualSens.Margin = new System.Windows.Forms.Padding(4);
            this.individualSens.Name = "individualSens";
            this.individualSens.Size = new System.Drawing.Size(160, 31);
            this.individualSens.TabIndex = 19;
            this.individualSens.Text = "INDIVIDUAL";
            this.individualSens.UseVisualStyleBackColor = true;
            // 
            // individualExp
            // 
            this.individualExp.AutoSize = true;
            this.individualExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.individualExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.individualExp.Location = new System.Drawing.Point(425, 114);
            this.individualExp.Margin = new System.Windows.Forms.Padding(4);
            this.individualExp.Name = "individualExp";
            this.individualExp.Size = new System.Drawing.Size(160, 31);
            this.individualExp.TabIndex = 20;
            this.individualExp.Text = "INDIVIDUAL";
            this.individualExp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(425, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 31);
            this.label4.TabIndex = 21;
            this.label4.Text = "OFFSETS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(425, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 31);
            this.label5.TabIndex = 22;
            this.label5.Text = "VIEW LIMITS";
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
            // getGyroDataBtn
            // 
            this.getGyroDataBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getGyroDataBtn.Location = new System.Drawing.Point(425, 299);
            this.getGyroDataBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getGyroDataBtn.Name = "getGyroDataBtn";
            this.getGyroDataBtn.Size = new System.Drawing.Size(165, 42);
            this.getGyroDataBtn.TabIndex = 24;
            this.getGyroDataBtn.Text = "GET GYRO DATA";
            this.getGyroDataBtn.UseVisualStyleBackColor = true;
            this.getGyroDataBtn.Click += new System.EventHandler(this.getGyroDataBtn_Click);
            // 
            // recenterGyro
            // 
            this.recenterGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recenterGyro.Location = new System.Drawing.Point(933, 299);
            this.recenterGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recenterGyro.Name = "recenterGyro";
            this.recenterGyro.Size = new System.Drawing.Size(165, 42);
            this.recenterGyro.TabIndex = 25;
            this.recenterGyro.Text = "RE-CENTER";
            this.recenterGyro.UseVisualStyleBackColor = true;
            this.recenterGyro.Click += new System.EventHandler(this.recenterGyro_Click);
            // 
            // recalibrateGyro
            // 
            this.recalibrateGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recalibrateGyro.Location = new System.Drawing.Point(694, 299);
            this.recalibrateGyro.Margin = new System.Windows.Forms.Padding(4);
            this.recalibrateGyro.Name = "recalibrateGyro";
            this.recalibrateGyro.Size = new System.Drawing.Size(165, 42);
            this.recalibrateGyro.TabIndex = 26;
            this.recalibrateGyro.Text = "RECALIBRATE";
            this.recalibrateGyro.UseVisualStyleBackColor = true;
            this.recalibrateGyro.Click += new System.EventHandler(this.recalibrateGyro_Click);
            // 
            // smoothness
            // 
            this.smoothness.AutoSize = true;
            this.smoothness.Cursor = System.Windows.Forms.Cursors.Hand;
            this.smoothness.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.smoothness.Location = new System.Drawing.Point(898, 364);
            this.smoothness.Margin = new System.Windows.Forms.Padding(4);
            this.smoothness.Name = "smoothness";
            this.smoothness.Size = new System.Drawing.Size(200, 31);
            this.smoothness.TabIndex = 27;
            this.smoothness.Text = "SMOOTHNESS";
            this.smoothness.UseVisualStyleBackColor = true;
            this.smoothness.CheckedChanged += new System.EventHandler(this.smoothness_CheckedChanged);
            // 
            // zeroHotkey
            // 
            this.zeroHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zeroHotkey.FormattingEnabled = true;
            this.zeroHotkey.Location = new System.Drawing.Point(933, 413);
            this.zeroHotkey.Name = "zeroHotkey";
            this.zeroHotkey.Size = new System.Drawing.Size(165, 25);
            this.zeroHotkey.TabIndex = 28;
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
            // pitchSens
            // 
            this.pitchSens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pitchSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitchSens.Location = new System.Drawing.Point(597, 48);
            this.pitchSens.MaxLength = 6;
            this.pitchSens.Name = "pitchSens";
            this.pitchSens.PlaceholderText = "Sens";
            this.pitchSens.Size = new System.Drawing.Size(105, 35);
            this.pitchSens.TabIndex = 47;
            this.pitchSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchSens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.pitchSens.Leave += new System.EventHandler(this.validateInput);
            // 
            // yawSens
            // 
            this.yawSens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.yawSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yawSens.Location = new System.Drawing.Point(723, 48);
            this.yawSens.MaxLength = 6;
            this.yawSens.Name = "yawSens";
            this.yawSens.PlaceholderText = "Sens";
            this.yawSens.Size = new System.Drawing.Size(105, 35);
            this.yawSens.TabIndex = 48;
            this.yawSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawSens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.yawSens.Leave += new System.EventHandler(this.validateInput);
            // 
            // rollSens
            // 
            this.rollSens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rollSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rollSens.Location = new System.Drawing.Point(847, 48);
            this.rollSens.MaxLength = 6;
            this.rollSens.Name = "rollSens";
            this.rollSens.PlaceholderText = "Sens";
            this.rollSens.Size = new System.Drawing.Size(105, 35);
            this.rollSens.TabIndex = 49;
            this.rollSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollSens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.rollSens.Leave += new System.EventHandler(this.validateInput);
            // 
            // commonSens
            // 
            this.commonSens.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commonSens.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commonSens.Location = new System.Drawing.Point(597, 49);
            this.commonSens.MaxLength = 6;
            this.commonSens.Name = "commonSens";
            this.commonSens.PlaceholderText = "Sens";
            this.commonSens.Size = new System.Drawing.Size(355, 35);
            this.commonSens.TabIndex = 50;
            this.commonSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.commonSens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.commonSens.Leave += new System.EventHandler(this.validateInput);
            // 
            // pitchExp
            // 
            this.pitchExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pitchExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitchExp.Location = new System.Drawing.Point(597, 109);
            this.pitchExp.MaxLength = 6;
            this.pitchExp.Name = "pitchExp";
            this.pitchExp.PlaceholderText = "Exp";
            this.pitchExp.Size = new System.Drawing.Size(105, 35);
            this.pitchExp.TabIndex = 51;
            this.pitchExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.pitchExp.Leave += new System.EventHandler(this.validateInput);
            // 
            // yawOffset
            // 
            this.yawOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.yawOffset.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yawOffset.Location = new System.Drawing.Point(723, 176);
            this.yawOffset.MaxLength = 6;
            this.yawOffset.Name = "yawOffset";
            this.yawOffset.PlaceholderText = "Offset";
            this.yawOffset.Size = new System.Drawing.Size(105, 35);
            this.yawOffset.TabIndex = 52;
            this.yawOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.yawOffset.Leave += new System.EventHandler(this.validateInput);
            // 
            // rollOffset
            // 
            this.rollOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rollOffset.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rollOffset.Location = new System.Drawing.Point(847, 176);
            this.rollOffset.MaxLength = 6;
            this.rollOffset.Name = "rollOffset";
            this.rollOffset.PlaceholderText = "Offset";
            this.rollOffset.Size = new System.Drawing.Size(105, 35);
            this.rollOffset.TabIndex = 53;
            this.rollOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.rollOffset.Leave += new System.EventHandler(this.validateInput);
            // 
            // pitchLimit
            // 
            this.pitchLimit.AcceptsReturn = true;
            this.pitchLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pitchLimit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitchLimit.Location = new System.Drawing.Point(597, 239);
            this.pitchLimit.MaxLength = 6;
            this.pitchLimit.Name = "pitchLimit";
            this.pitchLimit.PlaceholderText = "Limit";
            this.pitchLimit.Size = new System.Drawing.Size(105, 35);
            this.pitchLimit.TabIndex = 54;
            this.pitchLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.pitchLimit.Leave += new System.EventHandler(this.validateInput);
            // 
            // yawLimit
            // 
            this.yawLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.yawLimit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yawLimit.Location = new System.Drawing.Point(723, 239);
            this.yawLimit.MaxLength = 6;
            this.yawLimit.Name = "yawLimit";
            this.yawLimit.PlaceholderText = "Limit";
            this.yawLimit.Size = new System.Drawing.Size(105, 35);
            this.yawLimit.TabIndex = 55;
            this.yawLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.yawLimit.Leave += new System.EventHandler(this.validateInput);
            // 
            // rollLimit
            // 
            this.rollLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rollLimit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rollLimit.Location = new System.Drawing.Point(847, 239);
            this.rollLimit.MaxLength = 6;
            this.rollLimit.Name = "rollLimit";
            this.rollLimit.PlaceholderText = "Limit";
            this.rollLimit.Size = new System.Drawing.Size(105, 35);
            this.rollLimit.TabIndex = 56;
            this.rollLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.rollLimit.Leave += new System.EventHandler(this.validateInput);
            // 
            // yawExp
            // 
            this.yawExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.yawExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yawExp.Location = new System.Drawing.Point(723, 109);
            this.yawExp.MaxLength = 6;
            this.yawExp.Name = "yawExp";
            this.yawExp.PlaceholderText = "Exp";
            this.yawExp.Size = new System.Drawing.Size(105, 35);
            this.yawExp.TabIndex = 57;
            this.yawExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yawExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.yawExp.Leave += new System.EventHandler(this.validateInput);
            // 
            // rollExp
            // 
            this.rollExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rollExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rollExp.Location = new System.Drawing.Point(847, 109);
            this.rollExp.MaxLength = 6;
            this.rollExp.Name = "rollExp";
            this.rollExp.PlaceholderText = "Exp";
            this.rollExp.Size = new System.Drawing.Size(105, 35);
            this.rollExp.TabIndex = 58;
            this.rollExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.rollExp.Leave += new System.EventHandler(this.validateInput);
            // 
            // pitchOffset
            // 
            this.pitchOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pitchOffset.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pitchOffset.Location = new System.Drawing.Point(597, 176);
            this.pitchOffset.MaxLength = 6;
            this.pitchOffset.Name = "pitchOffset";
            this.pitchOffset.PlaceholderText = "Offset";
            this.pitchOffset.Size = new System.Drawing.Size(105, 35);
            this.pitchOffset.TabIndex = 59;
            this.pitchOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pitchOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.pitchOffset.Leave += new System.EventHandler(this.validateInput);
            // 
            // commonExp
            // 
            this.commonExp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.commonExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commonExp.Location = new System.Drawing.Point(597, 109);
            this.commonExp.MaxLength = 6;
            this.commonExp.Name = "commonExp";
            this.commonExp.PlaceholderText = "Exp";
            this.commonExp.Size = new System.Drawing.Size(355, 35);
            this.commonExp.TabIndex = 60;
            this.commonExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.commonExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.commonExp.Leave += new System.EventHandler(this.validateInput);
            // 
            // useExp
            // 
            this.useExp.AutoSize = true;
            this.useExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.useExp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.useExp.Location = new System.Drawing.Point(630, 364);
            this.useExp.Margin = new System.Windows.Forms.Padding(4);
            this.useExp.Name = "useExp";
            this.useExp.Size = new System.Drawing.Size(251, 31);
            this.useExp.TabIndex = 61;
            this.useExp.Text = "USE EXPONENTIAL";
            this.useExp.UseVisualStyleBackColor = true;
            this.useExp.CheckedChanged += new System.EventHandler(this.useExp_CheckedChanged);
            // 
            // updateSens
            // 
            this.updateSens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateSens.Location = new System.Drawing.Point(977, 48);
            this.updateSens.Margin = new System.Windows.Forms.Padding(4);
            this.updateSens.Name = "updateSens";
            this.updateSens.Size = new System.Drawing.Size(121, 42);
            this.updateSens.TabIndex = 63;
            this.updateSens.Text = "UPDATE GYRO";
            this.updateSens.UseVisualStyleBackColor = true;
            this.updateSens.Click += new System.EventHandler(this.updateSens_Click);
            // 
            // updateExp
            // 
            this.updateExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateExp.Location = new System.Drawing.Point(977, 109);
            this.updateExp.Margin = new System.Windows.Forms.Padding(4);
            this.updateExp.Name = "updateExp";
            this.updateExp.Size = new System.Drawing.Size(121, 42);
            this.updateExp.TabIndex = 64;
            this.updateExp.Text = "UPDATE GYRO";
            this.updateExp.UseVisualStyleBackColor = true;
            this.updateExp.Click += new System.EventHandler(this.updateExp_Click);
            // 
            // updateOffset
            // 
            this.updateOffset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateOffset.Location = new System.Drawing.Point(977, 176);
            this.updateOffset.Margin = new System.Windows.Forms.Padding(4);
            this.updateOffset.Name = "updateOffset";
            this.updateOffset.Size = new System.Drawing.Size(121, 42);
            this.updateOffset.TabIndex = 65;
            this.updateOffset.Text = "UPDATE GYRO";
            this.updateOffset.UseVisualStyleBackColor = true;
            this.updateOffset.Click += new System.EventHandler(this.updateOffset_Click);
            // 
            // updateLimits
            // 
            this.updateLimits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateLimits.Location = new System.Drawing.Point(977, 239);
            this.updateLimits.Margin = new System.Windows.Forms.Padding(4);
            this.updateLimits.Name = "updateLimits";
            this.updateLimits.Size = new System.Drawing.Size(121, 42);
            this.updateLimits.TabIndex = 66;
            this.updateLimits.Text = "UPDATE GYRO";
            this.updateLimits.UseVisualStyleBackColor = true;
            this.updateLimits.Click += new System.EventHandler(this.updateLimits_Click);
            // 
            // enableGyro
            // 
            this.enableGyro.AutoSize = true;
            this.enableGyro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableGyro.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.enableGyro.Location = new System.Drawing.Point(425, 364);
            this.enableGyro.Margin = new System.Windows.Forms.Padding(4);
            this.enableGyro.Name = "enableGyro";
            this.enableGyro.Size = new System.Drawing.Size(202, 31);
            this.enableGyro.TabIndex = 67;
            this.enableGyro.Text = "ENABLE GYRO";
            this.enableGyro.UseVisualStyleBackColor = true;
            this.enableGyro.CheckedChanged += new System.EventHandler(this.enableGyro_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1104, 461);
            this.Controls.Add(this.enableGyro);
            this.Controls.Add(this.updateLimits);
            this.Controls.Add(this.updateOffset);
            this.Controls.Add(this.updateExp);
            this.Controls.Add(this.updateSens);
            this.Controls.Add(this.useExp);
            this.Controls.Add(this.commonExp);
            this.Controls.Add(this.pitchOffset);
            this.Controls.Add(this.rollExp);
            this.Controls.Add(this.yawExp);
            this.Controls.Add(this.rollLimit);
            this.Controls.Add(this.yawLimit);
            this.Controls.Add(this.pitchLimit);
            this.Controls.Add(this.rollOffset);
            this.Controls.Add(this.yawOffset);
            this.Controls.Add(this.pitchExp);
            this.Controls.Add(this.commonSens);
            this.Controls.Add(this.rollSens);
            this.Controls.Add(this.yawSens);
            this.Controls.Add(this.pitchSens);
            this.Controls.Add(this.disconnectSerial);
            this.Controls.Add(this.scanPorts);
            this.Controls.Add(this.zeroHotkey);
            this.Controls.Add(this.smoothness);
            this.Controls.Add(this.recalibrateGyro);
            this.Controls.Add(this.recenterGyro);
            this.Controls.Add(this.getGyroDataBtn);
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
            this.Click += new System.EventHandler(this.Form1_Click);
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
        private Button getGyroDataBtn;
        private Button recenterGyro;
        private Button recalibrateGyro;
        private CheckBox smoothness;
        private ComboBox zeroHotkey;
        private Button scanPorts;
        private Button disconnectSerial;
        private TextBox pitchSens;
        private TextBox yawSens;
        private TextBox rollSens;
        private TextBox commonSens;
        private TextBox pitchExp;
        private TextBox yawOffset;
        private TextBox rollOffset;
        private TextBox pitchLimit;
        private TextBox yawLimit;
        private TextBox rollLimit;
        private TextBox yawExp;
        private TextBox rollExp;
        private TextBox pitchOffset;
        private TextBox commonExp;
        private CheckBox useExp;
        private Button updateSens;
        private Button updateExp;
        private Button updateOffset;
        private Button updateLimits;
        private CheckBox enableGyro;
    }
}