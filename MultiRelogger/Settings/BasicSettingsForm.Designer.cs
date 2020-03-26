namespace BigSister
{
    partial class BasicSettingsForm
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
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.chkInternetConn = new System.Windows.Forms.CheckBox();
            this.chkWarden = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numScreenOffset = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numGridsEach = new System.Windows.Forms.NumericUpDown();
            this.numOfScreens = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numWoWFanOutHeight = new System.Windows.Forms.NumericUpDown();
            this.numWoWFanOutWidth = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numWoWColumns = new System.Windows.Forms.NumericUpDown();
            this.numWoWRows = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numAutoCalcRatio = new System.Windows.Forms.NumericUpDown();
            this.numAutoCalcSize = new System.Windows.Forms.NumericUpDown();
            this.numWoWSpacingHeight = new System.Windows.Forms.NumericUpDown();
            this.numWoWSpacingWidth = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numWoWHeight = new System.Windows.Forms.NumericUpDown();
            this.numWoWWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkArrangeBotWindows = new System.Windows.Forms.CheckBox();
            this.chkArrangeWowWindows = new System.Windows.Forms.CheckBox();
            this.chkAutoArrange = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioNothing = new System.Windows.Forms.RadioButton();
            this.radioSleep = new System.Windows.Forms.RadioButton();
            this.radioShutdown = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numStopAfterHours = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkStopAtTime = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridsEach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfScreens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWFanOutHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWFanOutWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWRows)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoCalcRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoCalcSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWSpacingHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWSpacingWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWWidth)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopAfterHours)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(6, 6);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(71, 17);
            this.chkAutoRun.TabIndex = 0;
            this.chkAutoRun.Text = "Auto Run";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // chkInternetConn
            // 
            this.chkInternetConn.AutoSize = true;
            this.chkInternetConn.Location = new System.Drawing.Point(5, 29);
            this.chkInternetConn.Name = "chkInternetConn";
            this.chkInternetConn.Size = new System.Drawing.Size(265, 17);
            this.chkInternetConn.TabIndex = 2;
            this.chkInternetConn.Text = "Stop If No Internet Connection (restarts after 5 min)";
            this.chkInternetConn.UseVisualStyleBackColor = true;
            // 
            // chkWarden
            // 
            this.chkWarden.AutoSize = true;
            this.chkWarden.Location = new System.Drawing.Point(5, 52);
            this.chkWarden.Name = "chkWarden";
            this.chkWarden.Size = new System.Drawing.Size(238, 17);
            this.chkWarden.TabIndex = 3;
            this.chkWarden.Text = "Check For Warden Updates (Tripwire Status)";
            this.chkWarden.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(292, 299);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkInternetConn);
            this.tabPage1.Controls.Add(this.chkAutoRun);
            this.tabPage1.Controls.Add(this.chkWarden);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numScreenOffset);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.numGridsEach);
            this.tabPage2.Controls.Add(this.numOfScreens);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.numWoWFanOutHeight);
            this.tabPage2.Controls.Add(this.numWoWFanOutWidth);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.numWoWColumns);
            this.tabPage2.Controls.Add(this.numWoWRows);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.numWoWSpacingHeight);
            this.tabPage2.Controls.Add(this.numWoWSpacingWidth);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.numWoWHeight);
            this.tabPage2.Controls.Add(this.numWoWWidth);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.chkArrangeBotWindows);
            this.tabPage2.Controls.Add(this.chkArrangeWowWindows);
            this.tabPage2.Controls.Add(this.chkAutoArrange);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(284, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Window Placement";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numScreenOffset
            // 
            this.numScreenOffset.Location = new System.Drawing.Point(136, 250);
            this.numScreenOffset.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numScreenOffset.Name = "numScreenOffset";
            this.numScreenOffset.Size = new System.Drawing.Size(41, 20);
            this.numScreenOffset.TabIndex = 36;
            this.numScreenOffset.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(87, 253);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Offset by";
            // 
            // numGridsEach
            // 
            this.numGridsEach.Location = new System.Drawing.Point(181, 233);
            this.numGridsEach.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numGridsEach.Name = "numGridsEach";
            this.numGridsEach.Size = new System.Drawing.Size(41, 20);
            this.numGridsEach.TabIndex = 34;
            this.numGridsEach.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numOfScreens
            // 
            this.numOfScreens.Location = new System.Drawing.Point(51, 235);
            this.numOfScreens.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numOfScreens.Name = "numOfScreens";
            this.numOfScreens.Size = new System.Drawing.Size(41, 20);
            this.numOfScreens.TabIndex = 33;
            this.numOfScreens.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOfScreens.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(228, 233);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 26);
            this.label18.TabIndex = 32;
            this.label18.Text = "grids in\r\neach.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(91, 235);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "screens and want";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "I have";
            // 
            // numWoWFanOutHeight
            // 
            this.numWoWFanOutHeight.Enabled = false;
            this.numWoWFanOutHeight.Location = new System.Drawing.Point(181, 181);
            this.numWoWFanOutHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWFanOutHeight.Name = "numWoWFanOutHeight";
            this.numWoWFanOutHeight.Size = new System.Drawing.Size(41, 20);
            this.numWoWFanOutHeight.TabIndex = 29;
            this.numWoWFanOutHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numWoWFanOutWidth
            // 
            this.numWoWFanOutWidth.Enabled = false;
            this.numWoWFanOutWidth.Location = new System.Drawing.Point(106, 180);
            this.numWoWFanOutWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWFanOutWidth.Name = "numWoWFanOutWidth";
            this.numWoWFanOutWidth.Size = new System.Drawing.Size(41, 20);
            this.numWoWFanOutWidth.TabIndex = 28;
            this.numWoWFanOutWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWoWFanOutWidth.ValueChanged += new System.EventHandler(this.numWoWFanOutWidth_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(228, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = " in Pixels.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(153, 187);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "by";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Fan out size of";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(228, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "columns";
            // 
            // numWoWColumns
            // 
            this.numWoWColumns.Location = new System.Drawing.Point(181, 153);
            this.numWoWColumns.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWColumns.Name = "numWoWColumns";
            this.numWoWColumns.Size = new System.Drawing.Size(41, 20);
            this.numWoWColumns.TabIndex = 23;
            this.numWoWColumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWoWColumns.ValueChanged += new System.EventHandler(this.numWoWColumns_ValueChanged);
            // 
            // numWoWRows
            // 
            this.numWoWRows.Location = new System.Drawing.Point(106, 152);
            this.numWoWRows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWRows.Name = "numWoWRows";
            this.numWoWRows.Size = new System.Drawing.Size(41, 20);
            this.numWoWRows.TabIndex = 22;
            this.numWoWRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numWoWRows.ValueChanged += new System.EventHandler(this.numWoWRows_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(150, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "rows";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 26);
            this.label14.TabIndex = 19;
            this.label14.Text = "I want the grid to\r\n have";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numAutoCalcRatio);
            this.groupBox2.Controls.Add(this.numAutoCalcSize);
            this.groupBox2.Location = new System.Drawing.Point(172, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 86);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Calc Tool";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Calc";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ratio";
            // 
            // numAutoCalcRatio
            // 
            this.numAutoCalcRatio.DecimalPlaces = 2;
            this.numAutoCalcRatio.Location = new System.Drawing.Point(52, 30);
            this.numAutoCalcRatio.Name = "numAutoCalcRatio";
            this.numAutoCalcRatio.Size = new System.Drawing.Size(41, 20);
            this.numAutoCalcRatio.TabIndex = 10;
            this.numAutoCalcRatio.Value = new decimal(new int[] {
            130,
            0,
            0,
            131072});
            // 
            // numAutoCalcSize
            // 
            this.numAutoCalcSize.Location = new System.Drawing.Point(6, 29);
            this.numAutoCalcSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAutoCalcSize.Name = "numAutoCalcSize";
            this.numAutoCalcSize.Size = new System.Drawing.Size(41, 20);
            this.numAutoCalcSize.TabIndex = 12;
            this.numAutoCalcSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numWoWSpacingHeight
            // 
            this.numWoWSpacingHeight.Location = new System.Drawing.Point(181, 126);
            this.numWoWSpacingHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWSpacingHeight.Name = "numWoWSpacingHeight";
            this.numWoWSpacingHeight.Size = new System.Drawing.Size(41, 20);
            this.numWoWSpacingHeight.TabIndex = 17;
            // 
            // numWoWSpacingWidth
            // 
            this.numWoWSpacingWidth.Location = new System.Drawing.Point(106, 125);
            this.numWoWSpacingWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWSpacingWidth.Name = "numWoWSpacingWidth";
            this.numWoWSpacingWidth.Size = new System.Drawing.Size(41, 20);
            this.numWoWSpacingWidth.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "betwin the \r\nwindows";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "by";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "I want spacing of ";
            // 
            // numWoWHeight
            // 
            this.numWoWHeight.Location = new System.Drawing.Point(181, 99);
            this.numWoWHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWHeight.Name = "numWoWHeight";
            this.numWoWHeight.Size = new System.Drawing.Size(41, 20);
            this.numWoWHeight.TabIndex = 7;
            this.numWoWHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWoWHeight.ValueChanged += new System.EventHandler(this.numWoWHeight_ValueChanged);
            // 
            // numWoWWidth
            // 
            this.numWoWWidth.Location = new System.Drawing.Point(106, 98);
            this.numWoWWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numWoWWidth.Name = "numWoWWidth";
            this.numWoWWidth.Size = new System.Drawing.Size(41, 20);
            this.numWoWWidth.TabIndex = 6;
            this.numWoWWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numWoWWidth.ValueChanged += new System.EventHandler(this.numWoWWidth_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = " in Pixels.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "I want a grid of\r\n windows sized at";
            // 
            // chkArrangeBotWindows
            // 
            this.chkArrangeBotWindows.AutoSize = true;
            this.chkArrangeBotWindows.Enabled = false;
            this.chkArrangeBotWindows.Location = new System.Drawing.Point(6, 52);
            this.chkArrangeBotWindows.Name = "chkArrangeBotWindows";
            this.chkArrangeBotWindows.Size = new System.Drawing.Size(129, 17);
            this.chkArrangeBotWindows.TabIndex = 2;
            this.chkArrangeBotWindows.Text = "Arrange Bot Windows";
            this.chkArrangeBotWindows.UseVisualStyleBackColor = true;
            // 
            // chkArrangeWowWindows
            // 
            this.chkArrangeWowWindows.AutoSize = true;
            this.chkArrangeWowWindows.Location = new System.Drawing.Point(6, 29);
            this.chkArrangeWowWindows.Name = "chkArrangeWowWindows";
            this.chkArrangeWowWindows.Size = new System.Drawing.Size(141, 17);
            this.chkArrangeWowWindows.TabIndex = 1;
            this.chkArrangeWowWindows.Text = "Arrange WoW Windows";
            this.chkArrangeWowWindows.UseVisualStyleBackColor = true;
            // 
            // chkAutoArrange
            // 
            this.chkAutoArrange.AutoSize = true;
            this.chkAutoArrange.Location = new System.Drawing.Point(6, 6);
            this.chkAutoArrange.Name = "chkAutoArrange";
            this.chkAutoArrange.Size = new System.Drawing.Size(135, 17);
            this.chkAutoArrange.TabIndex = 0;
            this.chkAutoArrange.Text = "Auto Arrange Windows";
            this.chkAutoArrange.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.chkStopAtTime);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(284, 273);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Scheduling";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNothing);
            this.groupBox1.Controls.Add(this.radioSleep);
            this.groupBox1.Controls.Add(this.radioShutdown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numStopAfterHours);
            this.groupBox1.Location = new System.Drawing.Point(9, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stopping Options";
            // 
            // radioNothing
            // 
            this.radioNothing.AutoSize = true;
            this.radioNothing.Location = new System.Drawing.Point(6, 91);
            this.radioNothing.Name = "radioNothing";
            this.radioNothing.Size = new System.Drawing.Size(97, 17);
            this.radioNothing.TabIndex = 5;
            this.radioNothing.TabStop = true;
            this.radioNothing.Text = "Just Close Bots";
            this.radioNothing.UseVisualStyleBackColor = true;
            // 
            // radioSleep
            // 
            this.radioSleep.AutoSize = true;
            this.radioSleep.Location = new System.Drawing.Point(6, 68);
            this.radioSleep.Name = "radioSleep";
            this.radioSleep.Size = new System.Drawing.Size(100, 17);
            this.radioSleep.TabIndex = 4;
            this.radioSleep.TabStop = true;
            this.radioSleep.Text = "Sleep Computer";
            this.radioSleep.UseVisualStyleBackColor = true;
            // 
            // radioShutdown
            // 
            this.radioShutdown.AutoSize = true;
            this.radioShutdown.Location = new System.Drawing.Point(6, 45);
            this.radioShutdown.Name = "radioShutdown";
            this.radioShutdown.Size = new System.Drawing.Size(126, 17);
            this.radioShutdown.TabIndex = 3;
            this.radioShutdown.Text = "Shut Down Computer";
            this.radioShutdown.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "hours.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stop After";
            // 
            // numStopAfterHours
            // 
            this.numStopAfterHours.Location = new System.Drawing.Point(66, 19);
            this.numStopAfterHours.Name = "numStopAfterHours";
            this.numStopAfterHours.Size = new System.Drawing.Size(45, 20);
            this.numStopAfterHours.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Stuff Not Implemented beyond this point";
            // 
            // chkStopAtTime
            // 
            this.chkStopAtTime.AutoSize = true;
            this.chkStopAtTime.Location = new System.Drawing.Point(9, 37);
            this.chkStopAtTime.Name = "chkStopAtTime";
            this.chkStopAtTime.Size = new System.Drawing.Size(64, 17);
            this.chkStopAtTime.TabIndex = 7;
            this.chkStopAtTime.Text = "Stop At:";
            this.chkStopAtTime.UseVisualStyleBackColor = true;
            // 
            // BasicSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 363);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "BasicSettingsForm";
            this.Text = "BasicSettingsForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BasicSettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridsEach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfScreens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWFanOutHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWFanOutWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWRows)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoCalcRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoCalcSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWSpacingHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWSpacingWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWoWWidth)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopAfterHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkInternetConn;
        private System.Windows.Forms.CheckBox chkWarden;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioNothing;
        private System.Windows.Forms.RadioButton radioSleep;
        private System.Windows.Forms.RadioButton radioShutdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numStopAfterHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkStopAtTime;
        private System.Windows.Forms.NumericUpDown numWoWWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkArrangeBotWindows;
        private System.Windows.Forms.CheckBox chkArrangeWowWindows;
        private System.Windows.Forms.CheckBox chkAutoArrange;
        private System.Windows.Forms.NumericUpDown numWoWHeight;
        private System.Windows.Forms.NumericUpDown numAutoCalcSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numAutoCalcRatio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numWoWSpacingHeight;
        private System.Windows.Forms.NumericUpDown numWoWSpacingWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numWoWColumns;
        private System.Windows.Forms.NumericUpDown numWoWRows;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numWoWFanOutHeight;
        private System.Windows.Forms.NumericUpDown numWoWFanOutWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numGridsEach;
        private System.Windows.Forms.NumericUpDown numOfScreens;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numScreenOffset;
        private System.Windows.Forms.Label label21;

    }
}