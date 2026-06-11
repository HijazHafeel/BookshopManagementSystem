using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            panel3.Visible = false;
            panel4.Visible = true;
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
            // Basic validation


            string userId = txtUId.Text?.Trim();
            string userName = txtUserName.Text?.Trim();
            string newPass = txtPass.Text ?? string.Empty;
            string confPass = txtConPass.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Please enter the User ID (go to Next and verify staff details first).");
                return;
            }

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter User Name.");
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

            Controler.LogIn.singup(txtUId, txtUserName, txtPass);
            // Clear fields
            txtUserName.Clear();
            txtPass.Clear();
            txtConPass.Clear();
            txtUId.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtContact.Clear();
            comboBox1.SelectedIndex = -1;

            panel3.Visible = false;
            panel4.Visible = true;


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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNxt_Click(object sender, EventArgs e)
        {
           
            if(txtFName.Text == "" ||
                txtLName.Text == "" ||
                txtUId.Text == "" ||
                txtContact.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }else if(Controler.LogIn.isStaff(txtUId,txtFName, txtLName, txtContact, comboBox1))
            {
                panel3.Visible = true;
                panel4.Visible = false;

            }
            else
            {
                MessageBox.Show("No matching staff record found. Please check your details.");


            }
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtUId.Clear();
            txtFName.Clear();
            txtLName.Clear(); 
            txtContact.Clear();
            txtPass.Clear();
            txtConPass.Clear();
        }
    }
}
