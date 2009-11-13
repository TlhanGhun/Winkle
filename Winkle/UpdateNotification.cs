using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winkle
{
    public partial class UpdateNotification : Form
    {
        private string updateDownloadLink = "";

        public UpdateNotification()
        {
            InitializeComponent();
        }

        public bool setVersion(string appName, string versionText)
        {
            this.NewVersionAvailable.Text = appName + " " + versionText + " available";
            return true;
        }

        public bool setShortDescription(string appName, string versionText, Version currentVersion)
        {
            this.labelShortDescription.Text = "A newer version of " + appName + " is available for download. The new version is " + versionText + " (you have currently installed " + currentVersion.ToString() + ")";
            return true;
        }

        public bool setDescription( string descriptionText)
        {
            this.description.Text = descriptionText;
            return true;
        }

        public bool setDownloadLink(string downloadLinkText)
        {
            this.updateDownloadLink = downloadLinkText;
            return true;
        }

        private void buttonGetUpdate_Click(object sender, EventArgs e)
        {
            if (this.updateDownloadLink.StartsWith("http://") || this.updateDownloadLink.StartsWith("https://"))
                {
                    System.Diagnostics.Process.Start(updateDownloadLink);
                }
        }

        private void buttonIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
