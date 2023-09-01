using System;
using System.Collections.Generic;
using System.Data;
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
            string strData = "Admin, Norman Teodoro";         // This will be userData of the cookie   
            
            // Authenticate user using a function in the same file
            //bool isAuthenticated = ValidateUser(strUsername, strPassword);

            // Authenticate using a separate class file "authentication.cs"
            Authentication authUser = new Authentication();
            bool isAuthenticated = authUser.ValidateUser(strUsername, strPassword);
            
            if (isAuthenticated)
            {

                Session["SessionID"] = Guid.NewGuid().ToString(); // Generate a new session ID
                // Add the sessionID to userData cookie
                strData += "," + Session["SessionID"];

                // Create a FormsAuthentication ticket with user data
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,                      // Version number
                    strUsername,               // Username
                    DateTime.Now,           // Issue date
                    DateTime.Now.AddHours(1), // Expiration date
                    false,                  // Whether the cookie is persistent
                    strData                   // User data                                    
                );

                // Encrypt the authentication ticket
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                // Create a cookie containing the encrypted ticket
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                // Add the cookie to the response
                HttpContext.Current.Response.Cookies.Add(authCookie);
                               

                // Set the authentication cookie and redirect to the home page
                //FormsAuthentication.SetAuthCookie(strUsername, false);
                
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
        
        //private bool ValidateUser(string username, string password)
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