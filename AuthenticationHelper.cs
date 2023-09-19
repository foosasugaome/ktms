using System;
using System.Web;
using System.Web.Security;

namespace ktms
{
    public class AuthenticationHelper
    {
        public static UserAuthenticationInfo GetUserAuthenticationInfo()
        {
            // Get the Forms Authentication Cookie
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                try
                {
                    // Decrypt the cookie to get the Forms Authentication ticket
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // Access the user's authentication information
                    string userName = authTicket.Name;
                    DateTime expiration = authTicket.Expiration;
                    string userData = authTicket.UserData;
                    string[] strUserData = userData.Split(',');

                    return new UserAuthenticationInfo
                    {
                        UserName = userName,
                        Expiration = expiration,
                        UserData = userData,
                        UserDataArray = strUserData
                    };
                }
                catch (Exception)
                {
                    
                }
            }

            // Return null if the authentication cookie is not present or if an error occurs
            return null;
        }

        public static bool IsUserAuthenticated()
        {
            // Check if the user is authenticated based on your criteria
            UserAuthenticationInfo userAuthInfo = GetUserAuthenticationInfo();
            return userAuthInfo != null;
        }
    }

}