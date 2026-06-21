using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop_Management_System.model
{
    internal class myconn
    {

        private static SqlConnection conn;

        private static void NewConnection()
        {
            try
            {
                if (conn == null)
                {
                    string connectionString = "Server=LAPTOP-CBR2E6D3\\SQLEXPRESS;Database=Bookshop;Integrated Security=True;";

                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    Console.WriteLine("✅ Connection established successfully.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("❌ SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ General Error: " + ex.Message);
            }
        }
        public static DataTable Search(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    NewConnection();
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in Search: " + ex.Message);
            }

            return dt;
        }

        public static void Save(string sql)
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    NewConnection();
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Query executed successfully.");
                CloseConnection();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("❌ SQL Error in Save: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ General Error in Save: " + ex.Message);
            }
        }
        
        public static void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                    Console.WriteLine("🔒 Connection closed safely.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("❌ SQL Error while closing: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ General Error while closing: " + ex.Message);
            }
        }
    }
}
