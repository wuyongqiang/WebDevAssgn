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
    //protected DataSet dsOrder = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //dsOrder = new DataSet();
        if (!IsPostBack)
        {
            DataTable dt = RestaurantBiz.getDishItems();
            GridView1.DataSource = dt;
            GridView1.DataSourceID = "";
            GridView1.DataBind();
        }
    }

    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Order")
        //{
        //    // property to an Integer.
        //    int index = Convert.ToInt32(e.CommandArgument);

        //    // Retrieve the row that contains the button clicked
        //    // by the user from the Rows collection. Use the
        //    // CommandSource property to access the GridView control.
        //    GridView customersGridView = (GridView)e.CommandSource;
        //    GridViewRow row = customersGridView.Rows[index];

        //    DataRow rOrder = dsOrder.Tables[0].Rows.Add();

        //    rOrder["Id"] = Convert.ToInt64(row.Cells[0].Text);
        //    rOrder["Name"] = row.Cells[1].Text;
        //    rOrder["Quantity"] = 1;
        //    rOrder["Price"] = row.Cells[3].Text;

        //    // Create a new ListItem object for the customer in the row.


        //    if ((row.FindControl("TextBox1") != null) && row.FindControl("TextBox1").GetType().ToString().Contains("TextBox"))
        //    {
        //        TextBox tb = (TextBox)row.FindControl("TextBox1");
        //        try
        //        {
        //            int quant = Convert.ToInt16(tb.Text);

        //            rOrder["Quantity"] = quant;
        //            rOrder["Price"] = (Convert.ToDouble(row.Cells[3].Text) * quant).ToString("C");
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }

        //    GridView2.DataBind();

        }
}
