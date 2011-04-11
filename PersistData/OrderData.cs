using System;
using System.Collections;

using NHibernate;
using NHibernate.Cfg;
using PersistData;

using NHibernate.Tool.hbm2ddl;

namespace PersistData
{
    public class TOrderData
    {
        private ISessionFactory _sessions;

        public void Configure()
        {
            //_sessions = new Configuration()
            //    .AddClass(typeof(TOrder))
            //    .AddClass(typeof(TOrderItem))
            //    .BuildSessionFactory();
            Configuration cfg = new Configuration().Configure();
            _sessions =  cfg.BuildSessionFactory();
        }

        public void ExportTables()
        {
            //Configuration cfg = new Configuration()
            //    .AddClass(typeof(TOrder))
            //    .AddClass(typeof(TOrderItem));
            Configuration cfg = new Configuration().Configure();

            SchemaExport myschema = new SchemaExport(cfg);
            myschema.SetOutputFile(@"c:\OrderTables.txt");
            myschema.Create(true, false);
        }

        public TOrder CreateOrder(string name)
        {
            TOrder order = new TOrder();
            order.Name = name;
            order.Items = new ArrayList();

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Save(order);
                tx.Commit();
            }

            return order;
        }

        public void UpdateOrder(TOrder order)
        {
            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Update(order);
                tx.Commit();
            }
        }

        public TOrderItem CreateOrderItem(TOrder order, long dishId, string dishName,
            double price, double amount, double subPrice, string text)
        {
            TOrderItem item = new TOrderItem();
            item.DishId = dishId;
            item.DishName = dishName;
            item.Price = price;
            item.Amount = amount;
            item.SubPrice = subPrice;
            item.Text = text;

            order.Items.Add(item);

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Update(order);
                tx.Commit();
            }

            return item;
        }

        public TOrderItem CreateOrderItem(long orderId, long dishId,string dishName,
            double price, double amount,double subPrice, string text)
        {
            TOrderItem item = new TOrderItem();
            item.DishId = dishId;
            item.DishName = dishName;
            item.Price = price;
            item.Amount = amount;
            item.SubPrice = subPrice;
            item.Text = text;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                TOrder order = (TOrder)session.Load(typeof(TOrder), orderId);
                item.Order = order;
                order.Items.Add(item);
                tx.Commit();
            }

            return item;
        }

        public void UpdateOrderItem(TOrderItem item, long dishId, string dishName,
            double price, double amount, double subPrice, string text)
        {
            item.DishId = dishId;
            item.DishName = dishName;
            item.Price = price;
            item.Amount = amount;
            item.SubPrice = subPrice;
            item.Text = text;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Update(item);
                tx.Commit();
            }
        }

        public void UpdateOrderItem(long itemId, long dishId, string dishName,
            double price, double amount, double subPrice, string text)
        {
            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                TOrderItem item = (TOrderItem)session.Load(typeof(TOrderItem), itemId);
                item.DishId = dishId;
                item.DishName = dishName;
                item.Price = price;
                item.Amount = amount;
                item.SubPrice = subPrice;
                item.Text = text;
                tx.Commit();
            }
        }

        public IList listAllOrderAndItemCounts(int max)
        {
            IList result = null;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                IQuery q = session.CreateQuery(
                    "select order.id, order.Name, count(orderItem) " +
                    "from TOrder as order " +
                    "left outer join order.Items as orderItem " +
                    "group by order.Name, order.id " +
                    "order by max(orderItem.DateTime)"
                );
                q.SetMaxResults(max);
                result = q.List();
                tx.Commit();
            }

            return result;
        }

        public TOrder GetOrderAndAllItems(long orderId)
        {
            TOrder order = null;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                IQuery q = session.CreateQuery(
                    "from TOrder as order " +
                    "left outer join fetch order.Items " +
                    "where order.id = :orderId"
                );
                q.SetParameter("orderId", orderId);
                order = (TOrder)q.List()[0];
                tx.Commit();
            }

            return order;
        }

        public TOrder GetOrderAndAllItems(string Name)
        {
            TOrder order = null;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                IQuery q = session.CreateQuery(
                    "from TOrder as order " +
                    "left outer join fetch order.Items " +
                    "where order.Name = :orderName"
                );
                q.SetParameter("orderName", Name);
                order = (TOrder)q.List()[0];
                tx.Commit();
            }

            return order;
        }

        public IList ListOrdersAndItems(DateTime minDate, DateTime maxDate)
        {
            IList result = null;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                IQuery q = session.CreateQuery(
                    "from TOrder as order " +
                    "inner join order.Items as orderItem " +
                    "where order.DateTime > :minDate and order.DateTime < :maxDate"
                );

                DateTime date = DateTime.Now.AddMonths(-1);
                q.SetDateTime("minDate", minDate);
                q.SetDateTime("maxDate", maxDate);

                result = q.List();
                tx.Commit();
            }

            return result;
        }


    }
}
