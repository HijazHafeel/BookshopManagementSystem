using Bookshop_Management_System.model;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bookshop_Management_System.Controler
{
    internal class PublisherDetails
    {
        public static void LoadNames(ComboBox cmb)
        {
            try
            {
                string sql = "SELECT P_ID,P_Name FROM Publisher ORDER BY P_Name";
                DataTable dt = myconn.Search(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "P_Name";
                    cmb.ValueMember = "P_ID";
                }
                else
                {
                    cmb.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public static string getName(string Id)
        {
            try
            {
                string sql = "SELECT * FROM Publisher WHERE P_ID = '" + Id + "'";
                DataTable dt = model.myconn.Search(sql);
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    return r["P_Name"].ToString();

                }
                else
                {
                    MessageBox.Show("Publisher not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to retrieve publisher details: " + ex.Message);
            }
            return null;
        }

        public static void Insert(TextBox txtid, TextBox txtname, TextBox txtcontact, TextBox txtemail, TextBox txtadd)
        {
            try
            {
                string sql = "INSERT INTO Publisher (P_ID, P_Name, Contact, Email, Address) VALUES ('" + txtid.Text + "','" + txtname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + txtadd.Text + "')";
                myconn.Save(sql);
                MessageBox.Show("Publisher added successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to add publisher: " + ex.Message);
            }
        }

        public static void update(TextBox txtid, TextBox txtname, TextBox txtcontact, TextBox txtemail, TextBox txtadd)
        {
            try
            {
                string sql = "UPDATE Publisher SET P_Name = '" + txtname.Text + "', Contact = '" + txtcontact.Text + "', Email = '" + txtemail.Text + "', Address = '" + txtadd.Text + "' WHERE P_ID = '" + txtid.Text + "'";
                model.myconn.Save(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to add publisher: " + ex.Message);
            }
        }



        public static void delete(TextBox txtid)
        {
            try
            {
                string sql = "DELETE FROM Publisher WHERE P_ID = '" + txtid.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Publisher deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed to delete publisher: " + ex.Message);
            }
        }
        public static void getAll(DataGridView dgv)
        {
            try
            {
                string sql = "SELECT * FROM Publisher";
                DataTable dt = model.myconn.Search(sql);
                dgv.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    var r = row;
                    dgv.Rows.Add(r["P_ID"].ToString(), r["P_Name"].ToString(), r["Address"].ToString(), r["Contact"].ToString(), r["Email"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve publisher details: " + ex.Message);
                Console.WriteLine(ex);
               
            }
        }
}
}
