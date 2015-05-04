using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Ticket
{
    public partial class FrmMain : Form
    {
        private TicketClient _client;
        private string code = string.Empty;
        private bool isShowQueryOption = false;
        private bool isExit = false;
        private bool isEnabledSelf = false;
        private Timer timer = new Timer();

        public FrmMain()
        {
            InitializeComponent();
            Init();

            this.ShowInTaskbar = false;
            this.llblQueryOption.Click += new EventHandler(llblQueryOption_Click);
            this.llblPrevDate.Click += new EventHandler(llblPrevDate_Click);
            this.llblNextDate.Click += new EventHandler(llblNextDate_Click);
            this.llblSelectPassengers.Click += new EventHandler(llblSelectPassengers_Click);
            this.llblRemovePassenger.Click += new EventHandler(llblRemovePassenger_Click);
            this.llblAddChild.Click += new EventHandler(llblAddChild_Click);
            this.llblCopyPassenger.Click += new EventHandler(llblCopyPassenger_Click);
            this.llblExportPassengers.Click += new EventHandler(llblExportPassengers_Click);
            this.tsbtnLogin.Click += new EventHandler(tsbtnLogin_Click);
            this.btnQuery.Click += new EventHandler(btnQuery_Click);
            this.btnSelfQuery.Click += new EventHandler(btnSelfQuery_Click);
            this.tsbtnCancellation.Click += new EventHandler(tsbtnCancellation_Click);
            this.btnSubmitOrder.Click += new EventHandler(btnSubmitOrder_Click);
            this.lvPassenger.Click += new EventHandler(lvPassenger_Click);
            this.FormClosing += new FormClosingEventHandler(FrmMain_FormClosing);

            ShowQueryOption(false);
            ShowIpAddress();
            ShowNetwork();
            ShowTimer();
            ShowSelectPassengers(TicketUtil.ReadSelectedPassengers());

            InitClient();
            InitPassengerListView();
            ShowSelectPassengers();
            ShowQueryOption(Setting.GetInstance().QueryOption);

            this.webBrowser.DocumentText = global::Ticket.Properties.Resources.default_document;
            this.webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
        }

        void lvPassenger_Click(object sender, EventArgs e)
        {
            if (this.lvPassenger.SelectedItems.Count <= 0)
                return;

            SetControlEnabled(this.llblRemovePassenger, true);
            SetControlEnabled(this.llblAddChild, true);
        }

        void Init()
        {
            SetControlEnabled(this.llblSelectPassengers, false);
            SetControlEnabled(this.llblRemovePassenger, false);
            SetControlEnabled(this.llblAddChild, false);
        }

        void btnSelfQuery_Click(object sender, EventArgs e)
        {
            var fromName = this.txtFrom.Text.Trim();
            var toName = this.txtTo.Text.Trim();

            string from = (from s in _client.Cities where s.CnName == fromName select s.EnId).Single();
            string to = (from s in _client.Cities where s.CnName == toName select s.EnId).Single();
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                MessageBox.Show("请输入有效的出发地和目的地!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var toDate = this.dtTo.Value;

            if (toDate < DateTime.Now)
            {
                MessageBox.Show("请输入有效的出发日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEnabledSelf)
            {
                BeginQueryTicket(from, to, toDate, Setting.GetInstance().QueryInterval3);
                isEnabledSelf = true;
                this.btnSelfQuery.Text = "停止查询";
            }
            else
            {
                isEnabledSelf = false;
                SetControlEnabled(this.btnSelfQuery, false);
                this.btnSelfQuery.Text = "自助查询";
            }
        }

        private void QueryTicket(string from, string to, DateTime date)
        {
            var ticketResult = _client.QueryTicket(date.ToString("yyyy-MM-dd"), from, to);
            if (ticketResult != null)
            {
                var document = global::Ticket.Properties.Resources.query_document.Replace("{@queryContent}", TicketsToString(ticketResult.data));

                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.webBrowser.DocumentText = document;
                    }));
                }
                else
                {
                    this.webBrowser.DocumentText = document;
                }
            }
        }

        private void BeginQueryTicket(string from, string to, DateTime date, int queryInterval)
        {
            Task task = new Task(() =>
            {
                while (isEnabledSelf)
                {
                    QueryTicket(from, to, date);
                    System.Threading.Thread.Sleep(queryInterval);
                }
            });

            task.ContinueWith((t) =>
            {
                //异常处理
                SetControlEnabled(this.btnSelfQuery, true);
            });

            task.Start();
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var aTags = this.webBrowser.Document.GetElementsByTagName("a");
            foreach (HtmlElement ele in aTags)
            {
                ele.Click += new HtmlElementEventHandler(ele_Click);
            }

        }

        void ele_Click(object sender, HtmlElementEventArgs e)
        {
            var htmlEle = (sender as HtmlElement);
            if (htmlEle == null)
                return;

            var name = htmlEle.GetAttribute("name");
            switch (name)
            {
                case "station":
                    MessageBox.Show("station");
                    break;
                case "order":
                    MessageBox.Show("order");
                    break;
            }
        }

        void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            isExit = true;
            if (_client != null && _client.IsLogin)
            {
                _client.Logout();
            }
        }

        void btnSubmitOrder_Click(object sender, EventArgs e)
        {

        }

        void tsbtnCancellation_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.IsLogin)
            {
                _client.Logout();
                SetControlText(this.tsbtnLogin, "登录");
                SetControlText(this.slblUsername, "未登录");
            }
        }

        private void InitClient()
        {
            _client = new TicketClient(Encoding.UTF8);
            _client.LoadCitiesCompleted += new EventHandler<CityEventArgs>(_client_LoadCitiesCompleted);
            _client.RefreshVerifyCompleted += new EventHandler<VerifyEventArgs>(_client_RefreshVerifyCompleted);
            _client.LoginCompleted += new EventHandler<LoginEventArgs>(_client_LoginCompleted);
            _client.LoadPassengerCompleted += new EventHandler<PassengerEventArgs>(_client_LoadPassengerCompleted);
            _client.OpertionPassengerCompleted += new EventHandler<PassengerEventArgs>(_client_OpertionPassengerCompleted);
            _client.LoadCities();
        }

        int loginTryCount = 0;

        void _client_RefreshVerifyCompleted(object sender, VerifyEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (e.VerifyMode == VerifyMode.VerifyError)
                    {
                        FrmVerify frmVerify = new FrmVerify(e.VerifyImage);
                        frmVerify.InputCompleted += new EventHandler<InputEventArgs>(frmVerify_InputCompleted);
                        frmVerify.ShowDialog();
                        _client.CheckLogin(_client.User.Username, _client.User.Password, code.Trim(','));
                        loginTryCount++;
                    }
                    else if (e.VerifyMode == VerifyMode.Login)
                    {
                        FrmLogin frmLogin = new FrmLogin(e.VerifyImage);
                        frmLogin.LoginTrigger += new EventHandler<UserLoginEventArgs>(frmLogin_LoginTrigger);
                        frmLogin.ShowDialog();
                        _client.CheckLogin(_client.User.Username, _client.User.Password, code.Trim(','));
                    }
                    else if (e.VerifyMode == VerifyMode.Order)
                    {

                    }
                }));
            }
            else
            {
                if (e.VerifyMode == VerifyMode.VerifyError)
                {
                    FrmVerify frmVerify = new FrmVerify(e.VerifyImage);
                    frmVerify.InputCompleted += new EventHandler<InputEventArgs>(frmVerify_InputCompleted);
                    frmVerify.ShowDialog();
                    _client.CheckLogin(_client.User.Username, _client.User.Password, code.Trim(','));
                    loginTryCount++;
                }
                else if (e.VerifyMode == VerifyMode.Login)
                {
                    FrmLogin frmLogin = new FrmLogin(e.VerifyImage);
                    frmLogin.LoginTrigger += new EventHandler<UserLoginEventArgs>(frmLogin_LoginTrigger);
                    frmLogin.ShowDialog();
                    _client.CheckLogin(_client.User.Username, _client.User.Password, code.Trim(','));
                }
                else if (e.VerifyMode == VerifyMode.Order)
                {

                }
            }
        }

        void frmLogin_LoginTrigger(object sender, UserLoginEventArgs e)
        {
            _client.User = new User(e.Username, e.Password);
            this.code = e.Code;
        }

        void frmVerify_InputCompleted(object sender, InputEventArgs e)
        {
            this.code = e.Input;
        }

        void _client_LoadCitiesCompleted(object sender, CityEventArgs e)
        {
            if (e.Cities != null)
            {
                BindCityList((from s in e.Cities select s.CnName).ToArray());
            }
        }

        void _client_OpertionPassengerCompleted(object sender, PassengerEventArgs e)
        {
            if (e.Passengers != null)
            {

            }
        }

        void _client_LoadPassengerCompleted(object sender, PassengerEventArgs e)
        {
            SetStateText(string.Format("获取到{0}位常用联系人", e.Passengers.Length));
            SetControlEnabled(this.llblSelectPassengers, true);
        }

        void _client_LoginCompleted(object sender, LoginEventArgs e)
        {
            SetStateText(e.Message);
            if (e.Code == 0)
            {
                SetUsername(_client.User.Username);
                SetControlText(tsbtnLogin, this._client.User.NickName);
                Setting.GetInstance().Users.Add(_client.User);
                Setting.GetInstance().Save();
            }
            else
            {
                if (e.Message == "FALSE")
                {
                    //处理验证码错误
                    _client.RefreshVerify(VerifyMode.VerifyError);
                }
                else if (e.Message == "网络繁忙，请您重试。如正在使用第三方购票软件或插件，请卸载后重试。")
                {
                    _client.ClearCookies();
                    _client.InitLogin();
                    _client.RefreshVerify(VerifyMode.VerifyError);
                }
            }
        }

        private void InitPassengerListView()
        {
            this.lvPassenger.View = View.Details;
            this.lvPassenger.GridLines = true;
            this.lvPassenger.FullRowSelect = true;

            this.lvPassenger.Columns.Add(new ColumnHeader("ColName") { Text = "姓名", Width = 60, TextAlign = HorizontalAlignment.Center });
            this.lvPassenger.Columns.Add(new ColumnHeader("ColPassengerNo") { Text = "证件号码", Width = 120, TextAlign = HorizontalAlignment.Center });
            this.lvPassenger.Columns.Add(new ColumnHeader("ColSeat") { Text = "席位", Width = 60, TextAlign = HorizontalAlignment.Center });
            this.lvPassenger.Columns.Add(new ColumnHeader("ColState") { Text = "类型/状态", Width = 100, TextAlign = HorizontalAlignment.Center });
        }

        private void ShowSelectPassengers()
        {

        }

        private void ShowQueryOption(QueryOption queryOption)
        {
            //date
            this.dtTo.Value = DateTime.Now.AddDays(59);

            if (queryOption == null)
            {
                return;
            }

            this.txtFrom.Text = queryOption.FromStation;
            this.txtTo.Text = queryOption.ToStation;

            //seat
        }

        private string GetSelectedPassengers()
        {
            if (this.lvPassenger.Items.Count <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (ListViewItem item in this.lvPassenger.Items)
            {
                Passenger p = item.Tag as Passenger;
                if (p != null)
                {
                    sb.AppendLine(p.ToString());
                }
            }

            return sb.ToString();
        }

        void llblExportPassengers_Click(object sender, EventArgs e)
        {
            string passengerInfo = GetSelectedPassengers();
            if (passengerInfo.Length <= 0)
                return;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Filter = "文本文件(*.txt)|*.txt";
            sfDialog.FilterIndex = 1;
            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfDialog.FileName, passengerInfo);
            }
        }

        void llblCopyPassenger_Click(object sender, EventArgs e)
        {
            string text = GetSelectedPassengers();
            if (text.Length <= 0)
                return;

            Clipboard.SetText(text);
        }

        void llblAddChild_Click(object sender, EventArgs e)
        {

        }

        void llblRemovePassenger_Click(object sender, EventArgs e)
        {
            if (this.lvPassenger.SelectedItems.Count <= 0)
                return;

            foreach (ListViewItem item in this.lvPassenger.SelectedItems)
            {
                this.lvPassenger.Items.Remove(item);
            }
        }

        void llblSelectPassengers_Click(object sender, EventArgs e)
        {
            if (_client == null || !_client.IsLogin)
                return;

            FrmSelectPassenger frmSelectPassenger = new FrmSelectPassenger(_client.User.Passengers.ToArray());
            frmSelectPassenger.LoadPassengersTrigger += new EventHandler<PassengerEventArgs>(frmSelectPassenger_LoadPassengersTrigger);
            frmSelectPassenger.AddPassengerTrigger += new EventHandler<PassengerEventArgs>(frmSelectPassenger_AddPassengerTrigger);
            frmSelectPassenger.PassengersSeletedCompleted += new EventHandler<PassengerEventArgs>(frmSelectPassenger_PassengersSeletedCompleted);
            frmSelectPassenger.ShowDialog();
        }

        void frmSelectPassenger_PassengersSeletedCompleted(object sender, PassengerEventArgs e)
        {
            ShowSelectPassengers(e.Passengers);
            TicketUtil.SaveSelectedPassengers(e.Passengers);
        }

        void frmSelectPassenger_AddPassengerTrigger(object sender, PassengerEventArgs e)
        {

        }

        void frmSelectPassenger_LoadPassengersTrigger(object sender, PassengerEventArgs e)
        {
            if (_client != null && _client.IsLogin)
            {
                _client.GetPassengers();
                e.Passengers = _client.User.Passengers.ToArray();
            }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            var fromName = this.txtFrom.Text.Trim();
            var toName = this.txtTo.Text.Trim();

            string from = (from s in _client.Cities where s.CnName == fromName select s.EnId).Single();
            string to = (from s in _client.Cities where s.CnName == toName select s.EnId).Single();
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                MessageBox.Show("请输入有效的出发地和目的地!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var toDate = this.dtTo.Value;

            if (toDate < DateTime.Now)
            {
                MessageBox.Show("请输入有效的出发日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QueryTicket(from, to, toDate);

            //保存查询信息
            if (Setting.GetInstance().QueryOption.FromStation != fromName && Setting.GetInstance().QueryOption.ToStation != toName)
            {
                Setting.GetInstance().QueryOption.FromStation = fromName;
                Setting.GetInstance().QueryOption.ToStation = toName;
                Setting.GetInstance().Save();
            }
        }

        string TicketsToString(Ticket[] tickets)
        {
            if (tickets == null || tickets.Length <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var t in tickets)
            {
                sb.AppendLine(t.ToString());
            }

            return sb.ToString();
        }

        void CreateTicket()
        {
            var doc = this.webBrowser.Document;
            var tbody = this.webBrowser.Document.GetElementById("queryLeftTable");
            var tr = doc.CreateElement("<tr>");
            for (var i = 0; i < 16; i++)
            {
                var td = doc.CreateElement("<td>");
                td.SetAttribute("text", i.ToString());
                tr.AppendChild(td);
            }

            tbody.AppendChild(tr);
        }

        void tsbtnLogin_Click(object sender, EventArgs e)
        {
            if (_client != null && _client.IsLogin)
            {
                return;
            }
            _client.InitLogin();
            _client.RefreshVerify(VerifyMode.Login);
        }

        void llblNextDate_Click(object sender, EventArgs e)
        {
            this.dtTo.Value = this.dtTo.Value.AddDays(1);
        }

        void llblPrevDate_Click(object sender, EventArgs e)
        {
            this.dtTo.Value = this.dtTo.Value.AddDays(-1);
        }

        void BindCityList(string[] cities)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    var cCollection = new AutoCompleteStringCollection();
                    cCollection.AddRange(cities);

                    this.txtFrom.AutoCompleteCustomSource = cCollection;
                    this.txtFrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.txtFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    this.txtTo.AutoCompleteCustomSource = cCollection;
                    this.txtTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.txtTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }));
            }
            else
            {
                var cCollection = new AutoCompleteStringCollection();
                cCollection.AddRange(cities);

                this.txtFrom.AutoCompleteCustomSource = cCollection;
                this.txtFrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.txtFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;

                this.txtTo.AutoCompleteCustomSource = cCollection;
                this.txtTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.txtTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        void llblQueryOption_Click(object sender, EventArgs e)
        {
            if (isShowQueryOption)
            {
                ShowQueryOption(false);
            }
            else
            {
                ShowQueryOption(true);
            }
        }

        private void ShowQueryOption(bool isShow)
        {
            this.isShowQueryOption = isShow;
            this.panelQueryOption.Visible = isShowQueryOption;
            if (isShow)
            {
                SetControlText(llblQueryOption, "更多查询设置↑");
            }
            else
            {
                SetControlText(llblQueryOption, "更多查询设置↓");
            }
        }

        private void ShowIpAddress()
        {
            Task t = new Task(() =>
            {
                SetControlText(this.tsbtnIpAddress, TicketUtil.GetIpAddress());
            });

            t.ContinueWith((task) =>
            {
                //log task.Exception
            }, TaskContinuationOptions.OnlyOnFaulted);

            t.Start();
        }

        private void ShowNetwork()
        {
            Task t = new Task(() =>
            {
                while (true)
                {
                    var roundtripTime = TicketUtil.CheckNetwork();
                    string state = "极好";

                    if (roundtripTime > 400)
                    {
                        state = "1级";
                        SetControlImage(this.tsbtnNetwork, global::Ticket.Properties.Resources.wifi1);
                    }
                    else if (roundtripTime > 300 && roundtripTime < 400)
                    {
                        state = "2级";
                        SetControlImage(this.tsbtnNetwork, global::Ticket.Properties.Resources.wifi2);
                    }
                    else if (roundtripTime > 200 && roundtripTime < 300)
                    {
                        state = "3级";
                        SetControlImage(this.tsbtnNetwork, global::Ticket.Properties.Resources.wifi3);
                    }
                    else if (roundtripTime > 100 && roundtripTime < 200)
                    {
                        state = "4级";
                        SetControlImage(this.tsbtnNetwork, global::Ticket.Properties.Resources.wifi4);
                    }
                    else if (roundtripTime < 100)
                    {
                        state = "5级";
                        SetControlImage(this.tsbtnNetwork, global::Ticket.Properties.Resources.wifi5);
                    }

                    if (isExit)
                    {
                        break;
                    }

                    SetControlTip(this.tsbtnNetwork, string.Format("响应时间: {0}毫秒", roundtripTime));
                    SetControlText(this.tsbtnNetwork, state);
                    System.Threading.Thread.Sleep(5000);
                }
            });

            t.ContinueWith((task) =>
            {
                //log task.Exception
            }, TaskContinuationOptions.OnlyOnFaulted);

            t.Start();
        }

        void ShowTimer()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SetTime(DateTime.Now);
        }

        void ShowSelectPassengers(Passenger[] passengers)
        {
            if (passengers != null && passengers.Length > 0)
            {
                foreach (Passenger p in passengers)
                {
                    var lvItem = new ListViewItem(new string[] {
                        p.passenger_name,p.passenger_id_no,"默认",p.passenger_type_name+"/"+p.passenger_state
                    });
                    lvItem.Tag = p;
                    this.lvPassenger.Items.Add(lvItem);
                }
            }
        }

        private void SetControlText(ToolStripItem control, string text)
        {
            if (this.toolStripMain.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    control.Text = text;
                }));
            }
            else
            {
                control.Text = text;
            }
        }

        private void SetControlText(Control control, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    control.Text = text;
                }));
            }
            else
            {
                control.Text = text;
            }
        }

        private void SetControlImage(ToolStripItem item, Image image)
        {
            if (this.toolStripMain.InvokeRequired)
            {
                this.toolStripMain.Invoke((MethodInvoker)(() =>
                {
                    this.tsbtnNetwork.Image = image;
                }));
            }
            else
            {
                this.tsbtnNetwork.Image = image;
            }
        }

        private void SetControlEnabled(ToolStripItem control, bool isEnabled)
        {
            if (this.toolStripMain.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    control.Enabled = isEnabled;
                }));
            }
            else
            {
                control.Enabled = isEnabled;
            }
        }

        private void SetControlEnabled(Control control, bool isEnabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    control.Enabled = isEnabled;
                }));
            }
            else
            {
                control.Enabled = isEnabled;
            }
        }

        private void SetControlTip(ToolStripItem control, string tip)
        {
            if (this.toolStripMain.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    control.ToolTipText = tip;
                }));
            }
            else
            {
                control.ToolTipText = tip;
            }
        }

        private void SetStateText(string state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    bool scroll = false;
                    if (this.lbState.TopIndex == this.lbState.Items.Count - (int)(this.lbState.Height / this.lbState.ItemHeight))
                    {
                        scroll = true;
                    }
                    this.lbState.Items.Add(state);
                    if (scroll)
                    {
                        this.lbState.TopIndex = this.lbState.Items.Count - (int)(this.lbState.Height / this.lbState.ItemHeight);
                    }
                }));
            }
            else
            {
                bool scroll = false;
                if (this.lbState.TopIndex == this.lbState.Items.Count - (int)(this.lbState.Height / this.lbState.ItemHeight))
                {
                    scroll = true;
                }
                this.lbState.Items.Add(state);
                if (scroll)
                {
                    this.lbState.TopIndex = this.lbState.Items.Count - (int)(this.lbState.Height / this.lbState.ItemHeight);
                }
            }
        }

        private void SetUsername(string username)
        {
            if (this.statusStripMain.InvokeRequired)
            {
                this.statusStripMain.Invoke((MethodInvoker)(() =>
                {
                    this.slblUsername.Text = username;
                }));
            }
            else
            {
                this.slblUsername.Text = username;
            }
        }

        private void SetTime(DateTime date)
        {
            if (this.statusStripMain.InvokeRequired)
            {
                this.statusStripMain.Invoke((MethodInvoker)(() =>
                {
                    this.tslblTime.Text = string.Format("北京时间:{0}", date.ToString("yyyy-MM-dd HH:mm:ss"));
                }));
            }
            else
            {
                this.tslblTime.Text = string.Format("北京时间:{0}", date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        tsbtnLogin_Click(this, new EventArgs());
                    }));
                }
                else
                {
                    tsbtnLogin_Click(this, new EventArgs());
                }
            });

            t.Start();
        }
    }
}
