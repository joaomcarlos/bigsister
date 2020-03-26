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
      
        public void BabySit()
        {
            //LastBotActivity = DateTime.Now;
            if (Watching)
                return;
            Watching = true;
            if (BabySitterThread == null || !BabySitterThread.IsAlive)
            {
                BabySitterThread = new Thread(BabySit2) { Priority = ThreadPriority.BelowNormal };
                BabySitterThread.IsBackground = true;
                BabySitterThread.Start();
                ThreadList.Add(BabySitterThread);
                Log("Start Baby Sitting");
            }
            //Thread.Sleep(10000); //sleeping this (non threaded will delay GUI)
        }
        public Thread BabySitterThread2;
        private void BabySit2()
        {
            while (Watching)
            {
                if (BabySitterThread2 == null || !BabySitterThread2.IsAlive)
                {
                    try
                    {
                        Log("No suitable thread was found for Babysitting, yet Watching = " + Watching);
                        Log("Beeing a good sister and hanging up the phone to watch the kids");
                        BabySitterThread2 = new Thread(BabySit3);
                        BabySitterThread2.IsBackground = true;
                        BabySitterThread2.Priority = ThreadPriority.BelowNormal;
                        BabySitterThread2.Start();
                        ThreadList.Add(BabySitterThread2);
                        Log("BabySitting " + Sets.Alias);
                    }catch(Exception e)
                    {
                        Log("Something along the way happen, and BabySitterTrhead was no good, aborting it.");
                        if(BabySitterThread2 != null)
                            BabySitterThread2.Abort();
                    }
                }
                Thread.Sleep(5000);
            }
        }
        private void BabySit3()
        {
            while (Watching)
            {
                try
                {
                    if (Om == null && isValidProcess(WoWInstance))
                    {
                        Om = new ObjectManager((int)WoWInstance.Handle);
                    }
                    UpdateBotStatus();


                    if (isValidProcess(WoWInstance) && isValidProcess(BotInstance))
                    {
                        if (WoWInstance.HasExited || BotInstance.HasExited)
                            KillAndRestartWowAndBot();
                    }
                    else
                    {
                        KillAndRestartWowAndBot();
                    }
                    if (_shouldBeInGame && Om != null && isValidProcess(WoWInstance) && !Om.IsInGame &&
                        !Om.IsLoadingOrConnecting)
                    {
                        Log("ShouldBeInGame = " + _shouldBeInGame + ", but something went wrong with WoW.");
                        _shouldBeInGame = false;
                        Log("ShouldBeInGame = " + _shouldBeInGame);
                        KillAndRestartWowAndBot();
                    }
                    if (Om != null && !_shouldBeInGame && isValidProcess(WoWInstance) && Om.IsInGame)
                    {
                        // cool we are ingame xD
                        _shouldBeInGame = true;
                        Log("Cool we are ingame -> ShouldBeInGame = " + _shouldBeInGame);
                    }
                }
                catch (Exception e)
                {
                    Log("Error in Watch loop" + e);
                    Log("Are you running BigSister as admin?");
                    Log("Admin check returns :" + checkRights());
                }
                Thread.Sleep(1000);
            }
            Log("Exit Watching Loop, no longer Baby Sitting");
            //BabySitterThread2.Abort();
        }

    }
}