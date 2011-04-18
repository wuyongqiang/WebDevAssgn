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
            
        }
        else
        {
            ((RequiredFieldValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPasswordRequired")).Enabled = bChangePwd;
            ((RequiredFieldValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPasswordRequired")).Enabled = bChangePwd;
            ((CompareValidator)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPasswordCompare")).Enabled = bChangePwd;
        }
    }
    protected void ChangePasswordPushButton_Command(object sender, CommandEventArgs e)
    {
        //

    }
    protected void ChangeUserPassword_ChangingPassword(object sender, LoginCancelEventArgs e)
    {
        
    }
}
