using Bookshop_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Bookshop_Management_System.Controler
{
    internal class BookDetails
    {

        public static void searchId(ComboBox cmb1)
        {
            try
            {
                string sql = "SELECT A_ID, A_Name FROM Author ORDER BY A_Name";

                DataTable dt = myconn.Search(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmb1.DataSource = dt;
                    cmb1.DisplayMember = "A_Name";
                    cmb1.ValueMember = "A_ID";
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

        public static void getAll(DataGridView dgv)
        {
            try
            {
                string sql = "SELECT * FROM Book";
                DataTable dt = model.myconn.Search(sql);

                foreach (DataRow row in dt.Rows)
                {
                    var r = row;
                    dgv.Rows.Add(r["B_ISBN"].ToString(), r["B_Name"].ToString(),Controler.AuthorDetails.getName(r["A_ID"].ToString()) , r["B_Category"].ToString(), r["Stock"].ToString(), r["B_Price"].ToString(),Controler.PublisherDetails.getName(r["P_ID"].ToString()));
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to retrieve book details: " + ex.Message);
            }

        }
        public static void delete(TextBox txtid)
        {
            try
            {
                string sql = "DELETE FROM Book WHERE B_ISBN = '" + txtid.Text + "'";
                model.myconn.Save(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to delete book: " + ex.Message);
            }
        }
    

    public static void Insert(TextBox isbn, TextBox name, ComboBox authorId, ComboBox category, TextBox stock, TextBox price, ComboBox publisherId)
        {
            try
            {
                string sql = "INSERT INTO Book (B_ISBN, B_Name, A_ID, B_Category, Stock, B_Price, P_ID) " +
                             "VALUES ('"+isbn.Text+"', '"+name.Text+"', '"+authorId.SelectedValue.ToString() +"', '"+category.Text+"', "+stock.Text+", "+price.Text+", '"+publisherId.SelectedValue.ToString() + "')";
               
                model.myconn.Save(sql);
                MessageBox.Show("Book inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to insert book: " + ex.Message);
            }
        }

        public static void Update(TextBox isbn, TextBox name, ComboBox authorId, ComboBox category, TextBox stock, TextBox price, ComboBox publisherId)
        {
            try
            {
                string sql = "UPDATE Book SET B_Name = '" + name.Text + "', A_ID = '" + authorId.SelectedValue.ToString() + "', B_Category = '" + category.Text + "', Stock = " + stock.Text + ", B_Price = " + price.Text + ", P_ID = '" + publisherId.SelectedValue.ToString() + "' WHERE B_ISBN = '" + isbn.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Book updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to update book: " + ex.Message);
            }
        }
}
}
