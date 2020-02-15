using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Screenshot
{
    public partial class FtpSettingsControl : UserControl
    {
        public FTPSettings ftpSettings;
        
        public FtpSettingsControl(FTPSettings settings)
        {
            InitializeComponent();
            this.ftpSettings = settings;
        }

        private void FtpSettingsControl_Load(object sender, EventArgs e)
        {
            textImagesURL.Text = ftpSettings.DefaultImagesLocation;
            textServer.Text = ftpSettings.FTPServer;
            textPort.Text = ftpSettings.FTPPort.ToString();
            cbAnonymous.Checked = ftpSettings.AnonymousLogin;
            if (ftpSettings.AnonymousLogin)
            {
                textUser.Enabled = false;
                textPwd.Enabled = false;
            }
            else
            {
                textUser.Text = ftpSettings.FTPUser;
                textPwd.Text = ftpSettings.FTPPwd;
            }
            cbPrxyServer.Checked = ftpSettings.UseProxy;
            if (cbPrxyServer.Checked == false)
            {
                txtPrxyLogin.Enabled = false;
                txtPrxyPort.Enabled = false;
                txtPrxyPwd.Enabled = false;
                txtPrxyServer.Enabled = false;
            }
            else
            {
                txtPrxyLogin.Text = ftpSettings.PrxyUser;
                txtPrxyPort.Text = ftpSettings.PrxyPort.ToString();
                txtPrxyPwd.Text = ftpSettings.PrxyPwd;
                txtPrxyServer.Text = ftpSettings.PrxyServer;
            }

            HideProxyThingsAndResize();

        }

        private void HideProxyThingsAndResize()
        {
            cbPrxyServer.Visible = false;
            txtPrxyLogin.Visible = false;
            txtPrxyPort.Visible = false;
            txtPrxyPwd.Visible = false;
            txtPrxyServer.Visible = false;

            Rectangle rect = this.Bounds;

            rect.Width -= 255;
            this.Bounds = rect;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Int32 port = -1;
            try
            {
                Int32.TryParse(textPort.Text, out port);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid value in Port");
                return;
            }
            Task.Factory.StartNew(() =>
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + textServer.Text + "/Test.png");
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(textUser.Text, textPwd.Text);
                    request.UsePassive = true;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() => MessageBox.Show("Upload to FTP server failed due to the following reason: \n" + ex.Message)));
                    return;
                }
                this.Invoke((Action)(() => MessageBox.Show("Test successsful")));
            });

        }

        public FTPSettings GetLatestSettings()
        {
            ftpSettings.FTPUser = textUser.Text;
            ftpSettings.FTPPwd = textPwd.Text;
            try
            {
                Int32.TryParse(textPort.Text, out ftpSettings.FTPPort);
            }
            catch (Exception)
            {
                throw new Exception("Please enter a valid port");
            }
            ftpSettings.FTPServer = textServer.Text;
            ftpSettings.AnonymousLogin = cbAnonymous.Checked;
            ftpSettings.UseProxy = cbPrxyServer.Checked;
            ftpSettings.PrxyServer = txtPrxyServer.Text;
            ftpSettings.PrxyUser = txtPrxyLogin.Text;
            ftpSettings.PrxyPwd = txtPrxyPwd.Text;
            try
            {
                Int32.TryParse(txtPrxyPort.Text, out ftpSettings.PrxyPort);
            }
            catch (Exception)
            {
                throw new Exception("Please enter a valid port");
            }

            ftpSettings.DefaultImagesLocation = textImagesURL.Text;
            return ftpSettings;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ftpSettings.FTPUser = textUser.Text;
            ftpSettings.FTPPwd = textPwd.Text;
            try
            {
                Int32.TryParse(textPort.Text, out ftpSettings.FTPPort);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid port");
                return;
            }
            ftpSettings.FTPServer = textServer.Text;
            ftpSettings.AnonymousLogin = cbAnonymous.Checked;
            ftpSettings.UseProxy = cbPrxyServer.Checked;
            ftpSettings.PrxyServer = txtPrxyServer.Text;
            ftpSettings.PrxyUser = txtPrxyLogin.Text;
            ftpSettings.PrxyPwd = txtPrxyPwd.Text;
            try
            {
                Int32.TryParse(txtPrxyPort.Text, out ftpSettings.PrxyPort);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid port");
                return;
            }

            ftpSettings.DefaultImagesLocation = textImagesURL.Text;
        }

        private void cbAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnonymous.Checked)
            {
                textUser.Enabled = false;
                textPwd.Enabled = false;
            }
            else
            {
                textUser.Enabled = true;
                textPwd.Enabled = true;
            }
        }

        private void cbPrxyServer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrxyServer.Checked == true)
            {
                txtPrxyLogin.Enabled = true;
                txtPrxyPort.Enabled = true;
                txtPrxyPwd.Enabled = true;
                txtPrxyServer.Enabled = true;
            }
            else
            {
                txtPrxyLogin.Enabled = false;
                txtPrxyPort.Enabled = false;
                txtPrxyPwd.Enabled = false;
                txtPrxyServer.Enabled = false;
            }
        }
    }
}
