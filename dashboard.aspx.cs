using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ktms
{
    public partial class dashboard : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();

                    DataSet dashboardData = new DataSet();

                    using (SqlCommand command = new SqlCommand("GetDashboard", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dashboardData);
                    }

                    // Extract data from the dataset for each select statement
                    DataTable totalUsersTable = dashboardData.Tables[0];
                    int totalUsers = Convert.ToInt32(totalUsersTable.Rows[0]["TotalUsers"]);
                    lblTotalStudents.Text = totalUsers.ToString();

                    DataTable newStudentsTable = dashboardData.Tables[1];
                    int newStudents = Convert.ToInt32(newStudentsTable.Rows[0]["NewStudents"]);
                    lblNewStudents.Text = newStudents.ToString();

                    DataTable totalTestTypesTable = dashboardData.Tables[2];
                    int totalTestTypes = Convert.ToInt32(totalTestTypesTable.Rows[0]["TotalTestType"]);
                    lblTestType.Text = totalTestTypes.ToString();

                    DataTable totalAttemptsTable = dashboardData.Tables[3];
                    int totalAttempts = Convert.ToInt32(totalAttemptsTable.Rows[0]["TotalAttempts"]);
                    lblTotalAttempts.Text = totalAttempts.ToString();

                    DataTable passedAttemptsTable = dashboardData.Tables[4];
                    int passedAttempts = Convert.ToInt32(passedAttemptsTable.Rows[0]["PassedAttempts"]);
                    lblPassedAttempts.Text = passedAttempts.ToString();

                    DataTable failedAttemptsTable = dashboardData.Tables[5];
                    int failedAttempts = Convert.ToInt32(failedAttemptsTable.Rows[0]["FailedAttempts"]);
                    lblFailedAttempts.Text = failedAttempts.ToString();

                    connection.Close();
                }
            }
        }
    }
}