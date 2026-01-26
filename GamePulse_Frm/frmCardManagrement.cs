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
    public partial class frmCardManagrement : Form
    {
        DataTable dt = new DataTable();
        public frmCardManagrement()
        {
            InitializeComponent();
        }
        private void _FormatCardsGrid()
        {
            dgvCards.RowHeadersVisible = false;
            dgvCards.AllowUserToResizeRows = false;
            dgvCards.ReadOnly = true;
            dgvCards.AllowUserToAddRows = false;
            dgvCards.AllowUserToDeleteRows = false;
            dgvCards.AllowUserToOrderColumns = false;
            dgvCards.AllowUserToResizeColumns = false;
            dgvCards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCards.BackgroundColor = Color.White;
            dgvCards.BorderStyle = BorderStyle.None;
            dgvCards.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCards.EnableHeadersVisualStyles = false;
            dgvCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCards.ColumnHeadersHeight = 45;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(13, 110, 253);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgvCards.ColumnHeadersDefaultCellStyle = headerStyle;

            dgvCards.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgvCards.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCards.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dt = clsCardsBus.GetAllCard();
            dgvCards.DataSource = dt;
            if (dgvCards.Columns.Count > 0)
            {
                if (dgvCards.Columns.Contains("CardID"))
                {
                    dgvCards.Columns["CardID"].HeaderText = "ID";
                    dgvCards.Columns["CardID"].Width = 60;
                }

                if (dgvCards.Columns.Contains("CardUID"))
                {
                    dgvCards.Columns["CardUID"].HeaderText = "Card UID";
                }

                if (dgvCards.Columns.Contains("Balance"))
                {
                    dgvCards.Columns["Balance"].HeaderText = "Balance";
                    dgvCards.Columns["Balance"].DefaultCellStyle.Format = "C2"; 
                    dgvCards.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
                }

                if (dgvCards.Columns.Contains("CreatedDate"))
                {
                    dgvCards.Columns["CreatedDate"].HeaderText = "Issued Date";
                }

                if (dgvCards.Columns.Contains("Status"))
                {
                    dgvCards.Columns["Status"].HeaderText = "Status";
                }

                if (dgvCards.Columns.Contains("IssuedBy"))
                {
                    dgvCards.Columns["IssuedBy"].HeaderText = "Employee";
                }
            }
        }
        private void frmCardManagrement_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            _FormatCardsGrid();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateCard_Click(object sender, EventArgs e)
        {
            frmCreateCard frmCreateCard = new frmCreateCard();
            frmCreateCard.ShowDialog(this);
            frmCardManagrement_Load(null, null);
        }
    }
}
