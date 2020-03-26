using System;
using System.Runtime.InteropServices;


    public static class Window
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindow(
         string lpClassName,
         string lpWindowName);

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport(@"user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public static void SetPositionSize(string name, int x, int y, int width, int height)
        {
            IntPtr hWind = FindWindow(null, name);
            SetWindowPos(hWind, (IntPtr)null, x, y, width, height, 0u);
        }

        public static void SetPositionSize(IntPtr handle,string text, int x, int y, int width, int height)
        {
            //IntPtr hWind = FindWindow(null, name);
            SetWindowPos(handle, (IntPtr)null, x, y, width, height, 0u);
            SetWindowText(handle, text);
        }
        [DllImport("user32.dll", CharSet=CharSet.Auto,SetLastError=true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet=CharSet.Auto,SetLastError=true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        

    }
