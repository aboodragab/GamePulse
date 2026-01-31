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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            clsUsersBus user = clsUsersBus.FindByUserNameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (user != null)
            {
                if (!user.IsActive)
                {

                    txtUsername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                frmDashboard dashboard = new frmDashboard();
                dashboard.ShowDialog();
                this.Close();

            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
