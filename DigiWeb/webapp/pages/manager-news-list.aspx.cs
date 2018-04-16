﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Equal.DDD;
using Equal.Utility;
using Model.Domain;
using Model.IDao;

public partial class pages_manager_news_list : Page
{
    private bool? RequestFlag
    {
        get { return (bool?)ViewState["RequestFlag"]; }
        set { ViewState["RequestFlag"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RequestFlag = Request.QueryString["id"] != null ? Request.QueryString["id"].ToBool() : null;
            anp.SetStyle();
            BindData();
        }
    }

    private void BindData()
    {
        ArticleInfoCondition condition = new ArticleInfoCondition();
        IArticleInfoDao dao = IocContainer.Get<IArticleInfoDao>();
        anp.RecordCount = dao.SelectCount(condition);
        gv.DataSource = dao.SelectByPage(anp.StartRecordIndex, anp.PageSize, condition);
        gv.DataBind();
    }

    public void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ilblTitle = (Label)e.Row.FindControl("ilblTitle");
            Label ilblSubmitTime = (Label)e.Row.FindControl("ilblSubmitTime");
            Label ilblSubmitUser = (Label)e.Row.FindControl("ilblSubmitUser");
            Label ilblClickCount = (Label)e.Row.FindControl("ilblClickCount");

            ArticleInfo info = (ArticleInfo)e.Row.DataItem;

            ilblTitle.Text = info.Title;
            ilblSubmitTime.Text = info.SubmitTime;
            ilblSubmitUser.Text = info.SubmitUser;
            ilblClickCount.Text = info.ClickCount.ToString();

            HyperLink ihlDetail = (HyperLink)e.Row.FindControl("ihlDetail");
            LinkButton ilbtnDelete = (LinkButton)e.Row.FindControl("ilbtnDelete");
            HyperLink ihlEdit = (HyperLink)e.Row.FindControl("ihlEdit");
            
            ihlDetail.NavigateUrl = "news.aspx?id=" + info.Id;
            ihlDetail.Target = "_blank";
            if (RequestFlag.HasValue)
            {
                ihlEdit.Visible = true;
                ihlEdit.NavigateUrl = "manager-news.aspx?id=" + info.Id;
                ihlEdit.Target = "_blank";

                ilbtnDelete.Visible = true;
                ilbtnDelete.CausesValidation = false;
                ilbtnDelete.CommandName = "Delete";
                ilbtnDelete.OnClientClick = "return confirm('确定要删除此文章吗？');";
            }
            else
            {
                ilbtnDelete.Visible = false;
                ihlEdit.Visible = false;
            }
        }
    }

    public void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gv.DataKeys[e.RowIndex].Value.ToString();
        IocContainer.Get<IArticleInfoDao>().DeleteById(id.ToLongReq());
        BindData();
    }

    protected void anp_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}