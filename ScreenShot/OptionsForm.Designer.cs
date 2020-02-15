namespace Screenshot
{
    partial class OptionsForm
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
            this.components = new System.ComponentModel.Container();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnArrow = new System.Windows.Forms.Button();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.cmbFonts = new System.Windows.Forms.ComboBox();
            this.cmbFontSizes = new System.Windows.Forms.ComboBox();
            this.scrollPenSize = new System.Windows.Forms.HScrollBar();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.scrollOpacity = new System.Windows.Forms.HScrollBar();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.scrollArrow = new System.Windows.Forms.HScrollBar();
            this.lblArrowSize = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSelection = new System.Windows.Forms.Button();
            this.panelPen = new System.Windows.Forms.Panel();
            this.panelOpacity = new System.Windows.Forms.Panel();
            this.panelArrow = new System.Windows.Forms.Panel();
            this.panelFont = new System.Windows.Forms.Panel();
            this.panelColors = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.colorComboBox = new ColorComboTestApp.ColorComboBox();
            this.panelSave = new System.Windows.Forms.Panel();
            this.btnDropDown = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToFTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons.SuspendLayout();
            this.panelPen.SuspendLayout();
            this.panelOpacity.SuspendLayout();
            this.panelArrow.SuspendLayout();
            this.panelFont.SuspendLayout();
            this.panelColors.SuspendLayout();
            this.panelSave.SuspendLayout();
            this.popupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrop
            // 
            this.btnCrop.Image = global::Screenshot.Properties.Resources.Crop;
            this.btnCrop.Location = new System.Drawing.Point(3, 3);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(51, 48);
            this.btnCrop.TabIndex = 0;
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Image = global::Screenshot.Properties.Resources.Circle1;
            this.btnCircle.Location = new System.Drawing.Point(60, 57);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(51, 48);
            this.btnCircle.TabIndex = 0;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = global::Screenshot.Properties.Resources.Rectangle;
            this.btnRectangle.Location = new System.Drawing.Point(117, 57);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(51, 48);
            this.btnRectangle.TabIndex = 0;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnArrow
            // 
            this.btnArrow.Image = global::Screenshot.Properties.Resources.Arrow;
            this.btnArrow.Location = new System.Drawing.Point(3, 57);
            this.btnArrow.Name = "btnArrow";
            this.btnArrow.Size = new System.Drawing.Size(51, 48);
            this.btnArrow.TabIndex = 0;
            this.btnArrow.UseVisualStyleBackColor = true;
            this.btnArrow.Click += new System.EventHandler(this.btnArrow_Click);
            // 
            // btnPen
            // 
            this.btnPen.Image = global::Screenshot.Properties.Resources.Pen;
            this.btnPen.Location = new System.Drawing.Point(60, 3);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(51, 48);
            this.btnPen.TabIndex = 0;
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnLine
            // 
            this.btnLine.Image = global::Screenshot.Properties.Resources.Line;
            this.btnLine.Location = new System.Drawing.Point(174, 3);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(51, 48);
            this.btnLine.TabIndex = 0;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnText
            // 
            this.btnText.Image = global::Screenshot.Properties.Resources.Text;
            this.btnText.Location = new System.Drawing.Point(117, 3);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(51, 48);
            this.btnText.TabIndex = 0;
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // cmbFonts
            // 
            this.cmbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFonts.FormattingEnabled = true;
            this.cmbFonts.Location = new System.Drawing.Point(3, 9);
            this.cmbFonts.Name = "cmbFonts";
            this.cmbFonts.Size = new System.Drawing.Size(165, 21);
            this.cmbFonts.TabIndex = 1;
            this.cmbFonts.SelectedIndexChanged += new System.EventHandler(this.cmbFonts_SelectedIndexChanged);
            // 
            // cmbFontSizes
            // 
            this.cmbFontSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSizes.FormattingEnabled = true;
            this.cmbFontSizes.Location = new System.Drawing.Point(174, 9);
            this.cmbFontSizes.Name = "cmbFontSizes";
            this.cmbFontSizes.Size = new System.Drawing.Size(51, 21);
            this.cmbFontSizes.TabIndex = 2;
            this.cmbFontSizes.SelectedIndexChanged += new System.EventHandler(this.cmbFontSizes_SelectedIndexChanged);
            // 
            // scrollPenSize
            // 
            this.scrollPenSize.LargeChange = 2;
            this.scrollPenSize.Location = new System.Drawing.Point(73, 10);
            this.scrollPenSize.Maximum = 10;
            this.scrollPenSize.Minimum = 1;
            this.scrollPenSize.Name = "scrollPenSize";
            this.scrollPenSize.Size = new System.Drawing.Size(152, 17);
            this.scrollPenSize.TabIndex = 6;
            this.scrollPenSize.Value = 1;
            this.scrollPenSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollPenSize_Scroll);
            // 
            // lblPenWidth
            // 
            this.lblPenWidth.AutoSize = true;
            this.lblPenWidth.Location = new System.Drawing.Point(3, 11);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(60, 13);
            this.lblPenWidth.TabIndex = 7;
            this.lblPenWidth.Text = "Pen Width:";
            // 
            // scrollOpacity
            // 
            this.scrollOpacity.LargeChange = 25;
            this.scrollOpacity.Location = new System.Drawing.Point(73, 10);
            this.scrollOpacity.Maximum = 255;
            this.scrollOpacity.Minimum = 1;
            this.scrollOpacity.Name = "scrollOpacity";
            this.scrollOpacity.Size = new System.Drawing.Size(152, 17);
            this.scrollOpacity.TabIndex = 6;
            this.scrollOpacity.Value = 1;
            this.scrollOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollOpacity_Scroll);
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(3, 11);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(46, 13);
            this.lblOpacity.TabIndex = 7;
            this.lblOpacity.Text = "Opacity:";
            // 
            // scrollArrow
            // 
            this.scrollArrow.LargeChange = 5;
            this.scrollArrow.Location = new System.Drawing.Point(73, 10);
            this.scrollArrow.Maximum = 30;
            this.scrollArrow.Minimum = 5;
            this.scrollArrow.Name = "scrollArrow";
            this.scrollArrow.Size = new System.Drawing.Size(152, 17);
            this.scrollArrow.TabIndex = 6;
            this.scrollArrow.Value = 5;
            this.scrollArrow.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollArrow_Scroll);
            // 
            // lblArrowSize
            // 
            this.lblArrowSize.AutoSize = true;
            this.lblArrowSize.Location = new System.Drawing.Point(3, 11);
            this.lblArrowSize.Name = "lblArrowSize";
            this.lblArrowSize.Size = new System.Drawing.Size(60, 13);
            this.lblArrowSize.TabIndex = 7;
            this.lblArrowSize.Text = "Arrow Size:";
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnSelection);
            this.panelButtons.Controls.Add(this.btnCrop);
            this.panelButtons.Controls.Add(this.btnText);
            this.panelButtons.Controls.Add(this.btnPen);
            this.panelButtons.Controls.Add(this.btnLine);
            this.panelButtons.Controls.Add(this.btnCircle);
            this.panelButtons.Controls.Add(this.btnRectangle);
            this.panelButtons.Controls.Add(this.btnArrow);
            this.panelButtons.Location = new System.Drawing.Point(5, 12);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(230, 111);
            this.panelButtons.TabIndex = 8;
            // 
            // btnSelection
            // 
            this.btnSelection.Image = global::Screenshot.Properties.Resources.SelectionArrow;
            this.btnSelection.Location = new System.Drawing.Point(174, 57);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(51, 48);
            this.btnSelection.TabIndex = 1;
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // panelPen
            // 
            this.panelPen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPen.Controls.Add(this.lblPenWidth);
            this.panelPen.Controls.Add(this.scrollPenSize);
            this.panelPen.Location = new System.Drawing.Point(5, 126);
            this.panelPen.Name = "panelPen";
            this.panelPen.Size = new System.Drawing.Size(230, 40);
            this.panelPen.TabIndex = 9;
            // 
            // panelOpacity
            // 
            this.panelOpacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOpacity.Controls.Add(this.scrollOpacity);
            this.panelOpacity.Controls.Add(this.lblOpacity);
            this.panelOpacity.Location = new System.Drawing.Point(5, 169);
            this.panelOpacity.Name = "panelOpacity";
            this.panelOpacity.Size = new System.Drawing.Size(230, 40);
            this.panelOpacity.TabIndex = 10;
            // 
            // panelArrow
            // 
            this.panelArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelArrow.Controls.Add(this.lblArrowSize);
            this.panelArrow.Controls.Add(this.scrollArrow);
            this.panelArrow.Location = new System.Drawing.Point(5, 212);
            this.panelArrow.Name = "panelArrow";
            this.panelArrow.Size = new System.Drawing.Size(230, 40);
            this.panelArrow.TabIndex = 11;
            // 
            // panelFont
            // 
            this.panelFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFont.Controls.Add(this.cmbFonts);
            this.panelFont.Controls.Add(this.cmbFontSizes);
            this.panelFont.Location = new System.Drawing.Point(5, 255);
            this.panelFont.Name = "panelFont";
            this.panelFont.Size = new System.Drawing.Size(230, 40);
            this.panelFont.TabIndex = 12;
            // 
            // panelColors
            // 
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColors.Controls.Add(this.label1);
            this.panelColors.Controls.Add(this.colorComboBox);
            this.panelColors.Location = new System.Drawing.Point(5, 298);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(230, 40);
            this.panelColors.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Draw Color:";
            // 
            // colorComboBox
            // 
            this.colorComboBox.Extended = false;
            this.colorComboBox.Location = new System.Drawing.Point(73, 8);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.SelectedColor = System.Drawing.Color.Black;
            this.colorComboBox.Size = new System.Drawing.Size(152, 22);
            this.colorComboBox.TabIndex = 0;
            this.colorComboBox.ColorChanged += new ColorComboTestApp.ColorChangedHandler(this.colorComboBox_ColorChanged);
            // 
            // panelSave
            // 
            this.panelSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSave.Controls.Add(this.btnDropDown);
            this.panelSave.Controls.Add(this.btnAction);
            this.panelSave.Controls.Add(this.btnCancel);
            this.panelSave.Location = new System.Drawing.Point(5, 341);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(230, 40);
            this.panelSave.TabIndex = 14;
            // 
            // btnDropDown
            // 
            this.btnDropDown.Image = global::Screenshot.Properties.Resources.LittleArrow;
            this.btnDropDown.Location = new System.Drawing.Point(131, 10);
            this.btnDropDown.Name = "btnDropDown";
            this.btnDropDown.Size = new System.Drawing.Size(17, 21);
            this.btnDropDown.TabIndex = 3;
            this.btnDropDown.UseVisualStyleBackColor = true;
            this.btnDropDown.Click += new System.EventHandler(this.btnDropDown_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(21, 9);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(111, 23);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Save to File";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // popupMenu
            // 
            this.popupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToFileToolStripMenuItem,
            this.uploadToFTPToolStripMenuItem,
            this.saveToClipboardToolStripMenuItem});
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Size = new System.Drawing.Size(168, 70);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to File";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // uploadToFTPToolStripMenuItem
            // 
            this.uploadToFTPToolStripMenuItem.Name = "uploadToFTPToolStripMenuItem";
            this.uploadToFTPToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.uploadToFTPToolStripMenuItem.Text = "Upload to FTP";
            this.uploadToFTPToolStripMenuItem.Click += new System.EventHandler(this.uploadToFTPToolStripMenuItem_Click);
            // 
            // saveToClipboardToolStripMenuItem
            // 
            this.saveToClipboardToolStripMenuItem.Name = "saveToClipboardToolStripMenuItem";
            this.saveToClipboardToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveToClipboardToolStripMenuItem.Text = "Save to Clipboard";
            this.saveToClipboardToolStripMenuItem.Click += new System.EventHandler(this.saveToClipboardToolStripMenuItem_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 387);
            this.Controls.Add(this.panelSave);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.panelFont);
            this.Controls.Add(this.panelArrow);
            this.Controls.Add(this.panelOpacity);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelPen);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Annotate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            this.panelButtons.ResumeLayout(false);
            this.panelPen.ResumeLayout(false);
            this.panelPen.PerformLayout();
            this.panelOpacity.ResumeLayout(false);
            this.panelOpacity.PerformLayout();
            this.panelArrow.ResumeLayout(false);
            this.panelArrow.PerformLayout();
            this.panelFont.ResumeLayout(false);
            this.panelColors.ResumeLayout(false);
            this.panelColors.PerformLayout();
            this.panelSave.ResumeLayout(false);
            this.popupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnArrow;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.ComboBox cmbFonts;
        private System.Windows.Forms.ComboBox cmbFontSizes;
        private System.Windows.Forms.HScrollBar scrollPenSize;
        private System.Windows.Forms.Label lblPenWidth;
        private System.Windows.Forms.HScrollBar scrollOpacity;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.HScrollBar scrollArrow;
        private System.Windows.Forms.Label lblArrowSize;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelPen;
        private System.Windows.Forms.Panel panelOpacity;
        private System.Windows.Forms.Panel panelArrow;
        private System.Windows.Forms.Panel panelFont;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDropDown;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ContextMenuStrip popupMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToFTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.Label label1;
        private ColorComboTestApp.ColorComboBox colorComboBox;
    }
}