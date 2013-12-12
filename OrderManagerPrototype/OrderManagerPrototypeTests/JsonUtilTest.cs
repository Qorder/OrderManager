using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagerPrototype.Updater;

namespace OrderManagerPrototypeTests
{
    [TestClass]
    public class JsonUtilTest
    {
        [TestMethod]
        public void TestJsonRequestAndParsing()
        {
            List<Product> products = new List<Product>();
            List<Product> expectedProducts = new List<Product>
            {
                new Product( "mockName", 1, "mockUri" )
            };

            products = JsonUtil.GetProductList("http://83.212.118.113/mockJsons/mockCategoryJson.json");

            Assert.AreEqual(products[0], expectedProducts[0]);
        }
    }
}
