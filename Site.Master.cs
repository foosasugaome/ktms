using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the Forms Authentication Cookie
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {

                    // Decrypt the cookie to get the Forms Authentication ticket
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // Now we can access the user's authentication information
                    string userName = authTicket.Name;
                    DateTime expiration = authTicket.Expiration;

                    string userData = authTicket.UserData;

                    string[] strUserData = userData.Split(',');
                    Session["fullName"] = strUserData[1];
                    lblCurrentUser.Text = strUserData[1];
                    

                    Session["expiration"] = expiration;
                    Session["userData"] = userData.ToString();                  
                    
                }
                catch (Exception ex)
                {
                    Label1.Text = "An error occured. Error message : " + ex.Message;
                    //throw;
                }
            }
            else
            {
                Response.Redirect("signin.aspx");
            }


            if (Session["SessionID"] == null)
            {
                Response.Redirect("signin.aspx");
            }

        }      
    }
}