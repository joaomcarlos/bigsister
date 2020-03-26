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

        #region Grunt Work

        private void StartWoW()
        {
            try
            {
                if (Sets == null || String.IsNullOrEmpty(Sets.WoWPath)
                    || String.IsNullOrEmpty(Sets.RealmName)
                    || String.IsNullOrEmpty(Sets.RealmRegion))
                {
                    Log("Huston we have a problem: setting are still Null or Empty.");
                    if (Sets != null)
                    {
                        Log("WowPath: " + Sets.WoWPath);
                        Log("RealmName: " + Sets.RealmName);
                        Log("RealmRegion: " + Sets.RealmRegion);
                    }
                    else
                    {
                        Log("The whole settings struct is null for some reason.");
                    }
                    throw new Exception("Settings for wowpath,realmname, realmregion were null or whole settings struct was null.");
                }
                ChangeConfig(Sets.WoWConfigPath, Sets.RealmName, Sets.RealmRegion);
                Sleep(2000);
                WoWInstance = new Process
                                  {
                                      StartInfo =
                                          {
                                              FileName = Sets.WoWPath,
                                              WindowStyle = ProcessWindowStyle.Normal
                                          }
                                  };
                WoWInstance.Start();
                //Sleep(1000);
                WoWInstance.WaitForInputIdle(500);

                Log("Waiting for process to start responding.");
                Sleep(2000);

                while (!WoWInstance.Responding)
                {
                    Sleep(500);
                    Log("Waiting for WoW to open");
                }
                Log("WoW is responding");
                Log("Waiting extra 5secs, for everything to load.");
                Sleep(5000);
                if (WoWInstance.MainWindowHandle.ToInt32() > 0)
                    return;

                while (!(WoWInstance.MainWindowHandle.ToInt32() > 0))
                {
                    Log("WoW mainwindowhandle was not yet populated, wait a bit more.");
                    Sleep(1000);
                    WoWInstance.Refresh();
                }
                Log("Lets wait a bit more to make sure WoW window is ready.");
                Sleep(1000);
            }
            catch (Exception e)
            {
                Log("Error Starting wow:" + e);
                BabySitterThread2.Abort();
            }

        }

        private void StartBot()
        {
            try
            {
                Log("Starting Bot, type: " + Sets.BotType);
                BotInstance = new Process();
                BotInstance.StartInfo.FileName = Sets.BotPath;


                string syworkdir = "";
                string[] splitter = Sets.BotPath.Split('\\');
                for (int i = 0; i < splitter.Length - 1; i++)
                    syworkdir += splitter[i] + '\\';
                BotInstance.StartInfo.WorkingDirectory = syworkdir;


                BotInstance.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                if (Sets.BotType == Settings.BotTypeEnum.HonnorBuddyBig || Sets.LightMode)
                    BotInstance.StartInfo.Arguments = "/autostart";
                BotInstance.Start();
                Log("Waiting for bot to start responding.");
                Sleep(1000);
                BotInstance.WaitForInputIdle(1000);
                Log("Waiting for bot GUI to load become stable.");
                if (Sets.BotType == Settings.BotTypeEnum.GatherBuddy || Sets.BotType == Settings.BotTypeEnum.HonnorBuddy2)
                    Sleep(5000);
                else
                    Sleep(20000); //hb takes alot of time    
                Log("Bot Started.");
            }
            catch (Exception e)
            {
                Log("Error Starting bot: " + e);
            }
        }
        public void LoginBot()
        {
            Thread.Sleep(1000);
            LoginBot(false);
        }
        public void LoginBot(bool retry)
        {
            try
            {
                if (!isValidProcess(BotInstance))
                {
                    Log("For some reason BotInstance was not valid, waiting 1sec and retrying...");
                    Thread.Sleep(1000);
                    if(!retry)
                        LoginBot(true);
                    else
                    {
                        KillBotOnly();
                        StartBotOnly();
                    }
                    return;
                }
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
                    case Settings.BotTypeEnum.HonnorBuddy2:
                        LoginHonor2();
                        break;
                }
            }
            catch (Exception e)
            {
                Log("Error Logggingin bot: " + e);
                BabySitterThread2.Abort();
            }
        }

        public void LoginWoW()
        {
            LoginWoWsmart();
            //LoginWoWDumb();
        }
        public void LoginWoWsmart()
        {
            try
            {
                AutomationElement
                    aeWoWInstance = AutomationElement.FromHandle(WoWInstance.MainWindowHandle);


                kb = new KeyboardEmulator(WoWInstance.MainWindowHandle,
                                          aeWoWInstance,
                                          UseKeyboardEmulation);



                if (Om == null)
                    Om = new ObjectManager(WoWInstance.Id);
                while (!Om.IsAtLoginScreen)
                {
                    Log("Not Yet At Login Screen");
                    Thread.Sleep(1500);
                }
                if (!UseKeyboardEmulation)
                    aeWoWInstance.SetFocus();
                Sleep(500);
                Log("putting username");
                kb.SendString(Sets.WoWAccountName);
                Sleep(500);

                kb.SendString("{TAB}");
                Sleep(500);

                Log("putting password");
                kb.SendString(Sets.WoWAccountPass);
                Sleep(500);

                Log("loggin in");
                kb.SendString("{ENTER}");

                if (Sets.WoWAccountIsMulti)
                {
                    Log("Is multi and needs extra work");
                    Sleep(5000);
                    if (Sets.WoWbNetIndex > 0)
                    {
                        for (int i = 0; i < Sets.WoWbNetIndex; i++)
                        {
                            kb.SendString("{DOWN}");
                            Sleep(100);
                        }
                    }
                    kb.SendString("{ENTER}");
                    Log("Selected Account Index: " + Sets.WoWbNetIndex);
                }

                while (!Om.IsAtCharselect)
                {
                    Log("Waiting for charselect screen");
                    Sleep(500);
                    if (Om.IsLoadingOrConnecting)
                    {
                        Log("Queue detected, waiting");
                        continue;
                    }
                    // todo: roam around the realm wizard and select correct server
                    if (Om.IsAtRealmWizard) //hmm! try the selected one :/
                    {
                        Log("Is at realm wizard, need extra enter");
                        kb.SendString("{ENTER}");
                    }
                }
                Log("Character Screen Detected.");
                Sleep(2000);
                while (Om.SelectedCharacterIndex != Sets.WoWAccountCharNumber)
                {
                    Log("Wrong charselect index: " + Om.SelectedCharacterIndex);
                    if (Om.SelectedCharacterIndex > Sets.WoWAccountCharNumber)
                        kb.SendString("{UP}");
                    else
                        kb.SendString("{DOWN}");
                    Sleep(1000);
                }

                Log("Charindex correct: " + Sets.WoWAccountCharNumber + ", entering world");
                Sleep(500);
                kb.SendString("{ENTER}");

                Sleep(1000);
                while (Om.IsLoadingOrConnecting)
                {
                    Sleep(1000);
                    Log("Still loading or connecting");
                }

                while (!Om.IsInGame)
                {
                    Thread.Sleep(1500);
                    Log("Still not ingame");
                }

                // found that loading bot too fast, would sometimes 
                // not allow wow to fully reach ingame status, thus
                // crashing GB, adding extra sleep
                Log("Waiting WoW GUI to load.");
                Sleep(5000);
                Log("WoW GUI loaded, startWoW sequence finished.");
                LastBotActivity = DateTime.Now;
                _shouldBeInGame = true;
                Log("ShouldBeInGame = " + _shouldBeInGame);

            }
            catch (Exception e)
            {
                Log("Exception on login " + e);
                Status = Action.ForceRestart;
                BabySitterThread2.Abort();
                throw e;
            }

        }
        public void LoginWoWDumb()
        {
            try
            {
                AutomationElement
                    aeWoWInstance = AutomationElement.FromHandle(WoWInstance.MainWindowHandle);


                kb = new KeyboardEmulator(WoWInstance.MainWindowHandle,
                                          aeWoWInstance,
                                          UseKeyboardEmulation);



                if (Om == null)
                    Om = new ObjectManager(WoWInstance.Id);
                /*while (!Om.IsAtLoginScreen)
                {
                    Log("Not Yet At Login Screen");
                    Thread.Sleep(1500);
                }*/
                if (!UseKeyboardEmulation)
                    aeWoWInstance.SetFocus();
                Sleep(500);
                Log("putting username");
                kb.SendString(Sets.WoWAccountName);
                Sleep(500);

                kb.SendString("{TAB}");
                Sleep(500);

                Log("putting password");
                kb.SendString(Sets.WoWAccountPass);
                Sleep(500);

                Log("loggin in");
                kb.SendString("{ENTER}");

                if (Sets.WoWAccountIsMulti)
                {
                    Log("Is multi and needs extra work");
                    Sleep(5000);
                    if (Sets.WoWbNetIndex > 0)
                    {
                        for (int i = 0; i < Sets.WoWbNetIndex; i++)
                        {
                            kb.SendString("{DOWN}");
                            Sleep(100);
                        }
                    }
                    kb.SendString("{ENTER}");
                    Log("Selected Account Index: " + Sets.WoWbNetIndex);
                }
                Sleep(5000);
                
                    Log("Waiting for charselect screen");
                    Sleep(500);
                    if (Om.IsLoadingOrConnecting)
                    {
                        Log("Queue detected, waiting");
                    }
                    // todo: roam around the realm wizard and select correct server
                    if (Om.IsAtRealmWizard) //hmm! try the selected one :/
                    {
                        Log("Is at realm wizard, need extra enter");
                        kb.SendString("{ENTER}");
                    }
                
                Log("Character Screen Detected.");
                Sleep(2000);
                while (Om.SelectedCharacterIndex != Sets.WoWAccountCharNumber)
                {
                    Log("Wrong charselect index: " + Om.SelectedCharacterIndex);
                    if (Om.SelectedCharacterIndex > Sets.WoWAccountCharNumber)
                        kb.SendString("{UP}");
                    else
                        kb.SendString("{DOWN}");
                    Sleep(1000);
                }

                Log("Charindex correct: " + Sets.WoWAccountCharNumber + ", entering world");
                Sleep(500);
                kb.SendString("{ENTER}");

                Sleep(1000);
                while (Om.IsLoadingOrConnecting)
                {
                    Sleep(1000);
                    Log("Still loading or connecting");
                }

                while (!Om.IsInGame)
                {
                    Thread.Sleep(1500);
                    Log("Still not ingame");
                }

                // found that loading bot too fast, would sometimes 
                // not allow wow to fully reach ingame status, thus
                // crashing GB, adding extra sleep
                Log("Waiting WoW GUI to load.");
                Sleep(5000);
                Log("WoW GUI loaded, startWoW sequence finished.");
                LastBotActivity = DateTime.Now;
                _shouldBeInGame = true;
                Log("ShouldBeInGame = " + _shouldBeInGame);

            }
            catch (Exception e)
            {
                Log("Exception on login " + e);
                Status = Action.ForceRestart;
                BabySitterThread2.Abort();
                throw e;
            }

        }
        public void LoginWoWDumb2()
        {
            try
            {
                AutomationElement
                    aeWoWInstance = AutomationElement.FromHandle(WoWInstance.MainWindowHandle);


                kb = new KeyboardEmulator(WoWInstance.MainWindowHandle,
                                          aeWoWInstance,
                                          UseKeyboardEmulation);



                if (Om == null)
                    Om = new ObjectManager(WoWInstance.Id);
                if (!UseKeyboardEmulation)
                    aeWoWInstance.SetFocus();
                Sleep(500);
                Log("putting username");
                kb.SendString(Sets.WoWAccountName);
                Sleep(500);

                kb.SendString("{TAB}");
                Sleep(500);

                Log("putting password");
                kb.SendString(Sets.WoWAccountPass);
                Sleep(500);

                Log("loggin in");
                kb.SendString("{ENTER}");

                if (Sets.WoWAccountIsMulti)
                {
                    Log("Is multi and needs extra work");
                    Sleep(5000);
                    if (Sets.WoWbNetIndex > 0)
                    {
                        for (int i = 0; i < Sets.WoWbNetIndex; i++)
                        {
                            kb.SendString("{DOWN}");
                            Sleep(100);
                        }
                    }
                    kb.SendString("{ENTER}");
                    Log("Selected Account Index: " + Sets.WoWbNetIndex);
                }


                    Log("Waiting for charselect screen");
                    Sleep(10000);
                   
                
                
                Sleep(2000);
              

                Log("No idea if Charindex is correct: " + Sets.WoWAccountCharNumber + ", entering world");
                Sleep(500);
                kb.SendString("{ENTER}");

                Sleep(1000);
                
                    Sleep(1000);
                    Log("Still loading or connecting");

                Sleep(20000);

                // found that loading bot too fast, would sometimes 
                // not allow wow to fully reach ingame status, thus
                // crashing GB, adding extra sleep
                Log("Waiting WoW GUI to load.");
                Sleep(5000);
                Log("WoW GUI loaded, startWoW sequence finished.");
                LastBotActivity = DateTime.Now;
                _shouldBeInGame = true;
                Log("ShouldBeInGame = " + _shouldBeInGame);
            }
            catch (Exception e)
            {
                Log("Exception on login " + e);
                Status = Action.ForceRestart;
                BabySitterThread2.Abort();
                throw e;
            }

        }

        public void Sleep(int time)
        {
            Log("Waiting for " + (time * (1 + Sets.SleepMultiplier))/1000 + " seconds.");
            Thread.Sleep((int) (time*(1 + Sets.SleepMultiplier)));
        }

        private bool _stopAndGo = false;
        public void LoginGatherer()
        {
            if (BotInstance.HasExited)
                return;
            if (BotInstance.Responding)
            {
                Log("Bot is responding, Loggin In and Starting");
                /*
                AutomationElement aeBotInstance =
                    AutomationElement.FromHandle(BotInstance.MainWindowHandle);
                AutomationElementCollection aeAllTextBoxes =
                    aeBotInstance.FindAll(TreeScope.Children,
                                          new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                                ControlType.Edit));

                AutomationElement aeButton = aeBotInstance.FindFirst(TreeScope.Children,
                                                                     new PropertyCondition(
                                                                         AutomationElement.NameProperty,
                                                                         "Start botting"));*/


                try
                {
                    AutomationElement aeButton = FindButtonFromText("Start botting");
                    if (aeButton == null)
                    {
                        Log("Start Button not found, bot probably already Started");
                        if (_stopAndGo)
                            aeButton = FindButtonFromText("Stop botting");
                    }
                    if (aeButton != null)
                    {
                        Log("Button found, clicking.");
                        aeButton.SetFocus();
                        Sleep(500);
                        aeButton.SetFocus();
                        kb.SendString(BotInstance.MainWindowHandle, "{ENTER}");
                        //botIsRunning = true;
                    }
                    if (_stopAndGo)
                    {
                        Log("StopNgo detected");
                        _stopAndGo = false;
                        LoginGatherer();
                    }
                }
                catch (Exception e)
                {
                    Log("Error at loggingin, proably already logged in");
                }
            }
        }

        public AutomationElement FindButtonFromText(string text)
        {
            try
            {
                BotInstance.Refresh();
                AutomationElement aeWoWInstance =
                    AutomationElement.FromHandle(BotInstance.MainWindowHandle);
                AutomationElement d = aeWoWInstance.FindFirst(TreeScope.Descendants,
                                               new PropertyCondition(
                                                   AutomationElement.NameProperty,
                                                   text));
                return d;
            }
            catch (Exception e)
            {
                Log("Error finding automation element with name :" + text);
            }
            return null;
        }
        public void LoginHonorSmall()
        {
            if (BotInstance.Responding)
            {
                Log("Bot is responding, loggin in and starting");
                /*
                AutomationElement aeWoWInstance =
                    AutomationElement.FromHandle(BotInstance.MainWindowHandle);
                
                /*AutomationElementCollection aeAllTextBoxes =
                    aeWoWInstance.FindAll(TreeScope.Children,
                                          new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                                ControlType.Edit));
                */
                /* AutomationElement aeButton = aeWoWInstance.FindFirst(TreeScope.Descendants,
                                                                      new PropertyCondition(
                                                                          AutomationElement.NameProperty,
                                                                          "Start"));
                 /*AutomationElementCollection allbuttons =
                     aeWoWInstance.FindAll(TreeScope.Descendants,
                                           new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                                 ControlType.Button));
                 foreach (var allbutton in allbuttons)
                 {
                     //MessageBox.Show(allbutton.ToString());
                 }*/
                try
                {
                    AutomationElement aeButton = FindButtonFromText("Start");
                    if (aeButton == null)
                    {
                        Log("Start Button not found, bot probably already Started");
                        if (_stopAndGo)
                            aeButton = FindButtonFromText("Stop");
                    }
                    if (aeButton != null)
                    {
                        Log("Button found, clicking.");
                        aeButton.SetFocus();
                        Sleep(500);
                        aeButton.SetFocus();
                        kb.SendString(BotInstance.MainWindowHandle, "{ENTER}");
                    }
                    if (_stopAndGo)
                    {
                        Log("StopNgo detected");
                        _stopAndGo = false;
                        LoginHonorSmall();
                    }
                }
                catch (Exception e)
                {
                    Log("Error at loggingin, proably already logged in");
                }
            }
        }

        public void LoginHonor2()
        {
            if (BotInstance.Responding)
            {
                Log("Bot is responding, loggin in and starting");
                //try
               // {
                    AutomationElement
                    botinstance = AutomationElement.FromHandle(BotInstance.MainWindowHandle);
                    botinstance.SetFocus();
                    IntPtr hWnd = BotInstance.MainWindowHandle;
                    bool p = Window.SetForegroundWindow(hWnd);
                    if (!p)
                        Log("Could not set focus");
                    Log("Loggin in bot #1");
                    Sleep(500);
                    SendKeys.SendWait("{TAB}");
                    //kb.SendString(BotInstance.MainWindowHandle, "{TAB}");
                    Sleep(500);
                    SendKeys.SendWait("{TAB}");
                    Sleep(500);
                    SendKeys.SendWait("{TAB}");
                    //kb.SendString(BotInstance.MainWindowHandle, "{TAB}");
                    Sleep(500);
                    SendKeys.SendWait("{ENTER}");
                    //kb.SendString(BotInstance.MainWindowHandle, "{ENTER}");
                    Log("Loggin in bot #2");
                   /* Sleep(15000);
                    Log("Starting bot");
                    SendKeys.SendWait("{TAB}");
                    //kb.SendString(BotInstance.MainWindowHandle, "{TAB}");
                    Sleep(500);
                    SendKeys.SendWait("{ENTER}");
                    //kb.SendString(BotInstance.MainWindowHandle, "{ENTER}");
                */

                    Log("Bot Started");
                   
               // }
                    /*
                catch (Exception e)
                {
                    Log("Error at loggingin, proably already logged in");
                }*/
            }
        }

        public void LoginHonorBig()
        {
            if (BotInstance.Responding)
            {
                /*
                AutomationElement aeWoWInstance =
                    AutomationElement.FromHandle(BotInstance.MainWindowHandle);
                
                AutomationElement aeButton = aeWoWInstance.FindFirst(TreeScope.Descendants,
                                                                     new PropertyCondition(
                                                                         AutomationElement.NameProperty,
                                                                         "Login"));
                aeButton.SetFocus();
                Sleep(1000);
                aeButton.SetFocus();
                kb.SendString("{ENTER}");

                Sleep(15000);
                */
                try
                {
                    BotInstance.Refresh();
                    AutomationElement aeWoWInstance2 =
                        AutomationElement.FromHandle(BotInstance.MainWindowHandle);

                    AutomationElement aeButton2 = aeWoWInstance2.FindFirst(TreeScope.Descendants,
                                                                           new PropertyCondition(
                                                                               AutomationElement.NameProperty,
                                                                               "Start"));
                    /*
                    AutomationElement btn = aeWoWInstance2.FindFirst(TreeScope.Descendants,
                                                                     new PropertyCondition(
                                                                         AutomationElement.AutomationIdProperty,
                                                                         "_btnStart"));*/

                    //AutomationElementCollection btn = FindElementFromAutomationID(aeWoWInstance2, "_btnStart");
                    //btn.SetFocus();
                    if (aeButton2 != null)
                    {
                        aeButton2.SetFocus();
                        Sleep(1000);
                        //aeButton2.SetFocus();
                        kb.SendString(BotInstance.MainWindowHandle, "{ENTER}");
                    }
                    if (_stopAndGo)
                    {
                        Log("StopNgo detected");
                        Log("Button restart not possible yet for HB Big, restarting wow and bot");
                        _stopAndGo = false;
                        KillWowAndBot(); //button restart not possible yet
                    }
                }
                catch (Exception e)
                {
                    Log("Error at loggingin, proably already logged in");
                }
            }
        }

        #endregion

    }
}
