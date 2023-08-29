using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class edittestmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlTestType.SelectedValue = "1";
            txtQuestion.Text = "Question 4";
            txtAnswerA.Text = "Test";
            txtAnswerB.Text = "B Test";
            txtAnswerC.Text = "CTest";
            txtAnswerD.Text = "Test";
            txtCorrectAnswer.Text = "B";
        }
    }
}