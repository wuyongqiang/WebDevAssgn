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

        
        public static Dictionary<int, List<TOrderItemBiz>> ItemListDict;
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]

        static public List<TOrderItemBiz> getOrderItems(int sessionid)
        {
            List<TOrderItemBiz> rlt = null;
            if (ItemListDict == null)
            {
                ItemListDict = new Dictionary<int, List<TOrderItemBiz>>();
            }
            if (ItemListDict.ContainsKey(sessionid))
            {
                rlt = ItemListDict[sessionid];
            }
            else
            {
                rlt = new List<TOrderItemBiz>();
                ItemListDict[sessionid] = rlt;
            }
            
            return rlt;
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        static public void updateDataItem(TOrderItemBiz item)
        {
            int sessionid = 10;
            if (ItemListDict.ContainsKey(sessionid))
            {
                List<TOrderItemBiz> list = ItemListDict[sessionid];
                if (list != null)
                {
                    foreach (TOrderItemBiz oneitem in list)
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
        static public void deleteOrderItem(TOrderItemBiz item)
        {
            ;
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        static public void insertOrderItem(int sessionid, TOrderItemBiz item)
        {
            if (ItemListDict.ContainsKey(sessionid))
            {
                List<TOrderItemBiz> list = ItemListDict[sessionid];
                if (list == null)
                {
                    list = new List<TOrderItemBiz>();
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
