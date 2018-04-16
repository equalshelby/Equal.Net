using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Equal.DDD;

using Model.Domain;
using Model.IDao;

public partial class pages_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Type1

        ArticleInfoCondition cond1 = new ArticleInfoCondition();
        cond1.Type = ArticleInfoEnum.Type1;
        lblArticleInfoData1.InnerHtml = SetArticleInfoList(cond1, 14, false);
        #endregion

        #region Type2

        ArticleInfoCondition cond2 = new ArticleInfoCondition();
        cond2.Type = ArticleInfoEnum.Type2;
        lblArticleInfoData2.InnerHtml = SetArticleInfoList(cond2, 14, false);
        #endregion

        #region Type3

        ArticleInfoCondition cond3 = new ArticleInfoCondition();
        cond3.Type = ArticleInfoEnum.Type3;
        lblArticleInfoData3.InnerHtml = SetArticleInfoList(cond3, 4, true);
        #endregion

        #region Type4

        ArticleInfoCondition cond4 = new ArticleInfoCondition();
        cond4.Type = ArticleInfoEnum.Type4;
        lblArticleInfoData4.InnerHtml = SetArticleInfoList(cond4, 4, true);
        #endregion

        #region Type5

        ArticleInfoCondition cond5 = new ArticleInfoCondition();
        cond5.Type = ArticleInfoEnum.Type5;
        lblArticleInfoData5.Text = SetArticleInfoTitleList(cond5, 1);
        #endregion

        #region Type6

        ArticleInfoCondition cond6 = new ArticleInfoCondition();
        cond6.Type = ArticleInfoEnum.Type4;
        lblArticleInfoData6.Text = SetArticleInfoTitleList(cond6, 1);
        #endregion
    }

    public string SetArticleInfoList(ArticleInfoCondition cond, int count, bool hideClickCount)
    {
        IList<ArticleInfo> articleInfoList = IocContainer.Get<IArticleInfoDao>().SelectTop(count, cond);
        string articleInfoData = null;
        if (articleInfoList.Count > 0)
        {
            for (int i = 0; i < articleInfoList.Count; i++)
            {
                string title = articleInfoList[i].Title;
                if (title.Length > 15)
                    title = title.Substring(0, 15) + "...";
                if (hideClickCount)
                    articleInfoData = articleInfoData + "<li><a href=news.aspx?id=" + articleInfoList[i].Id + " title=" + articleInfoList[i].Title + " target='_blank'><p>" + title + "</p><span class='time'>[" + articleInfoList[i].SubmitTime + "]</span></a> </li>";
                else
                    articleInfoData = articleInfoData + "<li><a href=news.aspx?id=" + articleInfoList[i].Id + " title=" + articleInfoList[i].Title + " target='_blank'><p>" + title + "<em>点击量：" + articleInfoList[i].ClickCount + "</em></p><span class='time'>[" + articleInfoList[i].SubmitTime + "]</span></a> </li>";
            }
        }
        return articleInfoData;
    }

    public string SetArticleInfoTitleList(ArticleInfoCondition cond, int count)
    {
        IList<ArticleInfo> articleInfoList = IocContainer.Get<IArticleInfoDao>().SelectTop(count, cond);
        string articleInfoData = null;
        ArticleInfo articleInfo = articleInfoList.FirstOrDefault();
        if (articleInfo != null)
        {
            string title = articleInfo.Title;
            if (title.Length > 10)
                title = title.Substring(0, 10) + "...";
            articleInfoData = "<a href=news.aspx?id=" + articleInfo.Id + " title=" + articleInfo.Title + " target='_blank'><h3>" + title + "</h3><p>要闻头条：[" + articleInfo.SubmitTime + title + "]</p></a>";
        }
        return articleInfoData;
    }
}