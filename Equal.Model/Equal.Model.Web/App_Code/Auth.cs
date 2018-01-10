using System;

using Equal.DDD;
using Equal.Login.Domain;
using Equal.Login.IDao;
using Equal.Login.Svc;
using Equal.Utility.ExtensionMethod;
using Equal.Utility;

/// <summary>
/// 公共认证类
/// </summary>
public static partial class Auth
{

    /// <summary>
    /// 根据用户类型自动跳转到登录页面
    /// </summary>
    /// <param name="loginType"></param>
    private static void Relogin(string loginType = "")
    {
        //if (loginType == "xxx")
        //    xxxRelogin();
        return;

        //WebMessageHelper.ShowUnBack("未登录或由于闲置时间太长，登录会话已结束，请重新登录。");
    }

    /// <summary>
    /// 获取当前登录类型，未登录时会转到登录页面
    /// </summary>
    public static string LoginType
    {
        get
        {
            LoginToken loginToken;
            if (LoginHelper.TryGetLoginToken(out loginToken))
                return loginToken.LoginType;

            Relogin(loginToken.IfNotNull(s => s.LoginType, string.Empty));
            return string.Empty;
        }
    }

    /// <summary>
    /// 获取当前登录Id，未登录时会转到登录页面
    /// </summary>
    public static string LoginId
    {
        get
        {
            LoginToken loginToken;
            if (LoginHelper.TryGetLoginToken(out loginToken))
                return loginToken.LoginId;

            Relogin(loginToken.IfNotNull(s => s.LoginType, string.Empty));
            return string.Empty;
        }
    }

    /// <summary>
    /// 判断是否已登录
    /// </summary>
    public static bool IsLogin
    {
        get
        {
            LoginToken loginToken;
            LoginHelper.TryGetLoginToken(out loginToken);
            return loginToken != null;
        }
    }

    /// <summary>
    /// 获取登录用户的企业员工，如未登录返回null
    /// </summary>
    public static LoginUser GetEmployee()
    {
        LoginToken token = LoginHelper.GetLoginToken();
        if (token == null)
            return null;

        long? id = token.LoginId.ToInt64();
        if (!id.HasValue)
            return null;

        LoginUser loginUser = IocContainer.Get<ILoginUserDao>().SelectByIdReq(id.Value);

        if (loginUser == null)
            return null;

        if (loginUser.Disabled)
            return null;
        return null;
        //return employee;
    }

}