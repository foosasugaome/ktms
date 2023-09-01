using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    [Authorize] // TODO : Learn Authorize attribute implementaion
    public partial class secretpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Register a startup script to show an alert on page load
                string script = "alert('Welcome to the secret page!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "PageLoadAlert", script, true);
            }            
        }
    }
}