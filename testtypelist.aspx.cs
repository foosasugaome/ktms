using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class testtypelist : System.Web.UI.Page
    {

        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData(string searchText = "", int status = -1)
        {

            string strQuery = "SELECT [ID], [TestType], [Language],FORMAT([CreatedOn], 'MM dd yyyy') [CreatedOn], " +
                "CASE WHEN [Status] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status] FROM [dbo].[TestType] " +
                "WHERE (@Status = -1 OR [Status] = @Status) AND ([TestType] LIKE @SearchText OR [Language] LIKE @SearchText)";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    gvData.DataSource = ds;
                    gvData.DataBind();

                }
            }


        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            string strSearchText = txtSearch.Text;
            int intTestTypeStatus = Convert.ToInt32(ddlTestTypeStatus.SelectedValue.ToString());
            FillData(strSearchText, intTestTypeStatus);
        }

        protected void lnkChangeStatus_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            LinkButton objLinkButton = (LinkButton)sender;
            string strTestTypeID = objLinkButton.CommandArgument.ToString();
            string strQuery = "UPDATE [dbo].[TestType] SET [Status] = CASE WHEN [Status] = 0 THEN 1 ELSE 0 END WHERE [ID] = @TestTypeID";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", strTestTypeID);

                    conn.Open();
                    int intResult = cmd.ExecuteNonQuery();
                    if (intResult != 0)
                    {
                        lblResult.Text = "Status updated.";
                        FillData();
                    }
                }
            }

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            LinkButton objLinkButton = (LinkButton)sender;
            string strID = objLinkButton.CommandArgument;
            Session["editTestTypeID"] = strID;
            Response.Redirect("edittesttype.aspx");
        }
    }
}