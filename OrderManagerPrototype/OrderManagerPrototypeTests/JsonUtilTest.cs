using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagerPrototype.Updater;
using OrderManagerPrototype.Model;

namespace OrderManagerPrototypeTests
{
    [TestClass]
    public class JsonUtilTest
    {
 
        [TestMethod]
        public void TestJsonRequestAndParsing()
        {
            //FIXME
            List<Order> orders = new List<Order>();
            List<Order> expectedOrders = new List<Order>
            {
                new Order()
            };

            orders = NetworkUtil.GetOrderList("http://83.212.118.113/mockJsons/mockCategoryJson.json");

            Assert.AreEqual(orders, expectedOrders);
        }
    }
}
