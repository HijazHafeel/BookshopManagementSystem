using Bookshop_Management_System.Bookshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop_Management_System.Controler
{
    internal class LogIn
    {
<<<<<<< Updated upstream
=======
        public static Boolean LogInbtn(TextBox txtUname, TextBox txtPass)
        {
            try
            {
                // Simple validation check
                if (string.IsNullOrEmpty(txtUname.Text) || string.IsNullOrEmpty(txtPass.Text))
                {
                    MessageBox.Show("Please enter Username and Password.");
                    return false;
                }

                // FIXED: Added U_ID to the SELECT statement so it can be read below
                string sql = "SELECT U_ID, Role FROM Staff WHERE U_Name = '" + txtUname.Text + "' AND Password = '" + txtPass.Text + "'";
                DataTable dt = model.myconn.Search(sql);

                // Check if a matching user was found
                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["Role"].ToString().Trim().ToUpper();
                    GlobalData.LoggedInUser = txtUname.Text;
                    GlobalData.UserRole = role;
                    GlobalData.UserID = dt.Rows[0]["U_ID"].ToString().Trim();

                    if (role == "ADMIN" || role == "STAFF")
                    {
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

        public static void Changeapassword(TextBox txtUserId, TextBox txtUname, TextBox txtnewPass, TextBox txtCnfPass)
        {
            try
            {
                // Basic validation: Check if passwords match before doing database calls
                if (txtnewPass.Text != txtCnfPass.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }

                if (!IsValidPassword(txtnewPass.Text))
                {
                    MessageBox.Show("Password does not meet complexity requirements (Min 8 chars, Upper, Lower, Number, Symbol).");
                    return;
                }

                string checkSql = "SELECT * FROM Staff WHERE U_ID = '" + txtUserId.Text + "' AND U_Name = '" + txtUname.Text + "'";
                DataTable dt = model.myconn.Search(checkSql);

                if (dt.Rows.Count > 0)
                {
                    string updateSql = "UPDATE Staff SET Password = '" + txtnewPass.Text + "' WHERE U_ID = '" + txtUserId.Text + "' AND U_Name = '" + txtUname.Text + "'";
                    model.myconn.Save(updateSql);

                    MessageBox.Show("Password changed successfully.");

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

        public static Boolean isStaff(TextBox txtuserId, TextBox txtFullname, TextBox txtLastname, TextBox txtContact, ComboBox cmbGender)
        {
            try
            {
                string checkSql = "SELECT * FROM Staff WHERE U_ID = '" + txtuserId.Text + "' AND F_Name = '" + txtFullname.Text + "' AND L_Name = '" + txtLastname.Text + "' AND Contact = '" + txtContact.Text + "' AND Gender = '" + cmbGender.Text + "'";
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

        public static void singup(TextBox txtUId, TextBox txtUserName, TextBox txtPass)
        {
            try
            {
                string checkSql = "SELECT U_Name, Password FROM Staff WHERE U_ID = '" + txtUId.Text + "'";
                DataTable dt = model.myconn.Search(checkSql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No staff record found for the provided User ID. Please verify your details first.");
                    return;
                }

                var existingUName = dt.Rows[0]["U_Name"] == DBNull.Value ? string.Empty : dt.Rows[0]["U_Name"].ToString().Trim();
                var existingPass = dt.Rows[0]["Password"] == DBNull.Value ? string.Empty : dt.Rows[0]["Password"].ToString().Trim();

                if (!string.IsNullOrEmpty(existingUName) || !string.IsNullOrEmpty(existingPass))
                {
                    MessageBox.Show("Account already created for this staff member.");
                    return;
                }

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

        public static void Logout()
        {
            Controler.GlobalData.LoggedInUser = string.Empty;
            Controler.GlobalData.UserRole = string.Empty;
            Controler.GlobalData.UserID = string.Empty;

            // Hide all open non-login forms
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
>>>>>>> Stashed changes
    }
}
