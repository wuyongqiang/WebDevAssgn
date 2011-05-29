using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantApp;

public partial class Sales_Sales : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //Set the initial radio-button index
            SalesPeriodRadioButtonList.SelectedIndex = 0;
            HandleSalesPageRadioButtonEvent(sender, e);

        } 

   
    }

    protected void HandleSalesPageRadioButtonEvent(object sender, EventArgs e)
    {

     
        if (SalesPeriodRadioButtonList.SelectedValue.Equals("CustomDate"))
        {
            SalesCalendar.Visible = true;
            lblSalesFromDate.Visible = true;
            return;
        }
        else
        {

            SalesCalendar.Visible = false;
            lblSalesFromDate.Visible = false;

            lblTotalSalesTxt.Text = "Sales pr " + SalesPeriodRadioButtonList.SelectedItem + ": $";



            //call with 0L cannot be null
            callBusinessTier( SalesPeriodRadioButtonList.SelectedValue, new DateTime(2000,1,1) );

        }


     

    }


    protected void HandleSalesPageCalendarEvent(object sender, EventArgs e)
    {

        lblTotalSalesTxt.Text = "Sales since " + SalesCalendar.SelectedDate.Date.ToShortDateString() + ": $";
        callBusinessTier( null, SalesCalendar.SelectedDate );

    }


    private void callBusinessTier(string selectedRadioValue, DateTime fromDate )
    {

        lblTotalSales.Text = SalesBiz.getSalesData(selectedRadioValue, fromDate).ToString();
        SalesChart.DataSource = SalesBiz.getSalesDataPrDish(selectedRadioValue, fromDate);
        
        //rebind the new dataset
        SalesChart.DataBind();

    }
}