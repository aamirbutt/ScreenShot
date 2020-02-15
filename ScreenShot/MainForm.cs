using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Screenshot.Properties;
using System.Reflection;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Win32APIMethods;

namespace Screenshot
{
	public partial class MainForm : Form
	{

		#region Members & Properties

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private IntPtr _hPreviousWindow;
		public CurrentState currentState { get; set; }
		private OptionsForm optionsForm;
		public EditState editState { get; set; }

		List<Shape> drawObjects;
		public List<Point> penPoints;

		Line HorzGridLine;
		Line VertGridLine;

		public Point FirstEditPoint;
		public Point SecondEditPoint;
		public bool FirstEditPointDone;

		public Rectangle rcScreen;

		public Cursor rectCursor, cropCursor, circleCursor, penCursor, lineCursor, arrowCursor, selectionCursor, textCursor;

		public Color DrawingColor { get; set; }
		public int PenSize { get; set; }
		public int ShapeOpacity { get; set; }
		public float ArrowSize { get; set; }

		public Font txtFont;

		public KeyboardHooks kbHook;
		public MouseHooks mouseHook;

		public Rectangle origBmpRect;

		public FTPSettings ftpSettings;

		private Shape SelectedShape;
		private int selectedShapeIndex;
		private int leftDistance = 0;
		private int topDistance = 0;

		public string lastFTPLocation;
		Point? selectionPoint;

		public Color GridColor { get; set; }
		private ShotsHistory shotsHistory = new ShotsHistory(Properties.Settings.Default.NoOfHistoryFiles);
		public int NoOfHistoryItems { get; set; }

		#endregion


		#region Initializations

		public MainForm()
		{
			InitializeComponent();
			InitializeSysTrayIconAndMenu();
			_hPreviousWindow = IntPtr.Zero;
			currentState = CurrentState.STATE_IDLE;

			optionsForm = new OptionsForm(this);
			editState = EditState.NONE;

			drawObjects = new List<Shape>();
			penPoints = new List<Point>();

			HorzGridLine = new Line(2.0f, DrawingColor, Point.Empty, Point.Empty);
			VertGridLine = new Line(2.0f, DrawingColor, Point.Empty, Point.Empty);

			FirstEditPoint = new Point();
			SecondEditPoint = new Point();
			FirstEditPointDone = false;

			CalculateScreenRectangle();

			ftpSettings = new FTPSettings();
			ftpSettings.InitWithDefaults();

			cropCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.CropCursor.cur"));
			circleCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Circle.cur"));
			rectCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Rectangle.cur"));
			penCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Pen.cur"));
			lineCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Line.cur"));
			arrowCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Arrow.cur"));
			selectionCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Selection.cur"));
			textCursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("Screenshot.Resources.Text.cur"));

			Utility.ReadSettings(this);

			kbHook = new KeyboardHooks(this);
			mouseHook = new MouseHooks(this);

			origBmpRect = Rectangle.Empty;

			SelectedShape = null;
			selectedShapeIndex = -1;

			lastFTPLocation = String.Empty;

			AddHistoryMenuItems();
		}

		public void CalculateScreenRectangle()
		{
			rcScreen = System.Drawing.Rectangle.Empty;
			Screen[] screens = Screen.AllScreens;

			// Create a rectangle encompassing all screens...
			foreach (Screen screen in screens)
				rcScreen = System.Drawing.Rectangle.Union(rcScreen, screen.Bounds);

		}

		private void InitializeSysTrayIconAndMenu()
		{
			this.components = new System.ComponentModel.Container();

			 // Create the NotifyIcon.
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);

			notifyIcon.Icon = Resources.ResourceManager.GetObject("MainAppIcon") as Icon;
			notifyIcon.ContextMenuStrip = this.contextMenu;
			notifyIcon.Text = "Screenshot";
			notifyIcon.Visible = true;
		}
        
        private void AddHistoryMenuItems()
		{
            ToolStripMenuItem imageMenuItem = (contextMenu.Items[2] as ToolStripMenuItem);
            imageMenuItem.DropDownItems.Clear();
            ToolStripMenuItem[] items = new ToolStripMenuItem[NoOfHistoryItems];
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = new ToolStripMenuItem();
				items[i].Name = "image" + i.ToString();
				items[i].Text = "Image &" + (i+1).ToString();
				items[i].Click += new System.EventHandler(this.imageItem_Click);
			}

			imageMenuItem.DropDownItems.AddRange(items);
		}

		#endregion


		#region Event Handling

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Utility.WriteSettings(this);
			this.Close();
		}

		public void StartFullScreenCapturing()
		{
			Bitmap bmp = BitmapHandler.GetWholeScreenBitmap();
			origBmpRect = Rectangle.Empty;
			ActivateFormWithBitmap(bmp, true, CurrentState.STATE_EDITING, EditState.CROP);
		}

		private void captureFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StartFullScreenCapturing();
		}

		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != System.Windows.Forms.MouseButtons.Left) return; //We are  handling only Mousedown for left-click right now
			if (currentState == CurrentState.STATE_EDITING)
			{
				if(SelectedShape != null)
					SelectedShape.Selected = false;
				SelectedShape = null;
				if (editState != EditState.CROP)
				{
					SavePreviousText();
				}
				Point cursorPt = this.PointToClient(Cursor.Position);
				switch (editState)
				{
					case EditState.NONE:
						break;
					case EditState.CIRCLE:
					case EditState.RECTANGLE:
					case EditState.ARROW:
					case EditState.CROP:
					case EditState.LINE:
						FirstEditPoint = cursorPt;
						FirstEditPointDone = true;
						break;
					case EditState.TEXT:
						FirstEditPoint = cursorPt;
						FirstEditPointDone = true;
						break;
					case EditState.PEN:
						penPoints.Add(cursorPt);
						break;
					case EditState.SELECTION:
						int index = -1, leftDist = 0, topDist = 0;
						SelectedShape = GetShapeFromPoint(cursorPt, out index, out leftDist, out topDist);
						if (SelectedShape != null)
						{
							selectedShapeIndex = index;
							leftDistance = leftDist;
							topDistance = topDist;
							SelectedShape.Selected = true;
						}
						break;
					default:
						break;
				}
				//optionsForm.Hide();
			}
			else if (currentState == CurrentState.STATE_CAPTURINGWND)
			{
				CaptureWindow();
			}
		}

		private void SavePreviousText()
		{
			if (String.IsNullOrEmpty(textBox1.Text))
			{
				return;
			}
			Color color = Color.FromArgb(ShapeOpacity, DrawingColor);
			Point start = FirstEditPoint;
			Point end = SecondEditPoint;
			Utility.NormalizePts(ref start, ref end);
			Shape temp = new MyText(txtFont, textBox1.Text, color, start, end);
			drawObjects.Add(temp);
			textBox1.Text = String.Empty;
			textBox1.Hide();
		}

		private void MainForm_MouseUp(object sender, MouseEventArgs e)
		{
			//We are handling mouse up for left click only as of now
			if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
			
			if (currentState == CurrentState.STATE_EDITING)
			{
				Point cursorPt = this.PointToClient(Cursor.Position);
				switch (editState)
				{
					case EditState.NONE:
						break;
					case EditState.RECTANGLE:
					case EditState.CIRCLE:
					case EditState.ARROW:
					case EditState.LINE:
						if (FirstEditPoint != SecondEditPoint)
						{
							SecondEditPoint = cursorPt;
							Shape temp = GetNewShapeBasedOnType(editState, PenSize, DrawingColor);
							temp.StartPoint = FirstEditPoint;
							temp.EndPoint = SecondEditPoint;
							drawObjects.Add(temp);
						}
						FirstEditPoint = Point.Empty;
						SecondEditPoint = Point.Empty;
						FirstEditPointDone = false;
						break;
					case EditState.CROP:
						SecondEditPoint = cursorPt;
						if (FirstEditPoint != SecondEditPoint)
						{
							GenerateCropBitmapAndOverlay(FirstEditPoint, SecondEditPoint);
						}
						FirstEditPoint = Point.Empty;
						SecondEditPoint = Point.Empty;
						FirstEditPointDone = false;
						optionsForm.SetUIState(EditState.ARROW);
						break;
					case EditState.PEN:
						if (penPoints.Count != 0)
						{
							MyPen pen = new MyPen(PenSize, Color.FromArgb(ShapeOpacity, DrawingColor));
							pen.SetDrawPoints(penPoints);
							drawObjects.Add(pen);
						}
						penPoints.Clear();
						break;
					case EditState.TEXT:
						if (FirstEditPoint == SecondEditPoint)
						{
							SecondEditPoint.X = cursorPt.X + 100;
							SecondEditPoint.Y = cursorPt.Y + 30;
						}
						else
							SecondEditPoint = cursorPt;
						Point firstHit = this.PointToClient(FirstEditPoint);
						Point secondHit = this.PointToClient(SecondEditPoint);
						Utility.NormalizePts(ref firstHit, ref secondHit);
						textBox1.SetBounds(firstHit.X, firstHit.Y, secondHit.X - firstHit.X, secondHit.Y - firstHit.Y);
						this.textBox1.Visible = true;
						textBox1.Font = txtFont;
						textBox1.ForeColor = Color.FromArgb(ShapeOpacity, DrawingColor);
						textBox1.Focus();

						FirstEditPointDone = false;
						break;
					case EditState.SELECTION:
						if (SelectedShape != null && selectedShapeIndex != -1)
						{
							drawObjects[selectedShapeIndex] = SelectedShape;
							//SelectedShape = null;
							//selectedShapeIndex = -1;
						}
						break;
					default:
						break;
				}
			}
			Invalidate();
		}

		public void CaptureWindow()
		{
			if (_hPreviousWindow == IntPtr.Zero)
				return;
			WindowHighlighter.Refresh(_hPreviousWindow);

			using (Bitmap bmpWnd = BitmapHandler.GenerateBitmapFromHWnd(_hPreviousWindow))
			{
				Bitmap bmp = BitmapHandler.GenerateFullBitmapAroundCrop(bmpWnd, out origBmpRect);
				ActivateFormWithBitmap(bmp, true, CurrentState.STATE_EDITING, EditState.PEN);
			} 
		}

		public void HighlightCapturingWindows(Point pt)
		{
			// capture the window under the cursor's position
			IntPtr hWnd = Win32.WindowFromPoint(pt);

			// if the window we're over, is not the same as the one before, and we had one before, refresh it
			if (_hPreviousWindow != IntPtr.Zero && _hPreviousWindow != hWnd)
				WindowHighlighter.Refresh(_hPreviousWindow);

			if (hWnd != IntPtr.Zero)
			{
				// save the window we're over
				_hPreviousWindow = hWnd;

				Win32.Rect rc = new Win32.Rect();
				Win32.GetWindowRect(hWnd, ref rc);

				// highlight the window
				WindowHighlighter.Highlight(hWnd);
			}
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (currentState == CurrentState.STATE_EDITING)
			{
				if (editState == EditState.SELECTION)
					selectionPoint = (e.Button == System.Windows.Forms.MouseButtons.Left) ? new Point(e.X, e.Y) : (Point?)null;
				this.Invalidate();
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.C))
			{
				SaveToClipboard();
			}
			else if (keyData == (Keys.Control | Keys.S))
			{
				SaveToFile();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				GetBackToNormalState();
			}
			else if (e.KeyCode == Keys.Delete)
			{
				if (SelectedShape != null)
				{
					drawObjects.RemoveAt(selectedShapeIndex);
					SelectedShape = null;
					this.Invalidate();
				}
			}
			else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				if (SelectedShape != null)
				{
					SelectedShape.ApplyRepositioning(e.KeyCode);
					this.Invalidate();
				}
			}
		}

		private void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				if (currentState == CurrentState.STATE_EDITING || currentState == CurrentState.STATE_READYFOREDITING)
				{
					ShowOptionsForm();
				}
			}
		}

		private void captureWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (currentState != CurrentState.STATE_IDLE)
				return;
			currentState = CurrentState.STATE_CAPTURINGWND;
		}

		private void DrawTextForAnnotationDialog(Graphics g)
		{
			Font font = new Font("Arial", 20.0f, FontStyle.Bold);
			SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.DarkGray));
			g.DrawString("Right-click to see Annotation options", font, brush, new PointF(100f, 20f));
		}
		
		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			Rectangle borderRectangle = this.ClientRectangle;
			//borderRectangle.Inflate(-10, -10);
			ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.Red, 3, ButtonBorderStyle.Dashed,
																Color.Red, 3, ButtonBorderStyle.Dashed,
																Color.Red, 3, ButtonBorderStyle.Dashed,
																Color.Red, 3, ButtonBorderStyle.Dashed);
			if (optionsForm.Visible == false)
				DrawTextForAnnotationDialog(e.Graphics);
			if (currentState == CurrentState.STATE_EDITING)
			{
				//Draw already drawn shapes
				Graphics g = e.Graphics;
				Point cursorPt = this.PointToClient(Cursor.Position);
				switch (editState)
				{
					case EditState.NONE:
						break;
					case EditState.CROP:
						GenerateGridLinesFromPoint(cursorPt, out HorzGridLine, out VertGridLine);
						break;
					case EditState.PEN:
						if (penPoints.Count == 0) break;
						penPoints.Add(cursorPt);
						Color color = Color.FromArgb(ShapeOpacity, DrawingColor);
						MyPen pen = new MyPen(PenSize, color);
						pen.SetDrawPoints(penPoints);
						pen.Draw(g);
						break;
					case EditState.CIRCLE:
					case EditState.RECTANGLE:
					case EditState.ARROW:
					case EditState.LINE:
						if (!FirstEditPointDone) break;
						Shape temp = GetNewShapeBasedOnType(editState, PenSize, DrawingColor);
						temp.StartPoint = FirstEditPoint;
						temp.EndPoint = cursorPt;
						temp.Draw(g);
						break;
					case EditState.TEXT:
						if (!FirstEditPointDone) break;
						Point start = FirstEditPoint;
						Point end = cursorPt;
						Utility.NormalizePts(ref start, ref end);
						MyRectangle rect = new MyRectangle(1.0f, Color.Black, start, end);
						rect.Draw(g);
						break;
					case EditState.SELECTION:
						if (SelectedShape == null || !selectionPoint.HasValue) break;
						SelectedShape.AdjustPoints(selectionPoint.Value, leftDistance, topDistance);
						SelectedShape.Draw(g);
						break;
					default:
						break;
				}
				
				foreach (var shape in drawObjects)
				{
					shape.Draw(g);
				}

				//draw GridLines if in Cropping mode
				if (editState == EditState.CROP)
				{
					if (FirstEditPointDone)
					{
						Line horzLine, vertLine;
						GenerateGridLinesFromPoint(FirstEditPoint, out horzLine, out vertLine);
						horzLine.Draw(g);
						vertLine.Draw(g);
					}
					HorzGridLine.Draw(g);
					VertGridLine.Draw(g);
				}
			}
		}

		private void readFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();

			if (data.GetDataPresent(DataFormats.Bitmap))
			{
				Bitmap bitmap = (data.GetData(DataFormats.Bitmap, true) as Bitmap);
				Bitmap bmp = BitmapHandler.GenerateFullBitmapAroundCrop(bitmap, out origBmpRect);
				ActivateFormWithBitmap(bmp, true, CurrentState.STATE_EDITING, EditState.CROP);
			}
			else
				MessageBox.Show("Clipbard doesn't contain Image data");

		}

		private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm(ftpSettings, GridColor, NoOfHistoryItems);
			if (settings.ShowDialog() == DialogResult.OK)
			{
				ftpSettings = settings.ftpSettings;
				GridColor = settings.GridColor;
				NoOfHistoryItems = settings.NoOfHistoryImages;
				AddHistoryMenuItems();
				Utility.WriteSettings(this);
			}
		}

		private void copyLastImageLocationToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (String.IsNullOrEmpty(lastFTPLocation))
				{
					MessageBox.Show("There is no last image location");
					return;
				}
				Clipboard.SetText(lastFTPLocation);
			}
			catch (ExternalException)
			{ }
		}

		private void imageItem_Click(object sender, EventArgs e)
		{
			string name = (sender as ToolStripMenuItem).Name;
			char chIndex = name[name.Length - 1];
			int index = Convert.ToInt32(chIndex) - 48;
			string path = shotsHistory.GetElementAt(index);
			if (path == null)
			{
				MessageBox.Show("No image available");
				return;
			}
			ActivateFormWithBitmap(new Bitmap(path), true, CurrentState.STATE_EDITING, EditState.ARROW, false);
		}

		private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			for (int i = 0; i < Properties.Settings.Default.NoOfHistoryFiles; i++)
			{
				(contextMenu.Items[2] as ToolStripMenuItem).DropDownItems[i].Enabled = true;
			}
			for (int i = Properties.Settings.Default.NoOfHistoryFiles - 1; i >= shotsHistory.GetShotCount(); i--)
			{
				(contextMenu.Items[2] as ToolStripMenuItem).DropDownItems[i].Enabled = false;
			}
		}


		#endregion

		#region Helpers

		public void ActivateFormWithBitmap(Bitmap bmp, bool showOptionsDlg, CurrentState curState, EditState edState, bool addToHistory=true)
		{
			optionsForm.Hide();
			this.Show();

			this.WindowState = FormWindowState.Normal;
			this.Size = Utility.GetSizeBasedOnBitmapSize(bmp.Size);
			this.Location = Utility.GetFormLocationFromBitmapSize(bmp.Size);

			this.Activate();
			this.BackgroundImage = bmp;
			currentState = curState;

			if (showOptionsDlg)
			{
				editState = edState;
				ShowOptionsForm();
			}
			if(addToHistory)
				shotsHistory.AddBitmapToHistory(bmp);
		}

		public void SetCursorForType(EditState state)
		{
			switch (state)
			{
				case EditState.CROP:
					this.Cursor = cropCursor;
					break;
				case EditState.CIRCLE:
					this.Cursor = circleCursor;
					break;
				case EditState.RECTANGLE:
					this.Cursor = rectCursor;
					break;
				case EditState.PEN:
					this.Cursor = penCursor;
					break;
				case EditState.LINE:
					this.Cursor = lineCursor;
					break;
				case EditState.ARROW:
					this.Cursor = arrowCursor;
					break;
				case EditState.SELECTION:
					this.Cursor = selectionCursor;
					break;
				case EditState.TEXT:
					this.Cursor = textCursor;
					break;
				case EditState.NONE:
				default:
					this.Cursor = Cursors.Default;
					break;
			}
		}
		
		private void ShowOptionsForm()
		{
			optionsForm.Show();
			currentState = CurrentState.STATE_EDITING;
			if (editState == EditState.NONE)
			{
				editState = EditState.CROP;
			}
			Point location = this.Location;
			location.X += 3; location.Y += 3;
			optionsForm.Location = location;
			SetCursorForType(editState);
			optionsForm.SetPanels(editState);
			optionsForm.Activate();
			optionsForm.BringToFront();
			optionsForm.TopMost = true;
		}

		public void GetBackToNormalState()
		{
			Size currentsize = this.Size;
			Size newSize = new Size(currentsize.Width, currentsize.Height - 1);
			this.Size = newSize;
			this.WindowState = FormWindowState.Minimized;
			currentState = CurrentState.STATE_IDLE;
			this.BackgroundImage = null;
			this.Cursor = Cursors.Default;
			this.drawObjects.Clear();
			if(SelectedShape != null)
				SelectedShape.Selected = false;
			SelectedShape = null;
			optionsForm.Hide();
			this.Hide();
		}

		private Shape GetNewShapeBasedOnType(EditState state, float lineWidth, Color penColor)
		{
			Shape shape = null;
			Color color = Color.FromArgb(ShapeOpacity, penColor);
			switch (state)
			{
				case EditState.PEN:
					break;
				case EditState.CIRCLE:
					shape = new MyCircle(lineWidth, color, Point.Empty, Point.Empty);
					break;
				case EditState.RECTANGLE:
					shape = new MyRectangle(lineWidth, color, Point.Empty, Point.Empty);
					break;
				case EditState.ARROW:
					shape = new Arrow(color, Point.Empty, Point.Empty);
					Arrow temp = shape as Arrow;
					temp.ArrowWidth = ArrowSize;
					break;
				case EditState.LINE:
					shape = new Line(lineWidth, color, Point.Empty, Point.Empty);
					break;
				case EditState.CROP:
				case EditState.NONE:
				default:
					break;
			}
			return shape;
		}

		private void GenerateCropBitmapAndOverlay(Point FirstCropPoint, Point SecondCropPoint)
		{
			Bitmap croppedBitmap = BitmapHandler.CropBitmap(FirstCropPoint, SecondCropPoint, this.BackgroundImage as Bitmap);
			if (croppedBitmap == null) return;
			Bitmap bmp = BitmapHandler.GenerateFullBitmapAroundCrop(croppedBitmap, out origBmpRect);
			ActivateFormWithBitmap(bmp, true, CurrentState.STATE_EDITING, EditState.CROP);
		}

		private void GenerateGridLinesFromPoint(Point pt, out Line horzLine, out Line vertLine)
		{
			Point startPointXLine = new Point(0, pt.Y);
			Point endPointXLine = new Point(rcScreen.Width, pt.Y);

			Point startPointYLine = new Point(pt.X, 0);
			Point endPointYLine = new Point(pt.X, rcScreen.Height);
			
			horzLine = new Line(2.0f, GridColor, startPointXLine, endPointXLine);
			vertLine = new Line(2.0f, GridColor, startPointYLine, endPointYLine);
		}

		private Bitmap GetSaveableBitmap()
		{
			Bitmap bmp = this.BackgroundImage as Bitmap;
			BitmapHandler.AddShapesToBitmap(ref bmp, drawObjects);
			if (origBmpRect != Rectangle.Empty)
			{
				Bitmap bmpToSave = BitmapHandler.CropBitmap(new Point(origBmpRect.Left, origBmpRect.Top),
									new Point(origBmpRect.Right, origBmpRect.Bottom), bmp);
				bmp = bmpToSave;
			}
			return bmp;
		}
		
		internal void SaveToFile()
		{
			bool imageSaved = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "JPG File (*.jpg)|*.jpg|PNG File (*.png)|*.png|BMP File (*.bmp)|*.bmp";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Bitmap bmp = GetSaveableBitmap();
				if (dlg.FilterIndex == 1)
					bmp.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
				else if (dlg.FilterIndex == 2)
					bmp.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
				else if (dlg.FilterIndex == 3)
					bmp.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);

				imageSaved = true;
                GetBackToNormalState();
            }

			if(imageSaved)
				ShowStatusMessage("Image Saved to File", 2000);
			
			//notifyIcon.ShowBalloonTip(5, "Screenshot", "Image has been saved to File",
			//                            ToolTipIcon.None);

		}

		private void ShowStatusMessage(string Message, int timeout)
		{
			ProgressForm form = new ProgressForm();
			form.InitWithDefaults(true);
			form.UpdateStatus(Message);

			Task.Factory.StartNew(() =>
			{
				Thread.Sleep(timeout);
				form.Invoke((Action)(() => form.Close()));
			});
		}

		public void SaveToClipboard()
		{
			Bitmap bmp = GetSaveableBitmap();
			Clipboard.SetImage(bmp as Image);

			GetBackToNormalState();

			ShowStatusMessage("Image has been saved to clipboard", 4000);
			//notifyIcon.ShowBalloonTip(5, "Screenshot", "Image has been saved to clipboard. Press Ctrl+V in MSPaint",
			//    ToolTipIcon.None);
		  
		}

		private string GetFileNameToUpload()
		{
			DateTime time = DateTime.Now;
			string strFileName = String.Format("{0}{1}{2}_{3}{4}{5}{6}.png", time.Year, time.Month, time.Day, 
				time.Hour, time.Minute, time.Second, time.Millisecond);
			return strFileName;
		}
		
		internal void UploadToFTP()
		{
			string ftpFile = GetFileNameToUpload();

			Bitmap bmp = GetSaveableBitmap();
			if (bmp == null) return;

			string bmpPath = Directory.GetCurrentDirectory();
			bmpPath += @"\" + ftpFile;
			bmp.Save(bmpPath, ImageFormat.Png);
			GetBackToNormalState();

			ProgressForm form = new ProgressForm();
			form.InitWithDefaults();

			Task.Factory.StartNew(() =>
				{
					try
					{
						// Get the object used to communicate with the server.
						FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpSettings.FTPServer + '/' + ftpFile);
						request.Method = WebRequestMethods.Ftp.UploadFile;

						// This example assumes the FTP site uses anonymous logon.
						request.Credentials = new NetworkCredential(ftpSettings.FTPUser, ftpSettings.FTPPwd);
						
						// Copy the contents of the file to the request stream.
						byte[] fileContents = File.ReadAllBytes(bmpPath);
						request.ContentLength = fileContents.Length;
						request.UsePassive = true;

						using (Stream requestStream = request.GetRequestStream())
						{                            
							form.Invoke((Action)(() => form.UpdateStatus("Uploading...")));

							int i = 0;
							int loopIters = fileContents.Length / 1000 + 1;
							while (i < fileContents.Length)
							{
								int bytesToWrite = 1000;
								if ((fileContents.Length - i) < 1000)
									bytesToWrite = fileContents.Length - i;
								requestStream.Write(fileContents, i, bytesToWrite);
								i += 1000;
								form.Invoke((Action)(() => form.StepAhead(100 / loopIters)));
							}
							form.Invoke((Action)(() => form.StepAhead(100 / loopIters))); //Just to finish the damn thing
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Upload to FTP server failed due to the following reason: \n" + ex.Message);
						form.Invoke((Action)(() => form.Close()));
						return;
					}
				}
			).ContinueWith(_ =>
				{
					form.UpdateStatus("File uploaded... ");
					form.HideProgressBar();
					form.UpdateStatus("Image has been uploaded to FTP Server and copied to your");
					form.UpdateStatus2("clipboard. Press Ctrl+V in browser to view the image");

					string strFTPLoc = ftpSettings.DefaultImagesLocation + ftpFile;
					this.SetClipboardText(strFTPLoc);
					this.SetLastFTPLocation(strFTPLoc);
					Thread.Sleep(5000);      //Just to make sure that user sees the uploaded message.
					form.Close();
				}, TaskScheduler.FromCurrentSynchronizationContext() );
		}

		public void SetLastFTPLocation(string text)
		{
			lastFTPLocation = text;
		}

		public void SetClipboardText(string text)
		{
			try
			{
				Clipboard.SetText(text);
			}
			catch (System.Runtime.InteropServices.ExternalException)
			{
				
			}
		}

		private Shape GetShapeFromPoint(Point point, out int index, out int leftDist, out int topDist)
		{
			index = -1;
			leftDist = topDist = 0;
			if (drawObjects.Count == 0) return null;

			var result = drawObjects.Select((item, indx) => new { Item = item, Indx = indx })
									.Where(x => x.Item.GetShapeRect().PtInRect(point)).LastOrDefault(); ;

			if (result == null) return null;
			Shape shape = result.Item as Shape;
			leftDist = shape.DistanceFromLeft(point);
			topDist = shape.DistanceFromTop(point);
			index = result.Indx;
			return result.Item as Shape;
		}
		#endregion

	}
}
