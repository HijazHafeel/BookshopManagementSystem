using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bookshop_Management_System.Controler
{
    internal class LogIn
    {

        public static Boolean LogInbtn(TextBox txtUname, TextBox txtPass)
        {
            try
            {
                // 1. Simple validation check
                if (txtUname.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Please enter Username and Password.");
                    return false;
                }

                // 2. Build the SQL statement
                string sql = "SELECT Role FROM Staff WHERE U_Name = '" + txtUname.Text + "' AND Password = '" + txtPass.Text + "'";
                DataTable dt = model.myconn.Search(sql);

                // 3. Check if a matching user was found
                if (dt.Rows.Count > 0)
                {
                    // Get the role string and clear out trailing database spaces using Trim()
                    string role = dt.Rows[0]["Role"].ToString().Trim().ToUpper();
                    GlobalData.LoggedInUser = txtUname.Text;
                    GlobalData.UserRole = role;

                    if (role == "ADMIN")
                    {
                        MessageBox.Show("Welcome, Admin!");
                        return true;

                        // Open your Admin Form here
                    }
                    else if (role == "STAFF")
                    {
                        MessageBox.Show("Welcome, Staff!");
                        // Open your Staff/Billing Form here
                        return true;

                    }

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return false;

        }

        public static class GlobalData
        {
            // These variables will stay in memory and can be accessed from any form
            public static string LoggedInUser { get; set; } = "";
            public static string UserRole { get; set; } = "";
        }


        public static void Changeapassword(TextBox txtUserId, TextBox txtUname, TextBox txtnewPass, TextBox txtCnfPass)
        {
            try
            {
                string checkSql = "SELECT * FROM Staff WHERE U_ID = '" + txtUserId.Text + "' AND U_Name = '" + txtUname.Text + "'";
                DataTable dt = model.myconn.Search(checkSql);

                if (dt.Rows.Count > 0)
                {
                    // 4. User exists, update the password
                    string updateSql = "UPDATE Staff SET Password = '" + txtnewPass.Text + "' WHERE U_ID = '" + txtUserId.Text + "' AND U_Name = '" + txtUname.Text + "'";

                    // Using your connection's save/execute method
                    model.myconn.Save(updateSql);

                    MessageBox.Show("Password changed successfully.");

                    // 5. Clear the textboxes
                    txtUserId.Clear();
                    txtUname.Clear();
                    txtnewPass.Clear();
                    txtCnfPass.Clear();
                }
                else
                {
                    MessageBox.Show("No user found with supplied User ID and User Name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        public static Boolean isStaff(TextBox txtuserId, TextBox txtFullname, TextBox txtLastname, TextBox txtContact,ComboBox cmbGender)
        {
            try { 


            string checkSql = "SELECT * FROM Staff WHERE U_ID = '" + txtuserId.Text + "' AND F_Name = '" + txtFullname.Text + "'  AND L_Name = '" + txtLastname.Text + "' AND Contact = '" + txtContact.Text + "' AND Gender = '" + cmbGender.Text + "'";
           // MessageBox.Show(checkSql);
            DataTable dt = model.myconn.Search(checkSql);
            return dt.Rows.Count > 0;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return false;
        }     
    

    public static void singup(TextBox txtUId, TextBox txtUserName, TextBox txtPass) {
            try
            {
                // Check if staff record exists for provided U_ID
                string checkSql = "SELECT U_Name, Password FROM Staff WHERE U_ID = '" + txtUId.Text + "'";
                DataTable dt = model.myconn.Search(checkSql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No staff record found for the provided User ID. Please verify your details first.");
                    return;
                }

                var existingUName = dt.Rows[0]["U_Name"] == DBNull.Value ? string.Empty : dt.Rows[0]["U_Name"].ToString().Trim();
                var existingPass = dt.Rows[0]["Password"] == DBNull.Value ? string.Empty : dt.Rows[0]["Password"].ToString().Trim();

                // If either U_Name or Password already exists (non-empty), treat account as already created
                if (!string.IsNullOrEmpty(existingUName) || !string.IsNullOrEmpty(existingPass))
                {
                    MessageBox.Show("Account already created for this staff member.");
                    return;
                }

                // Update record with new username and password
                string updateSql = "UPDATE Staff SET U_Name = '" + txtUserName.Text + "', Password = '" + txtPass.Text + "' WHERE U_ID = '" + txtUId.Text + "'";
                model.myconn.Save(updateSql);

                MessageBox.Show("Account created successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public static bool IsValidPassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd) || pwd.Length < 8) return false;

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;
            foreach (char c in pwd)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSymbol = true;
            }

            return hasUpper && hasLower && hasDigit && hasSymbol;
        }
    }
}
