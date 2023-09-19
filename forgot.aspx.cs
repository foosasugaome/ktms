using System;
using System.Net.Mail;
using System.Net;

namespace ktms
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            // Validate email if it exists

            utils Util = new utils();
            if (Util.UserExists(txtEmail.Text))
            {
                SendEmail();
            }
            else
            {
                // Display error message
                pageMessage.Text = "The email you entered is not in our database.";
            }
        }


        protected void SendEmail()
        {

            // Replace these with your actual email and SMTP server settings
            string fromEmail = "norman.teodoro@gmail.com";
            string toEmail = "norman.teodoro@hotmail.com";
            string subject = "Reset your password";
            string body = "Test";


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
                IsBodyHtml = false, // Set to true if you're sending HTML content
            };

            // Add the recipient's email address
            mailMessage.To.Add(toEmail);

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                // Optional: Display a success message or perform other actions after sending the email.
                pageMessage.Text = "A password reset link has been sent to your email.";
            }
            catch (Exception ex)
            {
                pageMessage.Text = ex.Message;
                // Handle any exceptions that occur during the email sending process.
                // You can log the error or display an error message to the user.
                // For simplicity, we're not handling exceptions here, but you should in a production application.
            }
        }


    }
}