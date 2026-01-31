using GamePulse_Business;
using GamePulse_Frm.Games;
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
    public partial class frmDashboard : Form
    {
        DataTable dt=new DataTable();
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void _FormatTransactionsGrid()
        {
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToOrderColumns = false;
            dgvTransactions.AllowUserToResizeColumns = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTransactions.ColumnHeadersHeight = 45;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(13, 110, 253);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgvTransactions.ColumnHeadersDefaultCellStyle = headerStyle;

            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;

            if (dgvTransactions.Columns.Count > 0)
            {
                dgvTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvTransactions.Columns.Contains("OfferName"))
                {
                    dgvTransactions.Columns["OfferName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                dgvTransactions.Columns["TransactionID"].HeaderText = "ID";
                dgvTransactions.Columns["TransactionID"].Width = 60;
                dgvTransactions.Columns["TransactionDate"].HeaderText = "Date & Time";
                dgvTransactions.Columns["ActualAmount"].HeaderText = "Amount";
                dgvTransactions.Columns["ActualAmount"].DefaultCellStyle.Format = "N2";
                dgvTransactions.Columns["ActualAmount"].DefaultCellStyle.ForeColor = Color.Green;
                dgvTransactions.Columns["TransactionType"].HeaderText = "Type";
                dgvTransactions.Columns["CardUID"].HeaderText = "Card UID";
                dgvTransactions.Columns["GameName"].HeaderText = "Game";
                dgvTransactions.Columns["PerformedBy"].HeaderText = "User";
                dgvTransactions.Columns["OfferName"].HeaderText = "Offer";
            }
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            _RefreshAllDashboardData();
        }
        private void _RefreshDashboardStats()
        {
            var stats = clsDashboardBus.GetStats();
            if (stats != null)
            {
                lblTotalRevenue.Text = stats.TotalRevenue.ToString("C"); 
                lblActiveCards.Text = stats.ActiveCards.ToString() + " Cards";
                lblTodayPlays.Text = stats.TodayPlays.ToString() + " Plays";
            }
            var last = clsDashboardBus.GetLast();
            if (last != null)
            {
                lblTypeName.Text = last.TypeName;
                lblActualAmount.Text = last.ActualAmount.ToString("C");
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void _RefreshAllDashboardData()
        {
            dt = clsDashboardBus.GetTop50();
            dgvTransactions.DataSource = dt;
            _FormatTransactionsGrid();
            _RefreshDashboardStats();
        }
        private void timerDashboardRefresh_Tick(object sender, EventArgs e)
        {
            _RefreshAllDashboardData();
        }

        private void btnCardManagement_Click(object sender, EventArgs e)
        {
            frmCardManagrement cardManagrement = new frmCardManagrement();
            cardManagrement.ShowDialog();
            this.Close();
        }

        private void btnGameManagement_Click(object sender, EventArgs e)
        {
            frmGameManagment frmGameManagment = new frmGameManagment();
            frmGameManagment.ShowDialog();
            this.Close();

        }
    }
}
