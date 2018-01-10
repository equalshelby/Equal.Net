using System;
using System.Web.UI;

using Equal.DDD;
using Equal.Login.Domain;
using Equal.Login.IDao;


public partial class pages_login_user_edit : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegist_Click(object sender, EventArgs e)
    {
        LoginUser user = new LoginUser();
        
        user.LoginName = tbLoginName.Text.Trim();
        user.LoginPassWord = tbPassWord.Text.Trim();
        user.LoginType = LoginType.CommonUser;

        IocContainer.Get<ILoginUserDao>().Insert(user);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoginUser user = new LoginUser();
        LoginUserCondition cond = new LoginUserCondition();
        cond.LoginName = tbLoginName.Text;
        user = IocContainer.Get<ILoginUserDao>().SelectTop1(cond);
        tbLoginName.Text = user.LoginName;
        tbPassWord.Text = user.LoginPassWord;
    }
}