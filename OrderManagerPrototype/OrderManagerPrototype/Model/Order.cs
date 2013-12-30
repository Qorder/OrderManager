using System;
using System.Collections.Generic;

namespace OrderManagerPrototype.Model
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }
   
        public Order(string tableNumber,string dateTime,List<Product> products)
        {
           Products = new List<Product>();
            this.TableNumber = tableNumber;
            this.DateTime = dateTime;
            this.Products = products;
        }

        #region Properties

        public string TableNumber
        {
            get;
            set;
        }

        public string DateTime
        {
            get;
            set;
        }

        public List<Product> Products
        {
            get;
            set;
        }

        #endregion
    }
}
