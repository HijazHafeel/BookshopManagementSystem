using Bookshop_Management_System.Bookshop;
using Bookshop_Management_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bookshop_Management_System.Controler.LogIn;

namespace Bookshop_Management_System
{
    public partial class Book : Form
    {
        
        public Book()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Controler.BookDetails.searchId(comboBox2);
            Controler.PublisherDetails.LoadNames(comboBox3);
            Controler.BookDetails.getAll(dataGridView1);
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(validateInput())
            {
                Controler.BookDetails.Insert(textBox7,textBox1,comboBox2, comboBox1,textBox3, textBox4, comboBox3);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text)) { 
                MessageBox.Show("Please enter the ISBN of the book to update."); return;
            }
            else
            {
                Controler.BookDetails.delete(textBox7);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // Controler.BookDetails.searchId( comboBox2);
        }

        public Boolean validateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                comboBox2.SelectedItem == null ||
                comboBox1.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            // Validate ISBN length: allow 10 or 13 digits (ignore hyphens/spaces)
            var isbnRaw = textBox7.Text ?? string.Empty;
            if(Controler.validations.IsValidIsbn(isbnRaw))
            {
                MessageBox.Show("Please enter a valid ISBN (10 or 13 digits, with optional hyphens).");
                return false;
            }
            return true;
        
            // Additional validation logic can be added here (e.g., numeric checks, length checks, etc.)
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(validateInput()) {
                Controler.BookDetails.Update(textBox7, textBox1, comboBox2, comboBox1, textBox3, textBox4, comboBox3);
            }
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show();
            this.Close();


        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Show();
            this.Close();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Close();

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            GlobalData.LoggedInUser = "";
            GlobalData.UserRole = "";
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            // Use column names to get values safely
            this.textBox7.Text = row.Cells["ISBN"].Value?.ToString() ?? string.Empty;      
            this.textBox1.Text = row.Cells["BName"].Value?.ToString() ?? string.Empty;
            var authorName = row.Cells["AName"].Value?.ToString() ?? string.Empty;
            var category = row.Cells["Category"].Value?.ToString() ?? string.Empty;
            this.textBox3.Text = row.Cells["qty"].Value?.ToString() ?? string.Empty;
            this.textBox4.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;
            var publisher = row.Cells["PName"].Value?.ToString() ?? string.Empty;
            // try select item in combo box matching the gender value
            if (!string.IsNullOrEmpty(authorName))
            {
                int index = comboBox2.FindStringExact(authorName.Trim());

                if (index >= 0)
                {
                    comboBox2.SelectedIndex = index;
                }
            }
            if (!string.IsNullOrEmpty(category))
            {
                int index = comboBox1.FindStringExact(category.Trim());

                if (index >= 0)
                {
                    comboBox1.SelectedIndex = index;
                }
            }
            if (!string.IsNullOrEmpty(publisher))
            {
                int index = comboBox3.FindStringExact(publisher.Trim());

                if (index >= 0)
                {
                    comboBox3.SelectedIndex = index;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
