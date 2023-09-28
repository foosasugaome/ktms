using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class CreateGetDashboardSP : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkCreateSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (CreateGetDashboardStoredProcedure())
                {
                    lnkCreateSP.Enabled = false;
                    // Now you can call the stored procedure if needed
                    // CallGetDashboardStoredProcedure();
                }
                else
                {
                    lblCreateSPGetDashboard.Text = "Error creating stored procedure.";
                }
            }
            catch (Exception ex)
            {
                lblCreateSPGetDashboard.Text = "Error: " + ex.Message;
                lnkCreateSP.Enabled = true;
                // Handle exceptions here
                // You can display an error message or log the error
            }
        }

        private bool CreateGetDashboardStoredProcedure()
        {

            string[] sqlStatements =
                {
                    "USE [PracticumV1]",
                    "SET ANSI_NULLS ON",
                    "SET QUOTED_IDENTIFIER ON",
                    "CREATE PROCEDURE [dbo].[GetDashboard] AS",
                    "BEGIN",
                    //"--Total number of users",
                    "SELECT COUNT(ID) TotalUsers FROM [dbo].[Users] WHERE STATUS = 1;",
                    //"--Total number of new students. Counts from the start of the current month.",
                    "SELECT COUNT(ID) NewStudents FROM [dbo].[Users] WHERE CAST(CreatedOn AS date) >= CAST(DATEADD(month, DATEDIFF(month, 0, GETDATE()),0) AS DATE);",
                    //"--Total number of test types",
                    "SELECT COUNT(ID) TotalTestType FROM[dbo].[TestType] WHERE STATUS = 1;",
                    //"--Total number of attempts",
                    "SELECT COUNT(DISTINCT(TestStartID))TotalAttempts FROM[dbo].[UserTest] ;",
                    //"--Total number of passed attempts",
                    "SELECT COUNT(Result) PassedAttempts FROM(SELECT CASE WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) >= 0.75 THEN 1 ELSE 0 END ResultFROM[UserTest] GROUP BY TestStartID) Temp WHERE Result = 1;",
                    //"--Total number of failed attempts",
                    "SELECT COUNT(Result) FailedAttempts FROM(SELECT CASE WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) > 0.75 THEN 1 ELSE 0 END Result FROM[UserTest] GROUP BY TestStartID) TempWHERE Result = 0;",
                    //"--Fill Chart",
                    "SELECT TOP 7 COUNT(CreatedOn) TotalAttempts FROM[UserTest] WHERE CreatedOn > DATEADD(MM, -6, GETDATE()) GROUP BY CreatedOn;",
                    //"--Fill Pie",
                    //"--SELECT[ID],[TestType] +' - ' + [Language][TestType] FROM[dbo].[TestTypeMaster];",
                    "END;"
                };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string sqlStatement in sqlStatements)
                {
                    using (SqlCommand cmd = new SqlCommand(sqlStatement, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }

        }
    }
}
