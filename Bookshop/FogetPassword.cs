using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "")
            {
                MessageBox.Show("Please enter your Contact Number.");
                return;
            }

            string searchSql =
                "SELECT * FROM Staff WHERE Contact = '" +
                txtContact.Text + "'";

            DataTable dt = model.myconn.Search(searchSql);

            if (dt.Rows.Count > 0)
            {
                string updateSql =
                    "UPDATE Staff SET Password = '12345' " +
                    "WHERE Contact = '" + txtContact.Text + "'";

                model.myconn.Save(updateSql);

                MessageBox.Show(
                    "Password has been reset successfully.\n\n" +
                    "Your temporary password is: 12345");
            }
            else
            {
                MessageBox.Show("No user found with this Contact Number.");
                txtContact.Clear();
                txtContact.Focus();
            }
        }
    }
}
