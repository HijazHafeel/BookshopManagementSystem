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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            cmbRole.SelectedIndex = 0;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPass_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" ||
               txtUname.Text == "" ||
               txtPass.Text == "" ||
               txtConPass.Text == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            if (txtPass.Text != txtConPass.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            string sql =
                "INSERT INTO Users " +
                "(Username, Password, FullName, Email, Role) " +
                "VALUES ('" +
                txtUname.Text + "','" +
                txtPass.Text + "','" +
                txtFName.Text + "','" +
                txtEmail.Text + "','" +
                cmbRole.Text + "')";

            model.myconn.Save(sql);

            MessageBox.Show("User Registered Successfully");
        }


    }
}
