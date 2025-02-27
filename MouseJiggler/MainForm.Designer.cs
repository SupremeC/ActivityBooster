﻿
namespace SyntheticProdBooster.MouseJiggler
{
    partial class MainForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jiggleTimer = new System.Windows.Forms.Timer(this.components);
            this.flpLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBase = new System.Windows.Forms.Panel();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdTrayify = new System.Windows.Forms.Button();
            this.cbSettings = new System.Windows.Forms.CheckBox();
            this.cbJiggling = new System.Windows.Forms.CheckBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.lbPeriod = new System.Windows.Forms.Label();
            this.tbPeriod = new System.Windows.Forms.TrackBar();
            this.cbMinimize = new System.Windows.Forms.CheckBox();
            this.cbZen = new System.Windows.Forms.CheckBox();
            this.panelEmailer = new System.Windows.Forms.Panel();
            this.CbSendEmails = new System.Windows.Forms.CheckBox();
            this.lbEmailsPerDay = new System.Windows.Forms.Label();
            this.trackBarEmails = new System.Windows.Forms.TrackBar();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.flpLayout.SuspendLayout();
            this.panelBase.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPeriod)).BeginInit();
            this.panelEmailer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 1000;
            this.jiggleTimer.Tick += new System.EventHandler(this.JiggleTimer_Tick);
            // 
            // flpLayout
            // 
            this.flpLayout.AutoSize = true;
            this.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpLayout.Controls.Add(this.panelBase);
            this.flpLayout.Controls.Add(this.panelSettings);
            this.flpLayout.Controls.Add(this.panelEmailer);
            this.flpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLayout.Location = new System.Drawing.Point(0, 0);
            this.flpLayout.Name = "flpLayout";
            this.flpLayout.Padding = new System.Windows.Forms.Padding(5);
            this.flpLayout.Size = new System.Drawing.Size(340, 340);
            this.flpLayout.TabIndex = 2;
            // 
            // panelBase
            // 
            this.panelBase.Controls.Add(this.cmdAbout);
            this.panelBase.Controls.Add(this.cmdTrayify);
            this.panelBase.Controls.Add(this.cbSettings);
            this.panelBase.Controls.Add(this.cbJiggling);
            this.panelBase.Location = new System.Drawing.Point(8, 8);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(289, 28);
            this.panelBase.TabIndex = 3;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(198, 2);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(40, 23);
            this.cmdAbout.TabIndex = 2;
            this.cmdAbout.Text = "?";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.CmdAbout_Click);
            // 
            // cmdTrayify
            // 
            this.cmdTrayify.Location = new System.Drawing.Point(244, 2);
            this.cmdTrayify.Name = "cmdTrayify";
            this.cmdTrayify.Size = new System.Drawing.Size(40, 23);
            this.cmdTrayify.TabIndex = 3;
            this.cmdTrayify.Text = "🔽";
            this.cmdTrayify.UseVisualStyleBackColor = true;
            this.cmdTrayify.Click += new System.EventHandler(this.CmdTrayify_Click);
            // 
            // cbSettings
            // 
            this.cbSettings.Location = new System.Drawing.Point(88, 5);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(77, 19);
            this.cbSettings.TabIndex = 1;
            this.cbSettings.Text = "Settings...";
            this.cbSettings.UseVisualStyleBackColor = true;
            this.cbSettings.CheckedChanged += new System.EventHandler(this.CbSettings_CheckedChanged);
            // 
            // cbJiggling
            // 
            this.cbJiggling.AutoSize = true;
            this.cbJiggling.Location = new System.Drawing.Point(10, 5);
            this.cbJiggling.Name = "cbJiggling";
            this.cbJiggling.Size = new System.Drawing.Size(72, 19);
            this.cbJiggling.TabIndex = 0;
            this.cbJiggling.Text = "Jiggling?";
            this.cbJiggling.UseVisualStyleBackColor = true;
            this.cbJiggling.CheckedChanged += new System.EventHandler(this.CbJiggling_CheckedChanged);
            // 
            // panelSettings
            // 
            this.panelSettings.AutoSize = true;
            this.panelSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettings.Controls.Add(this.lbPeriod);
            this.panelSettings.Controls.Add(this.tbPeriod);
            this.panelSettings.Controls.Add(this.cbMinimize);
            this.panelSettings.Controls.Add(this.cbZen);
            this.panelSettings.Location = new System.Drawing.Point(8, 42);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(289, 110);
            this.panelSettings.TabIndex = 2;
            this.panelSettings.Visible = false;
            // 
            // lbPeriod
            // 
            this.lbPeriod.AutoSize = true;
            this.lbPeriod.Location = new System.Drawing.Point(244, 41);
            this.lbPeriod.Name = "lbPeriod";
            this.lbPeriod.Size = new System.Drawing.Size(21, 15);
            this.lbPeriod.TabIndex = 3;
            this.lbPeriod.Text = "1 s";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPeriod.Location = new System.Drawing.Point(4, 62);
            this.tbPeriod.Maximum = 60;
            this.tbPeriod.Minimum = 1;
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.Size = new System.Drawing.Size(281, 45);
            this.tbPeriod.TabIndex = 6;
            this.tbPeriod.TickFrequency = 2;
            this.tbPeriod.Value = 1;
            this.tbPeriod.ValueChanged += new System.EventHandler(this.TbPeriod_ValueChanged);
            // 
            // cbMinimize
            // 
            this.cbMinimize.AutoSize = true;
            this.cbMinimize.Location = new System.Drawing.Point(10, 37);
            this.cbMinimize.Name = "cbMinimize";
            this.cbMinimize.Size = new System.Drawing.Size(123, 19);
            this.cbMinimize.TabIndex = 5;
            this.cbMinimize.Text = "Minimize on start?";
            this.cbMinimize.UseVisualStyleBackColor = true;
            this.cbMinimize.CheckedChanged += new System.EventHandler(this.CbMinimize_CheckedChanged);
            // 
            // cbZen
            // 
            this.cbZen.AutoSize = true;
            this.cbZen.Location = new System.Drawing.Point(10, 11);
            this.cbZen.Name = "cbZen";
            this.cbZen.Size = new System.Drawing.Size(83, 19);
            this.cbZen.TabIndex = 4;
            this.cbZen.Text = "Zen jiggle?";
            this.cbZen.UseVisualStyleBackColor = true;
            this.cbZen.CheckedChanged += new System.EventHandler(this.CbZen_CheckedChanged);
            // 
            // panelEmailer
            // 
            this.panelEmailer.AutoSize = true;
            this.panelEmailer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelEmailer.Controls.Add(this.CbSendEmails);
            this.panelEmailer.Controls.Add(this.lbEmailsPerDay);
            this.panelEmailer.Controls.Add(this.trackBarEmails);
            this.panelEmailer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEmailer.Location = new System.Drawing.Point(8, 158);
            this.panelEmailer.Name = "panelEmailer";
            this.panelEmailer.Size = new System.Drawing.Size(290, 110);
            this.panelEmailer.TabIndex = 4;
            this.panelEmailer.Visible = false;
            // 
            // CbSendEmails
            // 
            this.CbSendEmails.AutoSize = true;
            this.CbSendEmails.Location = new System.Drawing.Point(10, 11);
            this.CbSendEmails.Name = "CbSendEmails";
            this.CbSendEmails.Size = new System.Drawing.Size(89, 19);
            this.CbSendEmails.TabIndex = 7;
            this.CbSendEmails.Text = "Send emails";
            this.CbSendEmails.UseVisualStyleBackColor = true;
            this.CbSendEmails.CheckedChanged += new System.EventHandler(this.CbSendEmails_CheckedChanged);
            // 
            // lbEmailsPerDay
            // 
            this.lbEmailsPerDay.AutoSize = true;
            this.lbEmailsPerDay.Location = new System.Drawing.Point(238, 41);
            this.lbEmailsPerDay.Name = "lbEmailsPerDay";
            this.lbEmailsPerDay.Size = new System.Drawing.Size(43, 15);
            this.lbEmailsPerDay.TabIndex = 3;
            this.lbEmailsPerDay.Text = "1 / day";
            // 
            // trackBarEmails
            // 
            this.trackBarEmails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarEmails.Location = new System.Drawing.Point(4, 62);
            this.trackBarEmails.Maximum = 40;
            this.trackBarEmails.Minimum = 1;
            this.trackBarEmails.Name = "trackBarEmails";
            this.trackBarEmails.Size = new System.Drawing.Size(283, 45);
            this.trackBarEmails.TabIndex = 6;
            this.trackBarEmails.TickFrequency = 2;
            this.trackBarEmails.Value = 1;
            this.trackBarEmails.ValueChanged += new System.EventHandler(this.TrackBarEmails_ValueChanged);
            // 
            // niTray
            // 
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "Mouse Jiggler";
            this.niTray.DoubleClick += new System.EventHandler(this.NiTray_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(340, 340);
            this.Controls.Add(this.flpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Synthetic Productivity Booster";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.flpLayout.ResumeLayout(false);
            this.flpLayout.PerformLayout();
            this.panelBase.ResumeLayout(false);
            this.panelBase.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPeriod)).EndInit();
            this.panelEmailer.ResumeLayout(false);
            this.panelEmailer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEmails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.FlowLayoutPanel flpLayout;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.TrackBar tbPeriod;
        private System.Windows.Forms.CheckBox cbMinimize;
        private System.Windows.Forms.CheckBox cbZen;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.CheckBox cbSettings;
        private System.Windows.Forms.CheckBox cbJiggling;
        private System.Windows.Forms.Label lbPeriod;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.Button cmdTrayify;
        private System.Windows.Forms.Panel panelEmailer;
        private System.Windows.Forms.Label lbEmailsPerDay;
        private System.Windows.Forms.TrackBar trackBarEmails;
        private System.Windows.Forms.CheckBox CbSendEmails;
    }
}

