using System;
using System.Web;
using System.Web.Security;

namespace ktms
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //if (!AuthenticationHelper.IsUserAuthenticated())
            //{
            //    Response.Redirect("signin.aspx");
            //}

            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                string userName = userAuthInfo.UserName;
                DateTime expiration = userAuthInfo.Expiration;
                string userData = userAuthInfo.UserData;
                string[] userInfoData = userAuthInfo.UserDataArray;
                lblCurrentUser.Text = userInfoData[2] + " " + userInfoData[3];
            }           
        }

    }
}