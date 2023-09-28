using System;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;

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
            var (userExists, userID) = Util.CheckUserExists(txtEmail.Text);
            if (userExists)
            {
                int intUserID = userID;
                string strSubject = "Reset password.";
                string strToEmail = txtEmail.Text;
                string strResetLink = "https://localhost:44321/reset.aspx?src=" + intUserID;
                // Create an HTML-formatted email body
                string strBody = "<html><body>";
                strBody += "<p>Hello,</p>";
                strBody += "<p>You have requested to reset your password. To reset your password, please click the following link:</p>";
                strBody += "<p><a href='" + strResetLink + "'>Reset Password</a></p>";
                strBody += "<p>If you did not request this password reset, you can safely ignore this email.</p>";
                strBody += "</body></html>";


                utils util = new utils();
                if (util.SendEmail(strSubject, strToEmail, strBody, true))                
                {
                    pageMessage.Text = "A password reset link has been sent to your email.";
                }
                else
                {
                    pageMessage.Text = "An error occured. Please try again later.";
                }

                //SendEmail(txtEmail.Text);
            }
            else
            {
                // Display error message
                pageMessage.Text = "The email you entered is not in our database.";
            }
        }

    }
}