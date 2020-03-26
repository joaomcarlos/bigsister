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


        #region diferent bot type managements

        public Thread TupdatePerformanceCounters;

        private void UpdateBotStatus()
        {
            if (isValidProcess(WoWInstance) && isValidProcess(BotInstance))
            {
                WoWInstance.Refresh();
                BotInstance.Refresh();
            }
            if (TupdatePerformanceCounters == null && !Sets.LightMode)
            {
                TupdatePerformanceCounters = new Thread(UpdatePerformanceCounters);
                TupdatePerformanceCounters.IsBackground = true;
                TupdatePerformanceCounters.Start();
                ThreadList.Add(TupdatePerformanceCounters);
            }
            if (Om == null && (WoWInstance != null) && (Status != Action.StartingWoW))
            {
                Om = new ObjectManager(WoWInstance.Id);
            }
            if (Om != null)
                CharName = Om.LocalPlayerName;

            ReloggerStatus = (Om != null && Om.IsInGame) ? "InGame" : "NotInGame";

            if (Sets.LightMode)
            {
                ReloggerStatus = BotLog = (Om != null && Om.IsInGame) ? "InGame" : "NotInGame";
                if(Om != null && !Om.IsInGame)
                    KillAndRestartWowAndBot();
                return;
            }
            switch (Sets.BotType)
            {
                case Settings.BotTypeEnum.GatherBuddy:
                    UpdateGatherStatus();
                    break;
                case Settings.BotTypeEnum.HonnorBuddyBig:
                    UpdateHBbigStatus();
                    break;
                case Settings.BotTypeEnum.HonnorBuddySmall:
                    UpdateHBsmallStatus();
                    break;
            }
        }

        public string ReadBotLogByAutomationLib()
        {
            if (BotInstance == null)
                return "BotInstanceStillNull";
            if (Sets.BotType == Settings.BotTypeEnum.GatherBuddy)
            {
                try
                {
                    AutomationElement aeBotInstance = AutomationElement.FromHandle(BotInstance.MainWindowHandle);

                    AutomationElementCollection aeBotLog = aeBotInstance.FindAll(TreeScope.Children,
                                                                                        new PropertyCondition(
                                                                                            AutomationElement.
                                                                                                ControlTypeProperty,
                                                                                            ControlType.Document));

                    //this is a better way, but needs correct name, find it later in SpyUI
                    //AutomationElementCollection aeBotLog = FindElementFromAutomationID(aeBotInstance, "textBoxLog");

                    foreach (AutomationElement ae in aeBotLog)
                    {
                        var textboxPattern = (TextPattern)ae.GetCurrentPattern(TextPattern.Pattern);
                        string enteredText = textboxPattern.DocumentRange.GetText(-1).Trim();
                        BotLog = enteredText;
                        string lastLine = enteredText.Substring(enteredText.LastIndexOf(Environment.NewLine) + 2);

                        checkMessage(lastLine);
                        return BotLog;
                    }
                    Log("Couldnt read log");
                }
                catch (Exception e)
                {
                    Log("Exception in (gatherer) readBotLog:+ " + e);
                    Log("Make sure bot isnt minimized to tray");
                }
            }
            if (Sets.BotType == Settings.BotTypeEnum.HonnorBuddySmall)
            {
                try
                {
                    AutomationElement aeBotInstance = AutomationElement.FromHandle(BotInstance.MainWindowHandle);

                    AutomationElementCollection aeAllTextBoxes = aeBotInstance.FindAll(TreeScope.Descendants,
                                                                                       new PropertyCondition(
                                                                                           AutomationElement.
                                                                                               ControlTypeProperty,
                                                                                           ControlType.Document));

                    //this is a better way, but needs correct name, find it later in SpyUI
                    //AutomationElementCollection aeBotLog = FindElementFromAutomationID(aeWoW,"textBoxLog");

                    foreach (AutomationElement ae in aeAllTextBoxes)
                    {
                        var textboxPattern = (TextPattern)ae.GetCurrentPattern(TextPattern.Pattern);
                        string enteredText = textboxPattern.DocumentRange.GetText(-1);
                        BotLog = enteredText;

                        String s1 = enteredText;

                        //s1 = s1.Replace("\r\n", "\n");
                        s1 = s1.Substring(0, s1.LastIndexOf("\r") - 1);

                        s1 = s1.Substring(s1.LastIndexOf("\r") + 1);

                        string lastLine = s1;

                        //string lastLine = enteredText.Substring(enteredText.LastIndexOf(Environment.NewLine) + 1);

                        checkMessage(lastLine);
                        return BotLog;
                    }
                }
                catch (Exception e)
                {
                    Log("Exception (hbsmall) in readBotLog:+ " + e);
                    Log("Make sure bot isnt minimized to tray");
                }
            }

            return BotLog;
        }
        public string ReadBotLogByLogFile()
        {
            if (BotInstance == null)
                return "BotInstanceStillNull";
            if (Sets.BotType == Settings.BotTypeEnum.GatherBuddy)
            {
                try
                {
                    
                    string filePath = Sets.BotPath.Substring(0, Sets.BotPath.LastIndexOf("\\")) + "\\Debug.html";
                    if (File.Exists(filePath))
                    {
                        StreamReader reader = new StreamReader(filePath);
                        string content = reader.ReadToEnd();
                        reader.Close();
                        string enteredText = content;
                        BotLog = enteredText;
                        string lastLine = enteredText.Substring(enteredText.LastIndexOf("["),
                                                                enteredText.LastIndexOf("<br>") -
                                                                enteredText.LastIndexOf("["));

                        checkMessage(lastLine);
                        return BotLog;
                    }
                    Log("Couldnt read log");
                }
                catch (Exception e)
                {
                    Log("Exception in (gatherer) readBotLog:+ " + e);
                    Log("Make sure bot is making a log file");
                }
            }
            if (Sets.BotType == Settings.BotTypeEnum.HonnorBuddySmall || Sets.BotType == Settings.BotTypeEnum.HonnorBuddyBig)
            {
                try
                {
                    string filePath = findNewestHBLog(Sets.BotPath);
                    if (File.Exists(filePath))
                    {
                        StreamReader reader = new StreamReader(filePath);
                        string content = reader.ReadToEnd();
                        reader.Close();
                        string enteredText = content;
                        BotLog = enteredText;
                        string lastLine = enteredText.Substring(enteredText.LastIndexOf("["),
                                                                enteredText.LastIndexOf("\n") -
                                                                enteredText.LastIndexOf("["));

                        checkMessage(lastLine);
                        return BotLog;
                    }
                    Log("Couldnt read log");
                    
                }
                catch (Exception e)
                {
                    Log("Exception (hbsmall) in readBotLog:+ " + e);
                    Log("Make sure bot is making logs");
                }
            }

            return BotLog;
        }

        private void UpdateGatherStatus()
        {
            try
            {
                //ReadBotLogByAutomationLib();
                ReadBotLogByLogFile();

            }
            catch (Exception e)
            {
                Log("Exception in updateGatherer:+ " + e);
            }
        }
        private void UpdateHBsmallStatus()
        {
            try
            {
                ReadBotLogByAutomationLib();
                //ReadBotLogByLogFile();
            }
            catch (Exception e)
            {
                Log("Exception in updateHBsmall:+ " + e);
            }
        }
        private void UpdateHBbigStatus()
        {
            try
            {
                ReadBotLogByAutomationLib();
                //ReadBotLogByLogFile();
            }
            catch (Exception e)
            {
                Log("Exception in updateHBbig:+ " + e);
            }
        }

        #endregion
    }
}