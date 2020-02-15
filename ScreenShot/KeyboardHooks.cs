using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MouseKeyboardLibrary;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace Screenshot
{
    public class KeyboardHooks: IDisposable
    {
        [CLSCompliant(false)]
        public KeyboardHook kbHook = new KeyboardHook();
        MainForm mainForm;

        public KeyboardHooks(MainForm form)
        {
            mainForm = form;
            InitializeKBHooks();
        }

        public void InitializeKBHooks()
        {
            kbHook.KeyDown +=new System.Windows.Forms.KeyEventHandler(kbHook_KeyDown);
            kbHook.Start();
        }

        public void kbHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (mainForm == null)
                return;

            if (e.Alt && e.KeyCode == Keys.PrintScreen)
            {
                Debug.WriteLine("In keyboard hook, capture wnd");
                mainForm.currentState = CurrentState.STATE_CAPTURINGWND;
            }
            else if (e.KeyCode == Keys.PrintScreen)
            {
                Debug.WriteLine("In keyboard hook, capture screen");
                mainForm.StartFullScreenCapturing();
            }
        }

        public void Dispose()
        {
            kbHook.Stop();
        }
    }

    public class MouseHooks : IDisposable
    {
        [CLSCompliant(false)]
        public MouseHook mouseHook = new MouseHook();
        public MainForm mainForm;
        public MouseHooks(MainForm form)
        {
            InitializeMouseHooks();
            mainForm = form;
        }

        public void InitializeMouseHooks()
        {
            mouseHook.MouseMove +=new MouseEventHandler(mouseHook_MouseMove);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.Start();
        }

        public void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (mainForm.currentState == CurrentState.STATE_CAPTURINGWND)
            {
                mainForm.HighlightCapturingWindows(new Point(e.X, e.Y));
            }            
        }

        public void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (mainForm.currentState == CurrentState.STATE_CAPTURINGWND)
            {
                mainForm.CaptureWindow();
            }
        }

        public void Dispose()
        {
            mouseHook.Stop();
        }
    }

}
