using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class signup : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            pageMessage.Text = string.Empty;
            pageMessage.CssClass = "alert-danger";

            string strPassword = txtPassword.Text;
            string strRePassword = txtRePassword.Text;
            
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            string strPhone = txtPhone.Text;

            string strEmail = txtEmail.Text.Trim();

            pageMessage.Text = HashPassword(strPassword);
            if (strPassword != strRePassword) 
            {
                txtRePassword.Focus();
                pageMessage.Text = "Password does not match.";
                pageMessage.CssClass = "alert-danger";
                return;
            }

            utils utils = new utils();
            var (userExists, userID) = utils.CheckUserExists(strEmail);
            if (userExists) 
            {
                pageMessage.Text = "Email already exists.";
                txtEmail.Focus();
                return;
            }
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                //Assign default values for user fields. 
                string strUserType = "Normal User";
                string strUserImage = "blank-profile-picture-973460_640.png";

                string strQuery = "INSERT INTO [dbo].[Users]([FirstName],[LastName],[Email],[Password],[Phone],[UserImage],[UserType]) VALUES(@FirstName, @LastName, @Email, @Password, @Phone, @UserImage,@UserType)";
                using (SqlCommand insertCommand = new SqlCommand(strQuery, conn))
                {

                    insertCommand.Parameters.AddWithValue("@FirstName", strFirstName);
                    insertCommand.Parameters.AddWithValue("@LastName", strLastName);
                    insertCommand.Parameters.AddWithValue("@Email", strEmail);
                    insertCommand.Parameters.AddWithValue("@Password", HashPassword(strPassword));
                    insertCommand.Parameters.AddWithValue("@Phone", strPhone);
                    insertCommand.Parameters.AddWithValue("@UserImage", strUserImage);
                    insertCommand.Parameters.AddWithValue("@UserType", strUserType);
                    
                    conn.Open();
                    int rowsAffected = 0;
                    try
                    {
                        rowsAffected = insertCommand.ExecuteNonQuery();                        
                    }
                    catch (Exception ex)
                    {
                        pageMessage.Text = "Cannot create an account now." + ex.Message;
                        pageMessage.CssClass = "alert-danger";
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
             
                    if (rowsAffected > 0)
                    {
                        pageMessage.Text = "Account created. Please sign in.";
                        pageMessage.CssClass = "alert-success";
                        txtFirstName.Text = string.Empty;
                        txtLastName.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtRePassword.Text = string.Empty;
                        txtPhone.Text = string.Empty;                
                    }
                    else
                    {
                        pageMessage.Text = "Failed to create account.";
                        pageMessage.CssClass = "alert-danger";
                    }
                }
            }
        }   

        private string HashPassword(string password)
        {
            // Generate a salt and hash the password using BCrypt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


    }
}