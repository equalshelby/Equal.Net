using System;
using System.Web.UI;

using Equal.DDD;
using Equal.Login.Domain;
using Equal.Login.IDao;
using Equal.Utility;


public partial class pages_login_user_edit : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegist_Click(object sender, EventArgs e)
    {
        LoginUser user = new LoginUser();

        user.Id = SnowFlake.GetNewId();
        user.LoginName = tbLoginName.Text.Trim();
        user.LoginPassWord = tbPassWord.Text.Trim();
        user.LoginType = LoginType.User;

        IocContainer.Get<ILoginUserDao>().Insert(user);
    }
}