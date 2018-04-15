using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Equal.DDD;

using Model.Domain;
using Model.IDao;

public partial class pages_HomeMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 国家行政主管部门的规章制度规范

        KeyValueCondition cond = new KeyValueCondition();
        cond.Key = "Nav";
        IList<KeyValue> keyValueList = IocContainer.Get<IKeyValueDao>().SelectTop(6, cond);
        string keyValueData = null;
        if (keyValueList.Count > 0)
        {
            for (int i = 0; i < keyValueList.Count; i++)
            {
                string title = keyValueList[i].Value;
                if (title.Length > 24)
                    title = title.Substring(0, 24) + "...";
                string url = "../index.aspx" + keyValueList[i].Id;
                keyValueData = keyValueData + "<li><a href=" + keyValueList[i].AdditionalData + " title=" + keyValueList[i].Value + " target='_blank'>" + title + "</a><span>"+ "</span> </li>";
            }
        }
        lblKeyValueData.InnerHtml = keyValueData;
        lblKeyValueDateFooter.InnerHtml = keyValueData;
        #endregion
    }
}
