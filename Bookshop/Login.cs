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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblUname_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogic_Click(object sender, EventArgs e)
        {

        }

        private void lblDisp_Click(object sender, EventArgs e)
        {

        }

        private void llblFPd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FogetPassword frm = new FogetPassword();
            frm.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUname.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Please enter Username and Password.");
                    return;
                }

                string sql =
                    "SELECT * FROM Staff WHERE " +
                    "U_Name = '" + txtUname.Text + "' " +
                    "AND Password = '" + txtPass.Text + "'";

                DataTable dt = model.myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!");
                    WelcomeFrame wf = new WelcomeFrame(txtUname.Text);
                    wf.Show();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message);
            }

        }

        private void llblReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUser frm = new NewUser();
            frm.Show();
            this.Hide();
        }
    }
}
