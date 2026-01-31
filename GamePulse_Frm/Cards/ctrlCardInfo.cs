using GamePulse_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePulse_Frm.Cards
{
    public partial class ctrlCardInfo : UserControl
    {
        public ctrlCardInfo()
        {
            InitializeComponent();
        }
        private clsCardsBus _Card;
        public void LoadCardData(int CardID)
        {
            _Card = clsCardsBus.FindByID(CardID);

            if (_Card == null)
            {
                MessageBox.Show("Card not found!");
                return;
            }

            lblCardUID.Text = _Card.CardUID;
            lblBalance.Text = _Card.Balance.ToString("C");
            lblStatus.Text = _Card.IsActive ? "Active" : "Blocked";
            lblStatus.ForeColor = _Card.IsActive ? Color.Green : Color.Red;
        }
    }
}
