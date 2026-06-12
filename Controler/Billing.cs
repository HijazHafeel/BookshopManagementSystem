using System;
using System.Data;
using System.Windows.Forms;
using Bookshop_Management_System.model;

namespace Bookshop_Management_System.Controler
{
    public static class Billings
    {
        // Looks up book details using the exact ISBN
        public static void Search(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            try
            {
                // Removed 'like' since an ISBN search should typically be exact
                string sql = "SELECT * FROM Book WHERE B_ISBN = '" + txt1.Text.Replace("'", "''") + "'";
                DataTable dt = myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    txt1.Text = r["B_ISBN"].ToString().Trim();
                    txt2.Text = r["B_Name"].ToString().Trim();
                    txt3.Text = r["B_Price"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error searching for book: " + ex.Message);
            }
        }

        // Saves billing information to the database
        // dg: expected columns include a Quantity column (assumed at index 3 based on your comment)
        public static void SaveBilling(DataGridView dg, string total)
        {
            try
            {
                if (dg.Rows.Count == 0 || (dg.AllowUserToAddRows && dg.Rows.Count == 1))
                {
                    MessageBox.Show("No items in the cart to save.");
                    return;
                }

                // FIXED: Calculate the actual sum of quantities instead of just counting rows
                int totalQty = 0;
                foreach (DataGridViewRow row in dg.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the empty placeholder row at the bottom

                    // Assumes Qty is in the 4th column (index 3) based on your comment: ISBN, Book_Name, Price, Qty, Total
                    if (row.Cells[3].Value != null && int.TryParse(row.Cells[3].Value.ToString(), out int rowQty))
                    {
                        totalQty += rowQty;
                    }
                }

                string userId = Controler.GlobalData.UserID;

                // Build and execute the INSERT statement
                string sql = "INSERT INTO Billing (U_ID, Qty, Total_Amount) VALUES ('" + userId.Replace("'", "''") + "', " + totalQty + ", " + total + ")";
                myconn.Save(sql);

                MessageBox.Show("Billing records saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to save billing: " + ex.Message);
            }
        }

        // Mirrors original signature; synchronized to use consistent database column names
        public static void Insert(TextBox jtf1, TextBox jtf2, TextBox jtf3, TextBox jtf4, TextBox jtf5)
        {
            try
            {
                // FIXED: Changed column names to match the 'Search' method schema (B_ISBN, B_Name, B_Price)
                string sql = "SELECT * FROM Book WHERE B_ISBN = '" + jtf1.Text.Replace("'", "''") + "'";
                DataTable dt = myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    jtf2.Text = r["B_Name"].ToString().Trim();
                    jtf3.Text = r["B_Price"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Generates the next Invoice Number instantly
        public static void InvoiceNo(Label lbl1)
        {
            try
            {
                // OPTIMIZED: Ask SQL Server to give the maximum ID instead of pulling down the whole table
                string sql = "SELECT MAX(Bill_ID) AS MaxID FROM Billing";
                DataTable dt = myconn.Search(sql);

                int nextId = 1; // Default to 1 if table is empty

                if (dt.Rows.Count > 0 && dt.Rows[0]["MaxID"] != DBNull.Value)
                {
                    nextId = Convert.ToInt32(dt.Rows[0]["MaxID"]) + 1;
                }

                lbl1.Text = nextId.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                lbl1.Text = "1"; // Fallback safe default
            }
        }

        // Populates a ComboBox suggestion list matching typed partial ISBNs
        public static void searchId(TextBox txt1, ComboBox cmb1)
        {
            try
            {
                string sql = "SELECT B_ISBN FROM Book WHERE B_ISBN LIKE '%" + txt1.Text.Replace("'", "''") + "%'";
                DataTable dt = myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                    // FIXED: Assigned the DataSource so items actually appear in the dropdown
                    cmb1.DataSource = dt;
                    cmb1.DisplayMember = "B_ISBN";
                    cmb1.ValueMember = "B_ISBN";
                }
                else
                {
                    cmb1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred during search: " + ex.Message);
            }
        }
    }
}