using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantApp;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = RestaurantBiz.getDishItems();
            GridView1.DataSource = dt;
            GridView1.DataSourceID = "";
            GridView1.DataBind();
            GvOrderDetail.TableOrder.Clear();
            LiteralCreateTime.Text = " page updated time:"+DateTime.Now.ToLongTimeString();
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Order")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridView customersGridView = (GridView)e.CommandSource;
            GridViewRow row = customersGridView.Rows[index];

            if ( row.FindControl("TextBox1") != null ) 
            {
                TextBox tb = (TextBox)row.FindControl("TextBox1");
                int services = 0;
                if (!int.TryParse(tb.Text, out services))
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Quantity Error');", true);
                else
                    RestaurantBiz.AddItemToOrderTable(index, services, GvOrderDetail.TableOrder);
            }
            GvOrderDetail.Update();
        }
    }

    protected void btnSumbitClick(object sender, EventArgs e)
    {
        if (GvOrderDetail.TableOrder.Rows.Count == 0)
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('your order is empty');", true);
        else
            Response.Redirect("~/Order/OrderForm.aspx");

    }
}
