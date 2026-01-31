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
    public partial class frmAddUpdateGame : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _GameID;
        private clsGamesBus _Game;
        public frmAddUpdateGame()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateGame(int Gameid)
        {
            InitializeComponent();
            _GameID = Gameid;
            _Mode = enMode.Update;
        }
        private void _FillCategoriesComboBox()
        {
            DataTable dt = clsGameTypesBus.GetAllGameTypes();

            cmbGameType.DataSource = dt;
            cmbGameType.DisplayMember = "GameTypeName";
            cmbGameType.ValueMember = "GameTypeID";
            if (dt.Rows.Count > 0)
                cmbGameType.SelectedIndex = 0;
        }

        private void _LodeData()
        {
            _Game = clsGamesBus.Find(_GameID);

            if (_Game == null)
            {
                MessageBox.Show("Game not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
                ctrlGamesInfo1.LoadGameData(_GameID);
                txtGameName.Text = _Game.GameName;
                txtPrice.Text = _Game.DefaultPrice.ToString();
                cmbGameType.SelectedValue = _Game.GameTypeID;

        }
        private void _RestForm()
        {
            lblTitle.Text = "Add New Game";
            txtGameName.Text = "";
            txtPrice.Text = "";
            cmbGameType.SelectedIndex = 0;
            ctrlGamesInfo1.RestForm();
        }
        private void frmAddUpdateGame_Load(object sender, EventArgs e)
        {
            _FillCategoriesComboBox();
            _RestForm();
            if(_Mode==enMode.Update)
            {
                lblTitle.Text = "Update Game Info";
                _LodeData();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_Mode == enMode.AddNew)
                _Game = new clsGamesBus();

            _Game.GameName = txtGameName.Text.Trim();
            _Game.DefaultPrice = decimal.Parse(txtPrice.Text.Trim());
            _Game.GameTypeID = (int)cmbGameType.SelectedValue;
            _Game.IsActive = true;

            if (_Game.Save())
            {
                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                _GameID = _Game.GameID;
                lblTitle.Text = "Update Game Info";

                ctrlGamesInfo1.LoadGameData(_GameID);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtPrice, "Price is required!");
            }
            if(!clsUtil.IsValidDecimal(txtPrice.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "Invalid Price! Please enter a numeric value (e.g., 10 or 10.50).");
            }
        }

        private void txtGameName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtGameName, "Name is required!");
            }
        }
    }
    }

