using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections;

namespace PersistData
{
   
        public class TOrderType
        {
            private long _id;
            private string _text;
           

            public virtual long Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public virtual string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            
        }
  
}
