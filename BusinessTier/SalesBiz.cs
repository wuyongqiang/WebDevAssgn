using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Data;
using DataAccessTier.SalesDataSetTableAdapters;


namespace RestaurantApp
{

    /**
     * This is the business tier for the SalesData
     */
    [System.ComponentModel.DataObject]
    public class SalesBiz
    {

        
        /**         
         * getOrderProcess data using an adapter class to populate the charts
         */
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Decimal getSalesData( String periodString, DateTime date )
        {

           
            SalesDataSet.SalesSelectCommandDataTable dataTable = getSalesDataTable(periodString, date);

            Decimal totalSum = 0;

            foreach (Data.SalesDataSet.SalesSelectCommandRow row in dataTable)
            {

                totalSum += row.Sum;
            }

            return totalSum;


        }


        /**
         * getOrderProcess data using an adapter class to populate the charts
         */
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        private static SalesDataSet.SalesSelectCommandDataTable getSalesDataTable( String numberOfDays, DateTime fromdate )
        {

            SalesSelectCommandTableAdapter adapter = new SalesSelectCommandTableAdapter();
            return adapter.GetSalesData(fromdate, Convert.ToInt32(numberOfDays));

        }


        /**
         * getOrderProcess data using an adapter class to populate the charts
         */
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static SalesDataSet.SalesPrDishDataTable getSalesDataPrDish(String numberOfDays, DateTime fromdate)
        {

            SalesPrDishTableAdapter adapter = new SalesPrDishTableAdapter();
            return adapter.GetSalesPrDishData(fromdate, Convert.ToInt32(numberOfDays));

        }


    }
}
