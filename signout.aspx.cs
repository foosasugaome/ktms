using System;
using System.Web.Security;

namespace ktms
{
    public partial class signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear the authentication cookie and sign out the user
            FormsAuthentication.SignOut();

            Session.Abandon();
            Session.Clear();
            Response.Redirect("signin.aspx");
        }
    }
}