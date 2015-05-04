using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Ticket
{
    public partial class FrmLogin : Form
    {
        private string _code;

        public FrmLogin(Image image)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.cbxUser.SelectedIndexChanged += new EventHandler(cbxUser_SelectedIndexChanged);
            this.btnStartLogin.Click += new EventHandler(btnStartLogin_Click);
            this.btnCancelLogin.Click += new EventHandler(btnCancelLogin_Click);
            this.llblLoginOption.Click += new EventHandler(llblLoginOption_Click);
            this.picVerify.MouseClick += new MouseEventHandler(picVerify_MouseClick);

            InitUser();

            SetVerifyImage(image);
        }

        void llblLoginOption_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能尚未开发!");
        }

        private void InitUser()
        {
            if (Setting.GetInstance().Users != null)
            {
                this.cbxUser.DataSource = Setting.GetInstance().Users;
                this.cbxUser.ValueMember = "Password";
                this.cbxUser.DisplayMember = "Username";
            }
        }

        int tagIndex = 12;

        void CreateSelectLogo(int x, int y, string point)
        {
            PictureBox pbox = new PictureBox();
            pbox.Image = global::Ticket.Properties.Resources.logo;
            pbox.Size = new System.Drawing.Size(26, 27);
            pbox.Location = new Point(x, y);
            pbox.Tag = point;
            pbox.TabIndex = tagIndex;
            pbox.TabStop = false;
            pbox.Click += new EventHandler(pbox_Click);
            pbox.Show();

            this.Controls.Add(pbox);

            pbox.BringToFront();

            tagIndex++;
        }

        void pbox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                this._code = this._code.Replace((sender as PictureBox).Tag.ToString(), "");
                this.Controls.Remove(sender as PictureBox);
                (sender as PictureBox).Dispose();
            }
        }

        /// <summary>
        /// 填充验证码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void picVerify_MouseClick(object sender, MouseEventArgs e)
        {
            string point = string.Format("{0},{1},", e.Location.X, e.Location.Y - 30);
            this._code += point;
            CreateSelectLogo(this.picVerify.Location.X + e.X - 13, this.picVerify.Location.Y + e.Y - 13, point);
        }

        //取消登录
        void btnCancelLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //开始登录
        void btnStartLogin_Click(object sender, EventArgs e)
        {
            var uname = this.cbxUser.Text.ToString();
            var upwd = this.txtPassword.Text;
            if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(upwd))
            {
                MessageBox.Show(this, "请输入用户名和密码后再登录!", "提示");
                return;
            }

            if (this._code.Trim(',').Length <= 0)
            {
                MessageBox.Show(this, "请点选验证码!", "提示");
                return;
            }

            OnLoginTrigger(new UserLoginEventArgs(uname, upwd, this._code));

            this.Close();
        }

        void _client_RefreshVerifyCompleted(object sender, VerifyEventArgs e)
        {
            if (e.VerifyMode == VerifyMode.Login)
            {
                SetVerifyImage(e.VerifyImage);
            }
        }

        //改变登录用户
        void cbxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = this.cbxUser.SelectedItem as User;
            if (user != null)
            {
                this.txtPassword.Text = user.Password;
            }
        }

        private void SetVerifyImage(Image image)
        {
            if (this.picVerify.InvokeRequired)
            {
                this.picVerify.Invoke((MethodInvoker)(() =>
                {
                    this.picVerify.Image = image;
                }));
            }
            else
            {
                this.picVerify.Image = image;
            }
        }

        public event EventHandler<UserLoginEventArgs> LoginTrigger;
        private void OnLoginTrigger(UserLoginEventArgs e)
        {
            if (LoginTrigger != null)
            {
                LoginTrigger(this, e);
            }
        }
    }

    public class UserLoginEventArgs : EventArgs
    {
        public UserLoginEventArgs(string uname, string password, string code)
        {
            this.Username = uname;
            this.Password = password;
            this.Code = code;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Code { get; private set; }
    }
}
