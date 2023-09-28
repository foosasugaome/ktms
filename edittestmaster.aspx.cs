using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class edittestmaster : System.Web.UI.Page
    {
        // Database connection string retrieved from configuration
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve and remove TestMasterID from session
                ViewState["TestMasterID"] = Session["TestMasterID"];
                Session.Remove("TestMasterID");

                // Check if TestMasterID is null, and redirect if so
                if (ViewState["TestMasterID"] == null)
                {
                    Response.Redirect("testmasterlist.aspx");
                }

                // Populate dropdown lists and load test master data
                FillDropDown();
                try
                {
                    string strFilePath = "~/Files/Question/";
                    int intTestMasterID = Convert.ToInt32(ViewState["TestMasterID"]);

                    string strQuery = "SELECT [ID],[TestTypeID],[Question],[QuestionImage],[AnswerA],[AnswerB],[AnswerC],[AnswerD],[CorrectAnswer] FROM [dbo].[TestMaster] WHERE ID = @ID";

                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", intTestMasterID);
                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                strFilePath += reader["QuestionImage"].ToString();

                                // Populate form fields with retrieved data
                                ddlTestType.SelectedValue = reader["TestTypeID"].ToString();
                                txtQuestion.Text = reader["Question"].ToString();
                                txtAnswerA.Text = reader["AnswerA"].ToString();
                                txtAnswerB.Text = reader["AnswerB"].ToString();
                                txtAnswerC.Text = reader["AnswerC"].ToString();
                                txtAnswerD.Text = reader["AnswerD"].ToString();
                                ddlCorrectAnswer.SelectedValue = reader["CorrectAnswer"].ToString();
                                imgQuestion.ImageUrl = strFilePath;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions (no specific action).
                }
            }
        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            int intTestMasterID = Convert.ToInt32(ViewState["TestMasterID"].ToString());

            // Get the current image file path
            string strFilePath = imgQuestion.ImageUrl.ToString();
            string[] strCurrentFilePath = strFilePath.Split('/');
            string strFileName = strCurrentFilePath[strCurrentFilePath.Length - 1];

            // Handle image upload and save
            if (fuQuestionImage.HasFile)
            {
                // Check file extension and type (File Type Validation)
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" }; // Add allowed extensions as needed
                string fileExtension = System.IO.Path.GetExtension(fuQuestionImage.FileName);
                if (!allowedExtensions.Contains(fileExtension.ToLower()))
                {
                    lblResult.Text = "Invalid file type. Please upload a valid image file.";
                    return;
                }

                // Check file size (File Size Limitations)
                int maxFileSizeInBytes = 2 * 1024 * 1024; // 2MB as an example, adjust as needed
                if (fuQuestionImage.FileContent.Length > maxFileSizeInBytes)
                {
                    lblResult.Text = "File size exceeds the maximum allowed limit.";
                    return;
                }

                string[] strArray = fuQuestionImage.FileName.Split('.');
                string strExtension = strArray[strArray.Length - 1];
                strFileName = Guid.NewGuid().ToString() + "." + strExtension;

                strFilePath = Server.MapPath("~/Files/Question/") + strFileName;
                fuQuestionImage.SaveAs(strFilePath);
            }

            string strQuery = "UPDATE [dbo].[TestMaster] SET [TestTypeID] = @TTID, [Question] = @Question, [QuestionImage] = @QuestionImage, [AnswerA]= @AnswerA,[AnswerB]= @AnswerB,[AnswerC]= @AnswerC,[AnswerD]= @AnswerD,[CorrectAnswer]=@CorrectAnswer WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery, conn))
                {
                    // Set parameters for the update query
                    cmd.Parameters.AddWithValue("@ID", intTestMasterID);
                    cmd.Parameters.AddWithValue("@TTID", ddlTestType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Question", txtQuestion.Text);
                    cmd.Parameters.AddWithValue("@QuestionImage", strFileName);
                    cmd.Parameters.AddWithValue("@AnswerA", txtAnswerA.Text);
                    cmd.Parameters.AddWithValue("@AnswerB", txtAnswerB.Text);
                    cmd.Parameters.AddWithValue("@AnswerC", txtAnswerC.Text);
                    cmd.Parameters.AddWithValue("@AnswerD", txtAnswerD.Text);
                    cmd.Parameters.AddWithValue("@CorrectAnswer", ddlCorrectAnswer.SelectedValue);

                    conn.Open();
                    int intRowsAffected = cmd.ExecuteNonQuery();
                    if (intRowsAffected != 0)
                    {
                        lblResult.Text = "Test Master updated.";
                    }
                }
            }

            // Exception handling (no specific action).
            try
            {
                // Additional code can be placed here if needed.
            }
            catch (Exception ex)
            {
                lblResult.Text = "An error occured. Error details : " + ex.Message;
            }
        }

        private void FillDropDown()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();

                    // Fill dropdown list for test types from the database
                    FillDropDownFromQuery(ddlTestType, "SELECT ID, TestType + ' - ' + Language AS TextFieldValue FROM TestType WHERE Status = @StatusTestType ORDER BY TestType", "@StatusTestType", 1);

                    // Add default "Select" item
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
                    // Populate the dropdown list from the query result
                    dropDownList.DataTextField = "TextFieldvalue"; // Assuming "TextFieldValue" is the common field name for both dropdowns
                    dropDownList.DataValueField = "ID";
                    dropDownList.DataSource = reader;
                    dropDownList.DataBind();
                }
            }
        }
    }
}
