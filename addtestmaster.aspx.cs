using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class addtestmaster : System.Web.UI.Page
    {

        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
            }
        }


        private void FillDropDown()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();

                    //FillDropDownFromQuery(ddlUserList, "SELECT ID, FirstName + ' ' + LastName AS TextFieldValue FROM USERS WHERE Status = @StatusUser ORDER BY FirstName", "@StatusUser", 1);
                    FillDropDownFromQuery(ddlTestType, "SELECT ID, TestType + ' - ' + Language AS TextFieldValue FROM TestType WHERE Status = @StatusTestType ORDER BY TestType", "@StatusTestType", 1);

                    // Add default "Select" items
                    //ddlUserList.Items.Insert(0, new ListItem("Select", "0"));
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

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            utils util = new utils();
            int intUID = util.CurrentLoggedUserID();

            if (intUID == 0)
            {
                lblResult.Text = "You need to log in to save.";
                hlSignin.Visible = true;
                return;
            }

            try
            {
                string strFileName = string.Empty;

                if (fuQuestionImage.HasFile)
                {
                    string[] strArray = fuQuestionImage.FileName.Split('.');
                    string strExtension = strArray[strArray.Length - 1];
                    strFileName = Guid.NewGuid().ToString() + "." + strExtension;

                    string strPath = Server.MapPath("~/Files/Question/") + strFileName;
                    fuQuestionImage.SaveAs(strPath);
                }

                // Get values from controls
                int intTestTypeID = Convert.ToInt32(ddlTestType.SelectedValue);
                string strQuestion = txtQuestion.Text;
                string strAnsA = txtAnswerA.Text;
                string strAnsB = txtAnswerB.Text;
                string strAnsC = txtAnswerC.Text;
                string strAnsD = txtAnswerD.Text;
                string strAnsCorr = txtCorrectAnswer.Text;

                // Verify if question exists
                string strVerifyQuestion = "SELECT COUNT(*) FROM [dbo].[TestMaster] WHERE [Question] = @Question";

                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(strVerifyQuestion, connection))
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Question", strQuestion);
                        int intResult = Convert.ToInt32(cmd.ExecuteScalar());
                        if (intResult > 0)
                        {
                            lblResult.Text = "Question already exists.";
                            return;
                        }
                    }

                    string strInsQuery = "INSERT INTO [dbo].[TestMaster] ([TestTypeID], [Question], [QuestionImage], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [CorrectAnswer], [CreatedBy]) " +
                                        "VALUES (@TTID, @Question, @QuestionImg, @AnsA, @AnsB, @AnsC, @AnsD, @AnsCorr, @UUID)";


                    string strInsQueryShow = "INSERT INTO [dbo].[TestMaster] ([TestTypeID], [Question], [QuestionImage], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [CorrectAnswer], [CreatedBy]) " +
                                        "VALUES (" + intTestTypeID +", '" +strQuestion+"', '"+strFileName+"','"+strAnsA+ "','"+strAnsB+"','"+strAnsC+"','"+strAnsD+"','"+strAnsCorr+"',"+intUID+")";

                    using (SqlCommand insertCommand = new SqlCommand(strInsQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@TTID", intTestTypeID);
                        insertCommand.Parameters.AddWithValue("@Question", strQuestion);
                        insertCommand.Parameters.AddWithValue("@QuestionImg", strFileName); // You can add the image here
                        insertCommand.Parameters.AddWithValue("@AnsA", strAnsA);
                        insertCommand.Parameters.AddWithValue("@AnsB", strAnsB);
                        insertCommand.Parameters.AddWithValue("@AnsC", strAnsC);
                        insertCommand.Parameters.AddWithValue("@AnsD", strAnsD);
                        insertCommand.Parameters.AddWithValue("@AnsCorr", strAnsCorr);
                        insertCommand.Parameters.AddWithValue("@UUID", intUID);

                        int rowsAffected = 0;

                        try
                        {
                            
                            rowsAffected = insertCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception, log it, or display an error message as needed
                            lblResult.Text = "An error occurred while adding the question." + ex.Message + " " + strInsQueryShow;
                            return;
                        }
                        finally
                        {
                            connection.Close(); // Ensure the connection is closed in all cases
                        }

                        if (rowsAffected > 0)
                        {
                            lblResult.Text = "Question added successfully.";
                            // Clear input fields if needed
                            txtQuestion.Text = string.Empty;
                            txtAnswerA.Text = string.Empty;
                            txtAnswerB.Text = string.Empty;
                            txtAnswerC.Text = string.Empty;
                            txtAnswerD.Text = string.Empty;
                            txtCorrectAnswer.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            lblResult.Text = "Failed to add the question.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {             
                lblResult.Text = "An error occurred.";
            }
        }

    }
}