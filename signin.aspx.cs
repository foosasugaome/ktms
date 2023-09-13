using System;
using System.Web;
using System.Web.Security;

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

            // Authenticate using a separate class file "authentication.cs"
            Authentication authenticationHelper = new Authentication();
            (bool isAuthenticated, UserInfo userInfo) = authenticationHelper.ValidateUser(strUsername, strPassword);

            if (isAuthenticated)
            {

                Session["SessionID"] = Guid.NewGuid().ToString(); // Generate a new session ID

                // string strData = "Admin, Norman Teodoro";         // This will be userData of the cookie   
                string strUserData = userInfo.ID + "," + userInfo.Email + "," + userInfo.FirstName + "," + userInfo.LastName + "," + userInfo.UserType;

                // Create a FormsAuthentication ticket with user data
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,                      // Version number
                    strUsername,               // Username
                    DateTime.Now,           // Issue date
                    DateTime.Now.AddHours(1), // Expiration date
                    false,                  // Whether the cookie is persistent
                    strUserData                   // User data                                                        
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
        }
    }
}