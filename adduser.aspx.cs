using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public partial class adduser : System.Web.UI.Page
    {

        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {


            if (UserExists(txtEmail.Text))
            {

                lblResult.Text = "Email already exists.";
                txtEmail.Focus();
                return;
            }

            try
            {
                string strFileName = string.Empty;

                if (fuUserPicture.HasFile)
                {
                    string[] strArray = fuUserPicture.FileName.Split('.');
                    string strExtension = strArray[strArray.Length - 1];
                    strFileName = Guid.NewGuid().ToString() + "." + strExtension;

                    string strPath = Server.MapPath("~/Files/UserPicture/") + strFileName;
                    fuUserPicture.SaveAs(strPath);
                }

                string strConn = ConfigurationManager.AppSettings["sqlConn"];

                // Hash the password securely
                utils utils = new utils();
                string hashedPassword = utils.HashPassword(txtPassword.Text);

                string strQuery = "INSERT INTO [dbo].[Users]([FirstName],[LastName],[Email],[Password],[Phone],[UserType],[UserImage]) " +
                                 "VALUES(@FirstName, @LastName, @Email, @Password, @Phone, @UserType, @UserImage)";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                    {
                        // Add parameters and their values to prevent SQL injection
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@UserType", ddlUserType.SelectedValue);
                        cmd.Parameters.AddWithValue("@UserImage", strFileName);

                        conn.Open();
                        int intResult = cmd.ExecuteNonQuery();

                        if (intResult != 0)
                        {
                            lblResult.Text = "Data has been saved successfully";

                            // Clear input fields
                            txtFirstName.Text = string.Empty;
                            txtLastName.Text = string.Empty;
                            txtEmail.Text = string.Empty;
                            txtPhone.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            ddlUserType.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Something went wrong. Please try again later.";
                // Log the error, don't throw it to the user
                LogError(ex);
            }
        }

        private bool UserExists(string email)
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


        private string LogError(Exception e)
        {
            string strErrorMessageLog = e.Message.ToString();
            return strErrorMessageLog;
        }


    }
}