namespace Screenshot
{
    partial class OtherSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHistoryShots = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorCmbBox = new ColorComboTestApp.ColorComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crop Line Color:";
            // 
            // cmbHistoryShots
            // 
            this.cmbHistoryShots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHistoryShots.FormattingEnabled = true;
            this.cmbHistoryShots.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbHistoryShots.Location = new System.Drawing.Point(148, 61);
            this.cmbHistoryShots.Name = "cmbHistoryShots";
            this.cmbHistoryShots.Size = new System.Drawing.Size(37, 21);
            this.cmbHistoryShots.TabIndex = 2;
            this.cmbHistoryShots.SelectedIndexChanged += new System.EventHandler(this.cmbHistoryShots_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No. of Images in History:";
            // 
            // colorCmbBox
            // 
            this.colorCmbBox.Extended = false;
            this.colorCmbBox.Location = new System.Drawing.Point(140, 26);
            this.colorCmbBox.Name = "colorCmbBox";
            this.colorCmbBox.SelectedColor = System.Drawing.Color.Black;
            this.colorCmbBox.Size = new System.Drawing.Size(120, 23);
            this.colorCmbBox.TabIndex = 0;
            this.colorCmbBox.ColorChanged += new ColorComboTestApp.ColorChangedHandler(this.colorCmbBox_ColorChanged);
            // 
            // OtherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbHistoryShots);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorCmbBox);
            this.Name = "OtherSettings";
            this.Size = new System.Drawing.Size(285, 214);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorComboTestApp.ColorComboBox colorCmbBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHistoryShots;
        private System.Windows.Forms.Label label2;
    }
}
