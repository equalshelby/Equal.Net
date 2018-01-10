using System;
using System.Web.UI;

public partial class pages_auth_login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Auth.IsEmployeeLogin)
            //    Response.Redirect(Nav.HomeUrl);
            //cbRemember.Checked = true;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Employee employee;
        //try
        //{
        //    employee = IocContainer.Get<EmployeeService>().VerifyEmployee(tbUsername.Text.Trim(), tbPassword.Text.Trim());
        //}
        //catch (ValidationException ex)
        //{
        //    lblScript.Text = ScriptHelper.CreateJavaScriptAlertBlock(ex.Message);
        //    return;
        //}

        //Auth.EmployeeLogin(employee, cbRemember.Checked);

        //if (!employee.DisableChangePassword && employee.ChangePasswordNextLogin)
        //    Response.Redirect("~/pages/auth/password.aspx?login=true");
        //else
        //    Response.Redirect(Nav.HomeUrl);
    }

}