using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class allocatetest : System.Web.UI.Page
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
                    ddlUserList.Items.Insert(0, new ListItem("Select", "0"));
                    ddlTestType.Items.Insert(0, new ListItem("Select", "0"));
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

        private void PopulateGrid()
        {
            string strQuery = "SELECT [ID], " +
                             "(SELECT FirstName+' '+LastName FROM [dbo].[Users] U WHERE U.ID = [UserID]) AS Name, " +
                             "(SELECT [TestType]+' - '+[Language] AS TestType FROM [dbo].[TestType] TT WHERE TT.ID = [TestTypeID]) AS TestType, " +
                             "FORMAT([CreatedOn], 'MMM dd yyyy') CreatedOn, " +
                             "CASE WHEN Status = 1 THEN 'Active' ELSE 'Deleted' END Status " +
                             "FROM [dbo].[AllocateTest] ORDER BY ID DESC";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                gvData.DataSource = reader;
                gvData.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int intTestType = Convert.ToInt32(ddlTestType.SelectedValue);
            int intUserID = Convert.ToInt32(ddlUserList.SelectedValue);

            string strQuery = "SELECT COUNT(*) FROM AllocateTest WHERE [UserID] = @UserID AND [TestTypeID] = @TestTypeID";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", intUserID);
                cmd.Parameters.AddWithValue("@TestTypeID", intTestType);
                conn.Open();
                int intResult = Convert.ToInt32(cmd.ExecuteScalar());
                lblResult.Text = intResult > 0
                    ? "Test already allocated to user."
                    : AllocateTest(intUserID, intTestType) ? "Test allocated to user." : "Cannot allocate test to user.";
            }

            FillDropDown();
            PopulateGrid();
        }

        private bool AllocateTest(int UUID, int TestTypeID)
        {
            string strQuery = "INSERT INTO [dbo].[AllocateTest] ([UserID],[TestTypeID]) VALUES (@UID,@TTID)";
            bool updateSuccess = false;

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("@UID", UUID);
                cmd.Parameters.AddWithValue("@TTID", TestTypeID);
                conn.Open();
                int intResult = cmd.ExecuteNonQuery();
                if (intResult != 0)
                {
                    updateSuccess = true;
                }
            }

            return updateSuccess;
        }


        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {

            lblResult.Text = string.Empty;
            LinkButton objLinkButton = (LinkButton)sender;
            string strID = objLinkButton.CommandArgument.ToString();
            string strQuery = "UPDATE [dbo].[AllocateTest] SET STATUS = CASE WHEN STATUS = 0 THEN 1 ELSE 0 END WHERE ID = @TestID";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {                
                cmd.Parameters.AddWithValue("@TestID", strID);

                conn.Open();
                int intResult = cmd.ExecuteNonQuery();

                lblResult.Text = intResult > 0 ? "Test deleted." : "Cannot update record.";                
            }
            FillDropDown();
            PopulateGrid();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}