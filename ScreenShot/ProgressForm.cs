using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Win32APIMethods;

namespace Screenshot
{
    public partial class ProgressForm : Form
    {
        public String FileName { get; set; }
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this.pgBar.Value = 0;
            labelSecond.Hide();
        }

        public void UpdateStatus(string status)
        {
            this.lblStatus.Text = status;
        }

        public void UpdateStatus2(string text)
        {
            pgBar.Hide();
            labelSecond.Show();
            labelSecond.Text = text;
        }

        public void StepAhead(int noOfSteps)
        {
            for (int i = 0; i < noOfSteps; i++)
            {
                this.pgBar.PerformStep();
                this.pgBar.Invalidate();
                this.pgBar.Update();
            }
        }

        public void HideProgressBar()
        {
            this.pgBar.Hide();
        }

        /*This method sets the custom progress form to the bottom right position and makes it topmost etc.*/
        public void InitWithDefaults(bool hideProgressBar = false)
        {
            this.Show();
            this.TopMost = true;
            this.BringToFront();
            if (hideProgressBar)
                this.HideProgressBar();
            this.UpdateStatus("Starting ...");
            this.StartPosition = FormStartPosition.Manual;
            this.Location = GetProgressFormStartingLocation();
        }

        public Point GetProgressFormStartingLocation()
        {
            TaskBarLocation tbLocation = Utility.GetTaskBarLocation();
            Rectangle taskbarRect = Win32.GetTaskbarPosition();
            Point position;

            switch (tbLocation)
            {
                case TaskBarLocation.TOP:
                case TaskBarLocation.LEFT:
                    position = new Point(taskbarRect.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
                    break;
                case TaskBarLocation.BOTTOM:
                    position = new Point(taskbarRect.Width - this.Width, taskbarRect.Y - this.Height);
                    break;
                case TaskBarLocation.RIGHT:
                    position = new Point(Screen.PrimaryScreen.Bounds.Width - taskbarRect.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
                    break;
                default:
                    position = Point.Empty;
                    break;
            }
            return position;
        }

        private void ProgressForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.Close();
            }
        }
    }
}
