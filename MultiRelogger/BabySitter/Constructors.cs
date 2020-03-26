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

        public BabySitter(Settings sets, Process wow, Process bot)
        {
            Sets = sets;
            WoWInstance = wow;
            BotInstance = bot;
            Log("Found bot: " + bot.Id + " attached to : " + wow.Id);
            _instances.Add(this);
            //Restarter = new Restarter(ref sets,ref bot, ref wow);
        }

        private bool _debug = false;
        public BabySitter(Settings sets)
        {
            Sets = sets;
            if (_debug)
            {
                Process[] processlist = Process.GetProcesses();

                int numberOfWows = 0;
                int numberOfBots = 0;
                foreach (Process p in processlist)
                {
                    if (p.ProcessName == sets.WoWName)
                    {
                        WoWInstance = p;
                        Log("found wow " + p.Id);
                        numberOfWows++;
                    }

                    if (p.ProcessName == sets.BotName)
                    {
                        BotInstance = p;
                        Log("found bot " + p.Id);
                        numberOfBots++;
                    }
                }
            }
            _instances.Add(this);
        }
        public void Dispose()
        {
            KillBabySitter();
        }

        public void KillBabySitter()
        {
            try
            {

                foreach (Thread t in ThreadList)
                {
                    t.IsBackground = true;
                    t.Abort();
                }
            }
            catch (Exception e) { }
        }


    }
}