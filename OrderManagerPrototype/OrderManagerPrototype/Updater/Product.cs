using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderManagerPrototype.Updater
{
    public class Product
    {

        double price;

        #region Public Constructors

        public Product(string name,double price,string notes)
        {
            this.Name = name;
            this.Price = price;
            this.Notes = notes;
        }

        public Product()
        {
            this.Name = null;
            this.Notes = null;
            this.Price=0;
        }

        #endregion

        #region Public Properties

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public double Price
        {
            get
            {
                return Math.Round(price, 2);
            }
            set
            {
                price = value;
            }
        }

        [JsonProperty("uri")]
        public string Notes
        {
            get;
            set;
        }

        #endregion

        #region Override Equality

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Product p = obj as Product;
            if ((Object)p == null)
            {
                return false;
            }

            return ((this.Name == p.Name) && (this.Price == p.Price) && (this.Notes == p.Notes));
        }

        #endregion
    }
}
