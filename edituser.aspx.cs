using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ktms
{
    public partial class edituser : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["EditUserID"] != null)
            {
                ViewState["EditUserID"] = Session["EditUserID"];
                Session.Remove("EditUserID");
                FillData();
            }
            if (ViewState["EditUserID"] == null)
            {
                Response.Redirect("userlist.aspx");
            }
            ViewState["Email"] = txtEmail.Text;
        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            string strFileName = string.Empty;

            utils util = new utils();


            if (ViewState["Email"].ToString() != txtEmail.Text || util.UserExists(txtEmail.Text))
            {
                lblResult.Text = "Email already exists.";
                txtEmail.Focus();
                return;
            }

            if (fuUserPicture.HasFile)
            {
                string[] strArray = fuUserPicture.FileName.Split('.');
                string strExtension = strArray[strArray.Length - 1];
                strFileName = Guid.NewGuid().ToString() + "." + strExtension;

                string strPath = Server.MapPath("~/Files/UserPicture/") + strFileName;
                fuUserPicture.SaveAs(strPath);
            }
            else
            {
                string[] strOldImgName = imgUserPicture.ImageUrl.ToString().Split('/');
                strFileName = strOldImgName[strOldImgName.Length - 1];
            }

            // Implementation of parameterized queries to protect against SQL injections
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                string strQuery = "UPDATE [dbo].[Users] SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [Phone] = @Phone, [UserType] = @UserType, [UserImage] = @UserImage WHERE ID = @UserID";

                // Create a new SqlCommand with the query and connection
                using (SqlCommand cmd = new SqlCommand(strQuery, connection))
                {
                    // Add parameters and their values to prevent SQL injection
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@UserType", ddlUserType.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserImage", strFileName);
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(ViewState["EditUserID"]));

                    try
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // The update was successful
                            FillData();
                            lblResult.Text = "Data has been save successfully";
                        }
                        else
                        {
                            // No rows were affected; handle this case accordingly
                            lblResult.Text = "Record cannot be updated. Please contact administrator.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                        lblResult.Text = ex.Message;

                    }
                }
            }



        }

        private void FillData()
        {

            // Implementation of parameterized queries to protect against SQL injections
            try
            {
                string strPath = "~/Files/UserPicture/";
                string strQuery = "SELECT [ID],[FirstName],[LastName],[Email],[Password],[Phone],[UserType], [UserImage], [Status],[CreatedOn] FROM [Users] WHERE ID = @EditUserID";

                using (SqlConnection connection = new SqlConnection(strConn))
                using (SqlCommand cmd = new SqlCommand(strQuery, connection))
                {
                    // Add parameters and their values to prevent SQL injection
                    cmd.Parameters.AddWithValue("@EditUserID", Convert.ToInt32(ViewState["EditUserID"]));
                    //cmd.Parameters.AddWithValue("@UserImage", strPath);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        imgUserPicture.ImageUrl = strPath + reader["UserImage"];
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        ddlUserType.SelectedValue = reader["UserType"].ToString();
                    }
                    else
                    {
                        lblResult.Text = "User not found.";
                    }
                }
            }
            catch (Exception e)
            {
                lblResult.Text = "Something went wrong. Try again later." + e.Message.ToString();
                throw;
            }

        }
    }
}