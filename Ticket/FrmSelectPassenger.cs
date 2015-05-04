using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ticket
{
    public partial class FrmSelectPassenger : Form
    {
        private Passenger[] _passengers;

        public FrmSelectPassenger(Passenger[] passengers)
        {
            this._passengers = passengers;

            InitializeComponent();
            this.txtQueryPassenger.TextChanged += new EventHandler(txtQueryPassenger_TextChanged);
            this.btnLoadPassengers.Click += new EventHandler(btnLoadPassengers_Click);
            this.btnImportPassenger.Click += new EventHandler(btnImportPassenger_Click);
            this.btnAddPassenger.Click += new EventHandler(btnAddPassenger_Click);
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.dgvPassenger.CellClick += new DataGridViewCellEventHandler(dgvPassenger_CellClick);

            ShowPassengers(this.txtQueryPassenger.Text.Trim());
        }

        void dgvPassenger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }

            var flag = (bool)this.dgvPassenger.Rows[e.RowIndex].Cells["colIndex"].Value;

            this.dgvPassenger.Rows[e.RowIndex].Cells["colIndex"].Value = !flag;

            var no = this.dgvPassenger.Rows[e.RowIndex].Cells["colIdNo"].Value.ToString();

            var passenger = from p in this._passengers where p.passenger_id_no == no select p;

            if (passenger.Count() > 0)
            {
                if (!flag)
                {
                    this.lvSelectPassengers.Items.Add(new ListViewItem() { Text = passenger.First().passenger_name, Tag = passenger.First() });
                }
                else
                {
                    foreach (ListViewItem item in this.lvSelectPassengers.Items)
                    {
                        if (passenger.First() == (item.Tag as Passenger))
                        {
                            this.lvSelectPassengers.Items.Remove(item);
                        }
                    }
                }
            }
        }

        private Regex regex = new Regex("^\\w+$");

        private void ShowPassengers(string query)
        {
            this.dgvPassenger.Rows.Clear();

            if (this._passengers == null || this._passengers.Length <= 0)
                return;

            var queryPassengrs = this._passengers;

            if (!string.IsNullOrEmpty(query))
            {
                queryPassengrs = (from p in this._passengers where regex.IsMatch(query) ? p.first_letter.Contains(query.ToUpper()) : p.passenger_name.Contains(query.ToUpper()) select p).ToArray();
            }

            foreach (Passenger p in queryPassengrs)
            {
                this.dgvPassenger.Rows.Add(new object[] { false, p.passenger_name, p.passenger_id_type_name, p.passenger_id_no, p.mobile_no + (string.IsNullOrEmpty(p.phone_no) ? string.Empty : "/" + p.phone_no), p.passenger_type_name, p.passenger_state, "删除 编辑" });
            }
        }

        void txtQueryPassenger_TextChanged(object sender, EventArgs e)
        {
            //转化成相应的拼音后实现搜索功能
            ShowPassengers(this.txtQueryPassenger.Text.Trim());
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            int count = this.lvSelectPassengers.Items.Count;
            if (count > 0)
            {
                var pArray = new Passenger[count];

                for (var i = 0; i < count; i++)
                {
                    pArray[i] = this.lvSelectPassengers.Items[i].Tag as Passenger;
                }

                OnPassengersSeletedCompleted(new PassengerEventArgs(OperCommand.Select, pArray));
            }

            this.Close();
        }

        void btnAddPassenger_Click(object sender, EventArgs e)
        {
            FrmPassenger frmPassenger = new FrmPassenger();
            frmPassenger.AddPassengerTrigger += new EventHandler<PassengerEventArgs>(frmPassenger_AddPassengerTrigger);
            frmPassenger.ShowDialog();
        }

        void frmPassenger_AddPassengerTrigger(object sender, PassengerEventArgs e)
        {
            OnAddPassengerTrigger(e);
        }

        void btnImportPassenger_Click(object sender, EventArgs e)
        {
            FrmImportPassenger frmImportPassenger = new FrmImportPassenger();
            frmImportPassenger.ShowDialog();
        }

        void btnLoadPassengers_Click(object sender, EventArgs e)
        {
            this.dgvPassenger.Rows.Clear();
            var passengerEventArgs = new PassengerEventArgs(OperCommand.Get, null);
            OnLoadPassengersTrigger(passengerEventArgs);
            //刷新常用联系完成,重新绑定信息
            this._passengers = passengerEventArgs.Passengers;
            ShowPassengers(this.txtQueryPassenger.Text.Trim());
        }

        public event EventHandler<PassengerEventArgs> LoadPassengersTrigger;
        private void OnLoadPassengersTrigger(PassengerEventArgs e)
        {
            if (LoadPassengersTrigger != null)
            {
                LoadPassengersTrigger(this, e);
            }
        }

        public event EventHandler<PassengerEventArgs> AddPassengerTrigger;
        private void OnAddPassengerTrigger(PassengerEventArgs e)
        {
            if (AddPassengerTrigger != null)
            {
                AddPassengerTrigger(this, e);
            }
        }

        public event EventHandler<PassengerEventArgs> PassengersSeletedCompleted;
        private void OnPassengersSeletedCompleted(PassengerEventArgs e)
        {
            if (PassengersSeletedCompleted != null)
            {
                PassengersSeletedCompleted(this, e);
            }
        }
    }
}
