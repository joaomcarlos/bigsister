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
    using System.Windows.Forms;
    using Microsoft.Win32;

    #endregion

    public partial class BasicSettingsForm : Form
    {
        public Form1 Parent;

        public BasicSettingsForm()
        {
            InitializeComponent();
        }

        //{.*Checked} = {bs..*};
        // \2 = \1

        //{.*Value} = {bs..*};
        // \2 = (int)\1
        private void SaveSettings()
        {
           

            BasicSettingsSaver bss = new BasicSettingsSaver(Application.StartupPath);
            BasicSettings bs = new BasicSettings();
            if (bss.Exists())
                bs = bss.Load();

            bs.AutoRun = chkAutoRun.Checked;
            bs.CheckForWarden = chkWarden.Checked;
            bs.StopIfNoInternetConn = chkInternetConn.Checked;
            bs.StopAfter = (int) numStopAfterHours.Value;
            bs.HasStopCondition = chkStopAtTime.Checked;


            bs.AutoRun = chkAutoRun.Checked;
            bs.CheckForWarden = chkWarden.Checked;
            bs.StopIfNoInternetConn = chkInternetConn.Checked;
            bs.HasStopCondition = chkStopAtTime.Checked;

            bs.WowWindowAutoArrange = chkAutoArrange.Checked;
            bs.WowWindowArrangeWowWindows = chkArrangeWowWindows.Checked;
            bs.WowWindowArrangeBotWindows = chkArrangeBotWindows.Checked;

            bs.StopAfter = (int) numStopAfterHours.Value;

            bs.WowWindowWidth = (int) numWoWWidth.Value;

            bs.WowWindowHeight = (int) numWoWHeight.Value;


            bs.WowWindowSpacingHeight = (int) numWoWSpacingHeight.Value;
            bs.WowWindowSpacingWidth = (int) numWoWSpacingWidth.Value;
            bs.WowWindowGridRows = (int) numWoWRows.Value;
            bs.WowWindowGridColumns = (int) numWoWColumns.Value;
            bs.WowWindowScreenNumber = (int) numOfScreens.Value;
            bs.WowWindowScreenOffset = (int) numScreenOffset.Value;

            bs.WowFanOutHeight = (int) numWoWFanOutHeight.Value;
            bs.WowFanOutWidth = (int) numWoWFanOutWidth.Value;

            bs.WowWindowGridCountPerScreen = (int) numGridsEach.Value;

            if (radioSleep.Checked)
                bs.StopCondition = BasicSettings.eStopCondition.Sleep;
            if (radioShutdown.Checked)
                bs.StopCondition = BasicSettings.eStopCondition.Shutdown;
            if (radioNothing.Checked)
                bs.StopCondition = BasicSettings.eStopCondition.Nothing;

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(
               "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp != null)
                if (bs.AutoRun)
                    // Add the value in the registry so that the application runs at startup
                    rkApp.SetValue("BabySitter", Application.ExecutablePath);
                else
                    // Remove the value from the registry so that the application doesn't start
                    rkApp.DeleteValue("BabySitter", false);


            bss.Save(bs);
        }

        private void BasicSettingsForm_Load(object sender, EventArgs e)
        {
            BasicSettingsSaver bss = new BasicSettingsSaver(Application.StartupPath);
            BasicSettings bs = new BasicSettings();
            if (bss.Exists())
                bs = bss.Load();

            chkAutoRun.Checked = bs.AutoRun;
            chkWarden.Checked = bs.CheckForWarden;
            chkInternetConn.Checked = bs.StopIfNoInternetConn;
            chkStopAtTime.Checked = bs.HasStopCondition;

            chkAutoArrange.Checked = bs.WowWindowAutoArrange;
            chkArrangeWowWindows.Checked = bs.WowWindowArrangeWowWindows;
            chkArrangeBotWindows.Checked = bs.WowWindowArrangeBotWindows;

            numStopAfterHours.Value = bs.StopAfter;

            numWoWWidth.Value = bs.WowWindowWidth;
            numWoWHeight.Value = bs.WowWindowHeight;
            numWoWSpacingHeight.Value = bs.WowWindowSpacingHeight;
            numWoWSpacingWidth.Value = bs.WowWindowSpacingWidth;
            numWoWRows.Value = bs.WowWindowGridRows;
            numWoWColumns.Value = bs.WowWindowGridColumns;
            numOfScreens.Value = bs.WowWindowScreenNumber;
            numScreenOffset.Value = bs.WowWindowScreenOffset;

            numWoWFanOutHeight.Value = bs.WowFanOutHeight;
            numWoWFanOutWidth.Value = bs.WowFanOutWidth;

            numGridsEach.Value = bs.WowWindowGridCountPerScreen;

            if (bs.HasStopCondition)
            {
                if (bs.StopCondition == BasicSettings.eStopCondition.Nothing)
                    radioSleep.Checked = true;
                if (bs.StopCondition == BasicSettings.eStopCondition.Sleep)
                    radioSleep.Checked = true;
                if (bs.StopCondition == BasicSettings.eStopCondition.Shutdown)
                    radioSleep.Checked = true;
            }
        }

        public void SetParent(Form1 p)
        {
            Parent = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            if (Parent != null)
                Parent.ReloadSettings();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numWoWHeight.Value = numAutoCalcSize.Value;
            numWoWWidth.Value = (int) Math.Round(numAutoCalcSize.Value*numAutoCalcRatio.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void numWoWWidth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numWoWHeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numWoWRows_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numWoWColumns_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numWoWFanOutWidth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}