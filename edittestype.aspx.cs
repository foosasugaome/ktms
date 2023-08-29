using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class edittestype : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlTestType.SelectedValue = "1";
            ddlLanguage.SelectedValue = "1";
        }
    }
}