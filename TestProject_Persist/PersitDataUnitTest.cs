using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.IO;

using PersistData;

using RestaurantApp;
namespace TestProject_Persist
{
    [TestClass]
    public class PersitDataUnitTest
    {
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
            }


        }
    }
}
