using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class usertest : System.Web.UI.Page
    {
        private readonly string strConn = ConfigurationManager.AppSettings["sqlConn"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown(ddlTestType);
            }
        }

        private void FillDropDown(DropDownList dropDownList)
        {
            try
            {
                utils util = new utils();
                int intUID = util.CurrentLoggedUserID();
                string strQuery = "SELECT dbo.AllocateTest.UserID, dbo.AllocateTest.ID AS ATID, dbo.AllocateTest.TestTypeID, dbo.TestType.TestType + ' - ' + dbo.TestType.Language AS TextFieldValue, dbo.TestType.Status AS TTStatus, dbo.AllocateTest.Status AS ATStatus FROM   dbo.AllocateTest INNER JOIN dbo.TestType ON dbo.AllocateTest.TestTypeID = dbo.TestType.ID WHERE (dbo.AllocateTest.UserID = @UID) AND (dbo.TestType.Status = 1) AND (dbo.AllocateTest.Status = 1)";
                using (SqlConnection connection = new SqlConnection(strConn))
                using (SqlCommand command = new SqlCommand(strQuery, connection))
                {
                    command.Parameters.AddWithValue("@UID", intUID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dropDownList.DataTextField = "TextFieldValue";
                        dropDownList.DataValueField = "TestTypeID";
                        dropDownList.DataSource = reader;
                        dropDownList.DataBind();
                    }
                }

                // Add default "Select" item
                dropDownList.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }



        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lnkNext.Visible = false;
                int selectedTestTypeID;
                if (!int.TryParse(ddlTestType.SelectedValue, out selectedTestTypeID))
                {
                    lblError.Text = "Invalid test type selection.";
                    return;
                }

                string strQuery = "SELECT [ID],[TestTypeID],[Question],[QuestionImage],[AnswerA],[AnswerB],[AnswerC],[AnswerD],[CorrectAnswer],[Status], 0 AS IsDisplayed FROM [dbo].[TestMaster] WHERE STATUS=1 AND TestTypeID = " + selectedTestTypeID;
                DataSet ds = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strQuery);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblError.Text = "There are no questions related to the selected test type.";
                    divStart.Visible = true;
                    divStartTest.Visible = false;
                    divResult.Visible = false;
                }
                else
                {
                    ViewState["Question"] = ds;
                    string strTestStartID = Guid.NewGuid().ToString();
                    ViewState["TestStartID"] = strTestStartID;
                    FillQuestion();
                }
            }

            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void lnkAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                utils util = new utils();
                int UID = util.CurrentLoggedUserID();
                string strQuery = string.Empty;
                string strTestStartID = string.Empty;
                int intIsCorrect = 0;
                LinkButton objLinkButton = (LinkButton)sender;
                string strCorrectAnswer = Convert.ToString(ViewState["CorrectAnswer"]);
                if (objLinkButton.CommandName == strCorrectAnswer)
                {
                    objLinkButton.BackColor = Color.Green;
                    objLinkButton.ForeColor = Color.White;
                    intIsCorrect = 1;

                }
                else
                {
                    objLinkButton.BackColor = Color.Red;
                    objLinkButton.ForeColor = Color.White;
                }

                ManageAnswer(false);
                strTestStartID = ViewState["TestStartID"].ToString();
                strQuery = "INSERT INTO [dbo].[UserTest] ([UserID],[TestTypeID],[TestMasterID],[IsCorrect],[TestStartID])VALUES(@UID,@TestTypeID,@TestMasterID,@IsCorrect,@TestStartID)";
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery,conn))
                    {
                        cmd.Parameters.AddWithValue("@UID", UID);
                        cmd.Parameters.AddWithValue("@TestTypeID", ddlTestType.SelectedValue);
                        cmd.Parameters.AddWithValue("@TestMasterID", ViewState["TestMasterID"].ToString());
                        cmd.Parameters.AddWithValue("@IsCorrect", intIsCorrect);
                        cmd.Parameters.AddWithValue("@TestStartID", strTestStartID);

                        conn.Open();
                        int intResult = cmd.ExecuteNonQuery();
                        if (intResult != 0)
                        {

                        }
                    }
                }
                lnkNext.Visible = true;


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ManageAnswer(bool IsEnabled)
        {
            lnkAnswerA.Enabled = IsEnabled;
            lnkAnswerB.Enabled = IsEnabled;
            lnkAnswerC.Enabled = IsEnabled;
            lnkAnswerD.Enabled = IsEnabled;
        }

        private void ResetAnswer()
        {
            lnkAnswerA.BackColor = Color.White;
            lnkAnswerA.ForeColor = Color.Black;
            lnkAnswerB.BackColor = Color.White;
            lnkAnswerB.ForeColor = Color.Black;
            lnkAnswerC.BackColor = Color.White;
            lnkAnswerC.ForeColor = Color.Black;
            lnkAnswerD.BackColor = Color.White;
            lnkAnswerD.ForeColor = Color.Black;

            ManageAnswer(true);
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            lnkNext.Visible = false;
            ResetAnswer();
            FillQuestion();
        }

        private void FillQuestion()
        {
            try
            {
                string strFilePath = "~/Files/Question/";

                divStart.Visible = false;
                divStartTest.Visible = true;
                divResult.Visible = false;
                DataSet ds = (DataSet)ViewState["Question"];
                DataRow[] dr = ds.Tables[0].Select("IsDisplayed=0");
                if (dr.Length > 0)
                {
                    lblQuestion.Text = Convert.ToString(dr[0]["Question"]);
                    imgQuestion.ImageUrl = strFilePath + Convert.ToString(dr[0]["QuestionImage"]);
                    lnkAnswerA.Text = Convert.ToString(dr[0]["AnswerA"]);
                    lnkAnswerB.Text = Convert.ToString(dr[0]["AnswerB"]);
                    lnkAnswerC.Text = Convert.ToString(dr[0]["AnswerC"]);
                    lnkAnswerD.Text = Convert.ToString(dr[0]["AnswerD"]);
                    ViewState["CorrectAnswer"] = Convert.ToString(dr[0]["CorrectAnswer"]);
                    ViewState["TestMasterID"] = Convert.ToString(dr[0]["ID"]);
                    dr[0]["IsDisplayed"] = 1;
                }
                else
                {
                    divStart.Visible = false;
                    divStartTest.Visible = false;
                    divResult.Visible = true;

                    //string strQuery = "SELECT COUNT(ID) TotalQuestions FROM [dbo].[UserTest] WHERE [TestStartID] = '" + ViewState["TestStartID"] + "';SELECT COUNT(ID) TotalCorrectAnswers FROM [dbo].[UserTest] WHERE [TestStartID] = '" + ViewState["TestStartID"] + "' AND IsCorrect=1";
                    //DataSet dsResult = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strQuery);
                    //lblTotalQuestions.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TotalQuestions"]);
                    //lblCorrectAnswer.Text = Convert.ToString(dsResult.Tables[1].Rows[0]["TotalCorrectAnswers"]);
                    //int intResult = SqlHelper.ExecuteNonQuery(strConn,CommandType.Text, strQuery);

                    string testStartID = ViewState["TestStartID"].ToString();
                    string query = "SELECT COUNT(ID) TotalQuestions, SUM(CASE WHEN IsCorrect = 1 THEN 1 ELSE 0 END) TotalCorrectAnswers FROM [dbo].[UserTest] WHERE [TestStartID] = @TestStartID";

                    using (SqlConnection connection = new SqlConnection(strConn))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TestStartID", testStartID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalQuestions = Convert.ToInt32(reader["TotalQuestions"]);
                                int totalCorrectAnswers = Convert.ToInt32(reader["TotalCorrectAnswers"]);

                                if ((totalCorrectAnswers / totalQuestions) * 100 >= 75)
                                {
                                    lblResult.Text = "You passed.";
                                    lblResult.CssClass = "alert-success";
                                }
                                else
                                {
                                    lblResult.Text = "You failed.";
                                    lblResult.CssClass = "alert-danger";
                                }


                                lblTotalQuestions.Text = totalQuestions.ToString();
                                lblCorrectAnswer.Text = totalCorrectAnswers.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void lnkFinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("usertest.aspx");
        }
    }
}