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

        #region Sequences

        public void KillBotOnly()
        {
            Log("KillBot requested");
            if (BotInstance == null)
                return;
            try
            {
                if (BotInstance != null)
                    BotInstance.Kill();
            }
            catch (Exception e)
            {
                Log("Exception in trying to kill bot: " + e);
            }

            BotInstance = null;
        }
        public void KillWowAndBot()
        {
            Log("KillWowAndBot requested");
            if (WoWInstance == null && BotInstance == null)
                return;
            try
            {
                if (WoWInstance != null)
                    WoWInstance.Kill();
                if (BotInstance != null)
                    BotInstance.Kill();
            }
            catch (Exception e)
            {
                Log("Exception in trying to kill wow and bot: " + e);
            }

            WoWInstance = null;
            BotInstance = null;
        }

        public void KillAndRestartWowAndBot()
        {
            Log("killAndRestartWowAndBot requested");
            //tryAttach();
            //KillAndRestartWowAndBot();
            Om = null;
            KillWowAndBot();
            StartFreshWowAndBotSequence();
        }
        public void StartFreshWowAndBotSequence()
        {
            BSController.QueueForControl(this);

            Log("I am in queue for control, waiting my turn.");
            while (BSController.IsInQueue(this))
            {
                if(!BSController.IsMyTurn(this))
                    Log("I still in queue for control, waiting my turn.");
                //else
                    //Log("Its my turn! Taking control.");

                Thread.Sleep(5000);
            }
        }

        public void StartFreshWowAndBotSequence(bool now)
        {
            Log("StartFreshWowAndBotSequence requested");
            LastBotActivity = DateTime.Now;
            /*
            BabySync.QueueMeForControl(this);
            Random rd = new Random();
            Thread.Sleep(rd.Next(1000,2000));
            while (!BabySync.IsItMyTurn(this))
            {
                Log("Another BabySitter has control, waiting my turn");
                Thread.Sleep(1000);
            }*/
            HasControl = true;
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }
            Status = Action.StartingWoW;
            Do();
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }
            Status = Action.LogginInWoW;
            Do();
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }
            Status = Action.StartingBot;
            Do();
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }
            Status = Action.LoggingInBot;
            Thread.Sleep(1000);
            Do();
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }

            // everything done..
            Status = Action.Finished;
            Do();
            if (Status == Action.ForceRestart && Status == Action.ForceStop)
            {
                HasControl = false;
                return;
            }
            HasControl = false;
        }

        public void StartWoWOnly()
        {
            Status = Action.StartingWoW;
            Do();
            Status = Action.LogginInWoW;
            Do();
            // everything done..
            Status = Action.Finished;
            Do();
        }

        public void StartBotOnly()
        {
            Status = Action.StartingBot;
            Do();
            Status = Action.LoggingInBot;
            Do();
            // everything done..
            Status = Action.Finished;
            Do();
        }

        #endregion

    }
}