using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace PersistData
{
    public class TOrderItem
        {
            private long _id;
            private long _dishId;
            private string _dishName;
            private decimal _price;
            private decimal _amount;
            private decimal _subPrice;
            private string _text;
            private TOrder _order;

            public virtual TOrder Order
            {
                get { return _order; }
                set { _order = value; }
            }


            public virtual long Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public virtual long DishId
            {
                get { return _dishId; }
                set { _dishId = value; }
            }

            public virtual string DishName
            {
                get { return _dishName; }
                set { _dishName = value; }
            }

            public virtual decimal Price
            {
                get { return _price; }
                set { _price = value; }
            }

            public virtual decimal Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

            public virtual decimal SubPrice
            {
                get { return _subPrice; }
                set { _subPrice = value; }
            }

            public virtual string Text
            {
                get { return _text; }
                set { _text = value; }
            }
           
        }

}
