using System;

namespace ktms
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected string strUserImg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!AuthenticationHelper.IsUserAuthenticated())
            {
                Response.Redirect("signin.aspx");
            }

            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                //userAuthInfo.UserName;
                //userAuthInfo.Expiration;
                //userAuthInfo.UserData;
                string[] userInfoData = userAuthInfo.UserDataArray;
                lblCurrentUser.Text = userInfoData[2] + " " + userInfoData[3];
                strUserImg = userInfoData[5];
            } 
        }

    }
}