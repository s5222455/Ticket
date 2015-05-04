using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticket
{
    public partial class FrmVerify : Form
    {
        private string _code;

        public FrmVerify(Image image)
        {
            InitializeComponent();
            this.picVerify.MouseClick += new MouseEventHandler(picVerify_MouseClick);
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            SetVerifyImage(image);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            OnInputCompleted(new InputEventArgs(this._code));
            this.Close();
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            OnInputCompleted(new InputEventArgs(this._code));
            this.Close();
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

        public event EventHandler<InputEventArgs> InputCompleted;
        private void OnInputCompleted(InputEventArgs e)
        {
            if (InputCompleted != null)
                InputCompleted(this, e);
        }
    }

    public class InputEventArgs : EventArgs
    {
        public InputEventArgs(string input)
        {
            this.Input = input;
        }

        public string Input { get; private set; }
    }
}
