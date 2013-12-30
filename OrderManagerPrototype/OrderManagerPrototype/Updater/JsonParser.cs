using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderManagerPrototype.Updater
{
    using Model;

    public class JsonParser
    {
        #region Static Properties

        static public string JArrayName
        {
            get;
            set;
        }

        #endregion

        #region Static Helper Methods

        //TODO: implement a custom parser (if needed)
        public static List<Product> GetProductList(JObject json)
        {
            return null;
        }

        #endregion
    }
}
