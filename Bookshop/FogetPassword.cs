using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bookshop_Management_System.Bookshop
{
    public partial class FogetPassword : Form
    {
        public FogetPassword()
        {
            InitializeComponent();
        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Validate inputs
            string userId = txtuserid.Text?.Trim();
            string userName = txtUserName.Text?.Trim();
            string newPass = txtNewPass.Text ?? string.Empty;
            string confPass = txtCnfPass.Text ?? string.Empty;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter both User ID and User Name.");
                return;
            }

            if (newPass != confPass)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            if (!Controler.LogIn.IsValidPassword(newPass))
            {
                MessageBox.Show("Password must be at least 8 characters and include an uppercase letter, a lowercase letter, a digit and a symbol.");
                return;
            }

           Controler.LogIn.Changeapassword(txtuserid, txtUserName, txtNewPass, txtCnfPass);
        }

       
    }
}
