using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;


class KeyboardEmulator
{

    public const UInt32 WM_CHAR = 0x0102;
    public const UInt32 WM_SYSKEYDOWN = 0x0104;
    public const UInt32 WM_KEYDOWN = 0x0100;
    public const UInt32 WM_KEYUP = 0x0101;

    private IntPtr _wowHandle;
    private bool _kbEmu = true;
    private AutomationElement _ae;

    public KeyboardEmulator(IntPtr p)
    {
        _wowHandle = p;
        _kbEmu = true;
    }
    public KeyboardEmulator(IntPtr p, AutomationElement ae, bool keyboardEmulation)
    {
        _wowHandle = p;
        _kbEmu = keyboardEmulation;
        _ae = ae;
    }

    #region pinvoke
    [DllImport("user32.dll")]
    public static extern int FindWindow(
    string lpClassName, // class name
    string lpWindowName // window name
    );
    [DllImport("user32.dll")]
    public static extern int SendMessage(
    int hWnd, // handle to destination window
    uint Msg, // message
    int wParam, // first message parameter
    int lParam // second message parameter
    );

    [DllImport("user32.dll")]
    public static extern int PostMessage(
    int hWnd, // handle to destination window
    uint Msg, // message
    int wParam, // first message parameter
    int lParam // second message parameter
    );
    #endregion

    public void SendString(string message)
    {
        if(_kbEmu)
            SendString(_wowHandle, message);
        else
        {
            _ae.SetFocus();
            SendKeys.SendWait(message);
        }
    }
    public  void SendString(IntPtr handle, string message)
    {
        if (message.Contains("{"))
        {
            PostMessage((int)handle, WM_KEYDOWN, (int)ConvertCharToKey(message), 0);
            PostMessage((int)handle, WM_KEYUP, (int)ConvertCharToKey(message), 0);
            return;
        }
        foreach (var s in message)
        {
            PostMessage((int)handle, WM_CHAR, (int)ConvertCharToKey("" + s), 0);
            Thread.Sleep(10);
        }
    }
    public  Keys ConvertCharToKey(string c)
    {

        switch (c)
        {
            case "{ENTER}":
            case "{enter}":
                return Keys.Enter;
            case "{DOWN}":
            case "{down}":
                return Keys.Down;
            case "{UP}":
            case "{up}":
                return Keys.Up;
            case "{TAB}":
            case "{tab}":
                return Keys.Tab;

            case "@":
                return (Keys)64;
            case ".":
                return (Keys)46;
            case "+":
                return (Keys)43;
            case "_":
                return (Keys)95;
            case "-":
                return (Keys)45;


            case "0":
                return (Keys)48;
            case "1":
                return (Keys)49;
            case "2":
                return (Keys)50;
            case "3":
                return (Keys)51;
            case "4":
                return (Keys)52;
            case "5":
                return (Keys)53;
            case "6":
                return (Keys)54;
            case "7":
                return (Keys)55;
            case "8":
                return (Keys)56;
            case "9":
                return (Keys)57;


        }
        //return Keys.NoName;
        return (Keys)Enum.Parse(typeof(Keys), c.ToUpper());
    }
}

