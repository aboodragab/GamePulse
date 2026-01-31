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
    public partial class frmGameInfo : Form
    {
        int gameID;
        public frmGameInfo(int gameID)
        {
            InitializeComponent();
            this.gameID = gameID;
        }
        private void frmGameInfo_Load(object sender, EventArgs e)
        {
            ctrlGamesInfo1.LoadGameData(this.gameID);
        }
    }
}
