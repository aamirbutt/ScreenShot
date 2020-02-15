namespace Screenshot
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFTPSettings = new System.Windows.Forms.TabPage();
            this.tabOtherSettings = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabFTPSettings);
            this.tabControl1.Controls.Add(this.tabOtherSettings);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(293, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFTPSettings
            // 
            this.tabFTPSettings.Location = new System.Drawing.Point(4, 25);
            this.tabFTPSettings.Name = "tabFTPSettings";
            this.tabFTPSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabFTPSettings.Size = new System.Drawing.Size(285, 214);
            this.tabFTPSettings.TabIndex = 0;
            this.tabFTPSettings.Text = "FTP Settings";
            this.tabFTPSettings.UseVisualStyleBackColor = true;
            // 
            // tabOtherSettings
            // 
            this.tabOtherSettings.Location = new System.Drawing.Point(4, 25);
            this.tabOtherSettings.Name = "tabOtherSettings";
            this.tabOtherSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabOtherSettings.Size = new System.Drawing.Size(285, 214);
            this.tabOtherSettings.TabIndex = 1;
            this.tabOtherSettings.Text = "Other Settings";
            this.tabOtherSettings.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(227, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 301);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFTPSettings;
        private System.Windows.Forms.TabPage tabOtherSettings;
        private System.Windows.Forms.Button btnOK;

    }
}