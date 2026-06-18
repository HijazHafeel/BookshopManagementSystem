using Bookshop_Management_System.Bookshop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bookshop_Management_System.Controler
{
    internal class StaffDetails
    {

        public static void Insert(TextBox txtUserID, TextBox txtFName, TextBox txtLName, TextBox txtUserContact, TextBox txtUserEmail, TextBox txtUserAdd, ComboBox cmbGende)
        {
            try
            {
                // Ensure the provided ID follows sequence (e.g., U001, U002...)
                var provided = txtUserID.Text?.Trim().ToUpper();
                // get current max numeric part
                string q = "SELECT MAX(CAST(SUBSTRING(U_ID,2,3) AS INT)) AS MaxNum FROM Staff";
                var dt = model.myconn.Search(q);
                int maxNum = 0;
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    int.TryParse(dt.Rows[0][0].ToString(), out maxNum);
                }
                int expected = maxNum + 1;
                var expectedId = "U" + expected.ToString("D3");
                if (!string.Equals(provided, expectedId, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Staff ID must be the next in sequence: {expectedId}");
                    return;
                }

               string sql = "INSERT INTO Staff (U_ID, F_name,L_Name,Address,Contact,Gender,Email,Role) VALUES ('" + txtUserID.Text+"', '"+txtFName.Text+"', '"+txtLName.Text+"', '"+txtUserAdd.Text+"', '"+txtUserContact.Text+"', '"+ (cmbGende.SelectedItem?.ToString() ?? string.Empty) +"', '"+txtUserEmail.Text.ToLower() + "', 'Staff')";

               model.myconn.Save(sql);
                MessageBox.Show("Data Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        public static void Update(TextBox txtUserID, TextBox txtFName, TextBox txtLName, TextBox txtUserContact, TextBox txtUserEmail, TextBox txtUserAdd, ComboBox cmbGende)
        {
            try
            {
                string sql = "UPDATE Staff SET F_name = '" + txtFName.Text + "', L_Name = '" + txtLName.Text + "', Address = '" + txtUserAdd.Text + "', Contact = '" + txtUserContact.Text + "', Gender = '" + cmbGende.SelectedItem?.ToString() ?? string.Empty + "', Email = '" + txtUserEmail.Text.ToLower() + "' WHERE U_ID = '" + txtUserID.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        public static void Delete(TextBox txtUserID)
        {
            try
            {
                string sql = "DELETE FROM Staff WHERE U_ID = '" + txtUserID.Text + "'";
                model.myconn.Save(sql);
                MessageBox.Show("Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        public static void getAll(DataGridView StaffTable)
        {
           try
            {
                string sql = "SELECT U_ID, F_Name, L_Name, Address, Contact, Gender, Email FROM Staff";
                DataTable dt = model.myconn.Search(sql);

                StaffTable.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    StaffTable.Rows.Add(
                        row["U_ID"].ToString(),
                        row["F_Name"].ToString(),
                        row["L_Name"].ToString(),
                        row["Address"].ToString(),
                        row["Contact"].ToString(),
                        row["Gender"].ToString(),
                        row["Email"].ToString().ToLower()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        
    }
}
}
