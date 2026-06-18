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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
<<<<<<< Updated upstream
=======

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(IsValidInput()) { 
            DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Controler.StaffDetails.Update(txtUId, txtFName, txtLName, txtContact, txtEmail, txtAddress, comboBox1);
            }
                
            }
            Controler.StaffDetails.getAll(dataGridView1);
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            Controler.StaffDetails.getAll(dataGridView1);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(IsValidInput())
            {
                Controler.StaffDetails.Insert(txtUId, txtFName, txtLName, txtContact, txtEmail, txtAddress, comboBox1);
                
            }
            Controler.StaffDetails.getAll(dataGridView1);
        }

        public bool IsValidInput()
        {
            if(string.IsNullOrWhiteSpace(txtUId.Text) ||
                string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (!Controler.Validation.IsValidContact(txtContact.Text))
            {
                MessageBox.Show("Please enter a valid contact number (10 digits, starting with 07).");
                return false;
            }
            if(!Controler.Validation.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            if(!Controler.Validation.IsValidStaffId(txtUId.Text))
            {
                MessageBox.Show("Please enter a valid Staff ID (e.g., U001).");
                return false;
            }
            return true;
        }

            
        

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUId.Text))
            {
                MessageBox.Show("Please enter the Staff ID to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Controler.StaffDetails.Delete(txtUId);
            }
            
            Controler.StaffDetails.getAll(dataGridView1);
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

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Close();
        
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            // Use column names to get values safely
            this.txtUId.Text = row.Cells["UserId"].Value?.ToString() ?? string.Empty;
            this.txtFName.Text = row.Cells["FName"].Value?.ToString() ?? string.Empty;
            this.txtLName.Text = row.Cells["LName"].Value?.ToString() ?? string.Empty;
            this.txtContact.Text = row.Cells["Contact"].Value?.ToString() ?? string.Empty;
            this.txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            this.txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
            var genderValue = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(genderValue))
            {
                int index = comboBox1.FindStringExact(genderValue.Trim());

                if (index >= 0)
                {
                    comboBox1.SelectedIndex = index;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
>>>>>>> Stashed changes
    }
}
