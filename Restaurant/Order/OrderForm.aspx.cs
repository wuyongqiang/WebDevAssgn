using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantApp;
using System.Text;

public partial class Order_OrderForm : System.Web.UI.Page
{

    public void ShowMessageBox(string message)
    {
        StringBuilder jsString = new StringBuilder();
        jsString.Append("<script language='javascript'>");
        jsString.AppendFormat("alert(\"{0}\");", message);
        jsString.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "JScript", jsString.ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (!Context.User.IsInRole("customer"))
            {
                ShowMessageBox("not a customer");
                LabelRslt.Text = "The user is not a customer,the order can't be submitted";
                return;
            }     
            
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

            LabelRslt.Text = "";
                 
        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //

        if (!Context.User.IsInRole("customer"))
        {
            ShowMessageBox("not a customer");
            LabelRslt.Text = "The user is not a customer,the order can't be submitted";
            return;
        }        

        RestaurantApp.RestaurantBiz.saveOrder(Context.User.Identity.Name, tbName.Text, tbPhone.Text, tbAdd.Text, tbAddition.Text, GvOrder1.TableOrder);

        LabelRslt.Text = "Order submitted successfully";
        btnSubmit.Enabled = false;
        GvOrder1.TableOrder.Clear();
        GvOrder1.Update();
    }
}