using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_ChangePasswordSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        Literal1.Text = "";
        if (!IsPostBack)
        {
            TextUserName.Text = Context.User.Identity.Name;

            string[] sa = Roles.GetAllRoles();

            if (!Roles.RoleExists("admin"))
                Roles.CreateRole("admin");

            if (!Roles.RoleExists("customer"))
                Roles.CreateRole("customer");

            foreach (string s in sa)
            {
                cblRoles.Items.Add(new ListItem(s, s));
            }

            if (!Roles.IsUserInRole(Context.User.Identity.Name, "admin"))           
            {
                TextUserName.Enabled = false;
                btnUser.Visible = false;
                
                cblRoles.Visible = false;
    
            }
 
            GetUserInfo();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //

        if (Roles.IsUserInRole(Context.User.Identity.Name, "admin"))
        {
            if ( (Membership.FindUsersByName(TextUserName.Text) !=null) && (Membership.FindUsersByName(TextUserName.Text).Count>0) )
            {
                
            }
            else
            {
                Literal1.Text = "no such user:" + TextUserName.Text; 
            }

            ProfileCommon p = new ProfileCommon();

            p.Initialize(TextUserName.Text, true);
            p.Address = TextAddress.Text;
            p.Phone = TextPhone.Text;
            p.Name = TextName.Text;

            //// Save the profile - must be done since we explicitly created this profile instance
            p.Save();

            string[] sa = Roles.GetRolesForUser(TextUserName.Text);
            if (sa.Length>0)
                Roles.RemoveUserFromRoles(TextUserName.Text,sa);

            Array.Resize<string>(ref sa, cblRoles.Items.Count);

            int i = 0;
            foreach (ListItem item in cblRoles.Items)
            {
                if (item.Selected)
                {
                    sa[i++] = item.Text;
                }
            }
            Array.Resize<string>(ref sa, i);
            if (i>0)
            Roles.AddUserToRoles(TextUserName.Text, sa);

            GetUserInfo();

            Literal1.Text = "Detail Information Saved Successfully!";

        }
        else
        {

            ProfileCommon p = new ProfileCommon();

            p.Initialize(Context.User.Identity.Name, true);
            p.Address = TextName.Text;
            p.Phone = TextPhone.Text;
            p.Name = TextName.Text;

            //// Save the profile - must be done since we explicitly created this profile instance
            p.Save();

            Literal1.Text = "Detail Information Saved Successfully!";
        }
    }

    //
    protected void GetUserInfo()
    {
        ProfileCommon pf = new ProfileCommon();
        pf.Initialize(TextUserName.Text, true);
        this.TextName.Text = pf.Name;
        this.TextAddress.Text = pf.Address;
        this.TextPhone.Text = pf.Phone;

        Literal2.Text = "";
        foreach (ListItem item in cblRoles.Items)
        {
            item.Selected = false;
        }

        string[] sa = Roles.GetRolesForUser(TextUserName.Text);
        foreach (string s in sa)
        {
            int idx = 1;
            ListItem item = cblRoles.Items.FindByText(s);
            if (item != null)
            {
                idx = cblRoles.Items.IndexOf(item);
                cblRoles.Items[idx].Selected = true;
                Literal2.Text += s+";";
            }
        }
    }
    
    protected void btnUser_Click(object sender, EventArgs e)
    {
        if ((Membership.FindUsersByName(TextUserName.Text) != null) && (Membership.FindUsersByName(TextUserName.Text).Count > 0))
        {
            GetUserInfo();
            Literal1.Text = "get user information successfully";
        }
        else
        {
            Literal1.Text = "no such user:" + TextUserName.Text;
        }

    }
}
