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

public partial class pages_manager_manager_key_value : Page
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
                KeyValue keyValue = IocContainer.Get<IKeyValueDao>().SelectById(RequestId.Value);
                if (keyValue != null)
                {
                    tbKey.Text = keyValue.Key;
                    tbType.Text = keyValue.AdditionalData;
                    tbValue.Text = keyValue.Value;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        KeyValue keyValue = new KeyValue();
        if (RequestId.HasValue)
            keyValue = IocContainer.Get<IKeyValueDao>().SelectById(RequestId.Value);
        keyValue.Key = tbKey.Text.Trim();
        keyValue.Value = tbValue.Text.Trim();
        keyValue.AdditionalData = tbType.Text.Trim();
        if (RequestId.HasValue)
            IocContainer.Get<IKeyValueDao>().Update(keyValue);
        else
            IocContainer.Get<IKeyValueDao>().Insert(keyValue);
    }
}