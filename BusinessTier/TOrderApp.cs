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

        public List<TAppOrderItem> Items{get;set;}

        public TAppOrder()
        {
            Items = new List<TAppOrderItem>();
        }

    }

    public class TAppOrderItem
    {
        public long Id{get;set;}
        public long DishId{get;set;}
        public string DishName{get;set;}
        public decimal Price{get;set;}
        public decimal Amount { get; set; }
        public decimal SubPrice { get; set; }
        public string Text{get;set;}
        public TAppOrder Order{get;set;}

        public void Copy(TAppOrderItem item)
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
