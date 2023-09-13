using System;

namespace ktms
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            //txtEmail.Text;
            //txtPassword.Text;
            //pageMessage.Text = HashPassword(password);
        }

        private string HashPassword(string password)
        {
            // Generate a salt and hash the password using BCrypt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}