using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Data;
using DataAccessTier;
using DataAccessTier.OrderProcessDataSetTableAdapters;
using DataAccessTier.CustomerEmailDataSetTableAdapters;


namespace RestaurantApp
{
   
    //Enums to strongly type the process steps
    enum OrderStatus : long { Unprocessed=1, Confirmed=2, Making=3, ReadyForPickup=4, ReadyForDelivery=5, InDelivery=6, Delivered=7, Cancelled=8};
    enum OrderType   : long { PickUp = 1, Delivery = 2 };


/**
 * This is the business tier for the OrderProcess - this handles the data gettng and the process from unconfirmed to delivered status
 */
    [System.ComponentModel.DataObject]
    public class OrderProcessBiz
    {
        
        /**
         * getOrderProcess data using an adapter class to populate the GridView 
         */
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static OrderProcessDataSet.OrderProcessSelectCommandDataTable getOrderProcessData()
        {

            OrderProcessSelectCommandTableAdapter adapter = new OrderProcessSelectCommandTableAdapter();

            DateTime now = DateTime.Today;
            OrderProcessDataSet.OrderProcessSelectCommandDataTable table = adapter.GetOrderProcessDataUsingFromdate(now);

            return table;

        }
        
        
        /**
         * The method updates the adapter with the new correct status
         */
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void updateOrderProcessData(long orderId, long statusId, long orderTypeId )
        {
            
            OrderProcessSelectCommandTableAdapter adapter = new OrderProcessSelectCommandTableAdapter();
            OrderProcessDataSet.OrderProcessSelectCommandDataTable table = adapter.GetOrderProcessDataUsingFromdate(DateTime.Today);
           
            long newOrderStatus = nextProcessStep(orderTypeId, statusId, orderTypeId);
            adapter.UpdateOrderProcessQuery(newOrderStatus, orderId);

        }
    
        /**
         * The method updates the orderid to cancelled
         */
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void updateOrderProcessData(long orderId )
        {


            OrderProcessSelectCommandTableAdapter adapter = new OrderProcessSelectCommandTableAdapter();
            //OrderProcessDataSet.OrderProcessSelectCommandDataTable orderTable = adapter.GetData();

            adapter.UpdateOrderProcessQuery( (long)OrderStatus.Cancelled, orderId) ;
            notifyCustomer(orderId);

        }

        private static void notifyCustomer(long orderId ) {

            //Get the email from the db
            EmailSelectCommandTableAdapter emailAdapter = new EmailSelectCommandTableAdapter();
            CustomerEmailDataSet.EmailSelectCommandDataTable emailTable = emailAdapter.GetEmailAddress(orderId);

            String name = "";
            String email = "";
            DateTime orderTime = DateTime.Now;

            foreach (CustomerEmailDataSet.EmailSelectCommandRow row in emailTable)
            {

                name = row.Name;
                email = row.Email;
                orderTime = row.ORDER_TIME;

            }

            string subject = "Asian Fast Food unable to process your order";
            string message = "Dear " + name + ", we regret that we are unable to processs your order id: " +
                             orderId + " at " + orderTime.ToString() + Environment.NewLine +
                             "We sincerely hope that you will order again with us." + Environment.NewLine +
                             "Kind regards" + Environment.NewLine + "Asian Fast Food";

            MailBiz.sendmail( email, message, subject );
        }


        /**
         * nextProcessStep selects the next step in the process status
         */
        private static long nextProcessStep(long orderId, long statusId, long orderTypeId )
        {

            OrderStatus status = (OrderStatus)statusId;

            switch ( status )
            {
                case OrderStatus.Unprocessed :
                
                    return (long)OrderStatus.Confirmed;

                case OrderStatus.Confirmed :
                    
                    return (long)OrderStatus.Making;

                case OrderStatus.Making:
                    
                    //Need to cope with pickup and delivery orders
                    return orderTypeId == (long)OrderType.PickUp ? (long)OrderStatus.ReadyForPickup : (long)OrderStatus.ReadyForDelivery; 
                
                case OrderStatus.ReadyForPickup :
                
                    return (long)OrderStatus.Delivered;
                
                case OrderStatus.ReadyForDelivery:
                    
                    return (long)OrderStatus.InDelivery;
                
                case OrderStatus.InDelivery:
                    
                    return (long)OrderStatus.Delivered;
                
                default:
                    return (long)OrderStatus.Delivered;

            }

     

        }

    }
}
