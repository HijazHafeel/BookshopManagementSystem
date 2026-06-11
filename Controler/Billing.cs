using System;
using System.Globalization;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;
using Bookshop_Management_System.model;

namespace Bookshop_Management_System.Controler
{
    public static class Billings
    {
        public static void Search(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            try
            {
                string sql = "SELECT * FROM Book Where B_ISBN like'" + txt1.Text + "'";
              //  String sq = "select * from author where Au_Id like'" + a + "' ";
                DataTable dt = myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    txt1.Text = r["B_ISBN"].ToString();
                    txt2.Text = r["B_Name"].ToString();
                    txt3.Text = r["B_Price"].ToString();
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Save all rows from the provided DataGridView into the Billing table.
        // dg: expected columns: ISBN, Book_Name, Price, Qty, Total (in that order)
        public static void SaveBilling(DataGridView dg, string userId,string total)
        {
            try
            {    int qty = dg.Rows.Count;
                   

                    // Build INSERT statement for Billing table (do NOT insert identity Bill_ID).
                    string sql = "INSERT INTO Billing (U_ID, Qty, Total_Amount) VALUES ('" +userId.Replace("'", "''") + "'," + qty + ", " + total.ToString() + ")";
                  
                    myconn.Save(sql);
                

                MessageBox.Show("Billing records saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to save billing: " + ex.Message);
            }
        }

        // Mirrors the original Java signature: many textboxes were passed although only a few used.
        public static void Insert(TextBox jtf1, TextBox jtf2, TextBox jtf3, TextBox jtf4, TextBox jtf5)
        {
            try
            {
                string sql = "SELECT * FROM Book Where ISBN ='" + jtf1.Text + "'";
                DataTable dt = myconn.Search(sql);
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    jtf2.Text = r["Book_name"].ToString();
                    jtf3.Text = r["Book_price"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void InvoiceNo(Label lbl1)
        {
            try
            {
                string sql = "select * from Billing ";
                DataTable dt = myconn.Search(sql);

                int maxId = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (int.TryParse(r["Bill_ID"].ToString(), out int id))
                    {
                        if (id > maxId) maxId = id;
                    }
                }

                lbl1.Text = (maxId + 1).ToString();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void searchId(TextBox txt1, ComboBox cmb1) {

            try
            { 
                string sql = "SELECT B_ISBN FROM Book WHERE B_ISBN LIKE '%" + txt1.Text + "%'";

                DataTable dt = myconn.Search(sql);

                if (dt.Rows.Count > 0)
                {
                   
                   
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
