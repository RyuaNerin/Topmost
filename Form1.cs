using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Topmost
{
    public partial class Form1 : Form
    {
        readonly NativeMethods.WinEventDelegate m_delegate;
        IntPtr m_hook;

        IntPtr m_hwnd;


        public Form1()
        {
            InitializeComponent();

            this.m_delegate = new NativeMethods.WinEventDelegate(this.WinEventProc);
        }

        private void windowFinder1_SelectedWindow(object sender, RyuaNerin.WindowFinderArgs e)
        {
            this.m_hwnd = e.Handle;
            this.checkBox1.Enabled = true;
            this.checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_hook != IntPtr.Zero)
                NativeMethods.UnhookWinEvent(this.m_hook);

            if (this.checkBox1.Checked)
            {
                this.m_hook = NativeMethods.SetWinEventHook(
                    NativeMethods.EVENT_SYSTEM_FOREGROUND,
                    NativeMethods.EVENT_SYSTEM_FOREGROUND,
                    IntPtr.Zero,
                    this.m_delegate,
                    0,
                    0,
                    NativeMethods.WINEVENT_OUTOFCONTEXT | NativeMethods.WINEVENT_SKIPOWNPROCESS);
            }
        }

        private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            NativeMethods.SetWindowPos(
                this.m_hwnd,
                new IntPtr(NativeMethods.HWND_TOPMOST),
                0,
                0,
                0,
                0,
                NativeMethods.DeferWindowPosCommands.SWP_NOMOVE | NativeMethods.DeferWindowPosCommands.SWP_NOSIZE | NativeMethods.DeferWindowPosCommands.SWP_SHOWWINDOW);
        }

        private static class NativeMethods
        {
            public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

            [DllImport("user32.dll")]
            public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

            [DllImport("user32.dll")]
            public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, DeferWindowPosCommands uFlags);

            public const int HWND_TOPMOST = -1;

            public const int EVENT_SYSTEM_FOREGROUND = 0x3;

            public const int WINEVENT_OUTOFCONTEXT = 0;
            public const int WINEVENT_SKIPOWNPROCESS = 2;

            [Flags]
            public enum DeferWindowPosCommands : uint
            {
                SWP_DRAWFRAME = 0x0020,
                SWP_FRAMECHANGED = 0x0020,
                SWP_HIDEWINDOW = 0x0080,
                SWP_NOACTIVATE = 0x0010,
                SWP_NOCOPYBITS = 0x0100,
                SWP_NOMOVE = 0x0002,
                SWP_NOOWNERZORDER = 0x0200,
                SWP_NOREDRAW = 0x0008,
                SWP_NOREPOSITION = 0x0200,
                SWP_NOSENDCHANGING = 0x0400,
                SWP_NOSIZE = 0x0001,
                SWP_NOZORDER = 0x0004,
                SWP_SHOWWINDOW = 0x0040
            };
        }
    }
}
