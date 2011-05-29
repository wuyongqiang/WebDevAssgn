using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantApp
{
    public class TOrderBiz
    {
        public long Id{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
        public string Phone{get;set;}
        public DateTime OrderTime{get;set;}
        public string AddText{get;set;}
        public string Status{get;set;}
        public string UserName { get; set; }
        public long StatusID { get; set; }
        public long OrderTypeID { get; set; }

        public List<TOrderItemBiz> Items{get;set;}

        public TOrderBiz()
        {
            Items = new List<TOrderItemBiz>();
        }

        public string ChipIn1For5()
        {
            string result = "";
            int count = Items.Count;

            for (int i = 0; i < count; i++)
            {
                int chipIn = ((int)Items[i].Amount) / 5;
                if (chipIn > 0)
                {
                    TOrderItemBiz chipInItem = new TOrderItemBiz();
                    chipInItem.Copy(Items[i]);
                    chipInItem.Amount = chipIn;
                    chipInItem.Price = 0;
                    chipInItem.SubPrice = 0;
                    Items.Add(chipInItem);
                    result = result + chipInItem.Amount.ToString() + " free " + chipInItem.DishName + ";";
                }
            }
            return result;
        }

    }

    public class TOrderItemBiz
    {
        public long Id{get;set;}
        public long DishId{get;set;}
        public string DishName{get;set;}
        public decimal Price{get;set;}
        public decimal Amount { get; set; }
        public decimal SubPrice { get; set; }
        public string Text{get;set;}
        public TOrderBiz Order{get;set;}

        public void Copy(TOrderItemBiz item)
        {
            DishId = item.DishId;
            Id = item.Id;
            DishName = item.DishName;
            Price = item.Price;
            Amount = item.Amount;
            SubPrice = item.SubPrice;
            Text = item.Text;
            Order = item.Order;
        }
    }
}
