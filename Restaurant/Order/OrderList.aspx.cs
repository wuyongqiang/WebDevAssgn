using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantApp;
using PersistData;

public partial class Order_OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GvOrderDetail.Editable = false;
        if (!IsPostBack)
        {
            PanelCalendar.Visible = false;
            GvOrderDetail.TableOrder.Clear();

            tbBegin.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    protected void RepeaterOrders_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       string s = ((Label)RepeaterOrders.Items[e.Item.ItemIndex].FindControl("ORDER_IDLabel")).Text;

       long id = Convert.ToInt64(s);

       RestaurantBiz.getOrderAndItems(id, GvOrderDetail.TableOrder);

       GvOrderDetail.Update();
    }
    protected void LinkButtonBeginDate_Click(object sender, EventArgs e)
    {
        LinkButtonBeinDate.ToolTip = "select date";
        PanelCalendar.Visible = true;
    }
    protected void LinkButtonEndDate_Click(object sender, EventArgs e)
    {
        LinkButtonEndDate.ToolTip = "select date";
        PanelCalendar.Visible = true;
    }
    protected void CalendarSearchDate_SelectionChanged(object sender, EventArgs e)
    {
        if (LinkButtonBeinDate.ToolTip == "select date")
        {
            LinkButtonBeinDate.ToolTip = "";
            tbBegin.Text = CalendarSearchDate.SelectedDate.ToString("yyyy-MM-dd");
        }
        else
        {
            LinkButtonEndDate.ToolTip = "";
            tbEnd.Text = CalendarSearchDate.SelectedDate.ToString("yyyy-MM-dd");
        }

        PanelCalendar.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateTime dt1, dt2;
        try
        {
            dt1 = Convert.ToDateTime(tbBegin.Text);
            dt2 = Convert.ToDateTime(tbEnd.Text).AddDays(1);
        }
        catch
        {
            Utils.ShowMessageBox(this,"date format incorrect");
            return;
        }   

        List<PersistData.TOrder> list = RestaurantBiz.getOrdersAndItems(dt1, dt2, Context.User.Identity.Name);
        RepeaterOrders.DataSource = list;
        RepeaterOrders.DataSourceID = null;
        RepeaterOrders.DataBind();
    }

    protected string GetStatusText(object id)
    {
        return RestaurantBiz.getStatusText( Convert.ToInt16( id));
    }

    protected string GetTypeText(object id)
    {
        return RestaurantBiz.getTypeText(Convert.ToInt16(id));
    }

}