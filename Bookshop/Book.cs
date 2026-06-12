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
            this.StartPosition = FormStartPosition.CenterScreen;
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
            Controler.BookDetails.getAll(dataGridView1);
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
            Controler.BookDetails.getAll(dataGridView1);
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
            if(!Controler.Validation.IsValidIsbn(isbnRaw))
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
            Controler.BookDetails.getAll(dataGridView1);
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            using (var author = new Author())
            {
                this.Hide();
                author.ShowDialog();
                this.Show();
            }


        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            using (var publisher = new Publisher())
            {
                this.Hide();
                publisher.ShowDialog();
                this.Show();
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            using (var staff = new Staff())
            {
                this.Hide();
                staff.ShowDialog();
                this.Show();
            }

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            using (var billing = new Billing())
            {
                this.Hide();
                billing.ShowDialog();
                this.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session
            Controler.GlobalData.LoggedInUser = string.Empty;
            Controler.GlobalData.UserRole = string.Empty;
            Controler.GlobalData.UserID = string.Empty;

            // Hide all open non-login forms
            var openForms = Application.OpenForms.Cast<Form>().ToList();
            foreach (var f in openForms)
            {
                if (f is Login) continue;
                try { f.Hide(); } catch { }
            }

            using (var login = new Login())
            {
                var res = login.ShowDialog();
                if (res == DialogResult.OK)
                {
                    var wf = Application.OpenForms.OfType<WelcomeFrame>().FirstOrDefault();
                    if (wf != null) wf.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
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
