using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantApp;

public partial class Order_OrderForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtOrder = (DataTable)Session["order"];
            if (dtOrder != null)
            {
                for(int i=0;i<dtOrder.Rows.Count;i++)
                    for (int j = 0; j < dtOrder.Columns.Count; j++)
                    {
                        GvOrder1.TableOrder.Rows[i][j] = dtOrder.Rows[i][j];
                    }
            }

            

            ProfileCommon pf = new ProfileCommon();
            pf.Initialize(Context.User.Identity.Name, true);
            tbAdd.Text = pf.Address;
            tbPhone.Text = pf.Phone;
            tbName.Text = pf.Name;
                 
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //

        RestaurantApp.RestaurantBiz.saveOrder(tbName.Text, tbPhone.Text, tbAdd.Text, tbAddition.Text, GvOrder1.TableOrder);
    }
}