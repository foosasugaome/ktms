using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            lblFullName.Text = (string)Session["fullName"];
            // Label1.Text = "Expiration : " + Session["Expiration"] + "<br /> User Data : " + Session["userData"] + "<br /> Session ID : " + Session["SessionID"];
        }
    }
}