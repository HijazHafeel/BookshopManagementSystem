using Bookshop_Management_System.Controler;
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
using static Bookshop_Management_System.Controler.LogIn;


namespace Bookshop_Management_System.Bookshop
{
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPubSave_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                Controler.PublisherDetails.Insert(textBox6, textBox2, textBox7, textBox3, textBox5);
            }
        }

        public Boolean validateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) 
                )
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            // Validate publisher ID format: should be 'p' followed by three digits (example: p001)
            var pubId = textBox6.Text?.Trim() ?? string.Empty;
            if (!Controler.validations.IsValidPublisherId(pubId))
            {
                MessageBox.Show("Publisher ID must be in the format 'p001' (letter 'p' followed by three digits).");
                return false;
            }




            // Validate email
            var email = textBox3.Text?.Trim() ?? string.Empty;
            if (!Controler.validations.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            // Validate contact number: must start with '07' and be 10 digits long
            var contact = textBox7.Text?.Trim() ?? string.Empty;
            if (!Controler.validations.IsValidContact(contact))
            {
                MessageBox.Show("Contact number must start with '07' and be 10 digits long.");
                return false;
            }

            return true;
        }

        private void btnPubDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter the Publisher ID to delete.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Controler.PublisherDetails.delete(textBox6);
                }

            }
        }

        private void btnPubReset_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {

                DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Controler.PublisherDetails.update(textBox6, textBox2, textBox7, textBox3, textBox5);
                }

            }
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            Controler.PublisherDetails.getAll(dataGridView1);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                MessageBox.Show(col.Name);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            // Use column names to get values safely
            this.textBox6.Text = row.Cells["PID"].Value?.ToString() ?? string.Empty;
            this.textBox2.Text = row.Cells["PName"].Value?.ToString() ?? string.Empty;
            this.textBox7.Text = row.Cells["PContact"].Value?.ToString() ?? string.Empty;
            this.textBox3.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            this.textBox5.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
            
            // try select item in combo box matching the gender value
            
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
            this.Close();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show(); this.Close();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show(); this.Close();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show(); this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            GlobalData.LoggedInUser = "";
            GlobalData.UserRole = "";
            this.Close();
        }
    }
    
}
