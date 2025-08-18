using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsDBConnection
{
    public class DatabaseConnection
    {
        private static string connectionString =
            "Data Source=INBOOK_Y1_PLUS\\SQLEXPRESS;Initial Catalog=user_auth;User ID=sa;Password=Welcome@12345";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn; 
            }
            catch (SqlException ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }
    }
}
