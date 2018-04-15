using Wuqi.Webdiyer;

/// <summary>
/// AspNetPager扩展方法类
/// </summary>
public static class ControlExtensionMethod_AspNetPager
{
    /// <summary>
    /// 设置分页控件
    /// </summary>
    /// <param name="pager"></param>
    public static void SetStyle(this AspNetPager pager)
    {
        pager.AlwaysShow = true;

        pager.PageSize = 15;

        pager.SubmitButtonText = "跳转";
        pager.SubmitButtonClass = "searchButton";


        pager.ShowCustomInfoSection = ShowCustomInfoSection.Right;
        pager.CustomInfoTextAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
        pager.CustomInfoHTML = "第 %CurrentPageIndex% 页，共 %PageCount% 页，每页显示 %PageSize% 条记录，共 %RecordCount% 条记录";

        pager.CssClass = "pager";
        pager.CustomInfoSectionWidth = 350;
        pager.CustomInfoStyle = "float:right";
        pager.CustomInfoClass = "custom-info";

        pager.NextPageText = "下一页";
        pager.PrevPageText = "上一页";

        pager.ShowFirstLast = false;

        pager.PrevNextButtonsClass = "next";
        pager.CurrentPageButtonClass = "current";
    }

    /// <summary>
    /// 设置分页控件，简洁版
    /// </summary>
    /// <param name="pager"></param>
    public static void SetSimpleStyle(this AspNetPager pager)
    {
        pager.AlwaysShow = false;
        pager.PageSize = 15;
        pager.SubmitButtonText = "GO";
        pager.PrevPageText = "上一页";
        pager.NextPageText = "下一页";
        pager.ShowFirstLast = false;
        pager.ShowPageIndex = false;
        pager.ShowCustomInfoSection = ShowCustomInfoSection.Right;
        pager.CustomInfoTextAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
        pager.CustomInfoHTML = "%CurrentPageIndex% / %PageCount%";
    }
}
