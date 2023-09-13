using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public partial class edittesttype : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["editTestTypeID"] = Session["editTestTypeID"];
                Session.Remove("editTestTypeID");

                string strQuery = "SELECT [ID],[TestType],[Language] FROM [dbo].[TestType] WHERE ID = @ID";
                using (SqlConnection conn = new SqlConnection(strConn))
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(ViewState["editTestTypeID"]));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtClassType.Text = reader["TestType"].ToString();
                        txtLanguage.Text = reader["Language"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            if (ViewState["editTestTypeID"] != null)
            {
                string strQuery = "UPDATE [dbo].[TestType] SET [TestType] = @TestType ,[Language] = @Language WHERE ID = @ID";
                using (SqlConnection conn = new SqlConnection(strConn))
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(ViewState["editTestTypeID"].ToString()));
                    cmd.Parameters.AddWithValue("@TestType", txtClassType.Text);
                    cmd.Parameters.AddWithValue("@Language", txtLanguage.Text);

                    conn.Open();
                    int intResult = cmd.ExecuteNonQuery();
                    lblResult.Text = intResult != 0 ? "Test type updated." : "Could not update record.";
                }
            }
        }
    }

}