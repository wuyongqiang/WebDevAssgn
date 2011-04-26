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
        //SELECT [ORDER_ID], [NAME], [ADDRESS], [PHONE], [ADDTEXT], [ORDER_TIME],[Price],[Status] FROM [TOrder]
        static public List<TOrder> getOrdersAndItems(DateTime min, DateTime max, string user)
        {
            TOrderData ob = new TOrderData();
            ob.Configure();

            List<TOrder> list = ob.GetOrdersAndAllItems(min,max,user);

            return list;
            //dtOrder.Rows.Clear();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    TOrder order = list[i];
                    
                    //dtOrder.Rows.Add();
                    //dtOrder.Rows[i][0] = order.Id;
                    //dtOrder.Rows[i][1] = order.Name;
                    //dtOrder.Rows[i][2] = order.Address;
                    //dtOrder.Rows[i][3] = order.Phone;
                    //dtOrder.Rows[i][4] = order.Address;
                    //dtOrder.Rows[i][5] = order.OrderTime;
                    //dtOrder.Rows[i][6] = order.Price;
                    //dtOrder.Rows[i][7] = order.Status;

                }

            }
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

        static public void saveOrder(string user_name, string name,string phone,string add,string text,DataTable dtOrder)
        {
        
            TAppOrder order = new TAppOrder();
            order.Name = name;
            order.UserName = user_name;
            order.Address = add;
            order.Phone = phone;
            order.AddText = text;
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
            //od.Id = order.Id;
            //od.Name = order.Name;
            //od.OrderTime = order.OrderTime;
            //od.Phone = order.Phone;
            //od.Address = order.Address;
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

            //int i = 8;
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
