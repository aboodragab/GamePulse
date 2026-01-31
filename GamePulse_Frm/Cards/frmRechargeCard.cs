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
    public partial class frmRechargeCard : Form
    {
        int cardid = -1;       
        public frmRechargeCard()
        {
            InitializeComponent();
        }
        public frmRechargeCard(int CardID)
        {
            InitializeComponent();
            cardid = CardID;
        }

        private void _FillOfferInComoboBox()
        {
            DataTable dt = clsOffersBus.GetAllOffer();

            cmbOffer.DataSource = dt;
            cmbOffer.DisplayMember = "OfferName"; 
            cmbOffer.ValueMember = "OfferID";     

            cmbOffer.SelectedIndex = -1;
        }
        private void _ResetDefualtValues()
        {
            clsCardsBus card=clsCardsBus.FindByID(cardid);
            _FillOfferInComoboBox();
            ctrlCardInfo1.LoadCardData(card.CardID);

        }
        private void frmRechargeCard_Load(object sender, EventArgs e)
        {
            cmbAmount.SelectedIndex = 0;
            _ResetDefualtValues();
        }

        private void cmbAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chbUseOffer.Checked)
            {
                if (cmbAmount.SelectedItem == null || string.IsNullOrEmpty(cmbAmount.Text)) return;
                decimal addedAmount = Convert.ToDecimal(cmbAmount.SelectedItem);
                lblNewBalance.Text = (addedAmount).ToString("C");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cmbOffer.Enabled = chbUseOffer.Checked;

            cmbAmount.Enabled = !chbUseOffer.Checked;

            cmbOffer.SelectedIndex = -1;
            cmbAmount.SelectedIndex = -1;
            lblNewBalance.Text = "[???]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsCardsBus card = clsCardsBus.FindByID(cardid);

            if (card == null)
            {
                MessageBox.Show("Card not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chbUseOffer.Checked)
            {
                if (cmbOffer.SelectedValue != null)
                {
                    int offerID = (int)cmbOffer.SelectedValue;
                    clsOffersBus offer = clsOffersBus.Find(offerID);

                    if (offer != null)
                    {
                        if (clsTransactionsBus.RechargeCard(card.CardID, offer.RequiredAmount, clsGlobal.CurrentUser.UserID, offer.OfferID))
                        {
                            if (card.Recharge(offer.CreditAmount))
                            {
                                MessageBox.Show("Offer applied and balance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _ResetDefualtValues();
                            }
                            else
                            {
                                MessageBox.Show("Transaction saved but failed to update card balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to complete the offer transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected offer details could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an offer first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (cmbAmount.SelectedItem != null)
                {
                    decimal amount = Convert.ToDecimal(cmbAmount.SelectedItem);

                    if (clsTransactionsBus.RechargeCard(card.CardID, amount, clsGlobal.CurrentUser.UserID, null))
                    {
                        if (card.Recharge(amount))
                        {
                            MessageBox.Show("Recharge completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _ResetDefualtValues();
                        }
                        else
                        {
                            MessageBox.Show("Transaction saved but failed to update card balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to complete the recharge transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an amount to recharge.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOffer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOffer.SelectedItem == null || string.IsNullOrEmpty(cmbOffer.Text)) return;
            if (chbUseOffer.Checked)
            {
                if (cmbOffer.SelectedValue != null)
                {
                    int offerID = (int)cmbOffer.SelectedValue;
                    clsOffersBus offer = clsOffersBus.Find(offerID);
                    lblNewBalance.Text = (offer.CreditAmount).ToString("C");
                }
            }
        }
    }
}
