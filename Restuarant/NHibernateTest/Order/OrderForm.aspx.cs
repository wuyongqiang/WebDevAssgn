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
namespace NHibernateTest.Order
{
    public partial class OrderForm : System.Web.UI.Page
    {
        protected DataSet dsOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
           // ProfileCommon p = new ProfileCommon();

            //p.Initialize( this.Context.Profile .UserName, true);

            dsOrder = (DataSet)Session["order"];

            if (dsOrder != null)
            {
                DataList1.DataSource = dsOrder;
                DataList1.DataBind();
            }

            TextBoxAddress.Text =(string) Context.Profile.GetPropertyValue("Address");
            TextBoxPhone.Text = (string)Context.Profile.GetPropertyValue("Phone");
        }
    }
}
