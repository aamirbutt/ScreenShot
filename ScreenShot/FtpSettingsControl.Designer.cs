namespace Screenshot
{
    partial class FtpSettingsControl
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
            this.cbPrxyServer = new System.Windows.Forms.CheckBox();
            this.cbAnonymous = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrxyPort = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textImagesURL = new System.Windows.Forms.TextBox();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.txtPrxyPwd = new System.Windows.Forms.TextBox();
            this.txtPrxyLogin = new System.Windows.Forms.TextBox();
            this.txtPrxyServer = new System.Windows.Forms.TextBox();
            this.textServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbPrxyServer
            // 
            this.cbPrxyServer.AutoSize = true;
            this.cbPrxyServer.Location = new System.Drawing.Point(286, 18);
            this.cbPrxyServer.Name = "cbPrxyServer";
            this.cbPrxyServer.Size = new System.Drawing.Size(111, 17);
            this.cbPrxyServer.TabIndex = 27;
            this.cbPrxyServer.Text = "Use Proxy Server:";
            this.cbPrxyServer.UseVisualStyleBackColor = true;
            this.cbPrxyServer.CheckedChanged += new System.EventHandler(this.cbPrxyServer_CheckedChanged);
            // 
            // cbAnonymous
            // 
            this.cbAnonymous.AutoSize = true;
            this.cbAnonymous.Location = new System.Drawing.Point(15, 46);
            this.cbAnonymous.Name = "cbAnonymous";
            this.cbAnonymous.Size = new System.Drawing.Size(110, 17);
            this.cbAnonymous.TabIndex = 3;
            this.cbAnonymous.Text = "Anonymous Login";
            this.cbAnonymous.UseVisualStyleBackColor = true;
            this.cbAnonymous.CheckedChanged += new System.EventHandler(this.cbAnonymous_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(15, 175);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(126, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test Settings...";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Default Images Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "User Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Server:";
            // 
            // txtPrxyPort
            // 
            this.txtPrxyPort.Location = new System.Drawing.Point(476, 47);
            this.txtPrxyPort.Name = "txtPrxyPort";
            this.txtPrxyPort.Size = new System.Drawing.Size(48, 20);
            this.txtPrxyPort.TabIndex = 29;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(211, 44);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(48, 20);
            this.textPort.TabIndex = 2;
            // 
            // textImagesURL
            // 
            this.textImagesURL.Location = new System.Drawing.Point(81, 145);
            this.textImagesURL.Name = "textImagesURL";
            this.textImagesURL.Size = new System.Drawing.Size(178, 20);
            this.textImagesURL.TabIndex = 6;
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(81, 96);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(178, 20);
            this.textPwd.TabIndex = 5;
            this.textPwd.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(81, 70);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(178, 20);
            this.textUser.TabIndex = 4;
            // 
            // txtPrxyPwd
            // 
            this.txtPrxyPwd.Location = new System.Drawing.Point(346, 96);
            this.txtPrxyPwd.Name = "txtPrxyPwd";
            this.txtPrxyPwd.Size = new System.Drawing.Size(178, 20);
            this.txtPrxyPwd.TabIndex = 31;
            this.txtPrxyPwd.UseSystemPasswordChar = true;
            // 
            // txtPrxyLogin
            // 
            this.txtPrxyLogin.Location = new System.Drawing.Point(346, 70);
            this.txtPrxyLogin.Name = "txtPrxyLogin";
            this.txtPrxyLogin.Size = new System.Drawing.Size(178, 20);
            this.txtPrxyLogin.TabIndex = 30;
            // 
            // txtPrxyServer
            // 
            this.txtPrxyServer.Location = new System.Drawing.Point(346, 44);
            this.txtPrxyServer.Name = "txtPrxyServer";
            this.txtPrxyServer.Size = new System.Drawing.Size(95, 20);
            this.txtPrxyServer.TabIndex = 28;
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(81, 16);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(178, 20);
            this.textServer.TabIndex = 1;
            // 
            // FtpSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPrxyServer);
            this.Controls.Add(this.cbAnonymous);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrxyPort);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textImagesURL);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.txtPrxyPwd);
            this.Controls.Add(this.txtPrxyLogin);
            this.Controls.Add(this.txtPrxyServer);
            this.Controls.Add(this.textServer);
            this.Name = "FtpSettingsControl";
            this.Size = new System.Drawing.Size(542, 214);
            this.Load += new System.EventHandler(this.FtpSettingsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPrxyServer;
        private System.Windows.Forms.CheckBox cbAnonymous;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrxyPort;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textImagesURL;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox txtPrxyPwd;
        private System.Windows.Forms.TextBox txtPrxyLogin;
        private System.Windows.Forms.TextBox txtPrxyServer;
        private System.Windows.Forms.TextBox textServer;
    }
}
