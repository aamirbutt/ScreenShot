using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class OptionsForm : Form
    {
        public MainForm parentForm;

        public List<string> lstActions = new List<string>() {"Save to File", "Save to Clipboard", "Upload to FTP" };

        public List<PanelInfo> panelInfo;
        public Size initialFormSize;
        public OptionsForm(MainForm form)
        {
            InitializeComponent();
            parentForm = form;

            panelInfo = new List<PanelInfo>();
            initialFormSize = Size.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                parentForm.SaveToClipboard();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                parentForm.SaveToFile();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.CROP);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.CIRCLE);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.RECTANGLE);
        }

        private void btnArrow_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.ARROW);
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.PEN); 
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.LINE);
        }

        public void SetUIState(EditState editState)
        {
            parentForm.editState = editState;
            parentForm.currentState = CurrentState.STATE_EDITING;
            parentForm.SetCursorForType(parentForm.editState);
            SetPanels(editState);
        }

        public void SetPanels(EditState editState)
        {
            RestoreOriginalPanels(false);
            switch (editState)
            {
                case EditState.NONE:
                    break;
                case EditState.CROP:
                case EditState.SELECTION:
                    HideControlsAndResize(new Panel[] { panelPen, panelOpacity, panelArrow, panelFont, panelColors });
                    break;
                case EditState.PEN:
                case EditState.CIRCLE:
                case EditState.RECTANGLE:
                case EditState.LINE:
                    HideControlsAndResize(new Panel[] { panelArrow, panelFont });
                    break;
                case EditState.ARROW:
                    HideControlsAndResize(new Panel[] { panelPen, panelFont });
                    break;
                case EditState.TEXT:
                    HideControlsAndResize(new Panel[] { panelPen, panelArrow });
                    break;
                default:
                    break;
            }
        }

        private void RestoreOriginalPanels(bool resizeForm)
        {
            if(resizeForm)
                this.SetBounds(this.Location.X, this.Location.Y, initialFormSize.Width, initialFormSize.Height);

            foreach (var panelItem in panelInfo)
            {
                Panel panel = panelItem.panelRef;
                panel.Show();
                panel.SetBounds(panelItem.panelLocation.X, panelItem.panelLocation.Y, panelItem.panelSize.Width, panelItem.panelSize.Height);
            }

        }

        private void btnText_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.TEXT);
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (parentForm == null) return;
            SetUIState(EditState.SELECTION);
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            colorComboBox.SelectedColor = parentForm.DrawingColor;

            scrollPenSize.Value = parentForm.PenSize;
            scrollOpacity.Value = parentForm.ShapeOpacity;
            scrollArrow.Value = (int)parentForm.ArrowSize;
            
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                cmbFonts.Items.Add(font.Name);
            }
            string[] sizes = new string[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };

            foreach (var str in sizes)
            {
                cmbFontSizes.Items.Add(str);
            }

            FillPanelInfoList();
            initialFormSize = this.Size;

            cmbFontSizes.SelectedItem = ((int)parentForm.txtFont.Size).ToString();
            cmbFonts.SelectedItem = parentForm.txtFont.Name;

            btnAction.Text = lstActions[0];

        }

        private void FillPanelInfoList()
        {
            panelInfo.Add(new PanelInfo(panelButtons.Size, panelButtons.Location, panelButtons));
            panelInfo.Add(new PanelInfo(panelPen.Size, panelPen.Location, panelPen));
            panelInfo.Add(new PanelInfo(panelOpacity.Size, panelOpacity.Location, panelOpacity));
            panelInfo.Add(new PanelInfo(panelArrow.Size, panelArrow.Location, panelArrow));
            panelInfo.Add(new PanelInfo(panelFont.Size, panelFont.Location, panelFont));
            panelInfo.Add(new PanelInfo(panelColors.Size, panelColors.Location, panelColors));
            panelInfo.Add(new PanelInfo(panelSave.Size, panelSave.Location, panelSave));
        }

        private void scrollPenSize_Scroll(object sender, ScrollEventArgs e)
        {
            parentForm.PenSize = e.NewValue;
        }

        private void scrollOpacity_Scroll(object sender, ScrollEventArgs e)
        {
            parentForm.ShapeOpacity = e.NewValue;
        }

        private void scrollArrow_Scroll(object sender, ScrollEventArgs e)
        {
            parentForm.ArrowSize = e.NewValue;
        }

        private void HideControlsAndResize(Panel[] panelsToHide)
        {
            int sizeToReduce = 0;
            foreach (var panel in panelsToHide)
            {
                panel.Hide();
                sizeToReduce += (panel.Size.Height + 3);
            }
            this.SetBounds(Location.X, Location.Y, this.initialFormSize.Width, this.initialFormSize.Height - sizeToReduce);
            AdjustRemainingPanels(panelsToHide);
        }

        private void MovePanelUp(Panel panel, int yDiff)
        {
            panel.SetBounds(panel.Location.X, panel.Location.Y - yDiff - 3, panel.Width, panel.Height);
        }
        
        private void AdjustRemainingPanels(Panel[] panelsToHide)
        {
            if (panelsToHide.Contains(panelPen))
            {
                MovePanelUp(panelOpacity, panelPen.Height);
                MovePanelUp(panelArrow, panelPen.Height);
                MovePanelUp(panelFont, panelPen.Height);
                MovePanelUp(panelColors, panelPen.Height);
                MovePanelUp(panelSave, panelPen.Height);
            }
            if (panelsToHide.Contains(panelOpacity))
            {
                MovePanelUp(panelArrow, panelOpacity.Height);
                MovePanelUp(panelFont, panelOpacity.Height);
                MovePanelUp(panelColors, panelOpacity.Height);
                MovePanelUp(panelSave, panelOpacity.Height);
            }
            if (panelsToHide.Contains(panelArrow))
            {
                MovePanelUp(panelFont, panelArrow.Height);
                MovePanelUp(panelColors, panelArrow.Height);
                MovePanelUp(panelSave, panelArrow.Height);
            }
            if (panelsToHide.Contains(panelFont))
            {
                MovePanelUp(panelColors, panelFont.Height);
                MovePanelUp(panelSave, panelFont.Height);
            }
            if (panelsToHide.Contains(panelColors))
            {
                MovePanelUp(panelSave, panelColors.Height);
            }
        }

        private void OptionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                parentForm.GetBackToNormalState();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            parentForm.GetBackToNormalState();
        }

        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 fontSize;
            Int32.TryParse(cmbFontSizes.Text, out fontSize);
            try
            {
                parentForm.txtFont = new Font(cmbFonts.Text, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cmbFontSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbFonts.Text))
                return;
            if (parentForm.txtFont != null)
            {
                Int32 fontSize;
                Int32.TryParse(cmbFontSizes.Text, out fontSize);
                parentForm.txtFont = new Font(cmbFonts.Text, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAction.Text = lstActions[0];
            parentForm.SaveToFile();
        }

        private void uploadToFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAction.Text = lstActions[2];
            parentForm.UploadToFTP();
        }

        private void saveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAction.Text = lstActions[1];
            parentForm.SaveToClipboard();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == lstActions[0])
            {
                parentForm.SaveToFile();
            }
            else if (btnAction.Text == lstActions[1])
            {
                parentForm.SaveToClipboard();
            }
            else if (btnAction.Text == lstActions[2])
            {
                parentForm.UploadToFTP();
            }
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            Point pt = new Point(btnAction.Location.X, btnAction.Location.Y + btnAction.Size.Height);
            popupMenu.Show(this.panelSave, pt);
        }

        private void colorComboBox_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            parentForm.DrawingColor = e.color;
        }
    }

    public class PanelInfo
    {
        public Size panelSize { get; set; }
        public Point panelLocation { get; set; }
        public Panel panelRef { get; set; }
        public PanelInfo(Size size, Point location, Panel panel)
        {
            panelSize = size;
            panelLocation = location;
            panelRef = panel;
        }
    }
}
