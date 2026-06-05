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
        

        public WelcomeFrame(string role)
        {
            InitializeComponent();

            if (role == "admin")
            {
                btnBook.Enabled = true;
                btnstaff.Enabled = true;
                btnpub.Enabled = true;
                btnAuthor.Enabled = true;
                btnBilling.Enabled = true;
            }
            else if (role == "staff")
            {
                btnBook.Enabled = true;
                btnstaff.Enabled = false;
                btnpub.Enabled = false;
                btnAuthor.Enabled = false;
                btnBilling.Enabled = true;
            }
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
            Form2 book = new Form2();
            book.Show();
            this.Close();
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
    }
}
