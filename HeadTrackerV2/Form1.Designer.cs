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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSC = new System.Windows.Forms.SplitContainer();
            this.uccom1 = new HeadTrackerV2.Usercontrolls.ucCOM();
            this.rightSC = new System.Windows.Forms.SplitContainer();
            this.ucpyr1 = new HeadTrackerV2.Usercontrolls.ucPYR();
            this.ucbtns1 = new HeadTrackerV2.Usercontrolls.ucBTNS();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSC)).BeginInit();
            this.mainSC.Panel1.SuspendLayout();
            this.mainSC.Panel2.SuspendLayout();
            this.mainSC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSC)).BeginInit();
            this.rightSC.Panel1.SuspendLayout();
            this.rightSC.Panel2.SuspendLayout();
            this.rightSC.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1000, 25);
            this.toolStrip1.TabIndex = 68;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.newProfileToolStripMenuItem,
            this.updateProfileToolStripMenuItem,
            this.removeProfileToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem1});
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.defaultToolStripMenuItem.Text = "Select ActiveProfile";
            // 
            // defaultToolStripMenuItem1
            // 
            this.defaultToolStripMenuItem1.Name = "defaultToolStripMenuItem1";
            this.defaultToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.defaultToolStripMenuItem1.Text = "Default";
            // 
            // newProfileToolStripMenuItem
            // 
            this.newProfileToolStripMenuItem.Name = "newProfileToolStripMenuItem";
            this.newProfileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newProfileToolStripMenuItem.Text = "New ActiveProfile";
            // 
            // updateProfileToolStripMenuItem
            // 
            this.updateProfileToolStripMenuItem.Name = "updateProfileToolStripMenuItem";
            this.updateProfileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.updateProfileToolStripMenuItem.Text = "Update ActiveProfile";
            // 
            // removeProfileToolStripMenuItem
            // 
            this.removeProfileToolStripMenuItem.Name = "removeProfileToolStripMenuItem";
            this.removeProfileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeProfileToolStripMenuItem.Text = "Remove ActiveProfile";
            // 
            // mainSC
            // 
            this.mainSC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSC.IsSplitterFixed = true;
            this.mainSC.Location = new System.Drawing.Point(0, 25);
            this.mainSC.Name = "mainSC";
            // 
            // mainSC.Panel1
            // 
            this.mainSC.Panel1.Controls.Add(this.uccom1);
            // 
            // mainSC.Panel2
            // 
            this.mainSC.Panel2.Controls.Add(this.rightSC);
            this.mainSC.Size = new System.Drawing.Size(1000, 500);
            this.mainSC.SplitterDistance = 404;
            this.mainSC.SplitterWidth = 1;
            this.mainSC.TabIndex = 70;
            // 
            // uccom1
            // 
            this.uccom1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uccom1.Location = new System.Drawing.Point(2, 3);
            this.uccom1.Name = "uccom1";
            this.uccom1.Size = new System.Drawing.Size(400, 500);
            this.uccom1.TabIndex = 71;
            // 
            // rightSC
            // 
            this.rightSC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightSC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSC.IsSplitterFixed = true;
            this.rightSC.Location = new System.Drawing.Point(0, 0);
            this.rightSC.Name = "rightSC";
            this.rightSC.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightSC.Panel1
            // 
            this.rightSC.Panel1.Controls.Add(this.ucpyr1);
            // 
            // rightSC.Panel2
            // 
            this.rightSC.Panel2.Controls.Add(this.ucbtns1);
            this.rightSC.Size = new System.Drawing.Size(595, 500);
            this.rightSC.SplitterDistance = 280;
            this.rightSC.SplitterWidth = 1;
            this.rightSC.TabIndex = 0;
            // 
            // ucpyr1
            // 
            this.ucpyr1.Location = new System.Drawing.Point(3, 2);
            this.ucpyr1.Name = "ucpyr1";
            this.ucpyr1.Size = new System.Drawing.Size(570, 270);
            this.ucpyr1.TabIndex = 0;
            // 
            // ucbtns1
            // 
            this.ucbtns1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ucbtns1.Location = new System.Drawing.Point(3, 3);
            this.ucbtns1.Name = "ucbtns1";
            this.ucbtns1.Size = new System.Drawing.Size(570, 210);
            this.ucbtns1.TabIndex = 71;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1000, 526);
            this.Controls.Add(this.mainSC);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeadTrackerV2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mainSC.Panel1.ResumeLayout(false);
            this.mainSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSC)).EndInit();
            this.mainSC.ResumeLayout(false);
            this.rightSC.Panel1.ResumeLayout(false);
            this.rightSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSC)).EndInit();
            this.rightSC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem profilesToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem1;
        private ToolStripMenuItem newProfileToolStripMenuItem;
        private ToolStripMenuItem updateProfileToolStripMenuItem;
        private ToolStripMenuItem removeProfileToolStripMenuItem;
        private SplitContainer mainSC;
        private SplitContainer rightSC;
        private Usercontrolls.ucCOM uccom1;
        private Usercontrolls.ucBTNS ucbtns1;
        private Usercontrolls.ucPYR ucpyr1;
    }
}