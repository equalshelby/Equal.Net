using System;
using System.Web.UI;

using Equal.DDD;

using Model.Domain;
using Model.IDao;

public partial class pages_manager_home_page : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HomePageInfo homePageInfo = IocContainer.Get<IHomePageInfoDao>().SelectTop1();
        if (homePageInfo != null)
        {
            tbWelcome.Text = homePageInfo.Welcome;
            tbList1Name.Text = homePageInfo.List1Name;
            tbList2Name.Text = homePageInfo.List2Name;
            tbList3Name.Text = homePageInfo.List3Name;
            tbList4Name.Text = homePageInfo.List4Name;
            tbPhone1.Text = homePageInfo.Phone1;
            tbPhone2.Text = homePageInfo.Phone2;
            tbEmail.Text = homePageInfo.Email;
            tbAddress.Text = homePageInfo.Address;
            tbCopyrightInfo.Text = homePageInfo.CopyrightInfo;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool flag = false;
        HomePageInfo homePageInfo = IocContainer.Get<IHomePageInfoDao>().SelectTop1();
        if (homePageInfo == null)
        {
            flag = true;
            homePageInfo = new HomePageInfo();
        }
        homePageInfo.Welcome = tbWelcome.Text.Trim();
        homePageInfo.List1Name = tbList1Name.Text.Trim();
        homePageInfo.List2Name = tbList2Name.Text.Trim();
        homePageInfo.List3Name = tbList3Name.Text.Trim();
        homePageInfo.List4Name = tbList4Name.Text.Trim();
        homePageInfo.Phone1 = tbPhone1.Text.Trim();
        homePageInfo.Phone2 = tbPhone2.Text.Trim();
        homePageInfo.Email = tbEmail.Text.Trim();
        homePageInfo.Address = tbAddress.Text.Trim();
        homePageInfo.CopyrightInfo = tbCopyrightInfo.Text.Trim();
        if (flag)
            IocContainer.Get<IHomePageInfoDao>().Insert(homePageInfo);
        else
            IocContainer.Get<IHomePageInfoDao>().Update(homePageInfo);
    }
}