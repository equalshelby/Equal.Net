using System.Web;
using System.Web.UI;

/// <summary>
/// PagesNav 页面导航
/// </summary>
public partial class Nav
{
    /// <summary>
    /// 登录页面路径
    /// </summary>
    public static string LoginUrl
    {
        get
        {
            return ((Page)HttpContext.Current.Handler).ResolveUrl("~/pages/auth/login.aspx");
        }
    }

    /// <summary>
    /// 主页路径
    /// </summary>
    public static string HomeUrl
    {

        get
        {
            return ((Page)HttpContext.Current.Handler).ResolveUrl("~/pages/index/main.aspx");
        }
    }
}