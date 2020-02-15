using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Screenshot
{
    public static class Utility
    {
        public static void NormalizePts(ref Point start, ref Point end)
        {
            if (end.X < start.X)
            {
                int temp = end.X;
                end.X = start.X;
                start.X = temp;
            }
            if (end.Y < start.Y)
            {
                int temp = end.Y;
                end.Y = start.Y;
                start.Y = temp;
            }
        }
        
        public static Point GetFormLocationFromBitmapSize(Size size)
        {
            Size fullSize = GetSizeBasedOnBitmapSize(size);
            
            Screen[] screens = Screen.AllScreens;
            int xPos = 0, yPos = 0;
            var indexes = screens.IndexesWhere(x => fullSize.Height <= x.Bounds.Height  && fullSize.Width <= x.Bounds.Width );
            if(indexes.Count != 0)
            {
                for (int i = 0; i < indexes[0]; i++)
                {
                    xPos += screens[i].Bounds.Width;
                }
            }
            return new Point(xPos, yPos);
        }

        public static Size GetSizeBasedOnBitmapSize(Size bmpSize)
        {
            Screen[] screens = Screen.AllScreens;

            //Find a screen in which this bitmap can fit. 
            //i.e., height of screen >= height of bmp and width of screen >= width of bmp
            //If no such screen is found, return the max height and addition of more than one screen that can fit the width
            var screen = screens.Where(x => (x.Bounds.Height >= bmpSize.Height && x.Bounds.Width >= bmpSize.Width)).FirstOrDefault();
            if (screen != null)
            {
                return new Size(screen.Bounds.Width, screen.Bounds.Height);
            }


            int height = screens.Select(x => x.Bounds.Height).Max();
            Size sizeToDisplay = new Size(0, height);
            for (int i = 0; i < screens.Length; i++)
            {
                sizeToDisplay.Width += screens[i].Bounds.Width;
                if (sizeToDisplay.Width >= bmpSize.Width)
                    break;
            }
            return sizeToDisplay;
        }

        public static TaskBarLocation GetTaskBarLocation()
        {
            TaskBarLocation taskBarLocation = TaskBarLocation.BOTTOM;
            bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
            if (taskBarOnTopOrBottom)
            {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0) taskBarLocation = TaskBarLocation.TOP;
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                {
                    taskBarLocation = TaskBarLocation.LEFT;
                }
                else
                {
                    taskBarLocation = TaskBarLocation.RIGHT;
                }
            }
            return taskBarLocation;
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public static Rectangle NormalizeRect(this Rectangle rect)
        {
            int left = rect.Left, right = rect.Right, top = rect.Top, bottom = rect.Bottom;
            if (left > right)
                Utility.Swap(ref left, ref right);
            if (top > bottom)
                Utility.Swap(ref top, ref bottom);

            return new Rectangle(left, top, right - left, bottom - top);

        }

        public static bool PtInRect(this Rectangle rectangle, Point pt)
        {
            Rectangle rect = rectangle.NormalizeRect();
            if (pt.X >= rect.Left && pt.X <= rect.Right && pt.Y >= rect.Top && pt.Y <= rect.Bottom)
                return true;
            return false;
        }

        public static void WriteSettings(MainForm form)
        {
            FTPSettings ftpSettings = form.ftpSettings;
            Properties.Settings.Default.PenWidth = form.PenSize;
            Properties.Settings.Default.Opacity = form.ShapeOpacity;
            Properties.Settings.Default.ArrowSize = form.ArrowSize;
            Properties.Settings.Default.FontName =  form.txtFont.Name;
            Properties.Settings.Default.FontSize = form.txtFont.Size;
            Properties.Settings.Default.Color= form.DrawingColor;
            Properties.Settings.Default.FTPServer = ftpSettings.FTPServer;
            Properties.Settings.Default.FTPPort = ftpSettings.FTPPort;
            Properties.Settings.Default.FTPUser = ftpSettings.FTPUser;
            SimplerAES aes = new SimplerAES();
            string encPwd = ftpSettings.FTPPwd == null ? "" : ftpSettings.FTPPwd;
            encPwd = aes.Encrypt(encPwd);
            Properties.Settings.Default.FTPPwd = encPwd;
            Properties.Settings.Default.AnonymousLogin = ftpSettings.AnonymousLogin;
            Properties.Settings.Default.UseProxyServer = ftpSettings.UseProxy;
            Properties.Settings.Default.ProxyServer = ftpSettings.PrxyServer;
            Properties.Settings.Default.ProxyUser = ftpSettings.PrxyUser;
            string prxyPwd = ftpSettings.PrxyPwd == null ? "" : ftpSettings.PrxyPwd;
            prxyPwd = aes.Encrypt(prxyPwd);
            Properties.Settings.Default.ProxyPassword = prxyPwd;
            Properties.Settings.Default.ProxyPort = ftpSettings.PrxyPort;
            Properties.Settings.Default.DefaultImagesLocation = ftpSettings.DefaultImagesLocation;
            Properties.Settings.Default.GridColor = form.GridColor;
            Properties.Settings.Default.NoOfHistoryFiles = form.NoOfHistoryItems;

            Properties.Settings.Default.Save();
        }

        public static void ReadSettings(MainForm form)
        {
            FTPSettings ftpSettings = new FTPSettings();
            form.PenSize = Properties.Settings.Default.PenWidth;
            form.ShapeOpacity = Properties.Settings.Default.Opacity;
            form.ArrowSize = Properties.Settings.Default.ArrowSize;

            form.txtFont = new Font(Properties.Settings.Default.FontName, Properties.Settings.Default.FontSize, FontStyle.Regular, GraphicsUnit.Pixel);

            form.DrawingColor = Properties.Settings.Default.Color;
            ftpSettings.FTPServer = Properties.Settings.Default.FTPServer;
            ftpSettings.FTPPort = Properties.Settings.Default.FTPPort;
            ftpSettings.FTPUser = Properties.Settings.Default.FTPUser;

            string temp = Properties.Settings.Default.FTPPwd;
            SimplerAES aes = new SimplerAES();
            ftpSettings.FTPPwd = temp == "" ? "" : aes.Decrypt(temp);
            
            ftpSettings.AnonymousLogin = Properties.Settings.Default.AnonymousLogin;
            ftpSettings.UseProxy = Properties.Settings.Default.UseProxyServer;
            ftpSettings.PrxyServer = Properties.Settings.Default.ProxyServer;
            ftpSettings.PrxyUser = Properties.Settings.Default.ProxyUser;

            temp = Properties.Settings.Default.ProxyPassword;
            ftpSettings.PrxyPwd = temp == "" ? "" : aes.Decrypt(temp);
            
            ftpSettings.PrxyPort = Properties.Settings.Default.ProxyPort;
            ftpSettings.DefaultImagesLocation = Properties.Settings.Default.DefaultImagesLocation;
            form.GridColor = Properties.Settings.Default.GridColor;
            form.ftpSettings = ftpSettings;
            form.NoOfHistoryItems = Properties.Settings.Default.NoOfHistoryFiles;
        }

    }

    public static class IEnumerableExtensions
    {
        public static int IndexWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            int index = 0;
            while (enumerator.MoveNext())
            {
                TSource obj = enumerator.Current;
                if (predicate(obj))
                    return index;
                index++;
            }
            return -1;
        }

        public static List<int> IndexesWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            List<int> indexes = new List<int>();
            int index = 0;
            while (enumerator.MoveNext())
            {
                TSource obj = enumerator.Current;
                if (predicate(obj))
                    indexes.Add(index);
                index++;
            }
            return indexes;
        }
    }
}
