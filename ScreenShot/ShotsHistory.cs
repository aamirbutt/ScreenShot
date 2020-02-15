using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

namespace Screenshot
{
    class ShotsHistory
    {
        private Queue<string> _filePaths = new Queue<string>();
        private string _folderPath;
        private int _size;

        public ShotsHistory(int size)
        {
            _size = size;
            _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _folderPath += @"\ScreenShot\";
            if (Directory.Exists(_folderPath))
                Directory.Delete(_folderPath, true);
            Directory.CreateDirectory(_folderPath);
        }

        private string GetFilePath(Bitmap bitmap)
        {
            DateTime time = DateTime.Now;
            string strFileName = String.Format("{0}{1}{2}_{3}{4}{5}{6}.png", time.Year, time.Month, time.Day,
                time.Hour, time.Minute, time.Second, time.Millisecond);
            string fullpath = _folderPath + strFileName;
            try
            {
                bitmap.Save(fullpath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return fullpath;
        }

        public void AddBitmapToHistory(Bitmap bitmap)
        {
            string filePath = GetFilePath(bitmap);
            if (_filePaths.Count >= _size)
            {
                string path = _filePaths.Dequeue();
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                { }
            }
            _filePaths.Enqueue(filePath);
        }

        public string GetElementAt(int index)
        {
            if (_filePaths.Count <= index)
            {
                return null;
            }
            return _filePaths.ElementAt(index);
        }

        public int GetShotCount()
        {
            return _filePaths.Count;
        }
    }
}
