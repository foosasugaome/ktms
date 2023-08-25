using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class signin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("default.aspx");
            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            // Get user credentials
            string strUsername = txtEmail.Text;
            string strPassword = txtPassword.Text;

            // Authenticate user using a function in the same file
            //bool isAuthenticated = ValidateUser(strUsername, strPassword);

            // Authenticat using a separate class file "authentication.cs"
            authentication authUser = new authentication();
            bool isAuthenticated = authUser.ValidateUser(strUsername, strPassword);
            
            if (isAuthenticated)
            {
                // Set the authentication cookie and redirect to the home page
                FormsAuthentication.SetAuthCookie(strUsername, false);
                Session["SessionID"] = Guid.NewGuid().ToString(); // Generate a new session ID
                Response.Redirect("default.aspx");
            }
            else
            {
                // Display error message
                pageMessage.Text = "Invalid username or password.";
            }

            //if (Session["SessionID"] == null)
            //{
            //    Session["SessionID"] = Guid.NewGuid().ToString(); // Generate a new session ID
            //}

            //// Now you can access the session ID throughout the application
            //string sessionID = Session["SessionID"].ToString();
            //if (sessionID != null)
            //{
            //    Response.Redirect("default.aspx");
            //} 
        }
        
        //public static bool ValidateUser(string username, string password)
        //{
        //    // For testing purposes, let's consider a simple hardcoded user/password combination
        //    string validUsername = "norman@gmail.com";
        //    string validPassword = "password";

        //    // Compare the provided username and password with the valid credentials
        //    if (username == validUsername && password == validPassword)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}