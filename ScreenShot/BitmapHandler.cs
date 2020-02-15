using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Win32APIMethods;

namespace Screenshot
{
    static class BitmapHandler
    {
        public static Bitmap GetWholeScreenBitmap()
        {
            System.Drawing.Rectangle rcScreen = System.Drawing.Rectangle.Empty;
            Screen[] screens = Screen.AllScreens;

            // Create a rectangle encompassing all screens...
            foreach (Screen screen in screens)
                rcScreen = System.Drawing.Rectangle.Union(rcScreen, screen.Bounds);
            //			System.Diagnostics.Trace.WriteLine(rcScreen);

            // Create a composite bitmap of the size of all screens...
            Bitmap finalBitmap = new Bitmap(rcScreen.Width, rcScreen.Height);

            // Get a graphics object for the composite bitmap and initialize it...
            Graphics g = Graphics.FromImage(finalBitmap);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            g.FillRectangle(SystemBrushes.Desktop, 0, 0, rcScreen.Width - rcScreen.X, rcScreen.Height - rcScreen.Y);

            // Get an HDC for the composite area...
            IntPtr hdcDestination = g.GetHdc();

            // Now, loop through screens, BitBlting each to the composite HDC created above...
            foreach (Screen screen in screens)
            {
                // Create DC for each source monitor...
                IntPtr hdcSource = Win32.CreateDC(IntPtr.Zero, screen.DeviceName, IntPtr.Zero, IntPtr.Zero);

                // Blt the source directly to the composite destination...
                int xDest = screen.Bounds.X - rcScreen.X;
                int yDest = screen.Bounds.Y - rcScreen.Y;
                //				bool success = BitBlt(hdcDestination, xDest, yDest, screen.Bounds.Width, screen.Bounds.Height, hdcSource, 0, 0, (int)TernaryRasterOperations.SRCCOPY);
                bool success = Win32.StretchBlt(hdcDestination, xDest, yDest, screen.Bounds.Width, screen.Bounds.Height, hdcSource, 0, 0, screen.Bounds.Width, screen.Bounds.Height, (int)Win32.TernaryRasterOperations.SRCCOPY);
                //				System.Diagnostics.Trace.WriteLine(screen.Bounds);
                if (!success)
                {
                    System.ComponentModel.Win32Exception win32Exception = new System.ComponentModel.Win32Exception();
                    System.Diagnostics.Trace.WriteLine(win32Exception);
                }

                // Cleanup source HDC...
                Win32.DeleteDC(hdcSource);
            }

            // Cleanup destination HDC and Graphics...
            g.ReleaseHdc(hdcDestination);
            g.Dispose();

            // Return composite bitmap which will become our Form's PictureBox's image...
            return finalBitmap;
        }

        public static Bitmap CropBitmap(Point start, Point end, Bitmap OrigBitmap)
        {
            // Check if it is a bitmap:
            if (OrigBitmap == null)
                throw new ArgumentException("No valid bitmap");

            //Normalize points
            Utility.NormalizePts(ref start, ref end);
            Rectangle rect = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            if (rect.Width == 0 || rect.Height == 0)
                return null;
            // Crop the image:
            Bitmap cropBmp = OrigBitmap.Clone(rect, OrigBitmap.PixelFormat);

            return cropBmp;
        }

        public static Bitmap GenerateFullBitmapAroundCrop(Bitmap croppedBitmap, out Rectangle origRect)
        {
            
            // Create a rectangle encompassing all screens...
            Rectangle rcScreen = new Rectangle();
            foreach (Screen screen in Screen.AllScreens)
                rcScreen = System.Drawing.Rectangle.Union(rcScreen, screen.Bounds);

            // Create a composite bitmap of the size of all screens...
            Size size = Utility.GetSizeBasedOnBitmapSize(croppedBitmap.Size);
            Bitmap bmp = new Bitmap(size.Width, size.Height);

            // Create graphics:
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //Draw a solid rectangle first.
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(225,225,225)))
                {
                    g.FillRectangle(brush, rcScreen);
                    //Calculate the point to draw
                    Point pt = new Point();
                    pt.X = (bmp.Width / 2) - (croppedBitmap.Width / 2);
                    pt.Y = (bmp.Height / 2) - (croppedBitmap.Height / 2);
                    // Draw the new image:
                    g.DrawImage(croppedBitmap, pt);
                    origRect = new Rectangle(pt, new Size(croppedBitmap.Width, croppedBitmap.Height));
                }
            }

            return bmp; 
        }

        public static void AddShapeToBitmap(ref Bitmap origBmp, Shape shape)
        {
            using (Graphics g = Graphics.FromImage(origBmp))
            {
                shape.Draw(g);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "Win32APIMethods.Win32.ReleaseDC(System.IntPtr,System.IntPtr)")]
        public static Bitmap GenerateBitmapFromHWnd(IntPtr hWnd)
        {
            
            Win32.Rect rc = new Win32.Rect();
            if (!Win32.GetWindowRect(hWnd, ref rc))
                return null;

            // create a bitmap from the visible clipping bounds of the graphics object from the window
            Bitmap bitmap = new Bitmap(rc.Width, rc.Height);

            try
            {
                Graphics gfxBitmap = Graphics.FromImage(bitmap);
                IntPtr hdcBitmap = gfxBitmap.GetHdc();
                IntPtr hdcWindow = Win32.GetWindowDC(hWnd);
                Win32.BitBlt(hdcBitmap, 0, 0, rc.Width, rc.Height, hdcWindow, 0, 0, (int)Win32.TernaryRasterOperations.SRCCOPY);

                gfxBitmap.ReleaseHdc(hdcBitmap);
                Win32.ReleaseDC(hWnd, hdcWindow);
                gfxBitmap.Dispose();
            }
            catch (Exception)
            {
                bitmap.Dispose();
                throw;
            }
            return bitmap;
        }

        public static void AddShapesToBitmap(ref Bitmap bmpTemp, List<Shape> drawObjects)
        {
            foreach (var shape in drawObjects)
            {
                BitmapHandler.AddShapeToBitmap(ref bmpTemp, shape);
            }
        }
    }
}
