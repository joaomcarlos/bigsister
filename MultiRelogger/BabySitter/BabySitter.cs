#region usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using WoWLib;

#endregion

namespace BigSister
{
    internal partial class BabySitter
    {
        public Thread BabySitterThread;
        public volatile int BotCpuUsage;
        public volatile Process BotInstance;
        public volatile string BotLog;
        public volatile int BotMemUsage;
        public volatile string CharName;
        public DateTime LastBotActivity = DateTime.Now;
        public volatile string LastBotMessage;

        public volatile ObjectManager Om;
        public volatile string ReloggerLog;
        public volatile string ReloggerStatus;
        public volatile Settings Sets;
        public volatile bool Watching;
        public volatile int WowCpuUsage;
        public volatile Process WoWInstance;
        public volatile int WowMemUsage;
        public volatile bool UseKeyboardEmulation = true;
        private volatile KeyboardEmulator kb;

        public volatile Action Status = Action.Waiting;
        public volatile bool HasControl;
        private volatile bool _shouldBeInGame; //isIngame

        private volatile static List<BabySitter> _instances = new List<BabySitter>();
        public volatile static BabySitterSync BabySync = new BabySitterSync();
        public volatile List<Thread> ThreadList = new List<Thread>();

        //public Restarter Restarter;




       


        public void Log(string msg)
        {
            try
            {
                if (!Directory.Exists("Logs"))
                    Directory.CreateDirectory("Logs");
                // create a writer and open the file
                TextWriter tw = new StreamWriter("Logs\\" + Sets.Alias + "_Log.txt", true);
                // write a line of text to the file
                tw.WriteLine(DateTime.Now + " " + msg);
                // close the stream
                tw.Close();

                if (msg.Contains("System."))
                {
                    msg = msg.Substring(0, msg.IndexOf("System."));
                }
                ReloggerLog += msg + "\n";
                ReloggerStatus = msg;
                if(Sets.LightMode || (Om!=null && !Om.IsInGame))
                    LastBotMessage = msg;
            }
            catch (Exception e)
            {
                ReloggerLog += "Failed to write log, please unlock the log.txt";
            }
        }

        public bool isValidProcess(Process p)
        {
            try
            {
                if (p == null)
                {
                    //Log("Not valid because of null");
                    return false;
                }
                if (p.HasExited)
                    return false;
                if (!p.Responding)
                {
                    //Log("Not valid because of not responding");
                    return false;
                }
                if (p.Id <= 0)
                {
                    //Log("Not valid because of pID<=0");
                    return false;
                }
                if (string.IsNullOrEmpty(p.ProcessName))
                {
                    //Log("Not valid because of IsNullOrEmpty(p.ProcessName)");
                    return false;
                }
                /*
                if (p.MainWindowHandle == IntPtr.Zero)
                {
                    Log("Not valid because of p.MainWindowHandle == IntPtr.Zero)");
                    return false;
                }
                */
                return true;
            }
            catch (Exception e)
            {
                Log("Process error: " + e);
            }
            return false;
        }

    }
}