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

        #region performance

        private void UpdatePerformanceCounters()
        {
            //var counter = new PerformanceCounter();
            while (Watching)
            {
                try
                {
                    //MessageBox.Show("perf counter");
                    if (isValidProcess(BotInstance))
                    {
                        var counter = new PerformanceCounter();
                        counter.CategoryName = "Process";
                        counter.CounterName = "% Processor Time";
                        counter.InstanceName = BotInstance.ProcessName;
                        double pPercent = counter.NextValue();
                        Thread.Sleep(50);
                        // yes, i need to call NextValue 2 times in a row :/
                        pPercent = counter.NextValue();
                        if (pPercent > 100)
                            pPercent = 100;
                        BotCpuUsage = (int)Math.Round(pPercent);

                        //todo: find out how to get mem usage for single process
                        WowMemUsage = Convert.ToInt32(WoWInstance.PrivateMemorySize64 / (10 ^ 8));
                        //BotMemUsage = 10;
                    }

                    if (isValidProcess(WoWInstance))
                    {
                        var counter = new PerformanceCounter();
                        counter.CategoryName = "Process";
                        counter.CounterName = "% Processor Time";
                        counter.InstanceName = WoWInstance.ProcessName;
                        double pPercent = counter.NextValue();
                        Thread.Sleep(50);
                        // yes, i need to call NextValue 2 times in a row :/
                        pPercent = counter.NextValue();
                        if (pPercent > 100)
                            pPercent = 100;
                        WowCpuUsage = (int)Math.Round(pPercent);

                        //todo: find out how to get mem usage for single process
                        WowMemUsage = Convert.ToInt32(WoWInstance.PrivateMemorySize64 / (10 ^ 8));
                        //WowMemUsage = 10; 
                    }


                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    //Log("Performance Counters problem :"+e);
                }
                TupdatePerformanceCounters = null;
            }
        }

        

        #endregion

    }
}