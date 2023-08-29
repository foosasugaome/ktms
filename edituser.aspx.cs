using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ktms
{
    public partial class edituser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = "Norman";
            txtLastName.Text = "Teodoro";
            txtEmail.Text = "norman@gmail.com";
            txtPhone.Text = "604 831 2345";
            ddlUserType.SelectedValue = "1";            
        }
    }
}