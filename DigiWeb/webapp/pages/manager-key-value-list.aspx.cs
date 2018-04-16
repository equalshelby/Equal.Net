using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Equal.DDD;
using Equal.Utility;
using Model.Domain;
using Model.IDao;

public partial class pages_manager_key_value_list : Page
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
        KeyValueCondition condition = new KeyValueCondition();
        IKeyValueDao dao = IocContainer.Get<IKeyValueDao>();
        anp.RecordCount = dao.SelectCount(condition);
        gv.DataSource = dao.SelectByPage(anp.StartRecordIndex, anp.PageSize, condition);
        gv.DataBind();
    }

    public void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ilblKey = (Label)e.Row.FindControl("ilblKey");
            Label ilblValue = (Label)e.Row.FindControl("ilblValue");
            Label ilblAdditionalData = (Label)e.Row.FindControl("ilblAdditionalData");

            KeyValue info = (KeyValue)e.Row.DataItem;

            ilblKey.Text = info.Key;
            ilblValue.Text = info.Value;
            ilblAdditionalData.Text = info.AdditionalData;
            
            LinkButton ilbtnDelete = (LinkButton)e.Row.FindControl("ilbtnDelete");
            HyperLink ihlEdit = (HyperLink)e.Row.FindControl("ihlEdit");
            
            if (RequestFlag.HasValue)
            {
                ihlEdit.Visible = true;
                ihlEdit.NavigateUrl = "manager-key-value.aspx?id=" + info.Id;
                ihlEdit.Target = "_blank";

                ilbtnDelete.Visible = true;
                ilbtnDelete.CausesValidation = false;
                ilbtnDelete.CommandName = "Delete";
                ilbtnDelete.OnClientClick = "return confirm('确定要删除此keyValue吗？');";
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
        IocContainer.Get<IKeyValueDao>().DeleteById(id.ToLongReq());
        BindData();
    }

    protected void anp_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}