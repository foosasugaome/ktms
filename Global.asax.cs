using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ktms
{
    public class Global : System.Web.HttpApplication
    {
        // TODO : Implement custom errors ans logging

        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception exception = Server.GetLastError();

            // Log the exception details (you can replace this with your own logging mechanism)
            LogException(exception);

            // Send an email notification if needed
            SendErrorNotification(exception);

            // Redirect the user to a user-friendly error page
            Response.Clear();
            Server.ClearError();

            // You can customize the error page URL

        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }


        // Function to log exceptions (replace with your own logging mechanism)
        private void LogException(Exception exception)
        {
            // Implement your logging logic here
            // You can log the exception details to a file, database, or a log management system
            string strErrorMessage = exception.Message;
            string strErrorQuery = "INSERT INTO [dbo].[ErrorLogs] ([ErrorMessage]) VALUES(@Error)";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand insertError = new SqlCommand(strErrorQuery, conn))
                {
                    insertError.Parameters.AddWithValue("@Error", strErrorMessage);
                    conn.Open();
                    insertError.ExecuteNonQuery();
                }
            }
        }

        // Function to send error notifications (replace with your own notification mechanism)
        private void SendErrorNotification(Exception exception)
        {
            // Implement your error notification logic here
            // You can send an email notification to the administrator with exception details
        }
    }
}