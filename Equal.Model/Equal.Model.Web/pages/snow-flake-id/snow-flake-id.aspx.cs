using System;
using System.Web.UI;

using Equal.Utility;

public partial class pages_snow_flake_id_snow_flake_id : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetInfo();
    }

    public void GetInfo()
    {
        for (int i = 0; i < 100; i++)
        {
            lblText.Text += SnowFlake.GetNewId() + "<br/>";
        }
    }
}