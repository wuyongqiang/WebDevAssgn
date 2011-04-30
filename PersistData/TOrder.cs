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
using System.Collections;

namespace PersistData
{
   
        public class TOrder
        {
            private long _id;
            private string _name;
            private string _address;
            private string _phone;
            private DateTime _orderTime;
            private string _addText;
            private long _status;
            private long _orderType;
            private string _userName;

            private IList _items;

            public virtual long Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public virtual string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public virtual string Address
            {
                get { return _address; }
                set { _address = value; }
            }

            public virtual string Phone
            {
                get { return _phone; }
                set { _phone = value; }
            }

            public virtual string AddText
            {
                get { return _addText; }
                set { _addText = value; }
            }

            

            public virtual DateTime OrderTime
            {
                get { return _orderTime; }
                set { _orderTime = value; }
            }

            public virtual long Status
            {
                get { return _status; }
                set { _status = value; }
            }

            public virtual long OrderType
            {
                get { return _orderType; }
                set { _orderType = value; }
            }
            
            public virtual string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            public virtual IList Items
            {
                get { return _items; }
                set { _items = value; }
            }

            public virtual decimal Price
            {
                get
                {
                    decimal price = 0;

                    foreach (TOrderItem item in _items)
                    {
                        price += item.SubPrice;
                    }
                    return price;
                }
            }
        }
  
}
