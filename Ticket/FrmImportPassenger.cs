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
    public partial class FrmImportPassenger : Form
    {
        public FrmImportPassenger()
        {
            InitializeComponent();
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.rtxtInstructions.ReadOnly = true;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            string[] passengers = this.rtxtPassenger.Lines;

            if (passengers.Length > 0)
            {
                Passenger passenger = null;
                var pers = (from s in passengers where (passenger = TextToPassenger(s)) != null select passenger).ToArray();
                OnSavePassengers(new PassengerEventArgs(OperCommand.Save, pers));
            }

            this.Close();
        }

        void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "文本文件(*.txt)|*.txt";
            ofDialog.FilterIndex = 1;
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                this.rtxtPassenger.Text = System.IO.File.ReadAllText(ofDialog.FileName, Encoding.GetEncoding("gb2312"));
            }
        }

        public event EventHandler<PassengerEventArgs> SavePassengers;
        private void OnSavePassengers(PassengerEventArgs e)
        {
            if (SavePassengers != null)
            {
                SavePassengers(this, e);
            }
        }

        private Passenger TextToPassenger(string passengerInfo)
        {
            if (passengerInfo.Length <= 0)
                return null;

            string[] pInfo = passengerInfo.Split(',');
            Passenger passenger = null;
            switch (pInfo.Length)
            {
                case 4:
                    passenger = new Passenger() { passenger_name = pInfo[0], passenger_id_type_code = pInfo[1], passenger_id_no = pInfo[2], mobile_no = pInfo[3], passenger_type = "1" };
                    break;
                case 5:
                    passenger = new Passenger() { passenger_name = pInfo[0], passenger_id_type_code = pInfo[1], passenger_id_no = pInfo[2], mobile_no = pInfo[3], passenger_type = pInfo[4] };
                    break;
            }

            return passenger;
        }
    }

    public class PassengerEventArgs : EventArgs
    {
        public PassengerEventArgs(OperCommand cmd, Passenger[] passengers)
        {
            this.OperCommand = cmd;
            this.Passengers = passengers;
        }

        public OperCommand OperCommand { get; private set; }

        public Passenger[] Passengers { get; set; }
    }

    public enum OperCommand
    {
        Get,
        Add,
        Delete,
        Save,
        Select,
    }
}
