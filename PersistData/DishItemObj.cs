using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

namespace PersistData
{
    public class DishItemObj
    {
        static protected List<DishItem> itemList = new List<DishItem>();
        static public  List<DishItem> GetAllDishItem()
        {
            itemList.Clear();

            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = session.BeginTransaction();

            IQuery query = session.CreateQuery("select c from DishItem as c where c.Id <= :MaxID");
            query.SetInt64("MaxID", 10);

            foreach (DishItem item in query.Enumerable())
            {
                itemList.Add(item);
            }

            tx.Commit();

            NHibernateHelper.CloseSession();

            return itemList;
        }
    }
}
