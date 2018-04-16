using System;
using System.Web.UI;

using Equal.DDD;
using Equal.Utility;

using Model.Domain;
using Model.IDao;

public partial class pages_manager_manager_news : Page
{
    private long? RequestId
    {
        get { return (long?)ViewState["RequestId"]; }
        set { ViewState["RequestId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RequestId = Request.QueryString["id"] != null ? Request.QueryString["id"].ToLong() : null;
            if (RequestId.HasValue)
            {
                ArticleInfo articleInfo = IocContainer.Get<IArticleInfoDao>().SelectById(RequestId.Value);
                if (articleInfo != null)
                {
                    tbTitle.Text = articleInfo.Title;
                    tbSubmitTime.Text = articleInfo.SubmitTime;
                    tbSubmitUser.Text = articleInfo.SubmitUser;
                    tbContext.Text = articleInfo.Context;
                    tbClickCount.Text = articleInfo.ClickCount.ToString();
                    ddlType.Items.FindByValue(articleInfo.Type.GetValue().ToString()).Selected = true;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ArticleInfo articleInfo = new ArticleInfo();
        if (RequestId.HasValue)
            articleInfo = IocContainer.Get<IArticleInfoDao>().SelectById(RequestId.Value);
        articleInfo.Title = tbTitle.Text.Trim();
        articleInfo.SubmitTime = tbSubmitTime.Text.Trim();
        articleInfo.SubmitUser = tbSubmitUser.Text.Trim();
        articleInfo.Context = tbContext.Text;
        articleInfo.Type = ddlType.SelectedValue.ToEnumReq<ArticleInfoEnum>();
        articleInfo.ClickCount =
            !string.IsNullOrEmpty(tbClickCount.Text.Trim()) ? tbClickCount.Text.Trim().ToIntReq() : 0;
        if (RequestId.HasValue)
            IocContainer.Get<IArticleInfoDao>().Update(articleInfo);
        else
            IocContainer.Get<IArticleInfoDao>().Insert(articleInfo);
    }
}