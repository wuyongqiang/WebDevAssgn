using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePasswordSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        Literal1.Text = "";
        if (!IsPostBack)
        {
            ProfileCommon pf = new ProfileCommon();
            pf.Initialize(Context.User.Identity.Name, true);
            this.TextName.Text = pf.Name;
            this.TextAddress.Text = pf.Address;
            this.TextPhone.Text = pf.Phone;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //
        ProfileCommon p = new ProfileCommon();

        p.Initialize(Context.User.Identity.Name, true);
        p.Address = TextName.Text;
        p.Phone = TextPhone.Text;
        p.Name = TextName.Text ;

        //// Save the profile - must be done since we explicitly created this profile instance
        p.Save();

        Literal1.Text = "Detail Information Saved Successfully!";
    }
}
