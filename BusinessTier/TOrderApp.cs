using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantApp
{
    public class TAppOrder
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

        public List<TAppOrderItem> Items{get;set;}

        public TAppOrder()
        {
            Items = new List<TAppOrderItem>();
        }


        public void ChipIn1For5()
        {
            int count = Items.Count;

            for (int i = 0; i < count; i++)
            {
                int chipIn = ((int)Items[i].Amount) / 5;
                if (chipIn > 0)
                {
                    TAppOrderItem chipInItem = new TAppOrderItem();
                    chipInItem.Copy(Items[i]);
                    chipInItem.Amount = chipIn;
                    chipInItem.Price = 0;                    
                    Items.Add(chipInItem);
                }
            }
        }
    }

    public class TAppOrderItem
    {
        public long Id{get;set;}
        public long DishId{get;set;}
        public string DishName{get;set;}
        public decimal Price{get;set;}
        public decimal Amount { get; set; }
        public string SubPrice { 
            get
            {   
                return (Amount * Price).ToString("F2"); }
        }
        public string Text{get;set;}
        public TAppOrder Order{get;set;}

        public void Copy(TAppOrderItem item)
        {
            DishId = item.DishId;
            Id = item.Id;
            DishName = item.DishName;
            Price = item.Price;
            Amount = item.Amount;           
            Text = item.Text;
            Order = item.Order;
        }
    }
}
