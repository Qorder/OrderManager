using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerPrototype.Model
{
    public class OrderHolder
    {

        static List<Order> Orders = new List<Order>();

        static public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        static public void RemoveOrderWithID(int id)
        {
            for(int i=0;i<Orders.Count ; i++)
            {
                if (Orders[i].OrderID == id)
                {
                    Orders.RemoveAt(i);
                    Console.WriteLine("Removed: " + i);
                }
            }
        }

        static public bool IsOrderUnique(int id)
        {
                foreach(Order order in Orders)
                {
                    if (order.OrderID == id)
                        return false;
                }
                return true;
        }

        static public int OrderID(int pos)
        {
            return Orders[pos].OrderID;
        }

    }
}
