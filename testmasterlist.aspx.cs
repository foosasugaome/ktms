using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ktms
{
    public partial class testmasterlist : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }


        private void FillData(string searchText = "", int status = -1)
        {

            string strPath = "~/Files/Question/";

            string strQuery = "SELECT dbo.TestMaster.ID, dbo.TestType.TestType + ' - ' + dbo.TestType.Language AS TMTestType, dbo.TestMaster.Question,'" + strPath + "' + dbo.TestMaster.QuestionImage AS QuestionImg, dbo.TestMaster.AnswerB, dbo.TestMaster.AnswerA, dbo.TestMaster.AnswerC, dbo.TestMaster.AnswerD,dbo.TestMaster.CorrectAnswer, FORMAT(dbo.TestMaster.CreatedOn, 'MMM dd yyyy') AS CreatedDate, dbo.Users.FirstName + ' ' + dbo.Users.LastName AS CreatedBy, dbo.TestMaster.Status FROM dbo.TestMaster INNER JOIN dbo.TestType ON dbo.TestMaster.TestTypeID = dbo.TestType.ID INNER JOIN dbo.Users ON dbo.TestMaster.CreatedBy = dbo.Users.ID WHERE (dbo.TestType.TestType LIKE @SearchText) OR (dbo.TestType.Language LIKE @SearchText) OR (dbo.TestMaster.Question LIKE @SearchText) OR (dbo.TestMaster.AnswerB LIKE @SearchText) OR (dbo.TestMaster.AnswerA LIKE @SearchText) OR (dbo.TestMaster.AnswerC LIKE @SearchText) OR (dbo.TestMaster.AnswerD LIKE @SearchText) OR (dbo.Users.FirstName + ' ' + dbo.Users.LastName LIKE @SearchText) ORDER BY dbo.TestMaster.ID DESC";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@Status", status);
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
            string strSearchText = txtSearch.Text;
            FillData(strSearchText);
        }
    }
}