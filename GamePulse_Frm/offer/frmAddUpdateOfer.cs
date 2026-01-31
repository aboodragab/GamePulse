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
using System.Xml.Linq;

namespace GamePulse_Frm.offer
{
    public partial class frmAddUpdateOfer : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _Offerid;
        clsOffersBus _Offer;
        public frmAddUpdateOfer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateOfer(int offer)
        {
            InitializeComponent();
            _Offerid = offer;
            _Mode = enMode.Update;
        }
        private void _LodeData()
        {
            _Offer = clsOffersBus.Find(_Offerid);

            if (_Offer == null)
            {
                MessageBox.Show("Offer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtName.Text = _Offer.OfferName;
            txtCredit.Text = _Offer.CreditAmount.ToString();
            txtRequired.Text = _Offer.RequiredAmount.ToString();
        }
        private void _RestForm()
        {
            lblTitle.Text = "Add Offer";
            txtName.Text = "";
            txtCredit.Text = "";
            txtRequired.Text = "";
        }
        private void frmAddUpdateOfer_Load(object sender, EventArgs e)
        {
            _RestForm();
            if(_Mode== enMode.Update)
            {
                lblTitle.Text = "Update Offer";
                _LodeData();
            }
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Name is required!");
            }
        }
        private void txtRequired_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRequired.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRequired, "Required Amount is required!");
            }
            if (!clsUtil.IsValidDecimal(txtRequired.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRequired, "Invalid input! Please enter a numeric value (e.g., 10 or 10.50).");
            }
        }
        private void txtCredit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCredit.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCredit, "Credit is required!");
            }
            if (!clsUtil.IsValidDecimal(txtCredit.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCredit, "Invalid input! Please enter a numeric value (e.g., 10 or 10.50).");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(_Mode==enMode.AddNew)
            {
                _Offer = new clsOffersBus();
            }
                _Offer.OfferName = txtName.Text;
                _Offer.RequiredAmount = Convert.ToDecimal(txtRequired.Text);
                _Offer.CreditAmount = Convert.ToDecimal(txtCredit.Text);
                _Offer.IsActive = true;

                if(_Offer.Save())
                {
                    MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Offer";
                }
                else
                {
                    MessageBox.Show("Error: Data was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
