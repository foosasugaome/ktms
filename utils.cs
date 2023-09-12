using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace ktms
{
    public class utils
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        public string HashPassword(string password)
        {
            // Generate a salt and hash the password using BCrypt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public Boolean UserExists(string email)
        {
            bool userFound = false;
            string strQuery = "SELECT COUNT(*) FROM [dbo].[Users] WHERE Email = @Email AND Status = 1";
            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (userCount > 0)
                {
                    userFound = true;
                }
            }
            return userFound;
        }
    }
}