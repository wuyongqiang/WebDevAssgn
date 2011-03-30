using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Restaurant;

namespace NHibernateTest
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            //
            // Create an empty Profile for the newly created user
           // ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);

            ProfileCommon p = new ProfileCommon();

            p.Initialize(CreateUserWizard1.UserName, true);
           

            // Populate some Profile properties off of the create user wizard
            p.Address = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TextAddress")).Text;
            p.Phone = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TextPhone")).Text;           

            // Save the profile - must be done since we explicitly created this profile instance
            p.Save();

        }
    }
}
