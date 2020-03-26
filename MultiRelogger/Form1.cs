// /*
// 	THIS CODE WAS MADE BY SILENT WARRIOR (AKA MRBIG)
// 	
// 	THIS CODE IS NOT TO BE USED OR SHARED WITHOUT MRBIGS
// 	EXPLICIT APPROVAL.
// 
// 	MRBIG CAN BE REACHED AT THESILENTWARRIOR@GMAIL.COM
// 
// 	DONATIONS CAN ALSO BE MADE USING SAME EMAIL
// 
// 	THANK YOU FOR READING MY CODE :)
// 
// */

#region Import Directives



#endregion

namespace BigSister
{
    #region Import Directives

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using GlacialComponents.Controls;

    #endregion

    public partial class Form1 : Form
    {
        #region formload

        private SaveSettings _safSets;

        public Form1()
        {
            InitializeComponent();
        }

        private bool asPassedDate()
        {
            return false;
            DateTime data = new DateTime(2010, 6, 5, 1, 0, 0);
            if (data.CompareTo(DateTime.Now) <= -1)
                return true;
            return false;
        }

        private bool checkRights()
        {
            bool isElevated = false;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isElevated;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (asPassedDate())
            {
                MessageBox.Show("Beta Test is over.");
                Application.Exit();
            }
            if (File.Exists("log.txt"))
                File.Delete("log.txt");
            //GetDetectionStatus();
            //timer2.Stop();
            //timer2.Start();

            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.InitialDirectory = Application.StartupPath;

            ReloadSettings();

            string name = "";
            int size = 10;
            bool lowerCase = false;
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                name = builder.ToString().ToLower();
            else
                name = builder.ToString();

            Text = name;
        }

        #endregion

        //todo: reduze memory and cpu usage of the relogger (more sleeps, more byrefs,less priority)

        //private List<BabySitter> BabySitters = new List<BabySitter>();
        //private List<Settings> BSController.BabySitterSettings = new List<Settings>();


        private bool _blockUpdatingList;
        private DateTime _lastDc;
        private bool _weGotDC;
        private BasicSettings bs = new BasicSettings();
        private BasicSettingsSaver bss = new BasicSettingsSaver(Application.StartupPath);
        private List<Thread> MyThreads = new List<Thread>();

        private bool updatingList;

        public void ReloadSettings()
        {
            bss = new BasicSettingsSaver(Application.StartupPath);
            if (bss.Exists())
                bs = bss.Load();

            _safSets = new SaveSettings(bs.LastUsedProfile);
            if (_safSets.Exists())
            {
                BSController.BabySitterSettings = _safSets.Load();
            }

            //btnBasicSettings.GradientHighColor = bs.AutoRun ? Color.Green : Color.Red;

            if (bs.TopMost)
            {
                btnTopMost.GradientHighColor = Color.Green;
                TopMost = true;
            }
            else
            {
                btnTopMost.GradientHighColor = Color.Red;
                TopMost = false;
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _safSets.Save(BSController.BabySitterSettings);
        }

        private void Log(string text)
        {
            Invoke((ThreadStart) delegate
                                     {
                                         textDebugLog.Text += text + "\n";
                                         textDebugLog.SelectionStart = textDebugLog.Text.Length;
                                         textDebugLog.ScrollToCaret();
                                     });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillAllTherads();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread bu = new Thread(StartMySitters);
            bu.IsBackground = true;
            bu.Start();
            MyThreads.Add(bu);
        }

        private void StartMySitters()
        {
            BSController.SequencialStartAll();
            while (true)
            {
                int n = 0;
                foreach (BabySitter sit in BSController.BabySitters)
                {
                    if (sit.Status != BabySitter.Action.Finished)
                        n++;
                }
                if (n <= 0)
                    break;

                Thread.Sleep(1000);
            }
            RearrangeWindows();
        }

        private bool SettingHasBabySitter(Settings set)
        {
            for (int i = 0; i < BSController.GetAllBabySitters().Count; i++)
            {
                if (BSController.GetAllBabySitters()[i].Sets == set)
                    return true;
            }
            return false;
        }

        private List<Process> GetRunningProcessesForSettings(Settings sets)
        {
            /*
            var wowpList = Process.GetProcessesByName(sets.WoWName);
            var botpList = Process.GetProcessesByName(sets.BotName);
            
            //remove existing bots from list


            foreach (var wow in wowpList)
            {
                foreach (var bot in botpList)
                {
                    if (wow != null && bot != null)
                        {
                            Process process = wow;
                            Process process1 = bot;
                            var existsInList =
                                BSController.GetAllBabySitters().FindAll(sitter => sitter.WoWInstance != process && sitter.BotInstance != process1);
                            if (existsInList.Count > 0)
                            {
                                var babySitter = new BabySitter(sets, wow, bot);
                                if (babySitter.ReadBotLogByAutomationLib().Contains("ProcessId: " + wow.Id + "."))
                                {
                                    var rList = new List<Process> {wow, bot};
                                    return rList;
                                }
                            }
                    }
                } 
            }*/
            return new List<Process>();
        }

        private void UpdateAndCleanBotList()
        {
            for (int i = 0; i < BSController.GetAllBabySitters().Count; i++)
            {
                UpdateBotList(BSController.GetAllBabySitters()[i]);
            }

            if (botList.Items.Count > BSController.BabySitterSettings.Count)
            {
                botList.Items.Clear();
                for (int i = 0; i < BSController.GetAllBabySitters().Count; i++)
                {
                    UpdateBotList(BSController.GetAllBabySitters()[i]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!TopMost && bs.TopMost)
                TopMost = bs.TopMost;
            if (asPassedDate())
            {
                BSController.KillAllBabySitters();
                MessageBox.Show("Beta Test is over.");
                Application.Exit();
            }
            if (!_blockUpdatingList)
            {
                updatingList = true;
                while (_blockUpdatingList)
                    Thread.Sleep(50);
                for (int i = 0; i < BSController.BabySitterSettings.Count; i++)
                {
                    if (!SettingHasBabySitter(BSController.BabySitterSettings[i]))
                    {
                        List<Process> ps = GetRunningProcessesForSettings(BSController.BabySitterSettings[i]);
                        if (ps.Count == 2)
                            BSController.BabySitters.Add(new BabySitter(BSController.BabySitterSettings[i], ps[0], ps[1]));
                        else
                            BSController.BabySitters.Add(new BabySitter(BSController.BabySitterSettings[i]));
                    }
                }
                if (BSController.GetAllBabySitters().Count > BSController.BabySitterSettings.Count)
                {
                    // huston we got a problem
                    this.Text = "Huston we got a problem: More BabySitters than settings... wtf";
                    foreach (BabySitter sitter in BSController.GetAllBabySitters())
                    {
                        sitter.Watching = false;
                    }
                    BSController.GetAllBabySitters().RemoveAll(sitter => true);
                }
                UpdateAndCleanBotList();

                if (botList.Items.Count > 0)
                {
                    GLItem item = botList.Items[_botListSelectedIndex];
                    BabySitter sitter = BSController.GetAllBabySitters().Find(s => s.Sets.Alias == item.SubItems[2].Text);
                    UpdateBotDetails(sitter);
                }
                updatingList = false;
            }
        }

        private void buttonStopScroll_Click(object sender, EventArgs e)
        {
            if (_scrollToCarretOnBotDetails)
                _scrollToCarretOnBotDetails = false;
            else
                _scrollToCarretOnBotDetails = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                btnTopMost.GradientHighColor = Color.Red;
                bs.TopMost = false;
            }
            else
            {
                TopMost = true;
                btnTopMost.GradientHighColor = Color.Green; //goddamn mouse...
                bs.TopMost = true;
            }
            bss.Save(bs);
        }

        private static string GetTripwireStatus()
        {
            String htmlCode;
            try
            {
                WebClient client = new WebClient();
                htmlCode = client.DownloadString("http://tripwire.gatherbuddy.de/");
            }
            catch (Exception e)
            {
                htmlCode = "";
            }
            return htmlCode;
            /* dont act smart :/
             * 
            // used to build entire input
            StringBuilder sb = new StringBuilder();

            // used on each read operation
            byte[] buf = new byte[8192];

            // prepare the web page we will be asking for
            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create("http://tripwire.gatherbuddy.de/");

            // execute the request
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?

            // print out page source
           return (sb.ToString());
             * */
        }

        private void GetDetectionStatus()
        {
            if (!bs.CheckForWarden)
            {
                lblDetectionStatus.Text = "Unchecked";
                return;
            }
            //MessageBox.Show(""+GetTripwireStatus().LastIndexOf("You are safe to use"));
            if (GetTripwireStatus().Contains("You are safe to use Buddy products!"))
            {
                lblDetectionStatus.Text = "Undetected";
                return;
            }
            lblDetectionStatus.Text = "Unknown";
            for (int i = 0; i < BSController.GetAllBabySitters().Count; i++)
            {
                BSController.GetAllBabySitters()[i].Watching = false;
                BSController.GetAllBabySitters()[i].Log("Main problem couldnt read Tripwrite status, force shutdown");
                BSController.GetAllBabySitters()[i].KillWowAndBot();
            }
        }

        private bool GetInternetStatus()
        {
            string strhost = "www.google.com";
            if (strhost.Length > 0)
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                try
                {
                    PingReply reply = pingSender.Send(strhost, timeout, buffer, options);
                    if (reply != null && reply.Status == IPStatus.Success)
                    {
                        lblPing.Text = "Ping:" + reply.RoundtripTime;
                        btnInternetStatus.GradientHighColor = Color.Green;
                        //Console.WriteLine("Ping was successful.");
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("Ping failed.");
                        lblPing.Text = "NA";
                        btnInternetStatus.GradientHighColor = Color.Maroon;
                        if (bs.StopIfNoInternetConn)
                        {
                            _weGotDC = true;
                            for (int i = 0; i < BSController.GetAllBabySitters().Count; i++)
                            {
                                BSController.GetAllBabySitters()[i].Watching = false;
                                BSController.GetAllBabySitters()[i].Log("Internet is down, force shutdown");
                                BSController.GetAllBabySitters()[i].KillWowAndBot();
                                timer2.Interval = bs.RestartIfNoInternetConnAfter*60*1000;
                            }
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer2.Interval != 30000)
                timer2.Interval = 30000;
            else
            {
                if (bs.AutoRun)
                {
                    StartMySitters();
                }
            }

            if (bs.StopIfNoInternetConn && _weGotDC &&
                _lastDc.AddMinutes(bs.RestartIfNoInternetConnAfter).CompareTo(DateTime.Now) <= -1)
            {
                if (GetInternetStatus())
                {
                    _weGotDC = false;
                    StartMySitters();
                }
            }
            GetInternetStatus();
            GetDetectionStatus();
        }

        private void buttonInternetStatus_Click(object sender, EventArgs e)
        {
            GetDetectionStatus();
            GetInternetStatus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (botList.Items.Count > 0)
            {
                GLItem item = botList.Items[_botListSelectedIndex];

                for (int i = 0; i < BSController.BabySitterSettings.Count; ++i)
                    if (BSController.BabySitterSettings[i].Alias == item.SubItems[2].Text)
                    {
                        _blockUpdatingList = true;
                        while (updatingList)
                            Thread.Sleep(50);
                        SettingsForm ss = new SettingsForm(BSController.BabySitterSettings[i]);
                        if (ss.ShowDialog() == DialogResult.OK)
                        {
                            if (ss.ResultSave)
                            {
                            }
                        }
                        if (ss.getSettings != null && ss.getSettings != BSController.BabySitterSettings[i])
                        {
                            BSController.BabySitterSettings[i] = ss.getSettings;
                        }
                        _blockUpdatingList = false;
                        return;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            SettingsForm ss2 = new SettingsForm(settings);
            if (ss2.ShowDialog() == DialogResult.OK)
            {
                if (ss2.ResultSave)
                {
                }
            }
            if (ss2.getSettings != null)
            {
                settings.SetSettings(ss2.getSettings);
                BSController.BabySitterSettings.Add(settings);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _safSets.SavePath = saveFileDialog1.FileName;
                _safSets.Save(BSController.BabySitterSettings);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _safSets.SavePath = openFileDialog1.FileName;
                BSController.BabySitterSettings = _safSets.Load();
                if (BSController.BabySitterSettings != null)
                {
                    bs.LastUsedProfile = _safSets.SavePath;
                    bss.Save(bs);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //BSController.GetAllBabySitters()[0].StartBotOnly();
            //BSController.GetAllBabySitters()[0].Sets.BotType = Settings.BotTypeEnum.HonnorBuddySmall;
            //MessageBox.Show(BSController.GetAllBabySitters()[0].ReadBotLogByAutomationLib());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (BabySitter s in BSController.GetAllBabySitters())
            {
                s.Watching = false;
                s.KillWowAndBot();
            }
            KillAllTherads();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KillAllTherads();
        }

        private void KillAllTherads()
        {
            foreach (Thread t in MyThreads)
            {
                t.Abort();
            }
            foreach (BabySitter s in BSController.GetAllBabySitters())
            {
                s.Watching = false;
                foreach (Thread t in s.ThreadList)
                {
                    t.Abort();
                }
            }
        }

        private void RearrangeWindows()
        {
            try
            {
                int n = 0;
                int colums = 0, rows = 0;
                int height = bs.WowWindowHeight;
                int width = bs.WowWindowWidth;
                int offset = 0;
                int screenN = 0;
                foreach (BabySitter sitter in BSController.GetAllBabySitters())
                {
                    // babynumber
                    n++;

                    if (n > (bs.WowWindowGridRows*bs.WowWindowGridColumns))
                    {
                        offset += bs.WowWindowScreenOffset;
                        n = 0;
                        colums = 0;
                        rows = 0;
                        screenN++;
                    }
                    if (colums > bs.WowWindowGridColumns)
                    {
                        colums = 1;
                        rows++;
                    }
                    if (rows > bs.WowWindowGridRows)
                        rows = 1;
                    int x = bs.WowWindowSpacingWidth + offset + width*colums;
                    int y = bs.WowWindowSpacingHeight + height*rows;

                    //Thread.Sleep(500);
                    if (!sitter.isValidProcess(sitter.WoWInstance) || sitter.WoWInstance == null ||
                        sitter.WoWInstance.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }
                    if (colums >= bs.WowWindowGridColumns && rows <= bs.WowWindowGridRows)
                    {
                        colums = 0;
                        rows++;
                    }

                    Window.SetPositionSize(sitter.WoWInstance.MainWindowHandle, (sitter.Sets.Alias.Length > 0)
                                                                                    ?
                                                                                        sitter.Sets.Alias
                                                                                    : ""
                                                                                      + " - Baby No. " + n +
                                                                                      ((bs.WowWindowScreenNumber > 1)
                                                                                           ?
                                                                                               "Screen: " + screenN
                                                                                           :
                                                                                               ""),
                                           x, y,
                                           width, height);

                    colums++;
                    /*
                if (!sitter.isValidProcess(sitter.BotInstance) || sitter.BotInstance == null ||
                    sitter.BotInstance.MainWindowHandle == null)
                {
                    continue;
                }
                if (colunas >= 5)
                {
                    colunas = 0;
                    linhas++;
                }
                Window.SetPositionSize(sitter.BotInstance.MainWindowHandle,
                                       tamanho*colunas, tamanho*linhas + 1, tamanho, tamanho);
                colunas++;
                */
                }
            }
            catch (Exception e)
            {
                Log("Error positioning windows :" + e);
            }
            Log("Windows Repositioned.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (botList.Items.Count > 0)
            {
                GLItem item = botList.Items[_botListSelectedIndex];
                BabySitter sitter = BSController.GetAllSittersByAlias(item.SubItems[2].Text);
                sitter.Watching = false;
                sitter.KillBabySitter();
                //UpdateBotDetails(sitter);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (botList.Items.Count > 0)
            {
                GLItem item = botList.Items[_botListSelectedIndex];
                BabySitter sitter = BSController.GetAllSittersByAlias(item.SubItems[2].Text);
                if (sitter == null)
                    return;
                //sitter.Watching = true;
                if (!sitter.Watching)
                    sitter.BabySit();
                //UpdateBotDetails(sitter);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RearrangeWindows();
        }

        // The path to the key where Windows looks for startup applications

        private void btnRunAtStartup_Click(object sender, EventArgs e)
        {
            BasicSettingsForm form = new BasicSettingsForm();
            form.Show();
            form.SetParent(this);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                List<Process> apps = new List<Process>();
                Process[] processlist = Process.GetProcesses();
                foreach (Process p in processlist)
                {
                    if (p.ProcessName.Contains("BigSister"))
                    {
                        apps.Add(p);
                    }
                }
                foreach (Process p in apps)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                Application.Exit();
            }
        }

        #region botlist

        private int _botListSelectedIndex;
        private bool _scrollToCarretOnBotDetails = true;
        private int botListIndex;

        private void AddToList(Settings sets)
        {
            GLItem item = new GLItem();
            GLSubItem subItem = new GLSubItem();
            subItem.Text = ++botListIndex + "";
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = "";
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = sets.Alias;
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = "CPU";
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = "Mem";
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = "";
            item.SubItems.Add(subItem);

            subItem = new GLSubItem();
            subItem.Text = "";
            item.SubItems.Add(subItem);


            ProgressBar pb;

            pb = new ProgressBar();
            pb.Value = 60;
            pb.Maximum = 100;
            item.SubItems[3].Control = pb;

            pb = new ProgressBar();
            pb.Value = 20;
            pb.Maximum = 100;
            item.SubItems[4].Control = pb;


            botList.Items.Add(item);
        }

        private void UpdateBotList(BabySitter sitter)
        {
            while (_blockUpdatingList)
                Thread.Sleep(50);
            int listIndex = -1;
            for (int i = 0; i < botList.Items.Count; ++i)
            {
                GLItem l = botList.Items[i];
                if (l.SubItems[2].Text == sitter.Sets.Alias)
                    listIndex = botList.Items.FindItemIndex(l);
            }
            //doesnt exist in list
            if (listIndex < 0)
            {
                AddToList(sitter.Sets);
                return;
            }

            botList.Items[listIndex].SubItems[1].Text = sitter.CharName;
            botList.Items[listIndex].SubItems[2].Text = sitter.Sets.Alias;
            ProgressBar pb = (ProgressBar) botList.Items[listIndex].SubItems[3].Control;
            pb.Value = sitter.WowCpuUsage;
            pb = (ProgressBar) botList.Items[listIndex].SubItems[4].Control;
            pb.Value = sitter.BotCpuUsage;
            botList.Items[listIndex].SubItems[5].Text = sitter.ReloggerStatus;
            botList.Items[listIndex].SubItems[6].Text = sitter.LastBotMessage;

            // MessageBox.Show(BSController.BabySitterSettings.Count+ "");
        }

        private void UpdateBotDetails(BabySitter sitter)
        {
            try
            {
                if (_scrollToCarretOnBotDetails)
                {
                    textBotLog.Text = sitter.BotLog;
                    textDebugLog.Text = sitter.ReloggerLog;
                }

                if (_scrollToCarretOnBotDetails)
                {
                    if (textBotLog.Text.Length > 1)
                        textBotLog.SelectionStart = textBotLog.Text.Length - 1;
                    textBotLog.ScrollToCaret();

                    if (textDebugLog.Text.Length > 1)
                        textDebugLog.SelectionStart = textDebugLog.Text.Length - 1;
                    textDebugLog.ScrollToCaret();
                }

                WowProgressBar1.Value = sitter.WowCpuUsage;
                WowProgressBar2.Value = sitter.WowMemUsage;

                botProgressBar1.Value = sitter.BotCpuUsage;
                botProgressBar2.Value = sitter.BotMemUsage;

                botStatusLabel.Text = sitter.LastBotMessage;
                this.Text = sitter.LastBotMessage;
            }
            catch (Exception e)
            {
            }
        }

        private void botList_Click(object sender, EventArgs e) //GlacialComponents.Controls.ClickEventArgs e)
        {
            _botListSelectedIndex = botList.Items.GetNextSelectedItemIndex(0);

            // if index is 0 it would return -1 ... stupid, this fixes it
            if (_botListSelectedIndex < 0)
                _botListSelectedIndex = 0;


            //Log(b +"");
        }

        #endregion
    }
}