using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

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
        public (bool UserExists, int UserID) CheckUserExists(string email)
        {
            bool userFound = false;
            int userId = -1; // Default value for the user ID

            string strQuery = "SELECT ID FROM [dbo].[Users] WHERE Email = @Email AND Status = 1";
            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userFound = true;
                    userId = Convert.ToInt32(result); // Get the user ID
                }
            }

            return (userFound, userId);
        }


        public int CurrentLoggedUserID()
        {
            int UUID = 0;

            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                string[] userInfoData = userAuthInfo.UserDataArray;
                UUID = Convert.ToInt32(userInfoData[0]);                
            }
            return UUID;
        }


        public bool SendEmail(string strSubject, string strTo, string strBody, bool bIsHTML)
        {

            // Replace these with your actual email and SMTP server settings
            string fromEmail = "norman.teodoro@gmail.com";
            string toEmail = strTo;
            string subject = strSubject;
            string body = strBody;


            // Email configuration           
            // Create a new SMTP client
            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp-relay.sendinblue.com", // Replace with your SMTP server address
                Port = 587, // Replace with your SMTP server port
                Credentials = new NetworkCredential("norman.teodoro@gmail.com", "WhtnIPHyRg18BrQ5"), // Replace with your email credentials
                EnableSsl = true, // Use SSL if required by your SMTP server
            };

            // Create an email message
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = bIsHTML, // Set to true if you're sending HTML content
            };

            // Add the recipient's email address
            mailMessage.To.Add(toEmail);

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                // Optional: Display a success message or perform other actions after sending the email.
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }




    }
}