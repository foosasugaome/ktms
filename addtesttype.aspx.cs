using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public partial class addtesttype : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            string strClassType = txtClassType.Text;
            string strLanguage = txtLanguage.Text;

            string strQuery = "INSERT INTO [dbo].[TestType] ([TestType],[Language]) VALUES(@ClassType, @Language)";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@ClassType", strClassType);
                    cmd.Parameters.AddWithValue("@Language", strLanguage);

                    conn.Open();
                    int intResult = cmd.ExecuteNonQuery();
                    if (intResult == 0)
                    {
                        lblResult.Text = "An error occured. Cannot create a new record.";
                        // log error
                        return;
                    }
                }

                lblResult.Text = "Recored added.";
            }
        }
    }
}