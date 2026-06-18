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
        public WelcomeFrame()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            // Open staff form as dialog and keep WelcomeFrame alive
            using (var staff = new Staff())
            {
                this.Hide();
                staff.ShowDialog();
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var author = new Author())
            {
                this.Hide();
                author.ShowDialog();
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var book = new Book())
            {
                this.Hide();
                book.ShowDialog();
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var publisher = new Publisher())
            {
                this.Hide();
                publisher.ShowDialog();
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var billing = new Billing())
            {
                this.Hide();
                billing.ShowDialog();
                this.Show();
            }
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
            
>>>>>>> Stashed changes
        }
    }
}
