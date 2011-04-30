using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using PersistData;

namespace RestaurantApp
{
    public class RestaurantBiz
    {
        // "$1.23 -> 1.23"
        static string stripDL(string s)
        {
            if (s[0] > '9' || s[0] <= '0')
            {
                s = s.Substring(1);
            }
            return s;
        }

        static private List<TOrderStatus> _orderStatusList = null;

        static public List<TOrderStatus> AllOrderStatus
        {
            get{
                if (_orderStatusList == null)
                {
                    TOrderData ob = new TOrderData();
                    ob.Configure();

                     _orderStatusList = ob.GetAllOrderStatus();

                }
                return _orderStatusList;
            }
           
        }

        static public string getStatusText(int id)
        {
            foreach(TOrderStatus item in  AllOrderStatus)
            {
                if (item.Id == id) return item.Text;
            }

            return "";
        }

        static private List<TOrderType> _orderTypeList = null;

        static public List<TOrderType> AllOrderTypes
        {
            get
            {
                if (_orderTypeList == null)
                {
                    TOrderData ob = new TOrderData();
                    ob.Configure();

                    _orderTypeList = ob.GetAllOrderTypes();

                }
                return _orderTypeList;
            }

        }

        static public string getTypeText(int id)
        {
            foreach (TOrderType item in AllOrderTypes)
            {
                if (item.Id == id) return item.Text;
            }

            return "";
        }

        static public List<TOrder> getOrdersAndItems(DateTime min, DateTime max, string user)
        {
            TOrderData ob = new TOrderData();
            ob.Configure();

            List<TOrder> list = ob.GetOrdersAndAllItems(min,max,user);

            return list;
        }
        static public void getOrderAndItems(long orderId, DataTable dtOrder)
        {
            TOrderData ob = new TOrderData();
            ob.Configure();

            TOrder order = ob.GetOrderAndAllItems(orderId);

            dtOrder.Rows.Clear();
            if (order != null)
            {
                for (int i = 0; i < order.Items.Count; i++)
                {

                    TOrderItem item = (TOrderItem)order.Items[i];
                    dtOrder.Rows.Add();
                    dtOrder.Rows[i][0] = item.DishId;
                    dtOrder.Rows[i][1] = item.DishName;
                    dtOrder.Rows[i][2] = Convert.ToInt32(item.Amount);
                    dtOrder.Rows[i][3] = item.SubPrice.ToString();
                    dtOrder.Rows[i][4] = item.Price.ToString();

                }

            }
        }

        static public void saveOrder(string user_name, string name,string phone,string add,string text,long orderType,DataTable dtOrder)
        {
        
            TAppOrder order = new TAppOrder();
            order.Name = name;
            order.UserName = user_name;
            order.Address = add;
            order.Phone = phone;
            order.AddText = text;
            order.OrderTypeID = orderType;
            if (dtOrder != null)
            {
                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {
                        TAppOrderItem item = new TAppOrderItem();
                        item.DishId = (long)dtOrder.Rows[i][0];
                        item.DishName = (string)dtOrder.Rows[i][1];

                        item.Amount = Convert.ToDecimal(stripDL(dtOrder.Rows[i][2].ToString()));
                        item.SubPrice = Convert.ToDecimal(stripDL(dtOrder.Rows[i][3].ToString()));
                        item.Price = Convert.ToDecimal(stripDL(dtOrder.Rows[i][4].ToString()));
                        item.Text = "";
                        order.Items.Add(item);
                 }
                   
            }
            saveOrder(order);
        }
        static public void saveOrder(TAppOrder order)
        {
            TOrderData ob = new TOrderData();
            ob.Configure();

            TOrder od = ob.CreateOrder(order.Name, order.Address, order.Phone, order.AddText);
            
            od.UserName = order.UserName;

            foreach (TAppOrderItem item in order.Items)
            {
                TOrderItem oditem = new TOrderItem();
                oditem.Order = od;
                oditem.Price = item.Price;
                oditem.Amount = item.Amount;
                oditem.SubPrice = item.SubPrice;
                oditem.Text = item.Text;
                oditem.DishId = item.DishId;
                oditem.DishName = item.DishName;

                od.Items.Add(oditem);
            }


            od.OrderType = order.OrderTypeID;
            ob.UpdateOrder(od);
        }

        static public DataTable getDishItems()
        {
            DataTable dt = new DataTable();

            dt.TableName = "DishItem";

            dt.Columns.Add("Id", System.Type.GetType("System.Int64"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Descript", System.Type.GetType("System.String"));
            dt.Columns.Add("Price", System.Type.GetType("System.String"));

            List<DishItem> listDishItem = PersistData.DishItemObj.GetAllDishItem();

            foreach (DishItem item in listDishItem)
            {
                
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Name"] = item.Name;
                row["Descript"] = item.Desc;
                row["Price"] = item.Price.ToString("f2");
                dt.Rows.Add(row);
            }


            return dt;
        }
    }
}
