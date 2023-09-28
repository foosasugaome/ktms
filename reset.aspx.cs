using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class reset : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            pageMessage.Text = string.Empty;
            string strPassword = txtPassword.Text;            
            string strConfirmPassword = txtConfirmPassword.Text;

                       

            // Ensure new password and confirm password match
            if (strPassword != strConfirmPassword)
            {
                pageMessage.Text = "New password and confirm password do not match.";
                return;
            }
            if (Request["src"] != null)
            {
                ViewState["UserID"] = Convert.ToString(Request["src"]);
            }
            else
            {
                pageMessage.Text = "Invalid link.";
            }
            int intUserID = Convert.ToInt32(ViewState["UserID"]);

            // Update the password in the database
            if (UpdatePasswordInDatabase(strPassword, intUserID))
            {
                pageMessage.Text = "Password updated successfully.";

                
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                pageMessage.Text = "Password updated.";
            }
            else
            {
                pageMessage.Text = "Failed to update the password. Please try again.";
            }
        }
        // Implement a method to update the password in the database
        private bool UpdatePasswordInDatabase(string newPassword, int userId)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                // Implement SQL query to update the user's password in the database
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();
                    string updateQuery = "UPDATE [Users] SET Password = @NewPassword WHERE ID = @UserId";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", hashedPassword);
                        command.Parameters.AddWithValue("@UserId", userId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }



    }
}