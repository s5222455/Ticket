namespace Ticket
{
    partial class FrmLogin
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.llblLoginOption = new System.Windows.Forms.LinkLabel();
            this.btnCancelLogin = new System.Windows.Forms.Button();
            this.btnStartLogin = new System.Windows.Forms.Button();
            this.rtxtTip = new System.Windows.Forms.RichTextBox();
            this.panelBanager = new System.Windows.Forms.Panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.picVerify = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBottom.SuspendLayout();
            this.panelBanager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.llblLoginOption);
            this.panelBottom.Controls.Add(this.btnCancelLogin);
            this.panelBottom.Controls.Add(this.btnStartLogin);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 319);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(546, 50);
            this.panelBottom.TabIndex = 0;
            // 
            // llblLoginOption
            // 
            this.llblLoginOption.AutoSize = true;
            this.llblLoginOption.Location = new System.Drawing.Point(12, 20);
            this.llblLoginOption.Name = "llblLoginOption";
            this.llblLoginOption.Size = new System.Drawing.Size(29, 12);
            this.llblLoginOption.TabIndex = 2;
            this.llblLoginOption.TabStop = true;
            this.llblLoginOption.Text = "选项";
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.Location = new System.Drawing.Point(471, 15);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(75, 23);
            this.btnCancelLogin.TabIndex = 1;
            this.btnCancelLogin.Text = "取消";
            this.btnCancelLogin.UseVisualStyleBackColor = true;
            // 
            // btnStartLogin
            // 
            this.btnStartLogin.Location = new System.Drawing.Point(390, 15);
            this.btnStartLogin.Name = "btnStartLogin";
            this.btnStartLogin.Size = new System.Drawing.Size(75, 23);
            this.btnStartLogin.TabIndex = 0;
            this.btnStartLogin.Text = "登录";
            this.btnStartLogin.UseVisualStyleBackColor = true;
            // 
            // rtxtTip
            // 
            this.rtxtTip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtTip.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxtTip.Location = new System.Drawing.Point(0, 43);
            this.rtxtTip.Name = "rtxtTip";
            this.rtxtTip.Size = new System.Drawing.Size(197, 276);
            this.rtxtTip.TabIndex = 2;
            this.rtxtTip.Text = "温馨提示：\n  1、12306.cn网站自3月16日起启用图形验证码\n\n  2、12306.cn网站每日07:00~23:00提供服务\n\n  3、在12306.c" +
    "n网站购票、改签和退票须不晚于开车前2小时";
            // 
            // panelBanager
            // 
            this.panelBanager.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBanager.Controls.Add(this.lbltitle);
            this.panelBanager.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanager.Location = new System.Drawing.Point(0, 0);
            this.panelBanager.Name = "panelBanager";
            this.panelBanager.Size = new System.Drawing.Size(546, 43);
            this.panelBanager.TabIndex = 3;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbltitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltitle.Location = new System.Drawing.Point(3, 9);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(298, 24);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "登录中国铁路客户服务中心";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(217, 63);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(47, 12);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "用户名:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(219, 96);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(47, 12);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "密  码:";
            // 
            // cbxUser
            // 
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(270, 60);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(195, 20);
            this.cbxUser.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(270, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(195, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(471, 63);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "快速注册";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(471, 96);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "忘记密码";
            // 
            // picVerify
            // 
            this.picVerify.Location = new System.Drawing.Point(221, 126);
            this.picVerify.Name = "picVerify";
            this.picVerify.Size = new System.Drawing.Size(293, 190);
            this.picVerify.TabIndex = 10;
            this.picVerify.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(546, 369);
            this.Controls.Add(this.picVerify);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cbxUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.rtxtTip);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBanager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelBanager.ResumeLayout(false);
            this.panelBanager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancelLogin;
        private System.Windows.Forms.Button btnStartLogin;
        private System.Windows.Forms.LinkLabel llblLoginOption;
        private System.Windows.Forms.RichTextBox rtxtTip;
        private System.Windows.Forms.Panel panelBanager;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox picVerify;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}