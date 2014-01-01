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
   
        public Order(int orderID,string tableNumber,string dateTime,List<Product> products)
        {
           Products = new List<Product>();
            this.TableNumber = tableNumber;
            this.DateTime = dateTime;
            this.Products = products;
            this.OrderID = orderID;
        }

        #region Properties

        public int OrderID
        {
            get;
            set;
        }

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

        public double TotalPrice
        {
            get
            {
                double price =0;
                foreach (Product product in Products)
                    price += product.Price;

                return price;
            }
            
        }

        public List<Product> Products
        {
            get;
            set;
        }

        #endregion
    }
}
