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
    public partial class frmCardInfo : Form
    {
        int cardId;
        public frmCardInfo(int cardID)
        {
            InitializeComponent();
            cardId = cardID;
        }
         
        private void frmCardInfo_Load(object sender, EventArgs e)
        {
            clsCardsBus card = clsCardsBus.FindByID(cardId);
            if (card != null)
            {
                ctrlCardInfo1.LoadCardData(card.CardID);
            }
        }
    }
}
