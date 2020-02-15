using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Screenshot
{
    public struct FTPSettings
    {
        public string FTPServer;
        public int FTPPort;
        public string FTPUser;
        public string FTPPwd;
        public bool AnonymousLogin;
        public bool UseProxy;
        public string PrxyServer;
        public string PrxyUser;
        public string PrxyPwd;
        public int PrxyPort;
        public string DefaultImagesLocation;

        public void InitWithDefaults()
        {
            this.FTPPort = 21;
            this.AnonymousLogin = false;
            this.UseProxy = false;
        }
    }
    
    public partial class SettingsForm : Form
    {
        public FTPSettings ftpSettings;
        private FtpSettingsControl ftpControl;
        private OtherSettings otherSettings;
        public Color GridColor { get; set; }
        public int NoOfHistoryImages { get; set; }
        
        public SettingsForm(FTPSettings settings, Color gridColor, int noOfHistoryImages)
        {
            InitializeComponent();
            this.ftpSettings = settings;
            this.NoOfHistoryImages = noOfHistoryImages;
            ftpControl = new FtpSettingsControl(settings);
            otherSettings = new OtherSettings(gridColor, NoOfHistoryImages);
            ftpControl.Parent = this.tabFTPSettings;
            otherSettings.Parent = this.tabOtherSettings;
            this.tabFTPSettings.Controls.Add(ftpControl);
            this.tabOtherSettings.Controls.Add(otherSettings);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ftpSettings = ftpControl.GetLatestSettings();
                GridColor = otherSettings.GridColor;
                NoOfHistoryImages = otherSettings.ItemsInHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
