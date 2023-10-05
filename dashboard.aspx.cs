using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

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


                    //// Test type pie chart
                    //DataTable testTypeTable = dashboardData.Tables[7];
                    //string strTestTypeChartData = "";
                    //foreach (DataRow item in testTypeTable.Rows)
                    //{
                    //    strTestTypeChartData += ",{value:" + item["ID"] + ", name:'" + item["TestType"] + "'}";
                    //}
                    //if (!string.IsNullOrEmpty(strTestTypeChartData))
                    //{
                    //    strTestTypeChartData = strTestTypeChartData.Remove(0, 1);
                    //}
                    //Page.RegisterStartupScript("FillChart", "<script>var TestTypeChartData=[" + strTestTypeChartData + "]</script>");

                    //// Passed table
                    //DataTable totalPassedTable = dashboardData.Tables[8];
                    //string strTotalPassedChartData = string.Empty;
                    //foreach (DataRow item in totalPassedTable.Rows)
                    //{
                    //    strTotalPassedChartData += "," + Convert.ToString(item["TotalPassed"]);
                    //}
                    //if (!string.IsNullOrEmpty(strTotalPassedChartData))
                    //{
                    //    strTotalPassedChartData = strTotalPassedChartData.Remove(0, 1);
                    //}

                    //Page.RegisterStartupScript("FillChart", "<script>var PassChartBar=[" + strTotalPassedChartData + "]</script>");


                    //// Failed table
                    //DataTable totalFailedTable = dashboardData.Tables[9];
                    //string strTotalFailedChartData = string.Empty;
                    //foreach (DataRow item in totalFailedTable.Rows)
                    //{
                    //    strTotalFailedChartData += "," + Convert.ToString(item["TotalFailed"]);
                    //}
                    //if (!string.IsNullOrEmpty(strTotalFailedChartData))
                    //{
                    //    strTotalFailedChartData = strTotalFailedChartData.Remove(0, 1);
                    //}
                    //Page.RegisterStartupScript("FillChart", "<script>var FailChartBar=[" + strTotalFailedChartData + "]</script>");


                    // Test Type pie chart
                    DataTable testTypeTable = dashboardData.Tables[7];
                    List<object> testTypeChartDataList = new List<object>();

                    foreach (DataRow item in testTypeTable.Rows)
                    {
                        var pieChartData = new
                        {
                            value = 1,
                            name = item["TestType"].ToString()
                        };
                        testTypeChartDataList.Add(pieChartData);
                    }

                    string strTestTypeChartData = new JavaScriptSerializer().Serialize(testTypeChartDataList);
                    if (!string.IsNullOrEmpty(strTestTypeChartData))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "FillChart", $"<script>var TestTypeChartData={strTestTypeChartData};</script>");
                    }

                    // Passed table
                    DataTable totalPassedTable = dashboardData.Tables[8];
                    string strTotalPassedChartData = string.Empty;
                    foreach (DataRow item in totalPassedTable.Rows)
                    {                        
                        strTotalPassedChartData += "," + Convert.ToString(item["TotalPassed"]);
                    }
                    if (!string.IsNullOrEmpty(strTotalPassedChartData))
                    {
                        strTotalPassedChartData = strTotalPassedChartData.Remove(0, 1);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "FillChart_Passed", $"<script>var PassChartBar=[{strTotalPassedChartData}];</script>");
                    }

                    // Failed table
                    DataTable totalFailedTable = dashboardData.Tables[9];                    
                    string strTotalFailedChartData = string.Empty;
                    foreach (DataRow item in totalFailedTable.Rows)
                    {                        
                        strTotalFailedChartData += "," + Convert.ToString(item["TotalFailed"]);
                    }
                    if (!string.IsNullOrEmpty(strTotalFailedChartData))
                    {
                        strTotalFailedChartData = strTotalFailedChartData.Remove(0, 1);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "FillChart_Failed", $"<script>var FailChartBar=[{strTotalFailedChartData}];</script>");
                    }

                    connection.Close();
                }
            }
        }
    




    }
}