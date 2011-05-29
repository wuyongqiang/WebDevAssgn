using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PersistData;
using RestaurantApp;
using System.Text;

public partial class Order_OrderForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            btnSubmit.OnClientClick = "return confirm('Do you really want to submit this order?');";
            if (!Context.User.IsInRole("customer"))
            {
                Utils.ShowMessageBox(this, "not a customer,the order can't be submitted");
                LabelRslt.Text = "The user is not a customer,the order can't be submitted";
            }     
            
            DataTable dtOrder = (DataTable)Session["order"];
            if (dtOrder != null)
            {
                for (int i = 0; i < dtOrder.Rows.Count; i++)
                    for (int j = 0; j < dtOrder.Columns.Count; j++)
                    {
                        GvOrderDetail.TableOrder.Rows[i][j] = dtOrder.Rows[i][j];
                    }
            }

            // get the order types data
            foreach (TOrderType item in RestaurantBiz.AllOrderTypes)
            {
                ddlOrderType.Items.Add(new ListItem(item.Text, item.Id.ToString()));
            }
            //select the first as default
            ddlOrderType.Items[0].Selected = true;

            ProfileCommon pf = new ProfileCommon();
            pf.Initialize(Context.User.Identity.Name, true);
            tbAdd.Text = pf.Address;
            tbPhone.Text = pf.Phone;
            tbName.Text = pf.Name;

            LabelRslt.Text = "";
                 
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!Context.User.IsInRole("customer"))
        {
            Utils.ShowMessageBox(this, "not a customer,the order can't be submitted");
            LabelRslt.Text = "The user is not a customer,the order can't be submitted";
            return;
        }
        if (GvOrderDetail.TableOrder.Rows.Count == 0)
        {
            Utils.ShowMessageBox(this, "empty order");
            return;
        }
        string promo = "";
        long orderId = RestaurantApp.RestaurantBiz.saveOrder(ref promo, Context.User.Identity.Name, tbName.Text, tbPhone.Text, tbAdd.Text, tbAddition.Text, Convert.ToInt64( ddlOrderType.SelectedValue), GvOrderDetail.TableOrder);

        LabelRslt.Text = "Order submitted successfully";
        if (!promo.Equals(""))
            LabelRslt.Text += " "+ promo;
        btnSubmit.Enabled = false;
        GvOrderDetail.TableOrder.Clear();
        GvOrderDetail.Update();
        GvOrderDetail.Visible = false;
        LinkButtonMyOrders.Visible = true;

        Utils.ShowMessageBox(this, "Order submitted successfully.\\n" + promo + " \\nYou can click menu [my orders] to check status");
    }
    protected void LinkButtonMyOrders_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Order/OrderList.aspx");
    }
    
}