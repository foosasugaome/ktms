using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public partial class changepassword : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            string strCurrentPassword = txtCurrentPassword.Text;
            string strNewPassword = txtNewPassword.Text;
            string strConfirmPassword = txtConfirmPassword.Text;
                       

            // Validate the current password
            if (!ValidateCurrentPassword(strCurrentPassword))
            {
                lblResult.Text = "Incorrect current password.";
                return;
            }

            // Ensure new password and confirm password match
            if (strNewPassword != strConfirmPassword)
            {
                lblResult.Text = "New password and confirm password do not match.";
                return;
            }

            // Update the password in the database
            if (UpdatePasswordInDatabase(strNewPassword))
            {
                lblResult.Text = "Password updated successfully.";
                
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";

                lblResult.Text = "Password updated.";
            }
            else
            {
                lblResult.Text = "Failed to update the password. Please try again.";
            }
        }

        // Implement a method to validate the current password
        private bool ValidateCurrentPassword(string currentPassword)
        {

            bool passwordValid = false;
            // Reuse authentication if passwords match
            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();
            if (userAuthInfo == null)
            {
                Response.Redirect("signin.aspx");
            }
            string[] userInfoData = userAuthInfo.UserDataArray;
            string strUsername = userInfoData[1];            

            Authentication authenticationHelper = new Authentication();
            (bool isAuthenticated, UserInfo userInfo) = authenticationHelper.ValidateUser(strUsername, currentPassword);
            if (isAuthenticated)
            {
                passwordValid = true;
            }
            return passwordValid;
        }


        // Implement a method to update the password in the database
        private bool UpdatePasswordInDatabase(string newPassword)
        {
            try
            {                
                int userId = GetUserId(); // Replace with the logic to get the current user's ID
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

        // Implement a method to get the current user's ID
        private int GetUserId()
        {
            int userID = 0;
            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();
            if (userAuthInfo != null) {
                string[] userInfoData = userAuthInfo.UserDataArray;
                userID = Convert.ToInt32(userInfoData[0]);               
            }
            return userID;
        }

    }
}