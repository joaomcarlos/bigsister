#region Import Directives

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace BigSister
{
    public partial class SettingsForm : Form
    {
        private bool _loadForm;
        private bool _resultSave;
        private Settings _sets;

        public SettingsForm(Settings sets)
        {
            InitializeComponent();
            _sets = sets;

            if (!string.IsNullOrEmpty(sets.Alias))
                _loadForm = true;
        }


        public Settings getSettings
        {
            get
            {
                if (isValidData(_sets)) return _sets;
                return null;
            }
        }

        public bool ResultSave
        {
            get { return _resultSave; }
        }

        private void loadForm()
        {
            txtAlias.Text = _sets.Alias;

            // old settings fixed on the Settings.cs
            // not anymore
            textWowPath.Text = _sets.WoWPath;

            textBotPath.Text = _sets.BotPath;
            chkMultiAccount.Checked = _sets.WoWAccountIsMulti;
            textWowAcc.Text = _sets.WoWAccountName;
            textWowPass.Text = _sets.WoWAccountPass;
            textWoWName.Text = _sets.WoWName;
            textBotName.Text = _sets.BotName;
            numericUpDown1.Value = _sets.WoWAccountCharNumber;
            multiAccIndex.Value = _sets.WoWbNetIndex;
            txtRealmName.Text = _sets.RealmName;
            txtRealmRegion.Text = _sets.RealmRegion;

            txtConfigFilePath.Text = _sets.WoWConfigPath;

            radioGather.Checked = _sets.BotType == Settings.BotTypeEnum.GatherBuddy;
            radioHonorBig.Checked = _sets.BotType == Settings.BotTypeEnum.HonnorBuddyBig;
            radioHonorSmall.Checked = _sets.BotType == Settings.BotTypeEnum.HonnorBuddySmall;
            radioHB2.Checked = _sets.BotType == Settings.BotTypeEnum.HonnorBuddy2;

            sleepMultiplier.Value = (decimal) _sets.SleepMultiplier;

            chkLightMode.Checked = _sets.LightMode;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            if (_loadForm)
                loadForm();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //textWowPath.Text = openFileDialog1.FileName;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            //textBotPath.Text = openFileDialog2.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textWowPath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBotPath.Text = openFileDialog2.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                txtConfigFilePath.Text = openFileDialog3.FileName;
            }
        }

        private bool isValidData(Settings sets)
        {
            bool isValid = true;
            if (sets == null || string.IsNullOrEmpty(sets.WoWPath))
                return false;

            if(string.IsNullOrEmpty(sets.Alias))
                return false;

            if (sets.Alias.Length <= 1)
                return false;
            if (sets.RealmName.Length <= 1)
                return false;

            if (sets.RealmRegion.Length <= 1)
                return false;
            if (sets.WoWPath.Length <= 1)
                return false;
            if (sets.BotPath.Length <= 1)
                return false;

            if (sets.WoWAccountName.Length <= 1)
                return false;
            if (sets.WoWAccountPass.Length <= 1)
                return false;
            if (sets.WoWName.Length <= 1)
                return false;
            if (sets.BotName.Length <= 1)
                return false;


            isValid = false;
            if (sets.BotType == Settings.BotTypeEnum.GatherBuddy)
                isValid = true;
            if (sets.BotType == Settings.BotTypeEnum.HonnorBuddyBig)
                isValid = true;
            if (sets.BotType == Settings.BotTypeEnum.HonnorBuddySmall)
                isValid = true;
            if (sets.BotType == Settings.BotTypeEnum.HonnorBuddy2)
                isValid = true;


            return isValid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings sets = new Settings();
            sets.WoWPath = textWowPath.Text;
            sets.BotPath = textBotPath.Text;
            sets.WoWAccountIsMulti = chkMultiAccount.Checked;
            sets.WoWAccountName = textWowAcc.Text;
            sets.WoWAccountPass = textWowPass.Text;
            sets.WoWName = textWoWName.Text;
            sets.BotName = textBotName.Text;
            sets.WoWAccountCharNumber = (int) numericUpDown1.Value;
            sets.WoWbNetIndex = (int) multiAccIndex.Value;
            sets.Alias = txtAlias.Text;
            sets.RealmName = txtRealmName.Text;
            sets.RealmRegion = txtRealmRegion.Text;
            sets.SleepMultiplier = (double) sleepMultiplier.Value;
            sets.LightMode = true;//chkLightMode.Checked;
            sets.WoWConfigPath = txtConfigFilePath.Text;

            if (radioGather.Checked)
                sets.BotType = Settings.BotTypeEnum.GatherBuddy;
            if (radioHonorBig.Checked)
                sets.BotType = Settings.BotTypeEnum.HonnorBuddyBig;
            if (radioHonorSmall.Checked)
                sets.BotType = Settings.BotTypeEnum.HonnorBuddySmall;
            if (radioHB2.Checked)
                sets.BotType = Settings.BotTypeEnum.HonnorBuddy2;


            if (!isValidData(sets))
            {
                MessageBox.Show("Data is not valid, please verify");
            }
            else
            {
                _sets = sets;
                /*
                        // fix old settings
                        string wowpath = sets.WoWPath;
                        while (wowpath.Contains("WoW.exe"))
                            wowpath = wowpath.Replace("\\WoW.exe", "");
                        while (wowpath.Contains("Wow.exe"))
                            wowpath = wowpath.Replace("\\Wow.exe", "");
                        while (wowpath.Contains("wow.exe"))
                            wowpath = wowpath.Replace("\\wow.exe", "");
                        _sets.WoWPath = wowpath;
                    */
                _resultSave = true;
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _resultSave = false;
            Close();
        }
    }
}