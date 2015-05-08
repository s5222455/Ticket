namespace Ticket
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnCancellation = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMyTicket = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsbtnIpAddress = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNetwork = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.slblUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.webBrowserOrder = new System.Windows.Forms.WebBrowser();
            this.panelQueryOption = new System.Windows.Forms.Panel();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtToStation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFromStation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStudent = new System.Windows.Forms.CheckBox();
            this.txtSetoutTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTrainSelected = new System.Windows.Forms.Button();
            this.btnTrainChooies = new System.Windows.Forms.Button();
            this.btnTrainNext = new System.Windows.Forms.Button();
            this.btnTrainPrev = new System.Windows.Forms.Button();
            this.checklbTrains = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSeatSelected = new System.Windows.Forms.Button();
            this.btnSeatChooies = new System.Windows.Forms.Button();
            this.btnSeatNext = new System.Windows.Forms.Button();
            this.btnSeatPrev = new System.Windows.Forms.Button();
            this.checklbSeat = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.lbState = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPassenger = new System.Windows.Forms.ListView();
            this.llblExportPassengers = new System.Windows.Forms.LinkLabel();
            this.llblCopyPassenger = new System.Windows.Forms.LinkLabel();
            this.llblAddChild = new System.Windows.Forms.LinkLabel();
            this.llblRemovePassenger = new System.Windows.Forms.LinkLabel();
            this.llblSelectPassengers = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSelfQuery = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.llblQueryOption = new System.Windows.Forms.LinkLabel();
            this.llblNextDate = new System.Windows.Forms.LinkLabel();
            this.llblPrevDate = new System.Windows.Forms.LinkLabel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMain.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelQueryOption.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.tsbtnCancellation,
            this.tsbtnMyTicket,
            this.tsbtnLogin,
            this.tsbtnIpAddress,
            this.tsbtnNetwork});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(867, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "帮助";
            // 
            // tsbtnCancellation
            // 
            this.tsbtnCancellation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnCancellation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnCancellation.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCancellation.Image")));
            this.tsbtnCancellation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancellation.Name = "tsbtnCancellation";
            this.tsbtnCancellation.Size = new System.Drawing.Size(36, 22);
            this.tsbtnCancellation.Text = "注销";
            // 
            // tsbtnMyTicket
            // 
            this.tsbtnMyTicket.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnMyTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnMyTicket.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMyTicket.Image")));
            this.tsbtnMyTicket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMyTicket.Name = "tsbtnMyTicket";
            this.tsbtnMyTicket.Size = new System.Drawing.Size(72, 22);
            this.tsbtnMyTicket.Text = "我的火车票";
            // 
            // tsbtnLogin
            // 
            this.tsbtnLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogin.Image")));
            this.tsbtnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogin.Name = "tsbtnLogin";
            this.tsbtnLogin.Size = new System.Drawing.Size(36, 22);
            this.tsbtnLogin.Text = "登录";
            // 
            // tsbtnIpAddress
            // 
            this.tsbtnIpAddress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnIpAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnIpAddress.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnIpAddress.Image")));
            this.tsbtnIpAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIpAddress.Name = "tsbtnIpAddress";
            this.tsbtnIpAddress.Size = new System.Drawing.Size(49, 22);
            this.tsbtnIpAddress.Text = "0.0.0.1";
            // 
            // tsbtnNetwork
            // 
            this.tsbtnNetwork.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnNetwork.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNetwork.Image")));
            this.tsbtnNetwork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNetwork.Name = "tsbtnNetwork";
            this.tsbtnNetwork.Size = new System.Drawing.Size(76, 22);
            this.tsbtnNetwork.Text = "网络状况";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStripMain);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelBottom);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelTop);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(867, 578);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(867, 625);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblUsername,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.tslblTime,
            this.toolStripStatusLabel5});
            this.statusStripMain.Location = new System.Drawing.Point(0, 0);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(867, 22);
            this.statusStripMain.TabIndex = 0;
            // 
            // slblUsername
            // 
            this.slblUsername.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.slblUsername.Name = "slblUsername";
            this.slblUsername.Size = new System.Drawing.Size(206, 17);
            this.slblUsername.Spring = true;
            this.slblUsername.Text = "未登录";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "信息发布区";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(27, 17);
            this.toolStripStatusLabel3.Text = "0/0";
            // 
            // tslblTime
            // 
            this.tslblTime.Name = "tslblTime";
            this.tslblTime.Size = new System.Drawing.Size(206, 17);
            this.tslblTime.Spring = true;
            this.tslblTime.Text = "北京时间:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.IsLink = true;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabel5.Spring = true;
            this.toolStripStatusLabel5.Text = "捐助我们";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panelQueryOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 375);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.webBrowser);
            this.panel3.Controls.Add(this.webBrowserOrder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 197);
            this.panel3.TabIndex = 1;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(867, 20);
            this.webBrowser.TabIndex = 0;
            // 
            // webBrowserOrder
            // 
            this.webBrowserOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserOrder.Location = new System.Drawing.Point(0, 3);
            this.webBrowserOrder.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserOrder.Name = "webBrowserOrder";
            this.webBrowserOrder.Size = new System.Drawing.Size(867, 194);
            this.webBrowserOrder.TabIndex = 1;
            // 
            // panelQueryOption
            // 
            this.panelQueryOption.Controls.Add(this.dtEnd);
            this.panelQueryOption.Controls.Add(this.dtStart);
            this.panelQueryOption.Controls.Add(this.checkBox5);
            this.panelQueryOption.Controls.Add(this.checkBox4);
            this.panelQueryOption.Controls.Add(this.checkBox3);
            this.panelQueryOption.Controls.Add(this.checkBox2);
            this.panelQueryOption.Controls.Add(this.checkBox1);
            this.panelQueryOption.Controls.Add(this.txtToStation);
            this.panelQueryOption.Controls.Add(this.label10);
            this.panelQueryOption.Controls.Add(this.txtFromStation);
            this.panelQueryOption.Controls.Add(this.label9);
            this.panelQueryOption.Controls.Add(this.cbStudent);
            this.panelQueryOption.Controls.Add(this.txtSetoutTime);
            this.panelQueryOption.Controls.Add(this.label8);
            this.panelQueryOption.Controls.Add(this.label7);
            this.panelQueryOption.Controls.Add(this.label6);
            this.panelQueryOption.Controls.Add(this.btnTrainSelected);
            this.panelQueryOption.Controls.Add(this.btnTrainChooies);
            this.panelQueryOption.Controls.Add(this.btnTrainNext);
            this.panelQueryOption.Controls.Add(this.btnTrainPrev);
            this.panelQueryOption.Controls.Add(this.checklbTrains);
            this.panelQueryOption.Controls.Add(this.label5);
            this.panelQueryOption.Controls.Add(this.btnSeatSelected);
            this.panelQueryOption.Controls.Add(this.btnSeatChooies);
            this.panelQueryOption.Controls.Add(this.btnSeatNext);
            this.panelQueryOption.Controls.Add(this.btnSeatPrev);
            this.panelQueryOption.Controls.Add(this.checklbSeat);
            this.panelQueryOption.Controls.Add(this.label4);
            this.panelQueryOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQueryOption.Location = new System.Drawing.Point(0, 0);
            this.panelQueryOption.Name = "panelQueryOption";
            this.panelQueryOption.Size = new System.Drawing.Size(867, 178);
            this.panelQueryOption.TabIndex = 0;
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEnd.Location = new System.Drawing.Point(552, 8);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ShowUpDown = true;
            this.dtEnd.Size = new System.Drawing.Size(52, 21);
            this.dtEnd.TabIndex = 29;
            this.dtEnd.Value = new System.DateTime(2015, 3, 26, 23, 59, 0, 0);
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStart.Location = new System.Drawing.Point(474, 8);
            this.dtStart.Name = "dtStart";
            this.dtStart.ShowUpDown = true;
            this.dtStart.Size = new System.Drawing.Size(52, 21);
            this.dtStart.TabIndex = 28;
            this.dtStart.Value = new System.DateTime(2015, 3, 26, 0, 0, 0, 0);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(682, 144);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(120, 16);
            this.checkBox5.TabIndex = 27;
            this.checkBox5.Text = "只显示可预订车次";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(682, 112);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(120, 16);
            this.checkBox4.TabIndex = 26;
            this.checkBox4.Text = "尝试不提交无座票";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(682, 79);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(168, 16);
            this.checkBox3.TabIndex = 25;
            this.checkBox3.Text = "23点自动暂停-7点自动继续";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(682, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(180, 16);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "余票不足时允许部分预订提交";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(682, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 16);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "查询到有票后自动预订和提交";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtToStation
            // 
            this.txtToStation.Location = new System.Drawing.Point(474, 111);
            this.txtToStation.Name = "txtToStation";
            this.txtToStation.Size = new System.Drawing.Size(186, 21);
            this.txtToStation.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "到达车站：";
            // 
            // txtFromStation
            // 
            this.txtFromStation.Location = new System.Drawing.Point(474, 73);
            this.txtFromStation.Name = "txtFromStation";
            this.txtFromStation.Size = new System.Drawing.Size(186, 21);
            this.txtFromStation.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "出发车站：";
            // 
            // cbStudent
            // 
            this.cbStudent.AutoSize = true;
            this.cbStudent.Location = new System.Drawing.Point(609, 11);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(72, 16);
            this.cbStudent.TabIndex = 18;
            this.cbStudent.Text = "我是学生";
            this.cbStudent.UseVisualStyleBackColor = true;
            // 
            // txtSetoutTime
            // 
            this.txtSetoutTime.Location = new System.Drawing.Point(474, 40);
            this.txtSetoutTime.Name = "txtSetoutTime";
            this.txtSetoutTime.Size = new System.Drawing.Size(186, 21);
            this.txtSetoutTime.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "出发时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(532, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "到";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "出发时间：";
            // 
            // btnTrainSelected
            // 
            this.btnTrainSelected.Location = new System.Drawing.Point(363, 117);
            this.btnTrainSelected.Name = "btnTrainSelected";
            this.btnTrainSelected.Size = new System.Drawing.Size(41, 23);
            this.btnTrainSelected.TabIndex = 11;
            this.btnTrainSelected.Text = "反选";
            this.btnTrainSelected.UseVisualStyleBackColor = true;
            // 
            // btnTrainChooies
            // 
            this.btnTrainChooies.Location = new System.Drawing.Point(363, 88);
            this.btnTrainChooies.Name = "btnTrainChooies";
            this.btnTrainChooies.Size = new System.Drawing.Size(41, 23);
            this.btnTrainChooies.TabIndex = 10;
            this.btnTrainChooies.Text = "全选";
            this.btnTrainChooies.UseVisualStyleBackColor = true;
            // 
            // btnTrainNext
            // 
            this.btnTrainNext.Location = new System.Drawing.Point(363, 37);
            this.btnTrainNext.Name = "btnTrainNext";
            this.btnTrainNext.Size = new System.Drawing.Size(41, 23);
            this.btnTrainNext.TabIndex = 9;
            this.btnTrainNext.Text = "下移";
            this.btnTrainNext.UseVisualStyleBackColor = true;
            // 
            // btnTrainPrev
            // 
            this.btnTrainPrev.Location = new System.Drawing.Point(363, 6);
            this.btnTrainPrev.Name = "btnTrainPrev";
            this.btnTrainPrev.Size = new System.Drawing.Size(41, 23);
            this.btnTrainPrev.TabIndex = 8;
            this.btnTrainPrev.Text = "上移";
            this.btnTrainPrev.UseVisualStyleBackColor = true;
            // 
            // checklbTrains
            // 
            this.checklbTrains.FormattingEnabled = true;
            this.checklbTrains.Items.AddRange(new object[] {
            "高铁/城际",
            "动车",
            "Z字头",
            "T字头",
            "K字头",
            "其它"});
            this.checklbTrains.Location = new System.Drawing.Point(257, 6);
            this.checklbTrains.Name = "checklbTrains";
            this.checklbTrains.Size = new System.Drawing.Size(100, 164);
            this.checklbTrains.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(233, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 54);
            this.label5.TabIndex = 6;
            this.label5.Text = "车次类型";
            // 
            // btnSeatSelected
            // 
            this.btnSeatSelected.Location = new System.Drawing.Point(170, 117);
            this.btnSeatSelected.Name = "btnSeatSelected";
            this.btnSeatSelected.Size = new System.Drawing.Size(41, 23);
            this.btnSeatSelected.TabIndex = 5;
            this.btnSeatSelected.Text = "反选";
            this.btnSeatSelected.UseVisualStyleBackColor = true;
            // 
            // btnSeatChooies
            // 
            this.btnSeatChooies.Location = new System.Drawing.Point(170, 88);
            this.btnSeatChooies.Name = "btnSeatChooies";
            this.btnSeatChooies.Size = new System.Drawing.Size(41, 23);
            this.btnSeatChooies.TabIndex = 4;
            this.btnSeatChooies.Text = "全选";
            this.btnSeatChooies.UseVisualStyleBackColor = true;
            // 
            // btnSeatNext
            // 
            this.btnSeatNext.Location = new System.Drawing.Point(170, 37);
            this.btnSeatNext.Name = "btnSeatNext";
            this.btnSeatNext.Size = new System.Drawing.Size(41, 23);
            this.btnSeatNext.TabIndex = 3;
            this.btnSeatNext.Text = "下移";
            this.btnSeatNext.UseVisualStyleBackColor = true;
            // 
            // btnSeatPrev
            // 
            this.btnSeatPrev.Location = new System.Drawing.Point(170, 6);
            this.btnSeatPrev.Name = "btnSeatPrev";
            this.btnSeatPrev.Size = new System.Drawing.Size(41, 23);
            this.btnSeatPrev.TabIndex = 2;
            this.btnSeatPrev.Text = "上移";
            this.btnSeatPrev.UseVisualStyleBackColor = true;
            // 
            // checklbSeat
            // 
            this.checklbSeat.FormattingEnabled = true;
            this.checklbSeat.Items.AddRange(new object[] {
            "商务座",
            "特等座",
            "一等座",
            "二等座",
            "高级软卧",
            "软卧",
            "硬卧",
            "软座",
            "硬座",
            "无座"});
            this.checklbSeat.Location = new System.Drawing.Point(64, 6);
            this.checklbSeat.Name = "checklbSeat";
            this.checklbSeat.Size = new System.Drawing.Size(100, 164);
            this.checklbSeat.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 54);
            this.label4.TabIndex = 0;
            this.label4.Text = "席位类型";
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.btnSubmitOrder);
            this.panelBottom.Controls.Add(this.lbState);
            this.panelBottom.Controls.Add(this.groupBox1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 405);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(867, 173);
            this.panelBottom.TabIndex = 1;
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(787, 8);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitOrder.TabIndex = 2;
            this.btnSubmitOrder.Text = "提交订单";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            // 
            // lbState
            // 
            this.lbState.FormattingEnabled = true;
            this.lbState.ItemHeight = 12;
            this.lbState.Location = new System.Drawing.Point(369, 33);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(495, 136);
            this.lbState.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPassenger);
            this.groupBox1.Controls.Add(this.llblExportPassengers);
            this.groupBox1.Controls.Add(this.llblCopyPassenger);
            this.groupBox1.Controls.Add(this.llblAddChild);
            this.groupBox1.Controls.Add(this.llblRemovePassenger);
            this.groupBox1.Controls.Add(this.llblSelectPassengers);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "乘客信息";
            // 
            // lvPassenger
            // 
            this.lvPassenger.GridLines = true;
            this.lvPassenger.Location = new System.Drawing.Point(6, 50);
            this.lvPassenger.Name = "lvPassenger";
            this.lvPassenger.Size = new System.Drawing.Size(347, 108);
            this.lvPassenger.TabIndex = 6;
            this.lvPassenger.UseCompatibleStateImageBehavior = false;
            this.lvPassenger.View = System.Windows.Forms.View.Details;
            // 
            // llblExportPassengers
            // 
            this.llblExportPassengers.AutoSize = true;
            this.llblExportPassengers.Location = new System.Drawing.Point(288, 35);
            this.llblExportPassengers.Name = "llblExportPassengers";
            this.llblExportPassengers.Size = new System.Drawing.Size(29, 12);
            this.llblExportPassengers.TabIndex = 5;
            this.llblExportPassengers.TabStop = true;
            this.llblExportPassengers.Text = "导出";
            // 
            // llblCopyPassenger
            // 
            this.llblCopyPassenger.AutoSize = true;
            this.llblCopyPassenger.Location = new System.Drawing.Point(222, 35);
            this.llblCopyPassenger.Name = "llblCopyPassenger";
            this.llblCopyPassenger.Size = new System.Drawing.Size(29, 12);
            this.llblCopyPassenger.TabIndex = 4;
            this.llblCopyPassenger.TabStop = true;
            this.llblCopyPassenger.Text = "复制";
            // 
            // llblAddChild
            // 
            this.llblAddChild.AutoSize = true;
            this.llblAddChild.Location = new System.Drawing.Point(79, 35);
            this.llblAddChild.Name = "llblAddChild";
            this.llblAddChild.Size = new System.Drawing.Size(53, 12);
            this.llblAddChild.TabIndex = 3;
            this.llblAddChild.TabStop = true;
            this.llblAddChild.Text = "添加儿童";
            // 
            // llblRemovePassenger
            // 
            this.llblRemovePassenger.AutoSize = true;
            this.llblRemovePassenger.Location = new System.Drawing.Point(44, 35);
            this.llblRemovePassenger.Name = "llblRemovePassenger";
            this.llblRemovePassenger.Size = new System.Drawing.Size(29, 12);
            this.llblRemovePassenger.TabIndex = 2;
            this.llblRemovePassenger.TabStop = true;
            this.llblRemovePassenger.Text = "移除";
            // 
            // llblSelectPassengers
            // 
            this.llblSelectPassengers.AutoSize = true;
            this.llblSelectPassengers.Location = new System.Drawing.Point(9, 35);
            this.llblSelectPassengers.Name = "llblSelectPassengers";
            this.llblSelectPassengers.Size = new System.Drawing.Size(29, 12);
            this.llblSelectPassengers.TabIndex = 1;
            this.llblSelectPassengers.TabStop = true;
            this.llblSelectPassengers.Text = "选择";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(347, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "*请先选择您即将购票的乘客，以便在预订过程中自动加载提交。";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSelfQuery);
            this.panelTop.Controls.Add(this.btnQuery);
            this.panelTop.Controls.Add(this.llblQueryOption);
            this.panelTop.Controls.Add(this.llblNextDate);
            this.panelTop.Controls.Add(this.llblPrevDate);
            this.panelTop.Controls.Add(this.dtTo);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtTo);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtFrom);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(867, 30);
            this.panelTop.TabIndex = 0;
            // 
            // btnSelfQuery
            // 
            this.btnSelfQuery.Location = new System.Drawing.Point(780, 3);
            this.btnSelfQuery.Name = "btnSelfQuery";
            this.btnSelfQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSelfQuery.TabIndex = 10;
            this.btnSelfQuery.Text = "自助查询";
            this.btnSelfQuery.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(694, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // llblQueryOption
            // 
            this.llblQueryOption.AutoSize = true;
            this.llblQueryOption.Location = new System.Drawing.Point(597, 10);
            this.llblQueryOption.Name = "llblQueryOption";
            this.llblQueryOption.Size = new System.Drawing.Size(89, 12);
            this.llblQueryOption.TabIndex = 8;
            this.llblQueryOption.TabStop = true;
            this.llblQueryOption.Text = "更多查询设置↓";
            // 
            // llblNextDate
            // 
            this.llblNextDate.AutoSize = true;
            this.llblNextDate.Location = new System.Drawing.Point(564, 10);
            this.llblNextDate.Name = "llblNextDate";
            this.llblNextDate.Size = new System.Drawing.Size(11, 12);
            this.llblNextDate.TabIndex = 7;
            this.llblNextDate.TabStop = true;
            this.llblNextDate.Text = ">";
            // 
            // llblPrevDate
            // 
            this.llblPrevDate.AutoSize = true;
            this.llblPrevDate.Location = new System.Drawing.Point(418, 10);
            this.llblPrevDate.Name = "llblPrevDate";
            this.llblPrevDate.Size = new System.Drawing.Size(11, 12);
            this.llblPrevDate.TabIndex = 6;
            this.llblPrevDate.TabStop = true;
            this.llblPrevDate.Text = "<";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(435, 6);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(123, 21);
            this.dtTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "出发日期：";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(236, 5);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 21);
            this.txtTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "出发地：";
            // 
            // txtFrom
            // 
            this.txtFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFrom.Location = new System.Drawing.Point(64, 5);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 21);
            this.txtFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "出发地：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 650);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.toolStripMain);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车票工具";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelQueryOption.ResumeLayout(false);
            this.panelQueryOption.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llblQueryOption;
        private System.Windows.Forms.LinkLabel llblNextDate;
        private System.Windows.Forms.LinkLabel llblPrevDate;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnSelfQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelQueryOption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checklbSeat;
        private System.Windows.Forms.Button btnSeatSelected;
        private System.Windows.Forms.Button btnSeatChooies;
        private System.Windows.Forms.Button btnSeatNext;
        private System.Windows.Forms.Button btnSeatPrev;
        private System.Windows.Forms.Button btnTrainSelected;
        private System.Windows.Forms.Button btnTrainChooies;
        private System.Windows.Forms.Button btnTrainNext;
        private System.Windows.Forms.Button btnTrainPrev;
        private System.Windows.Forms.CheckedListBox checklbTrains;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbStudent;
        private System.Windows.Forms.TextBox txtSetoutTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFromStation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtToStation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.ToolStripButton tsbtnNetwork;
        private System.Windows.Forms.ToolStripButton tsbtnIpAddress;
        private System.Windows.Forms.ToolStripButton tsbtnLogin;
        private System.Windows.Forms.ToolStripButton tsbtnMyTicket;
        private System.Windows.Forms.ToolStripButton tsbtnCancellation;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbState;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel llblSelectPassengers;
        private System.Windows.Forms.LinkLabel llblExportPassengers;
        private System.Windows.Forms.LinkLabel llblCopyPassenger;
        private System.Windows.Forms.LinkLabel llblAddChild;
        private System.Windows.Forms.LinkLabel llblRemovePassenger;
        private System.Windows.Forms.ToolStripStatusLabel slblUsername;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tslblTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ListView lvPassenger;
        private System.Windows.Forms.WebBrowser webBrowserOrder;
    }
}

