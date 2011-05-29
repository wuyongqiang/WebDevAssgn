using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.IsInRole("Sales"))
        {
            NavigationMenu.FindItem("Sales").Enabled = true;
        }
        else
        {
            NavigationMenu.FindItem("Sales").Enabled = false;
        }

    }
}
