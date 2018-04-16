using System;
using System.Web.UI;

using Equal.DDD;
using Equal.Utility;

using Model.Domain;
using Model.IDao;

public partial class pages_news : Page
{
    private long? RequestId
    {
        get { return (long?)ViewState["RequestId"]; }
        set { ViewState["RequestId"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RequestId = Request.QueryString["id"] != null ? Request.QueryString["id"].ToLong() : null;
        if (RequestId.HasValue)
        {
            ArticleInfo articleInfo = IocContainer.Get<IArticleInfoDao>().SelectById(RequestId.Value);
            if (articleInfo != null)
            {
                lblTitle.Text = articleInfo.Title;
                lblSubmitTime.Text = articleInfo.SubmitTime;
                lblSubmitUser.Text = articleInfo.SubmitUser;
                lblContext.Text = articleInfo.Context;
                articleInfo.ClickCount += 1;
                IocContainer.Get<IArticleInfoDao>().Update(articleInfo);
            }
        }
    }
}