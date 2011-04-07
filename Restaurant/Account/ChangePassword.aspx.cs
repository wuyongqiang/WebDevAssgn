using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    private bool bChangePwd = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        bChangePwd = true;
        if (!IsPostBack)
        {
            ProfileCommon p = new ProfileCommon();

            p.Initialize(ChangeUserPassword.UserName, true);

            ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextAddress")).Text = p.Address;
            ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextPhone")).Text = p.Phone;

            //// Save the profile - must be done since we explicitly created this profile instance
            p.Save();
        }
        else
        {
            bChangePwd = !((CheckBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CheckBoxChangePWD")).Checked;

            ((RequiredFieldValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPasswordRequired")).Enabled = bChangePwd;

            ((RequiredFieldValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPasswordRequired")).Enabled = bChangePwd;


            ((CompareValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPasswordCompare")).Enabled = bChangePwd;

        }
    }
    protected void ChangePasswordPushButton_Command(object sender, CommandEventArgs e)
    {
        //
       
        ProfileCommon p = new ProfileCommon();

        p.Initialize(ChangeUserPassword.UserName, true);

        p.Address = ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextAddress")).Text;
        p.Phone = ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextPhone")).Text;

        //// Save the profile - must be done since we explicitly created this profile instance
        p.Save();

    }
    protected void ChangeUserPassword_ChangingPassword(object sender, LoginCancelEventArgs e)
    {
        if (!bChangePwd)
        {
            e.Cancel = true;

            ProfileCommon p = new ProfileCommon();

            p.Initialize(ChangeUserPassword.UserName, true);

            p.Address = ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextAddress")).Text;
            p.Phone = ((TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("TextPhone")).Text;

            //// Save the profile - must be done since we explicitly created this profile instance
            p.Save();

            ((Literal)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("LiteralNoPwdChange")).Text = "change address&phone successfully";
        }
    }
}
