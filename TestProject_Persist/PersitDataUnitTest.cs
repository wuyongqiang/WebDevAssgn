using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.IO;

using PersistData;
using NHibernate;
using NHibernate.Cfg;

using NHibernate.Tool.hbm2ddl;

using RestaurantApp;
namespace TestProject_Persist
{
    [TestClass]
    public class PersitDataUnitTest
    {

        public void saveOrder()
        {
            ISessionFactory _sessions;
            Configuration cfg = new Configuration().Configure();
            _sessions = cfg.BuildSessionFactory();

            TOrderData ob = new TOrderData();
            ob.Configure();

            TOrder od = ob.CreateOrder("test","order.Address", "order.Phone", "order.AddText",1);
            //od.Id = order.Id;
            //od.Name = order.Name;
            //od.OrderTime = order.OrderTime;
            //od.Phone = order.Phone;
            //od.Address = order.Address;
            //od.AddText = order.AddText;

            using (ISession session = _sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {

                od = session.Load<TOrder>(od.Id);
               




                for (int i = 0; i < 8; i++)
                {
                    TOrderItem oditem = new TOrderItem();
                    oditem.Order = od;
                    oditem.Price = 9.99M;
                    oditem.Amount = 2;
                    oditem.SubPrice = 19.99M;
                    oditem.Text = "test" + od.Id;
                    oditem.DishId = 1;
                    oditem.DishName = "test" + i;
                    //oditem.Id = -1;

                    od.Items.Add(oditem);
                    
                }
                session.Flush();
                tx.Commit();
            }

           
        }


        public long  saveOrder1()
        {
            ISessionFactory _sessions;
            Configuration cfg = new Configuration().Configure();
            _sessions = cfg.BuildSessionFactory();

            TOrderData ob = new TOrderData();
            ob.Configure();

            TOrder od = ob.CreateOrder("test", "order.Address", "order.Phone", "order.AddText",1);
            //od.Id = order.Id;
            //od.Name = order.Name;
            //od.OrderTime = order.OrderTime;
            //od.Phone = order.Phone;
            //od.Address = order.Address;
            //od.AddText = order.AddText;

            


                for (int i = 0; i < 8; i++)
                {
                    TOrderItem oditem = new TOrderItem();
                    oditem.Order = od;
                    oditem.Price = 9.99M;
                    oditem.Amount = 2;
                    oditem.SubPrice = 19.99M;
                    oditem.Text = "testb" + od.Id;
                    oditem.DishId = 1;
                    oditem.DishName = "testb" + i;
                    od.Items.Add(oditem);

                }
                ob.UpdateOrder(od);

                return od.Id;
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<DishItem> list = PersistData.DishItemObj.GetAllDishItem();

            Assert.AreNotEqual(list.Count, 0);

            Console.WriteLine("first dish" + list[0].Name);

            DataTable dt = RestaurantApp.RestaurantBiz.getDishItems();

            Console.WriteLine(dt.Rows.Count);

            TOrderData orderData = new TOrderData();

            orderData.Configure();

            long id = saveOrder1(); 

            TOrder order= orderData.GetOrderAndAllItems(id);

            Assert.AreNotEqual(order.Items.Count,0);

            Console.WriteLine(order.OrderTime);

            List<TOrderStatus> list1 =  orderData.GetAllOrderStatus();
            Console.WriteLine("List<TOrderStatus> count is " + list1.Count);

            List<TOrderType> list2 = orderData.GetAllOrderTypes();
            Console.WriteLine("List<TOrderType> count is " + list2.Count);
            /*
            orderData.ExportTables();

            try
            {
                StreamReader rd = File.OpenText(@"c:\orderTables.txt");
                while (!rd.EndOfStream)
                {
                   Console.WriteLine( rd.ReadLine());
                }
                
            }catch(Exception ex)
            {
                Assert.Fail("open file failed");
            }*/


        }
    }
}
