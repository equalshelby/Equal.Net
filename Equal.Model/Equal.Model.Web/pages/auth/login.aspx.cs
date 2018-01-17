using System;
using System.Web.UI;

using Equal.DDD;
using Equal.Login.Domain;
using Equal.Login.Svc;
using Equal.Utility.Web;
using Equal.Utility;

public partial class pages_auth_login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Auth.IsLogin)
                Response.Redirect(Nav.HomeUrl);
            cbRemember.Checked = true;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LoginUser loginUser;
        try
        {
            loginUser = IocContainer.Get<LoginUserSvc>().VerifyLoginUser(tbUsername.Text.Trim(), tbPassword.Text.Trim());
        }
        catch (ValidationException ex)
        {
            lblScript.Text = ScriptHelper.CreateJavaScriptAlertBlock(ex.Message);
            return;
        }

        Auth.Login(loginUser, cbRemember.Checked);

        //if (!loginUser.DisableChangePassword && loginUser.ChangePasswordNextLogin)
        //    Response.Redirect("~/pages/auth/password.aspx?login=true");
        //else
            Response.Redirect(Nav.HomeUrl);
    }

}