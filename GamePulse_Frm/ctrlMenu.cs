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
    public partial class ctrlMenu : UserControl
    {
        private readonly Color _activeBackColor = Color.FromArgb(13, 110, 253); 
        private readonly Color _activeForeColor = Color.White;
        private readonly Color _defaultBackColor = Color.White;
        private readonly Color _defaultForeColor = Color.Black;

        public event Action<string> OnMenuClick;
        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            _ResetButtonStyles();
            clickedButton.BackColor = _activeBackColor;
            clickedButton.ForeColor = _activeForeColor;
            OnMenuClick?.Invoke(clickedButton.Name);
        }
        private void _ResetButtonStyles()
        {
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn.Name != "btnLogout") 
                {
                    btn.BackColor = _defaultBackColor;
                    btn.ForeColor = _defaultForeColor;
                }
            }
        }
        private void _SubscribeToEvents()
        {
            
            btnDashboard.Click += MenuButton_Click;
            btnCardManagement.Click += MenuButton_Click;
            btnTopUp.Click += MenuButton_Click;
            btnGameManagement.Click += MenuButton_Click;
            btnPlayDeduction.Click += MenuButton_Click;
            btnTransactions.Click += MenuButton_Click;
            btnReports.Click += MenuButton_Click;
            btnLogout.Click += MenuButton_Click;
        }
        public ctrlMenu()
        {
            InitializeComponent();
        }

        private void pnlLogoSection_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
