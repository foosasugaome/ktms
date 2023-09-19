using System;
using System.Runtime.Remoting.Messaging;

namespace ktms
{
    public partial class _default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                string[] userInfoData = userAuthInfo.UserDataArray;
                lblFullName.Text = userInfoData[2];

                string strRole = userInfoData[4];                
            }
        }        
    }
}