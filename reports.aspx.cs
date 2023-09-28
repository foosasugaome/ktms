using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class reports : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
                PopulateGrid();
            }
        }

        private void FillDropDown()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();

                    FillDropDownFromQuery(ddlUserList, "SELECT ID, FirstName + ' ' + LastName AS TextFieldValue FROM USERS WHERE Status = @StatusUser ORDER BY FirstName", "@StatusUser", 1);
                    FillDropDownFromQuery(ddlTestType, "SELECT ID, TestType + ' - ' + Language AS TextFieldValue FROM TestType WHERE Status = @StatusTestType ORDER BY TestType", "@StatusTestType", 1);

                    // Add default "Select" items
                    ddlUserList.Items.Insert(0, new ListItem("Select", "-1"));
                    ddlTestType.Items.Insert(0, new ListItem("Select", "-1"));
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Cannot retrieve records from the database. " + ex.Message;
            }
        }

        private void FillDropDownFromQuery(DropDownList dropDownList, string query, string paramName, int paramValue)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(paramName, paramValue);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dropDownList.DataTextField = "TextFieldvalue"; // Assuming "TextFieldValue" is the common field name for both dropdowns
                    dropDownList.DataValueField = "ID";
                    dropDownList.DataSource = reader;
                    dropDownList.DataBind();
                }
            }
        }

        //private void PopulateGrid()
        //{
        //    string strQuery = string.Empty;

        //    if (ddlUserList.SelectedIndex == 0 && ddlTestType.SelectedIndex == 0)
        //    {
        //        strQuery = "SELECT CASE WHEN((CorrectAnswers / TotalQuestions) * 100) >= 75 THEN 'Passed' ELSE 'Fail' END TestResult, TotalQuestions, CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT COUNT(TestStartID)TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END)CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT (SELECT FirstName+' 'LastName FROM Users U WHERE U.ID = [UserID]) Name, (SELECT [TestType]+' - '+[Language] as TestType FROM [TestType] TT WHERE TT.ID = [TestTypeID]) TestType, FORMAT(CreatedOn, 'MMM dd yyyy')CreatedOn, IsCorrect, TestStartID FROM [UserTest]) Temp GROUP By Name, TestType, CreatedOn, TestStartID) Temp1  ORDER BY CreatedOn DESC";
        //    }
        //    else if (ddlUserList.SelectedIndex == 0 && ddlTestType.SelectedIndex > 0)
        //    {
        //        strQuery = "SELECT CASE WHEN((CorrectAnswers / TotalQuestions) * 100) >= 75 THEN 'Passed' ELSE 'Fail' END TestResult, TotalQuestions, CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT COUNT(TestStartID)TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END)CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT (SELECT FirstName+' 'LastName FROM Users U WHERE U.ID = [UserID]) Name, (SELECT [TestType]+' - '+[Language] as TestType FROM [TestType] TT WHERE TT.ID = [TestTypeID]) TestType, FORMAT(CreatedOn, 'MMM dd yyyy')CreatedOn, IsCorrect, TestStartID FROM [UserTest] WHERE TestTypeID=@TestType) Temp GROUP By Name, TestType, CreatedOn, TestStartID) Temp1  ORDER BY CreatedOn DESC";
        //    }
        //    else if (ddlUserList.SelectedIndex > 0 && ddlTestType.SelectedIndex == 0)
        //    {
        //        strQuery = "SELECT CASE WHEN((CorrectAnswers / TotalQuestions) * 100) >= 75 THEN 'Passed' ELSE 'Fail' END TestResult, TotalQuestions, CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT COUNT(TestStartID)TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END)CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT (SELECT FirstName+' 'LastName FROM Users U WHERE U.ID = [UserID]) Name, (SELECT [TestType]+' - '+[Language] as TestType FROM [TestType] TT WHERE TT.ID = [TestTypeID]) TestType, FORMAT(CreatedOn, 'MMM dd yyyy')CreatedOn, IsCorrect, TestStartID FROM [UserTest] WHERE UserID=@UID) Temp GROUP By Name, TestType, CreatedOn, TestStartID) Temp1  ORDER BY CreatedOn DESC";
        //    }
        //    else
        //    {
        //        strQuery = "SELECT CASE WHEN((CorrectAnswers / TotalQuestions) * 100) >= 75 THEN 'Passed' ELSE 'Fail' END TestResult, TotalQuestions, CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT COUNT(TestStartID)TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END)CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT (SELECT FirstName+' 'LastName FROM Users U WHERE U.ID = [UserID]) Name, (SELECT [TestType]+' - '+[Language] as TestType FROM [TestType] TT WHERE TT.ID = [TestTypeID]) TestType, FORMAT(CreatedOn, 'MMM dd yyyy')CreatedOn, IsCorrect, TestStartID FROM [UserTest] WHERE TestTypeID=@TestType AND UserID=@UID) Temp GROUP By Name, TestType, CreatedOn, TestStartID) Temp1  ORDER BY CreatedOn DESC";
        //    }

        //    using (SqlConnection conn = new SqlConnection(strConn))
        //    using (SqlCommand cmd = new SqlCommand(strQuery, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@TestType", ddlTestType.SelectedValue);
        //        cmd.Parameters.AddWithValue("@UID", ddlUserList.SelectedValue);
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        gvData.DataSource = reader;
        //        gvData.DataBind();
        //    }
        //}


        private void PopulateGrid()
        {
            string strQuery = "SELECT CASE WHEN((CorrectAnswers / TotalQuestions) * 100) >= 75 THEN 'Passed' ELSE 'Fail' END TestResult, TotalQuestions, CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT COUNT(TestStartID)TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END)CorrectAnswers, Name, TestType, CreatedOn FROM (SELECT (SELECT FirstName+' 'LastName FROM Users U WHERE U.ID = [UserID]) Name, (SELECT [TestType]+' - '+[Language] as TestType FROM [TestType] TT WHERE TT.ID = [TestTypeID]) TestType, FORMAT(CreatedOn, 'MMM dd yyyy')CreatedOn, IsCorrect, TestStartID FROM [UserTest] WHERE (@TestType = -1 OR TestTypeID = @TestType) AND (@UID = -1 OR UserID = @UID)) Temp GROUP By Name, TestType, CreatedOn, TestStartID) Temp1  ORDER BY CreatedOn DESC";

            int selectedUser = int.TryParse(ddlUserList.SelectedValue, out int userValue) ? userValue : -1; // parse the value of ddluserlist. if it parses successfully, it will assign the ddluserlist value as an int. if not it will asssign the value -1
            int selectedTestType = int.TryParse(ddlTestType.SelectedValue, out int testTypeValue) ? testTypeValue : -1;

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TestType", selectedTestType);
                cmd.Parameters.AddWithValue("@UID", selectedUser);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                gvData.DataSource = reader;
                gvData.DataBind();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        protected void ddlTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}