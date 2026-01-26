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

namespace GamePulse_Frm
{
    public partial class frmCreateCard : Form
    {
        public frmCreateCard()
        {
            InitializeComponent();
        }
        private void btnCreateCard_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsCardsBus card = new clsCardsBus();
            card.CardUID=txtRFID.Text;
            card.Balance = 0;
            card.CreatedByUserID=1;

            if (card.Save())
            {
                decimal initialAmount = 0;

                if (decimal.TryParse(txtBalance.Text, out initialAmount) && initialAmount > 0)
                {
                    if (clsTransactionsBus.RechargeCard(card.CardID, initialAmount, 1, null))
                    {
                        card.Recharge(initialAmount);
                        MessageBox.Show("Card created and initialized with balance successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Card created successfully, but failed to add the initial balance. Please recharge it manually.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("This Card Number already exists in the system. Please use a different card.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBalance_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                errorProvider1.SetError(txtBalance, "Balance cannot be empty.");
            }
            else if (!clsUtil.IsValidDecimal(txtBalance.Text))
            {
                errorProvider1.SetError(txtBalance, "Please enter a valid amount (e.g., 10 or 10.50).");
            }
            else
            {
                errorProvider1.SetError(txtBalance, "");
            }
        }

        private void txtRFID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRFID.Text))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtRFID, "Card ID cannot be empty!");
            }
            else if (!clsUtil.IsValidCardUID(txtRFID.Text.Trim()))
            {
                errorProvider1.SetError(txtRFID, "Invalid Card ID! Use only letters and numbers (5-20 characters).");
            }
            else
            {
                errorProvider1.SetError(txtRFID, ""); 
            }
        }
    }
}
