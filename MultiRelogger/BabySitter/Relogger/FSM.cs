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


        #region FSM type thing

        public enum Action
        {
            StartingWoW,
            LogginInWoW,
            StartingBot,
            LoggingInBot,
            Waiting,
            Finished,
            ForceStop,
            ForceRestart
        }

        private void Do()
        {
            try
            {
                if (Om == null && !(Status == Action.StartingWoW))
                    Om = new ObjectManager(WoWInstance.Id);
                switch (Status)
                {
                    case Action.StartingWoW:
                        StartWoW();
                        //Thread.Sleep(5000);
                        break;
                    case Action.LogginInWoW:
                        LoginWoW();
                        break;
                    case Action.StartingBot:
                        StartBot();
                        while (!BotInstance.Responding)
                            Thread.Sleep(1500);
                        break;
                    case Action.LoggingInBot:
                        if (Sets.LightMode)
                        {
                            //Status = Action.Finished;
                           // return;
                        }
                        Thread.Sleep(1000);
                        LoginBot();
                        Thread.Sleep(1000);
                        break;
                    case Action.Waiting:
                        Thread.Sleep(1000);
                        break;
                    case Action.Finished:
                        break;
                    case Action.ForceStop:
                        KillWowAndBot();
                        Thread.Sleep(1000);
                        break;
                    case Action.ForceRestart:
                        KillAndRestartWowAndBot();
                        break;
                }
            }
            catch (Exception e)
            {
                Log("Exception in FSM Do(): " + e);
                Status = Action.ForceRestart;
                BabySitterThread2.Abort();
            }
        }

        #endregion
    }
}