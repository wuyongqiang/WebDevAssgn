using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        if (!IsPostBack)
        {
            //
            Session["SessionID"] = 10;
        }
       
    }



    protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows == 0)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //insert one item into the order

        // <asp:Parameter Name="sessionid" Type="Int32" />
        //        <asp:Parameter Name="item" Type="Object" />


        RestaurantApp.TAppOrderItem item = new RestaurantApp.TAppOrderItem();
        item.DishName = " fried rice";
        RestaurantApp.OrderObj.insertOrderItem((int)Session["SessionID"], item);

     

        form1.DataBind();
    }
    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        //
        int i = e.NewValues.Count;
    }
    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //

        int i = e.InputParameters.Count;



        Object ob = e.InputParameters.Values;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
    }
}