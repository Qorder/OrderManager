using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace OrderManagerPrototype.Updater
{
    using Model;
    
    public class NetworkUtil
    {
        #region Static Helper Methods

        public static JObject GetJson(string url)
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

        public static void NotifyWebService(int id,string status, string uript1 = "http://snf-185147.vm.okeanos.grnet.gr:8080/qorderws/orders/order/", string uript2 = "/order?status=")
        {
            using (var wb = new WebClient())
            {
                Console.WriteLine("Notified " + id);
                Byte[] bytes = new byte[] { 0x20 };
                Thread notifierThread = new Thread(
                o =>
                {
                    try
                    {
                        var response = wb.UploadData(uript1 + id + uript2 + status, "POST", bytes);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                notifierThread.IsBackground = true;
                notifierThread.Start();
            }
        }

        

        public static List<Order> GetOrderList(string url)
        {

            List<Order> completeOrder = new List<Order>();

            try
            {
                JObject json = NetworkUtil.GetJson(url);
                JArray orderArray = (JArray)json["orders"];

                foreach (JObject orderArrayItem in orderArray)
                {
                    Order orderitem = new Order();
                    List<Product> productList = new List<Product>();
                    orderitem.OrderID = (int)orderArrayItem["id"];

                    if(!OrderHolder.IsOrderUnique(orderitem.OrderID))
                    {
                        Console.WriteLine("Dropped " + orderitem.OrderID);
                        continue;
                    }

                    orderitem.TableNumber = (string)orderArrayItem["tableNumber"];
                    orderitem.DateTime = (string)orderArrayItem["dateTime"];
                    orderitem.TotalPrice = (double)orderArrayItem["totalPrice"];
                    JArray orders = (JArray)orderArrayItem["orderedProducts"];

                    foreach (JObject order in orders)
                    {

                        Product product = new Product();
                        JObject orderDTO = (JObject)order["productDTO"];
                        product.Name = (string)orderDTO["name"];
                        product.Price = (double)orderDTO["price"];
                        product.Attributes = (string)order["attributes"];
                        product.Quantity = (int)order["quantity"];
                        product.Notes = (string)order["notes"];
                        productList.Add(product);

                    }
                    orderitem.Products = productList;
                    OrderHolder.AddOrder(orderitem);
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
