using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

        if (!IsPostBack)
        {
            string[] sa = Roles.GetAllRoles();

            if (!Roles.RoleExists("admin"))
                Roles.CreateRole("admin");

            if (!Roles.RoleExists("customer"))
                Roles.CreateRole("customer");

           
            foreach (string s in sa)
            {
                ((DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("ddlRoles")).Items.Add(new ListItem(s,s));
            }

            if (!Context.User.IsInRole("admin"))
            {
                ((DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("ddlRoles")).SelectedIndex = 1;
                ((DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("ddlRoles")).Enabled = false;
            }    
            
        }
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        ProfileCommon p = new ProfileCommon();

        p.Initialize(RegisterUser.UserName, true);

        p.Address = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("TextAddress")).Text;
        p.Name = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("TextName")).Text;
        p.Phone = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("TextPhone")).Text;

        //// Save the profile - must be done since we explicitly created this profile instance
        p.Save();

        FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

        if (RegisterUser.UserName == "admin")
        {
            Roles.AddUserToRole(RegisterUser.UserName, "admin");
        }
        else
        {
            Roles.AddUserToRole(RegisterUser.UserName, "customer");
        }

        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/FirstPage.aspx";
        }
        Response.Redirect(continueUrl);
    }

}
