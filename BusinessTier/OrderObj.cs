using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantApp;

namespace RestaurantApp
{
    [System.ComponentModel.DataObject]
    public class OrderObj
    {
        //List<City>

        
        public static Dictionary<int, List<TAppOrderItem>> ItemListDict;
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]

        static public List<TAppOrderItem> getOrderItems(int sessionid)
        {
            List<TAppOrderItem> rlt = null;
            if (ItemListDict == null)
            {
                ItemListDict = new Dictionary<int, List<TAppOrderItem>>();
            }
            if (ItemListDict.ContainsKey(sessionid))
            {
                rlt = ItemListDict[sessionid];
            }
            else
            {
                rlt = new List<TAppOrderItem>();
                ItemListDict[sessionid] = rlt;
            }
            
            return rlt;
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        static public void updateDataItem(TAppOrderItem item)
        {
            int sessionid = 10;
            if (ItemListDict.ContainsKey(sessionid))
            {
                List<TAppOrderItem> list = ItemListDict[sessionid];
                if (list != null)
                {
                    foreach (TAppOrderItem oneitem in list)
                    {
                        if (item.DishId == oneitem.DishId)
                        {
                            oneitem.Copy(item);
                        }
                    }
                }
            }
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        static public void deleteOrderItem(TAppOrderItem item)
        {
            ;
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        static public void insertOrderItem(int sessionid, TAppOrderItem item)
        {
            if (ItemListDict.ContainsKey(sessionid))
            {
                List<TAppOrderItem> list = ItemListDict[sessionid];
                if (list == null)
                {
                    list = new List<TAppOrderItem>();
                    ItemListDict[sessionid] = list;
                }
                if (list != null)
                {
                    list.Add(item);
                }
            }
        }


    }
}
