using System;
using System.Collections.Generic;

using Equal.DDD;

using Model.Domain;
using Model.IDao;

public partial class pages_HomeMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 首页信息
        HomePageInfo homePageInfo = IocContainer.Get<IHomePageInfoDao>().SelectTop1();
        if (homePageInfo != null)
        {
            lblWelcome.Text = homePageInfo.Welcome;
            //tbList1Name.Text = homePageInfo.List1Name;
            //tbList2Name.Text = homePageInfo.List2Name;
            //tbList3Name.Text = homePageInfo.List3Name;
            //tbList4Name.Text = homePageInfo.List4Name;
            lblPhone1.Text = homePageInfo.Phone1;
            lblPhone2.Text = homePageInfo.Phone2;
            lblEmail.Text = homePageInfo.Email;
            lblAddress.Text = homePageInfo.Address;
            lblCopyrightInfo.Text = homePageInfo.CopyrightInfo;
        }
        #endregion

        #region Nav

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
                keyValueData = keyValueData + "<li><a href=" + keyValueList[i].AdditionalData + " title=" + keyValueList[i].Value + " target='_blank'>" + title + "</a><span>"+ "</span> </li>";
            }
        }
        lblKeyValueData.InnerHtml = keyValueData;
        lblKeyValueDateFooter.InnerHtml = keyValueData;
        #endregion
    }
}
