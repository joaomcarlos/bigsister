namespace BigSister
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textWoWName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBotName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textWowPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBotPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkMultiAccount = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioHonorBig = new System.Windows.Forms.RadioButton();
            this.radioGather = new System.Windows.Forms.RadioButton();
            this.radioHonorSmall = new System.Windows.Forms.RadioButton();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textWowPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textWowAcc = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.multiAccIndex = new System.Windows.Forms.NumericUpDown();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRealmName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRealmRegion = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtConfigFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.label12 = new System.Windows.Forms.Label();
            this.sleepMultiplier = new System.Windows.Forms.NumericUpDown();
            this.chkLightMode = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.radioHB2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiAccIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepMultiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Wow.exe";
            this.openFileDialog1.Filter = "WoW Executable File|Wow.exe";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textWoWName
            // 
            this.textWoWName.Enabled = false;
            this.textWoWName.Location = new System.Drawing.Point(13, 233);
            this.textWoWName.Name = "textWoWName";
            this.textWoWName.Size = new System.Drawing.Size(100, 20);
            this.textWoWName.TabIndex = 0;
            this.textWoWName.Text = "Wow";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WoW Process Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bot Process Name";
            // 
            // textBotName
            // 
            this.textBotName.Enabled = false;
            this.textBotName.Location = new System.Drawing.Point(13, 272);
            this.textBotName.Name = "textBotName";
            this.textBotName.Size = new System.Drawing.Size(100, 20);
            this.textBotName.TabIndex = 2;
            this.textBotName.Text = "Gatherbuddy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WoW Path";
            // 
            // textWowPath
            // 
            this.textWowPath.Location = new System.Drawing.Point(13, 110);
            this.textWowPath.Name = "textWowPath";
            this.textWowPath.Size = new System.Drawing.Size(228, 20);
            this.textWowPath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bot Path";
            // 
            // textBotPath
            // 
            this.textBotPath.Location = new System.Drawing.Point(13, 188);
            this.textBotPath.Name = "textBotPath";
            this.textBotPath.Size = new System.Drawing.Size(228, 20);
            this.textBotPath.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkMultiAccount
            // 
            this.chkMultiAccount.AutoSize = true;
            this.chkMultiAccount.Location = new System.Drawing.Point(13, 298);
            this.chkMultiAccount.Name = "chkMultiAccount";
            this.chkMultiAccount.Size = new System.Drawing.Size(67, 17);
            this.chkMultiAccount.TabIndex = 45;
            this.chkMultiAccount.Text = "MultiAcc";
            this.chkMultiAccount.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioHB2);
            this.groupBox1.Controls.Add(this.radioHonorBig);
            this.groupBox1.Controls.Add(this.radioGather);
            this.groupBox1.Controls.Add(this.radioHonorSmall);
            this.groupBox1.Location = new System.Drawing.Point(119, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 106);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot Type";
            // 
            // radioHonorBig
            // 
            this.radioHonorBig.AutoSize = true;
            this.radioHonorBig.Enabled = false;
            this.radioHonorBig.Location = new System.Drawing.Point(18, 81);
            this.radioHonorBig.Name = "radioHonorBig";
            this.radioHonorBig.Size = new System.Drawing.Size(107, 17);
            this.radioHonorBig.TabIndex = 8;
            this.radioHonorBig.Text = "HonorBuddy (big)";
            this.radioHonorBig.UseVisualStyleBackColor = true;
            // 
            // radioGather
            // 
            this.radioGather.AutoSize = true;
            this.radioGather.Location = new System.Drawing.Point(18, 13);
            this.radioGather.Name = "radioGather";
            this.radioGather.Size = new System.Drawing.Size(87, 17);
            this.radioGather.TabIndex = 6;
            this.radioGather.TabStop = true;
            this.radioGather.Text = "GatherBuddy";
            this.radioGather.UseVisualStyleBackColor = true;
            // 
            // radioHonorSmall
            // 
            this.radioHonorSmall.AutoSize = true;
            this.radioHonorSmall.Location = new System.Drawing.Point(18, 58);
            this.radioHonorSmall.Name = "radioHonorSmall";
            this.radioHonorSmall.Size = new System.Drawing.Size(116, 17);
            this.radioHonorSmall.TabIndex = 7;
            this.radioHonorSmall.Text = "HonorBuddy (small)";
            this.radioHonorSmall.UseVisualStyleBackColor = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Bot Executable File|*.exe";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "WoW Password";
            // 
            // textWowPass
            // 
            this.textWowPass.Location = new System.Drawing.Point(119, 381);
            this.textWowPass.Name = "textWowPass";
            this.textWowPass.Size = new System.Drawing.Size(154, 20);
            this.textWowPass.TabIndex = 49;
            this.textWowPass.Text = "pikachu_I_luv_u";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "WoW Account";
            // 
            // textWowAcc
            // 
            this.textWowAcc.Location = new System.Drawing.Point(119, 342);
            this.textWowAcc.Name = "textWowAcc";
            this.textWowAcc.Size = new System.Drawing.Size(154, 20);
            this.textWowAcc.TabIndex = 47;
            this.textWowAcc.Text = "ash@pokemonkids.net";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(63, 348);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 51;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(77, 316);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(30, 20);
            this.numericUpDown1.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 26);
            this.label7.TabIndex = 53;
            this.label7.Text = "Char Index\r\n0=first char";
            // 
            // multiAccIndex
            // 
            this.multiAccIndex.Location = new System.Drawing.Point(77, 295);
            this.multiAccIndex.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.multiAccIndex.Name = "multiAccIndex";
            this.multiAccIndex.Size = new System.Drawing.Size(30, 20);
            this.multiAccIndex.TabIndex = 54;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(7, 25);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(162, 20);
            this.txtAlias.TabIndex = 55;
            this.txtAlias.Text = "Cookie Monster";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Alias";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Realm Name";
            // 
            // txtRealmName
            // 
            this.txtRealmName.Location = new System.Drawing.Point(10, 64);
            this.txtRealmName.Name = "txtRealmName";
            this.txtRealmName.Size = new System.Drawing.Size(159, 20);
            this.txtRealmName.TabIndex = 57;
            this.txtRealmName.Text = "My Realm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Realm Region";
            // 
            // txtRealmRegion
            // 
            this.txtRealmRegion.Location = new System.Drawing.Point(175, 64);
            this.txtRealmRegion.Name = "txtRealmRegion";
            this.txtRealmRegion.Size = new System.Drawing.Size(63, 20);
            this.txtRealmRegion.TabIndex = 59;
            this.txtRealmRegion.Text = "EU";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 146);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 23);
            this.button5.TabIndex = 63;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(274, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Path to your Config.wtf File (wowFolder\\WTF\\Config.wtf)";
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.Location = new System.Drawing.Point(13, 149);
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(228, 20);
            this.txtConfigFilePath.TabIndex = 61;
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.Filter = "WoW Configuration File|Config.wtf";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(172, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 26);
            this.label12.TabIndex = 65;
            this.label12.Text = "Sleep \r\nMultiplier";
            // 
            // sleepMultiplier
            // 
            this.sleepMultiplier.DecimalPlaces = 2;
            this.sleepMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.sleepMultiplier.Location = new System.Drawing.Point(226, 25);
            this.sleepMultiplier.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.sleepMultiplier.Name = "sleepMultiplier";
            this.sleepMultiplier.Size = new System.Drawing.Size(46, 20);
            this.sleepMultiplier.TabIndex = 64;
            this.sleepMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkLightMode
            // 
            this.chkLightMode.AutoSize = true;
            this.chkLightMode.Checked = true;
            this.chkLightMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLightMode.Enabled = false;
            this.chkLightMode.Location = new System.Drawing.Point(173, 87);
            this.chkLightMode.Name = "chkLightMode";
            this.chkLightMode.Size = new System.Drawing.Size(79, 17);
            this.chkLightMode.TabIndex = 66;
            this.chkLightMode.Text = "Light Mode";
            this.chkLightMode.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "Formula : Wait * (1+SleepMulti)";
            // 
            // radioHB2
            // 
            this.radioHB2.AutoSize = true;
            this.radioHB2.Location = new System.Drawing.Point(17, 35);
            this.radioHB2.Name = "radioHB2";
            this.radioHB2.Size = new System.Drawing.Size(93, 17);
            this.radioHB2.TabIndex = 9;
            this.radioHB2.Text = "HonorBuddy 2";
            this.radioHB2.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 412);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chkLightMode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sleepMultiplier);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtConfigFilePath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRealmRegion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRealmName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.multiAccIndex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textWowPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textWowAcc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkMultiAccount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBotPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textWowPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBotName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textWoWName);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiAccIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepMultiplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textWoWName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBotName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textWowPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBotPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkMultiAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioHonorBig;
        private System.Windows.Forms.RadioButton radioGather;
        private System.Windows.Forms.RadioButton radioHonorSmall;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textWowPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textWowAcc;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown multiAccIndex;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRealmName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRealmRegion;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConfigFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown sleepMultiplier;
        private System.Windows.Forms.CheckBox chkLightMode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioHB2;
    }
}