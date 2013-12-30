using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderManagerPrototype.Updater
{
    using Model;

    public class JsonUtil
    {
        static public List<Product> GetProductList(string url)
        {
            try
            {
                List<Product> products = new List<Product>();
                using (WebClient wc = new WebClient())
                {                 
                    var json = wc.DownloadString(url);
                    Product product = JsonConvert.DeserializeObject<Product>(json);
                    products.Add(product);
                }
                return products;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
