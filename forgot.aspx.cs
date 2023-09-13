using System;

namespace ktms
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public static bool ValidateEmail(string username)
        {
            // For testing purposes, let's consider a simple hardcoded user/password combination
            string validUsername = "norman@gmail.com";


            // Compare the provided username and password with the valid credentials
            return username == validUsername;
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            // Validate email if it exists
            bool validEmail = ValidateEmail(txtEmail.Text);

            if (validEmail)
            {
                // Send email
            }
            else
            {
                // Display error message
                pageMessage.Text = "The email you entered is not in our database.";
            }
        }
    }
}