using Bookshop_Management_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookshop_Management_System.Bookshop
{
    public partial class Billing : Form
    {
        // Holds all book records loaded on form load
        
        DataTable dt = new DataTable();

        public Billing()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSubtotal();
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSubtotal();
        }

        private void DataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSubtotal();
        }

        // Sum the last column (named "Total") of the DataGridView and set textBox6
        private void UpdateSubtotal()
        {
            try
            {
                decimal sum = 0m;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    object val = null;
                    // prefer column name if present
                    if (dataGridView1.Columns.Contains("Total"))
                        val = row.Cells["Total"].Value;
                    else if (row.Cells.Count > 0)
                        val = row.Cells[row.Cells.Count - 1].Value; // fallback to last column

                    if (val == null) continue;

                    if (decimal.TryParse(val.ToString(), out decimal v))
                        sum += v;
                }

                textBox6.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            
            try
            {
                Controler.Billings.InvoiceNo(label11);
                // Also prepare an in-memory autocomplete list for ISBNs
                string sql = "SELECT B_ISBN FROM Book";
                dt = myconn.Search(sql);

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    collection.Add(row["B_ISBN"].ToString());
                }
               
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = collection;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred while loading books: " + ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter an ISBN.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox4.Text)) {
                MessageBox.Show("Please enter an Book Count.");
                return;
            }
            else
            {
                try
                {
                    // Controler.Billings.Insert(textBox1, textBox2, textBox3, textBox4);
                    // Add the book to the DataGridView
                    float price = float.Parse(textBox3.Text);
                    int Count = int.Parse(textBox4.Text);
                    float total = price * Count;
                    dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, total.ToString());
                    // Clear input fields after adding
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    UpdateSubtotal();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("An error occurred while adding the book: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        // When the user types into textBox1, query the database for matching ISBNs and populate comboBox1.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Populate combobox suggestions based on current textbox text
            try
            {
                Controler.Billings.searchId(textBox1, comboBox1);
                Controler.Billings.Search(textBox1, textBox2, textBox3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(textBox7.Text) < float.Parse(textBox6.Text))
                {
                    MessageBox.Show("Amount paid cannot be less than the subtotal.");
                    return;
                }
                // Use a default user id and customer name for now; adjust as needed
                
                string total = textBox6.Text;

                Controler.Billings.SaveBilling(dataGridView1,total);

                // Clear the grid after saving
                dataGridView1.Rows.Clear();
                UpdateSubtotal();

                // Refresh invoice number
                Controler.Billings.InvoiceNo(label11);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to save billing records: " + ex.Message);
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
           
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSubtotal();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // 1. Safely extract the subtotal (default to 0 if empty or invalid)
            float.TryParse(textBox6.Text, out float subtotal);

            // 2. Safely extract the amount paid (default to 0 if empty or invalid)
            float.TryParse(textBox7.Text, out float amount);

            // 3. Perform the calculation and display the balance change
            textBox8.Text = (amount - subtotal).ToString("0.00");
        }

        
    }
}
