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
    internal class AuthorDetails
    {
        public static void Insert(TextBox txtAuthId, TextBox txtAuthName, TextBox txtAuthPhone, TextBox txtAuthEmail, TextBox txtAuthAddress, ComboBox cmbAuthGender)
        {
            try
            {
                // Ensure author ID is sequential (e.g., A001 -> A002)
                var provided = txtAuthId.Text?.Trim().ToUpper();
                string q = "SELECT MAX(CAST(SUBSTRING(A_ID,2,3) AS INT)) FROM Author";
                var dt = model.myconn.Search(q);
                int maxNum = 0;
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    int.TryParse(dt.Rows[0][0].ToString(), out maxNum);
                }
                int expected = maxNum + 1;
                var expectedId = "A" + expected.ToString("D3");
                if (!string.Equals(provided, expectedId, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Author ID must be the next in sequence: {expectedId}");
                    return;
                }

                string escName = txtAuthName.Text.Replace("'", "''");
                string escPhone = txtAuthPhone.Text.Replace("'", "''");
                string escEmail = txtAuthEmail.Text.Replace("'", "''");
                string escAddress = txtAuthAddress.Text.Replace("'", "''");
                string gender = cmbAuthGender.SelectedItem?.ToString() ?? string.Empty;
                string sql = $"INSERT INTO Author (A_ID, A_Name, Address, Contact, Gender, Email) VALUES ('{txtAuthId.Text}','{escName}','{escAddress}','{escPhone}','{gender}','{escEmail}')";
                model.myconn.Save(sql);
                MessageBox.Show("Author details saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to save author details: " + ex.Message);
            }
        }

        public static void Update(TextBox txtAuthId, TextBox txtAuthName, TextBox txtAuthPhone, TextBox txtAuthEmail, TextBox txtAuthAddress, ComboBox cmbAuthGender)
        {
            try
            {
                string sql = "UPDATE Author SET A_Name = '" + txtAuthName.Text + "', Address = '" + txtAuthAddress.Text + "', Contact = '" + txtAuthPhone.Text + "', Gender = '" + cmbAuthGender.SelectedItem.ToString() + "', Email = '" + txtAuthEmail.Text + "' WHERE A_ID = '" + txtAuthId.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Author details updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to update author details: " + ex.Message);
            }
        }

        public static void Delete(TextBox txtAuthId)
        {
            try
            {
                string sql = "DELETE FROM Author WHERE A_ID = '" + txtAuthId.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Author details deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to delete author details: " + ex.Message);
            }

        }

        public static void Search(TextBox txtAuthId, TextBox txtAuthName, TextBox txtAuthPhone, TextBox txtAuthEmail, TextBox txtAuthAddress, ComboBox cmbAuthGender)
        {
            try
            {
                string sql = "SELECT * FROM Author WHERE A_ID = '" + txtAuthId.Text + "'";
                DataTable dt = model.myconn.Search(sql);
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    txtAuthName.Text = r["A_Name"].ToString();
                    txtAuthAddress.Text = r["Address"].ToString();
                    txtAuthPhone.Text = r["Contact"].ToString();
                    cmbAuthGender.SelectedItem = r["Gender"].ToString();
                }
                else
                {
                    MessageBox.Show("Author not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to search author details: " + ex.Message);
            }
        }

        public static void getAll(DataGridView dgv)
        {
            try
            {
                string sql = "SELECT * FROM Author";
                DataTable dt = model.myconn.Search(sql);

                foreach (DataRow row in dt.Rows)
                {
                    var r = row;
                    dgv.Rows.Add(r["A_ID"].ToString(), r["A_Name"].ToString(), r["Contact"].ToString(), r["Email"].ToString(),r["Address"].ToString(), r["Gender"].ToString() );
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to retrieve author details: " + ex.Message);
            }
            
        }
        public static string getName(string Id)
        {
            try {
                string sql = "SELECT * FROM Author WHERE A_ID = '" + Id + "'";
                DataTable dt = model.myconn.Search(sql);
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    return r["A_Name"].ToString();

                }
                else
                {
                    MessageBox.Show("Author not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to retrieve author details: " + ex.Message);
            }
            return null;
        }
}
}
