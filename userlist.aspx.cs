using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class userlist : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            LinkButton objLinkButton = (LinkButton)sender;
            string strID = objLinkButton.CommandArgument;
            Session["EditUserID"] = strID;

            Response.Redirect("edituser.aspx");

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            LinkButton objLinkButton = (LinkButton)sender;
            string strID = objLinkButton.CommandArgument.ToString();
            string strQuery = "UPDATE [USERS] SET STATUS = CASE WHEN STATUS = 0 THEN 1 ELSE 0 END WHERE ID = @UserID";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                // Add the parameter to the query
                cmd.Parameters.AddWithValue("@UserID", strID);

                conn.Open();
                int intResult = cmd.ExecuteNonQuery();

                if (intResult != 0)
                {
                    lblResult.Text = "User status has been updated.";
                    FillData();
                }
                conn.Close();
            }
        }

        private void FillData(string searchText = "", int status = -1)
        {
            try
            {
                string strPath = "~/Files/UserPicture/";
                string strQuery = "SELECT [ID], [FirstName], [LastName], [Email], [Password], [Phone], [UserType], '" + strPath + "' + [UserImage] as UserImage, " +
                                 "CASE WHEN [Status] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status], FORMAT([CreatedOn], 'MMM dd yyyy') [CreatedOn] FROM [Users] " +
                                 "WHERE (@SearchText = '' OR [FirstName] LIKE @SearchText OR [LastName] LIKE @SearchText OR [Email] LIKE @SearchText OR [Phone] LIKE @SearchText) " +
                                 "AND (@Status = -1 OR [Status] = @Status)";

                using (SqlConnection conn = new SqlConnection(strConn))
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    gvData.DataSource = ds;
                    gvData.DataBind();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                lblResult.Text = "An error occured. Pleae try again later.";
                throw ex;
            }
        }


        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            string strSearchText = txtSearch.Text.Trim();
            int intStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            FillData(strSearchText, intStatus);
        }


    }
}