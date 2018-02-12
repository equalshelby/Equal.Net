using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_index_main : System.Web.UI.Page
{
    protected void btnOut_Click(object sender, EventArgs e)
    {
        Auth.Logout();
        Response.Redirect(Nav.LoginUrl);
    }
}