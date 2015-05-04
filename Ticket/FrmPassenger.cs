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
    public partial class FrmPassenger : Form
    {
        public FrmPassenger()
        {
            InitializeComponent();
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            BindPassengerType();
            BindIdType();
        }

        private void BindPassengerType()
        {
            BindCombobox(typeof(PassengerType), cbxPassengerType);
        }

        private void BindIdType()
        {
            BindCombobox(typeof(CardType), cbxIdType);
        }

        private void BindCombobox(Type t, ComboBox cbx)
        {
            this.cbxPassengerType.DataSource = EnumHelper.ConvertEnumToListItems(t);
            this.cbxPassengerType.ValueMember = "Value";
            this.cbxPassengerType.DisplayMember = "Text";
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnYes_Click(object sender, EventArgs e)
        {
            string name = string.Empty;
            string idType = string.Empty;
            string idNo = string.Empty;
            string mobileNo = string.Empty;
            string passengerType = string.Empty;

            OnAddPassengerTrigger(new PassengerEventArgs(OperCommand.Add, new Passenger[] { }));
            this.Close();
        }

        public event EventHandler<PassengerEventArgs> AddPassengerTrigger;
        private void OnAddPassengerTrigger(PassengerEventArgs e)
        {
            if (AddPassengerTrigger != null)
            {
                AddPassengerTrigger(this, e);
            }
        }
    }
}
