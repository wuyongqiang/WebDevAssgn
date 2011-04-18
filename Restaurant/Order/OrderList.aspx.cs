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
        GvOrder1.Editable = false;
        if (!IsPostBack)
        {
            List<PersistData.TOrder> list = RestaurantBiz.getOrdersAndItems(DateTime.Now, DateTime.Now, Context.User.Identity.Name);
            Repeater1.DataSource = list;
            Repeater1.DataSourceID = null;
            Repeater1.DataBind();

            Panel1.Visible = false;

        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //
       //TextBox1.Text =   e.CommandSource.ToString();

       string s = ((Label)Repeater1.Items[e.Item.ItemIndex].FindControl("ORDER_IDLabel")).Text;

       long id = Convert.ToInt64(s);

       RestaurantBiz.getOrderAndItems(id, GvOrder1.TableOrder);

       GvOrder1.Update();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton1.ToolTip = "select date";
        Panel1.Visible = true;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton2.ToolTip = "select date";
        Panel1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (LinkButton1.ToolTip == "select date")
        {
            LinkButton1.ToolTip = "";
            tbBegin.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
        else
        {
            LinkButton2.ToolTip = "";
            tbEnd.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }

        Panel1.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //
        DateTime dt1 = Convert.ToDateTime("1900-01-01");
        try
        {
            dt1 = Convert.ToDateTime(tbBegin.Text);
        }catch(Exception ex)
        {
        }

        DateTime dt2 = Convert.ToDateTime("2300-01-01");
        try
        {
            dt2 = Convert.ToDateTime(tbEnd.Text).AddDays(1);
        }
        catch (Exception ex)
        {
        }
        List<PersistData.TOrder> list = RestaurantBiz.getOrdersAndItems(dt1, dt2, Context.User.Identity.Name);
        Repeater1.DataSource = list;
        Repeater1.DataSourceID = null;
        Repeater1.DataBind();
    }
}