
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace BigSister
{
    class Restarter
    {
        public Restarter(ref Settings sets,ref Process bot,ref Process wow)
        {
            this.Sets = sets;
            this.Wow = wow;
            this.Bot = bot;
        }
       

        public Action Status = Action.Waiting;
        public Settings Sets;

        public Process Bot;
        public Process Wow;

        #region Sequences
        public void KillWowAndBot()
        {
            try
            {
                Wow.Kill();
                Bot.Kill();
            }
            catch (Exception e)
            {
            }

            Wow = null;
            Bot = null;
        }
        public void KillAndRestartWowAndBot()
        {
            //log("killAndRestartWowAndBot requested");
            //tryAttach();
            //KillAndRestartWowAndBot();
            KillWowAndBot();
            StartFreshWowAndBotSequence();
        }
        public void StartFreshWowAndBotSequence()
        {
            Status = Action.StartingWoW;
            Do();
            Status = Action.LogginInWoW;
            Do();
            Status = Action.StartingBot;
            Do();
            Status = Action.LoggingInBot;
            Do();

            // everything done..
            Status = Action.Finished;
            Do();
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

        #region FSM
        public enum Action
        {
            StartingWoW,
            LogginInWoW,
            StartingBot,
            LoggingInBot,
            Waiting,
            Finished,
            ForceStop
        }
        private void Do()
        {

            switch (Status)
            {
                case Action.StartingWoW:
                    StartWoW();
                    Thread.Sleep(15000);
                    break;
                case Action.LogginInWoW:
                    LoginWoW();
                    Thread.Sleep(15000);
                    break;
                case Action.StartingBot:
                    StartBot();
                    Thread.Sleep(15000);
                    break;
                case Action.LoggingInBot:
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
                    break;
                
            }
        }

        #endregion

        #region Grunt Work
        private void StartWoW()
        {
            Wow = new Process();
            Wow.StartInfo.FileName = Sets.WoWPath;
            Wow.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            Wow.Start();
            Thread.Sleep(1000);
            Wow.WaitForInputIdle(1000);
        }

        private void StartBot()
        {
            Bot = new Process();
            Bot.StartInfo.FileName = Sets.BotPath;
            Bot.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            Bot.Start();
            Thread.Sleep(1000);
            Bot.WaitForInputIdle(1000);
        }

        public void LoginBot()
        {
            switch (Sets.BotType)
            {
                case Settings.BotTypeEnum.GatherBuddy:
                    LoginGatherer();
                    break;
                case Settings.BotTypeEnum.HonnorBuddyBig:
                    LoginHonorBig();
                    break;
                case Settings.BotTypeEnum.HonnorBuddySmall:
                    LoginHonorSmall();
                    break;

            }
        }
       

        

        public void LoginWoW()
        {
            //log("loginWow");
            if (Wow.Responding)
            {
                AutomationElement aeWoW =
                    AutomationElement.FromHandle(Wow.MainWindowHandle);
                /*
                AutomationElementCollection aeAllTextBoxes =
                    aeWoW.FindAll(TreeScope.Children,
                                  new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                        ControlType.Edit));

                AutomationElement aeTextBox1 = aeAllTextBoxes[0];
                AutomationElement aeTextBox2 = aeAllTextBoxes[0];

                aeTextBox1.SetFocus();
                 */

                aeWoW.SetFocus();
                Thread.Sleep(1000);
                SendKeys.SendWait(Sets.WoWAccountName);
                Thread.Sleep(1000);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(1000);
                SendKeys.SendWait(Sets.WoWAccountPass);
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(5000);
                SendKeys.SendWait("{ENTER}");
                if (Sets.WoWAccountIsMulti)
                {
                    Thread.Sleep(5000);
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }


        public void LoginGatherer()
        {
            if (Bot.HasExited)
                return;
            if (Bot.Responding)
            {
                AutomationElement aeWoW =
                    AutomationElement.FromHandle(Bot.MainWindowHandle);
                AutomationElementCollection aeAllTextBoxes =
                    aeWoW.FindAll(TreeScope.Children,
                                  new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                        ControlType.Edit));

                AutomationElement aeButton = aeWoW.FindFirst(TreeScope.Children,
                                                             new PropertyCondition(AutomationElement.NameProperty,
                                                                                   "Start botting"));
                aeButton.SetFocus();
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
                //botIsRunning = true;
            }
        }

        

        public void LoginHonorSmall()
        {
            if (Bot.Responding)
            {
                AutomationElement aeWoW =
                    AutomationElement.FromHandle(Bot.MainWindowHandle);
                AutomationElementCollection aeAllTextBoxes =
                    aeWoW.FindAll(TreeScope.Children,
                                  new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                        ControlType.Edit));

                AutomationElement aeButton = aeWoW.FindFirst(TreeScope.Children,
                                                             new PropertyCondition(AutomationElement.NameProperty,
                                                                                   "Start botting"));
                aeButton.SetFocus();
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
            }
        }

       

        public void LoginHonorBig()
        {
            if (Bot.Responding)
            {
                AutomationElement aeWoW =
                    AutomationElement.FromHandle(Bot.MainWindowHandle);
                AutomationElementCollection aeAllTextBoxes =
                    aeWoW.FindAll(TreeScope.Children,
                                  new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                        ControlType.Edit));

                AutomationElement aeButton = aeWoW.FindFirst(TreeScope.Children,
                                                             new PropertyCondition(AutomationElement.NameProperty,
                                                                                   "Start botting"));
                aeButton.SetFocus();
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
            }
        }

        #endregion

        #region helpers
        private AutomationElementCollection FindElementFromAutomationID(AutomationElement targetApp, string automationID)
        {
            return targetApp.FindAll(
                TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationID));
        }

        #endregion


    }
}
