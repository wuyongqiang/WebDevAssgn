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
        static public DataTable getDishItems()
        {
            DataTable dt = new DataTable();

            dt.TableName = "DishItem";

            dt.Columns.Add("Id", System.Type.GetType("System.Int64"));
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Descript", System.Type.GetType("System.String"));
            dt.Columns.Add("Price", System.Type.GetType("System.String"));

            List<DishItem> listDishItem = PersistData.DishItemObjs.GetAllDishItem();

            int i = 8;
            foreach (DishItem item in listDishItem)
            {
                
                DataRow row = dt.NewRow();
                row["Id"] = i++;// item.Id;
                row["Name"] = item.Name;
                row["Descript"] = item.Desc;
                row["Price"] = item.Price.ToString("f2");
                dt.Rows.Add(row);
            }


            return dt;
        }
    }
}
