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
    public partial class WelcomeFrame : Form
    {

        String username = Controler.LogIn.GlobalData.LoggedInUser;
        string role = Controler.LogIn.GlobalData.UserRole;
        

        public WelcomeFrame()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Close();
        }

        private void WelcomeFrame_Load(object sender, EventArgs e)
        {
            label1.Text = "HI! Welcome, " + username;

            if (role == "ADMIN")
            {
                btnBook.Enabled = true;
                btnstaff.Enabled = true;
                btnpub.Enabled = true;
                btnAuthor.Enabled = true;
                btnBilling.Enabled = true;
            }
            else if (role == "STAFF")
            {
                btnBook.Enabled = true;
                btnstaff.Enabled = false;
                btnpub.Enabled = false;
                btnAuthor.Enabled = false;
                btnBilling.Enabled = true;
            }
            else
            {
                btnBook.Enabled = true;
                btnstaff.Enabled = true;
                btnpub.Enabled = true;
                btnAuthor.Enabled = true;
                btnBilling.Enabled = true;

            }
        }
    }
}
