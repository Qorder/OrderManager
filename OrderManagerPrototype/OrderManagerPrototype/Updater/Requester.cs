using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OrderManagerPrototype.Updater
{
    using Events;
    using Model;

    public class Requester
    {

        #region Declarations

        string requestURL;
        //Stopwatch sw;

        #endregion

        #region Constructor

        public Requester(string requestURL)
        {
            this.requestURL = requestURL;
            //sw = new Stopwatch();
            //sw.Start();
            products = new List<Product>();
            Flag = false;
        }

        #endregion

        #region Public Properties

        public bool Flag
        {
            get;
            set;
        }

        public List<Product> products
        {
            get;
            set;
        }

        #endregion

        public void Update()
        {
            //Note: changed stopwatch with sleep for performance
            /* if (sw.ElapsedMilliseconds / 1000 > 5) //66
             {
                 sw.Stop();
                 sw.Reset();
                 sw.Start();*/

            System.Threading.Thread.Sleep(5000);

            products = null;
            products = JsonUtil.GetProductList(requestURL);

            if (products != null)
            {
                Flag = true;
            }
        }
    

    }
}
