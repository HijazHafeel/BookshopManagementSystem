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
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");

            cmbGender.SelectedIndex = 0;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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
                txtUName.Text == "" ||
                txtPass.Text == "" ||
                txtConPass.Text == "" ||
                txtContact.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            if (txtPass.Text != txtConPass.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Generate next User ID
            string uid = "U001";

            DataTable dt = model.myconn.Search(
                "SELECT TOP 1 U_ID FROM Staff ORDER BY U_ID DESC");

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["U_ID"].ToString().Trim();

                int number = Convert.ToInt32(lastID.Substring(1));
                number++;

                uid = "U" + number.ToString("000");
            }

            string sql =
                "INSERT INTO Staff " +
                "(U_ID, U_Name, F_Name, L_Name, Address, Contact, Gender, Password) " +
                "VALUES ('" +
                uid + "','" +
                txtUName.Text + "','" +
                txtFName.Text + "','" +
                txtLName.Text + "','" +
                txtAddress.Text + "','" +
                txtContact.Text + "','" +
                cmbGender.Text + "','" +
                txtPass.Text + "')";

            model.myconn.Save(sql);

            MessageBox.Show(
                "Registration Successful!\nYour User ID is: " + uid);

            txtUName.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtPass.Clear();
            txtConPass.Clear();

            cmbGender.SelectedIndex = 0;

            txtFName.Focus();
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {

        }

        private void llblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }
    }
}
