using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Equal.DDD;

using Model.Domain;
using Model.IDao;

public partial class pages_manager_manager_key_value : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        KeyValue keyValue = new KeyValue();
        keyValue.Key = tbKey.Text.Trim();
        keyValue.Value = tbValue.Text.Trim();
        keyValue.AdditionalData = tbType.Text.Trim();
        IocContainer.Get<IKeyValueDao>().Insert(keyValue);
    }
}