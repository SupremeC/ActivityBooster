

using System;
using System.Windows.Forms;
using SyntheticProdBooster.MailerNS;
using SyntheticProductivityBooster.MouseJiggler.Properties;

namespace SyntheticProdBooster.MouseJiggler
{
    public partial class MainForm : Form
    {
        private Mailer mailer;
        private int emailsPerDay;
        private bool firstShown = true;
        private int jigglePeriod;
        private bool minimizeOnStartup;
        private bool zenJiggleEnabled;
        protected bool Zig = true;

        public int EmailsPerDay
        {
            get => this.emailsPerDay;
            set
            {
                this.emailsPerDay = value;
                Settings.Default.EmailsPerDay = value;
                Settings.Default.Save();

                this.lbEmailsPerDay.Text = $"{value} / day";
            }
        }
        public bool JiggleOnStartup { get; }
        public int JigglePeriod
        {
            get => this.jigglePeriod;
            set
            {
                this.jigglePeriod = value;
                Settings.Default.JigglePeriod = value;
                Settings.Default.Save();

                this.jiggleTimer.Interval = value * 1000;
                this.lbPeriod.Text = $"{value} s";
            }
        }
        public bool MinimizeOnStartup
        {
            get => this.minimizeOnStartup;
            set
            {
                this.minimizeOnStartup = value;
                Settings.Default.MinimizeOnStartup = value;
                Settings.Default.Save();
            }
        }
        public bool ZenJiggleEnabled
        {
            get => this.zenJiggleEnabled;
            set
            {
                this.zenJiggleEnabled = value;
                Settings.Default.ZenJiggle = value;
                Settings.Default.Save();
            }
        }


        public MainForm () : this (jiggleOnStartup: false, minimizeOnStartup: false, zenJiggleEnabled: false, jigglePeriod: 1)
        { }

        public MainForm (bool jiggleOnStartup, bool minimizeOnStartup, bool zenJiggleEnabled, int jigglePeriod)
        {
            this.InitializeComponent ();

            // Jiggling on startup?
            this.JiggleOnStartup = jiggleOnStartup;

            // Set settings properties
            // We do this by setting the controls, and letting them set the properties.
            this.cbMinimize.Checked = minimizeOnStartup;
            this.cbZen.Checked      = zenJiggleEnabled;
            this.tbPeriod.Value     = jigglePeriod;

            // Init mailer
            mailer = new Mailer();
        }


        private void MainForm_Load (object sender, EventArgs e)
        {
            if (this.JiggleOnStartup)
                this.cbJiggling.Checked = true;
        }

        private void UpdateNotificationAreaText ()
        {
            if (!this.cbJiggling.Checked)
            {
                this.niTray.Text = "Not jiggling the mouse.";
            }
            else
            {
                string? ww = this.ZenJiggleEnabled ? "with" : "without";
                this.niTray.Text = $"Jiggling mouse every {this.JigglePeriod} s, {ww} Zen.";
            }
        }

        private void CmdAbout_Click (object sender, EventArgs e)
        {
            new AboutBox ().ShowDialog (owner: this);
        }


        private void CbSettings_CheckedChanged (object sender, EventArgs e)
        {
            this.panelSettings.Visible = this.cbSettings.Checked;
            this.panelEmailer.Visible = this.cbSettings.Checked;
        }

        private void CbMinimize_CheckedChanged (object sender, EventArgs e)
        {
            this.MinimizeOnStartup = this.cbMinimize.Checked;
        }

        private void CbZen_CheckedChanged (object sender, EventArgs e)
        {
            this.ZenJiggleEnabled = this.cbZen.Checked;
        }

        private void TbPeriod_ValueChanged (object sender, EventArgs e)
        {
            this.JigglePeriod = this.tbPeriod.Value;
        }

        private void CbJiggling_CheckedChanged (object sender, EventArgs e)
        {
            this.jiggleTimer.Enabled = this.cbJiggling.Checked;
        }

        private void JiggleTimer_Tick (object sender, EventArgs e)
        {
            if (this.ZenJiggleEnabled)
                Helpers.Jiggle (delta: 0);
            else if (this.Zig)
                Helpers.Jiggle (delta: 4);
            else //zag
                Helpers.Jiggle (delta: -4);

            this.Zig = !this.Zig;
        }

        private void CmdTrayify_Click (object sender, EventArgs e)
        {
            this.MinimizeToTray ();
        }

        private void NiTray_DoubleClick (object sender, EventArgs e)
        {
            this.RestoreFromTray ();
        }

        private void MinimizeToTray ()
        {
            this.Visible        = false;
            this.ShowInTaskbar  = false;
            this.niTray.Visible = true;

            this.UpdateNotificationAreaText ();
        }

        private void RestoreFromTray ()
        {
            this.Visible        = true;
            this.ShowInTaskbar  = true;
            this.niTray.Visible = false;
        }

        private void MainForm_Shown (object sender, EventArgs e)
        {
            if (this.firstShown && this.MinimizeOnStartup)
                this.MinimizeToTray ();

            this.firstShown = false;
        }

        private void TrackBarEmails_ValueChanged(object sender, EventArgs e)
        {
            EmailsPerDay = trackBarEmails.Value;
        }

        private void CbSendEmails_CheckedChanged(object sender, EventArgs e)
        {
            if (CbSendEmails.Checked)
                mailer.StartMailing(Settings.Default.EmailsPerDay, Settings.Default.EmailStartAtHour, Settings.Default.EmailEndAtHour);
            else
                mailer.StopMailing();
        }
    }
}
