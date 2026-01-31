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
    public partial class ctrlGamesInfo : UserControl
    {
        public ctrlGamesInfo()
        {
            InitializeComponent();
        }
        private clsGamesBus Game;
        public void LoadGameData(int GameID)
        {
            Game = clsGamesBus.Find(GameID);
            if (Game == null)
            {
                MessageBox.Show("Card not found!");
                return;
            }
            lblGameID.Text = GameID.ToString();
            lblName.Text = Game.GameName;
            lblPrice.Text = Game.DefaultPrice.ToString();
            lblStatus.Text = Game.IsActive ? "Active" : "Blocked";
            lblStatus.ForeColor = Game.IsActive ? Color.Green : Color.Red;
            lblCategory.Text = clsGameTypesBus.Find(Game.GameTypeID).GameTypeName;

        }
        private void ctrlGamesInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
