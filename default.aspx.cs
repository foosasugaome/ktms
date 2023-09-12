using System;

namespace ktms
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                string userName = userAuthInfo.UserName;
                DateTime expiration = userAuthInfo.Expiration;
                string userData = userAuthInfo.UserData;
                string[] userInfoData = userAuthInfo.UserDataArray;
                lblFullName.Text = userInfoData[2];
            }
        }
    }
}