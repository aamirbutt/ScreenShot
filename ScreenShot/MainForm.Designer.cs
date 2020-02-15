namespace Screenshot
{
    partial class MainForm
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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.captureFullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPreviousImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.copyLastImageLocationToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tempToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureFullScreenToolStripMenuItem,
            this.captureWindowToolStripMenuItem,
            this.loadPreviousImageToolStripMenuItem,
            this.readFromClipboardToolStripMenuItem,
            this.separatorToolStripMenuItem,
            this.copyLastImageLocationToClipboardToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.tempToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(289, 170);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // captureFullScreenToolStripMenuItem
            // 
            this.captureFullScreenToolStripMenuItem.Name = "captureFullScreenToolStripMenuItem";
            this.captureFullScreenToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.captureFullScreenToolStripMenuItem.Text = "Capture &Full Screen                 PrintScreen";
            this.captureFullScreenToolStripMenuItem.Click += new System.EventHandler(this.captureFullScreenToolStripMenuItem_Click);
            // 
            // captureWindowToolStripMenuItem
            // 
            this.captureWindowToolStripMenuItem.Name = "captureWindowToolStripMenuItem";
            this.captureWindowToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.captureWindowToolStripMenuItem.Text = "Capture &Window              Alt+PrintScreen";
            this.captureWindowToolStripMenuItem.Click += new System.EventHandler(this.captureWindowToolStripMenuItem_Click);
            // 
            // loadPreviousImageToolStripMenuItem
            // 
            this.loadPreviousImageToolStripMenuItem.Name = "loadPreviousImageToolStripMenuItem";
            this.loadPreviousImageToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.loadPreviousImageToolStripMenuItem.Text = "Load &Previous Image";
            // 
            // readFromClipboardToolStripMenuItem
            // 
            this.readFromClipboardToolStripMenuItem.Name = "readFromClipboardToolStripMenuItem";
            this.readFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.readFromClipboardToolStripMenuItem.Text = "Read Image From &Clipboard";
            this.readFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.readFromClipboardToolStripMenuItem_Click);
            // 
            // separatorToolStripMenuItem
            // 
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            this.separatorToolStripMenuItem.Size = new System.Drawing.Size(285, 6);
            // 
            // copyLastImageLocationToClipboardToolStripMenuItem
            // 
            this.copyLastImageLocationToClipboardToolStripMenuItem.Name = "copyLastImageLocationToClipboardToolStripMenuItem";
            this.copyLastImageLocationToClipboardToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.copyLastImageLocationToClipboardToolStripMenuItem.Text = "Copy Last Image &Location to Clipboard";
            this.copyLastImageLocationToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyLastImageLocationToClipboardToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(288, 22);
            this.settingsToolStripMenuItem1.Text = "&Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // tempToolStripMenuItem
            // 
            this.tempToolStripMenuItem.Name = "tempToolStripMenuItem";
            this.tempToolStripMenuItem.Size = new System.Drawing.Size(285, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(116, 82);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureFullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureWindowToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem readFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator tempToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLastImageLocationToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPreviousImageToolStripMenuItem;
    }
}

