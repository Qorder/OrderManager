using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderManagerPrototype.Updater
{
    using Model;
    
    public class JsonUtil
    {
        #region Static Helper Methods

        static public JObject GetJson(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var response = wc.DownloadString(url);
                    JObject json = JObject.Parse(response);
                    return (json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while getting json" + ex.Message);
                return null;
            }
        }

        public static List<Order> GetOrderList(string url)
        {

            List<Order> completeOrder = new List<Order>();

            try
            {
                JObject json = JsonUtil.GetJson(url);
                JArray orderArray = (JArray)json["orders"];

                foreach (JObject orderArrayItem in orderArray)
                {
                    Order orderitem = new Order();
                    List<Product> productList = new List<Product>();
   
                    orderitem.TableNumber = (string)orderArrayItem["tableNumber"];
                    orderitem.DateTime = (string)orderArrayItem["dateTime"];
                    JArray orders = (JArray)orderArrayItem["orderedProducts"];

                    foreach (JObject order in orders)
                    {

                        Product product = new Product();
                        JObject orderDTO = (JObject)order["productDTO"];
                        product.Name = (string)orderDTO["name"];
                        product.Price = (double)orderDTO["price"];

                        product.Notes = (string)order["notes"];
                        productList.Add(product);

                    }
                    orderitem.Products = productList;
                    completeOrder.Add(orderitem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while parsing json" + ex.Message);
                return null;
            }
            return completeOrder;
        }

        #endregion
    }
}
