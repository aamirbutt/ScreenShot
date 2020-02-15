using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class OtherSettings : UserControl
    {
        public Color GridColor { get; set; }
        public int ItemsInHistory  { get; set; }

        public OtherSettings(Color gridColor, int noOfHistoryItems)
        {
            InitializeComponent();
            this.GridColor = gridColor;
            this.colorCmbBox.SelectedColor = gridColor;
            ItemsInHistory = noOfHistoryItems;
            cmbHistoryShots.SelectedIndex = ItemsInHistory - 1;
        }

        private void colorCmbBox_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            this.GridColor = e.color;
        }

        private void cmbHistoryShots_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbHistoryShots.SelectedItem.ToString();
            int noOfItems;
            Int32.TryParse(value, out noOfItems);
            ItemsInHistory = noOfItems;
        }
    }
}
