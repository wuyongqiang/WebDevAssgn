using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

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
            List<DishItem> list = PersistData.DishItemObjs.GetAllDishItem();

            Assert.AreNotEqual(list.Count, 0);

            Console.WriteLine("first dish" + list[0].Name);

            DataTable dt = RestaurantBiz.getDishItems();

            Console.WriteLine(dt.Rows.Count);

        }
    }
}
