using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantApp;

public partial class Order_OrderProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /**
     * Event handler for the Next button
     */
    public void GridViewCommandEventHandler(object sender, GridViewCommandEventArgs e)
    {
      

            int rowIndex = int.Parse(e.CommandArgument.ToString());

            //get cell data to compute on
            long orderId     = long.Parse(OrderProcessGridView.DataKeys[rowIndex].Values[0].ToString());
            long statusId    = long.Parse(OrderProcessGridView.DataKeys[rowIndex].Values[1].ToString());
            long orderTypeId = long.Parse(OrderProcessGridView.DataKeys[rowIndex].Values[2].ToString());


          //check if it's the Next button which was presssed
        if( e.CommandName.Equals("Advance")) {

            OrderProcessBiz.updateOrderProcessData(orderId, statusId, orderTypeId);

        //cancel button was pressed
        } else {

            OrderProcessBiz.updateOrderProcessData(orderId);

        }

        //update the gridview
        OrderProcessGridView.DataBind();

    }


}