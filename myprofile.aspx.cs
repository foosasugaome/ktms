using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public partial class myprofile : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {
            UserAuthenticationInfo userAuthInfo = AuthenticationHelper.GetUserAuthenticationInfo();

            if (userAuthInfo != null)
            {
                string strPath = "~/Files/UserPicture/";
                string[] userInfoData = userAuthInfo.UserDataArray;

                string strQuery = "SELECT [ID],[FirstName],[LastName],[Email],[Password],[Phone],[UserType], [UserImage], [Status],[CreatedOn] FROM [Users] WHERE [Email] = @Email";



                using (SqlConnection con = new SqlConnection(strConn))
                using (SqlCommand cmd = new SqlCommand(strQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Email", userInfoData[1]);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        imgUserPicture.ImageUrl = strPath + reader["UserImage"];
                        lblFullName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        lblFirstName.Text = reader["FirstName"].ToString();
                        lblLastName.Text = reader["LastName"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                        lblPhone.Text = reader["Phone"].ToString();
                        lblUserType.Text = reader["UserType"].ToString();
                    }
                    con.Close();
                }


                //string userName = userAuthInfo.UserName;
                //DateTime expiration = userAuthInfo.Expiration;
                //string userData = userAuthInfo.UserData;
                //string[] userInfoData = userAuthInfo.UserDataArray;
                //lblFullName.Text = userInfoData[2];
            }
        }
    }
}