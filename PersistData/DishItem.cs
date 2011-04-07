using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistData
{
    public class DishItem
    {
        private Int64 id;
        private string name;
        private string description;
        private float price;

        public DishItem()
        {
        }

        public virtual Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Desc
        {
            get { return description; }
            set { description = value; }
        }

        public virtual float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
