using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Helpers;

namespace ktms
{
    public class Authentication
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        public (bool IsAuthenticated, UserInfo UserInfo) ValidateUser(string username, string password)
        {
            UserInfo userInfo = null;

            string query = "SELECT [ID],[Email], [FirstName], [LastName], [Password], [UserType] FROM [dbo].[USERS] WHERE [Email] = @Email AND Status = 1";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", username);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["Password"].ToString();
                        if (VerifyHash(password, storedPasswordHash))
                        {
                            userInfo = new UserInfo
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Email = reader["Email"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                UserType = reader["UserType"].ToString()
                            };
                        }
                    }
                }
            }

            bool isAuthenticated = userInfo != null;
            return (isAuthenticated, userInfo);
        }

        private bool VerifyHash(string password, string storedPasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);
        }

    }
}