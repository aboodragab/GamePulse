using GamePulse_Business;
using GamePulse_Frm.Games;
using GamePulse_Frm.offer;
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
    public partial class frmOfferMangment : Form
    {
        public frmOfferMangment()
        {
            InitializeComponent();
        }
        DataTable dtOffers=new DataTable();
        private void _FormatOffersGrid()
        {
            
            dgvOffers.RowHeadersVisible = false;
            dgvOffers.AllowUserToResizeRows = false;
            dgvOffers.ReadOnly = true;
            dgvOffers.AllowUserToAddRows = false;
            dgvOffers.AllowUserToDeleteRows = false;
            dgvOffers.AllowUserToOrderColumns = false;
            dgvOffers.AllowUserToResizeColumns = false;
            dgvOffers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOffers.BackgroundColor = Color.White;
            dgvOffers.BorderStyle = BorderStyle.None;
            dgvOffers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOffers.EnableHeadersVisualStyles = false;
            dgvOffers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOffers.ColumnHeadersHeight = 45;

            
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(13, 110, 253);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgvOffers.ColumnHeadersDefaultCellStyle = headerStyle;

            
            dgvOffers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgvOffers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOffers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            dtOffers = clsOffersBus.GetAllOffer();
            dgvOffers.DataSource = dtOffers;

            if (dgvOffers.Columns.Count > 0)
            {
                if (dgvOffers.Columns.Contains("OfferID"))
                {
                    dgvOffers.Columns["OfferID"].HeaderText = "ID";
                    dgvOffers.Columns["OfferID"].Width = 60;
                }

                if (dgvOffers.Columns.Contains("OfferName"))
                {
                    dgvOffers.Columns["OfferName"].HeaderText = "Offer Name";
                }

                if (dgvOffers.Columns.Contains("RequiredAmount"))
                {
                    dgvOffers.Columns["RequiredAmount"].HeaderText = "Required";
                    dgvOffers.Columns["RequiredAmount"].DefaultCellStyle.Format = "C2";
                    dgvOffers.Columns["RequiredAmount"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                }

                if (dgvOffers.Columns.Contains("CreditAmount"))
                {
                    dgvOffers.Columns["CreditAmount"].HeaderText = "Credit";
                    dgvOffers.Columns["CreditAmount"].DefaultCellStyle.Format = "C2";
                    dgvOffers.Columns["CreditAmount"].DefaultCellStyle.ForeColor = Color.Blue;
                }

                if (dgvOffers.Columns.Contains("Status"))
                {
                    dgvOffers.Columns["Status"].HeaderText = "Status";
                }
            }
        }
        private void frmOfferMangment_Load(object sender, EventArgs e)
        {
            _FormatOffersGrid();
        }

        private void btnCreateOffer_Click(object sender, EventArgs e)
        {
            frmAddUpdateOfer add = new frmAddUpdateOfer();
            add.ShowDialog();
            frmOfferMangment_Load(null,null);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard= new frmDashboard();
            dashboard.ShowDialog();
            this.Close();
        }

        private void btnCardManagement_Click(object sender, EventArgs e)
        {
            frmCardManagrement cardManagement = new frmCardManagrement();
            cardManagement.ShowDialog();
            this.Close();
        }

        private void btnGameManagement_Click(object sender, EventArgs e)
        {
            frmGameManagment gameManagment = new frmGameManagment();
            gameManagment.ShowDialog();
            this.Close();
        }

        private void updateOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int OfferID = (int)dgvOffers.CurrentRow.Cells[0].Value;
            frmAddUpdateOfer updateOfer = new frmAddUpdateOfer(OfferID);
            updateOfer.ShowDialog();
            frmOfferMangment_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            string currentStatus = dgvOffers.CurrentRow.Cells["Status"].Value.ToString();
            if (currentStatus == "Active")
            {
                activeToolStripMenuItem.Enabled = false;
                blockToolStripMenuItem.Enabled = true;
                updateOfferToolStripMenuItem.Enabled = true;
            }
            else
            {
                activeToolStripMenuItem.Enabled = true;
                blockToolStripMenuItem.Enabled = false;
                updateOfferToolStripMenuItem.Enabled = false;
            }
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int OfferID = (int)dgvOffers.CurrentRow.Cells[0].Value;
            if (clsOffersBus.Active(OfferID))
            {
                MessageBox.Show("Offer has been activated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _FormatOffersGrid();
            }
            else
            {
                MessageBox.Show("Failed to activate the Offer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int OfferID = (int)dgvOffers.CurrentRow.Cells[0].Value;
            if (clsOffersBus.Block(OfferID))
            {
                MessageBox.Show("Offer has been blocked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _FormatOffersGrid();
            }
            else
            {
                MessageBox.Show("Failed to block the Offer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
