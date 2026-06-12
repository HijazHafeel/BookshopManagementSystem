using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bookshop_Management_System.Controler.LogIn;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bookshop_Management_System.Bookshop
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (IsValidInput())
            {

                Controler.AuthorDetails.Insert(txtAuthId, txtAuthName, txtAuthContact, txtAuthEmail, txtAuthAdd, cmbGender);

            }
            Controler.AuthorDetails.getAll(AuthorTable);
        }

        private Boolean IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtAuthId.Text) ||
                string.IsNullOrWhiteSpace(txtAuthName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthContact.Text) ||
                string.IsNullOrWhiteSpace(txtAuthEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAuthAdd.Text) ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            // Contact: must start with '07' and be exactly 10 digits
            string contact = txtAuthContact.Text.Trim();
            if (!Regex.IsMatch(contact, @"^07\d{8}$"))
            {
                MessageBox.Show("Please enter a valid contact number starting with '07' and 10 digits long.");
                return false;
            }

            // Email: validate format using MailAddress
            string email = txtAuthEmail.Text.Trim();
            try
            {
                var addr = new MailAddress(email);
                if (addr.Address != email)
                {
                    MessageBox.Show("Please enter a valid email address.");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (IsValidInput()) {

                DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Controler.AuthorDetails.Update(txtAuthId, txtAuthName, txtAuthContact, txtAuthEmail, txtAuthAdd, cmbGender);
                }
                
            }
            Controler.AuthorDetails.getAll(AuthorTable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthId.Text)) { 
                MessageBox.Show("Please enter the Author ID to delete.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Controler.AuthorDetails.Delete(txtAuthId);
                }
                
            }
            Controler.AuthorDetails.getAll(AuthorTable);
        }

        private void Author_Load(object sender, EventArgs e)
        {
            Controler.AuthorDetails.getAll(AuthorTable);
            // Wire up cell click handler to populate fields when a row is clicked
            //this.AuthorTable.CellClick += new DataGridViewCellEventHandler(this.AuthorTable_CellClick);
        }

        private void AuthorTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = this.AuthorTable.Rows[e.RowIndex];
            // Use column names to get values safely
            this.txtAuthId.Text = row.Cells["Author_ID"].Value?.ToString() ?? string.Empty;
            this.txtAuthName.Text = row.Cells["Name"].Value?.ToString() ?? string.Empty;
            this.txtAuthContact.Text = row.Cells["Contact"].Value?.ToString() ?? string.Empty;
            this.txtAuthEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            this.txtAuthAdd.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
            var genderVal = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
            // try select item in combo box matching the gender value
            if (!string.IsNullOrEmpty(genderVal))
            {
                int index = cmbGender.FindStringExact(genderVal.Trim());

                if (index >= 0)
                {
                    cmbGender.SelectedIndex = index;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            using (var book = new Book())
            {
                this.Hide();
                book.ShowDialog();
                this.Show();
            }
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            
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
            Controler.GlobalData.LoggedInUser = string.Empty;
            Controler.GlobalData.UserRole = string.Empty;
            Controler.GlobalData.UserID = string.Empty;

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

        private void AuthorTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
