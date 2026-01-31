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

namespace GamePulse_Frm.Games
{
    public partial class frmGameManagment : Form
    {
        public frmGameManagment()
        {
            InitializeComponent();
        }
        DataTable dtGames = new DataTable();

        private void _FormatGamesGrid()
        {
            
            dgvGames.RowHeadersVisible = false;
            dgvGames.AllowUserToResizeRows = false;
            dgvGames.ReadOnly = true;
            dgvGames.AllowUserToAddRows = false;
            dgvGames.AllowUserToDeleteRows = false;
            dgvGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGames.BackgroundColor = Color.White;
            dgvGames.BorderStyle = BorderStyle.None;
            dgvGames.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvGames.EnableHeadersVisualStyles = false;
            dgvGames.ColumnHeadersHeight = 45;

            
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(13, 110, 253);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGames.ColumnHeadersDefaultCellStyle = headerStyle;

            
            dgvGames.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgvGames.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvGames.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGames.AllowUserToOrderColumns = false;
            dgvGames.AllowUserToResizeColumns = false;
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGames.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);


            dtGames = clsGamesBus.GetAllGame();
            dgvGames.DataSource = dtGames;

            if (dgvGames.Columns.Count > 0)
            {
                if (dgvGames.Columns.Contains("GameID"))
                {
                    dgvGames.Columns["GameID"].HeaderText = "ID";
                    dgvGames.Columns["GameID"].Width = 60;
                }

                if (dgvGames.Columns.Contains("GameName"))
                {
                    dgvGames.Columns["GameName"].HeaderText = "Game Name";
                }

                if (dgvGames.Columns.Contains("DefaultPrice"))
                {
                    dgvGames.Columns["DefaultPrice"].HeaderText = "Price";
                    dgvGames.Columns["DefaultPrice"].DefaultCellStyle.Format = "C2"; // تنسيق عملة
                    dgvGames.Columns["DefaultPrice"].DefaultCellStyle.ForeColor = Color.DarkGreen; // تمييز السعر بالأخضر
                }

                if (dgvGames.Columns.Contains("isActive"))
                {
                    dgvGames.Columns["isActive"].HeaderText = "Status";
                }

                if (dgvGames.Columns.Contains("GameTypeName"))
                {
                    dgvGames.Columns["GameTypeName"].HeaderText = "Category";
                }
            }
        }
        private void frmGameManagment_Load(object sender, EventArgs e)
        {
            _FormatGamesGrid();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.ShowDialog();
            this.Close();
        }

        private void btnCardManagement_Click(object sender, EventArgs e)
        {
            frmCardManagrement cardManagement = new frmCardManagrement();
            cardManagement.ShowDialog();
            this.Close();
        }

        private void showGameInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int GameID = (int)dgvGames.CurrentRow.Cells[0].Value;
            frmGameInfo game = new frmGameInfo(GameID);
            game.ShowDialog();
            this.Close();
        }

        private void dgvGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
