using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
            this.StartPosition = FormStartPosition.CenterScreen;
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
            using (var frm = new FogetPassword())
            {
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
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
           if(Controler.LogIn.LogInbtn(txtUname, txtPass)) {
                // Signal successful login to Program.Main and close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void llblReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new NewUser())
            {
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
        }
    }
}
