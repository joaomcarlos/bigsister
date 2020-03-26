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

        #region message management

        private void checkMessage(string msg)
        {
            //if (msg.Contains("ReadUInt")) // assume it crashed
              //  KillAndRestartWowAndBot();
            //if (msg.Contains("Please login to your WoW character and then restart Global.Honorbuddy"))
              //  KillAndRestartWowAndBot();
           // if (msg.Contains("Not connected to WoWInstance."))
             //   KillAndRestartWowAndBot();
            if (msg.Contains("SESSION LIMIT") || msg.Contains("Reached maximum allowed sessions!") || msg.Contains("Please auth first"))
            {

                //Thread.Sleep(30 * 1000);
                _stopAndGo = true;
                LoginBot();
            }
            if (msg.Contains("is stopped."))
                LoginBot();
            if (msg.Contains("is there a valid wow connection"))
                KillAndRestartWowAndBot();

            if (msg != LastBotMessage)
            {
                // its running
                LastBotActivity = DateTime.Now;
                LastBotMessage = msg;
                return;
            }
            if (LastBotActivity.AddMinutes(5).CompareTo(DateTime.Now) <= -1)
            {
                //last activity 5 minute ago, raise red alert
                //killAndRestartWowAndBot();
                Log("Last Activity received on: " + LastBotActivity.ToShortTimeString());
                Log("Last bot activity was over 5 minutes ago, restarting");
                KillAndRestartWowAndBot();
            }
        }

        #endregion

    }
}