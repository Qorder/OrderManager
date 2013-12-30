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
            orders = new List<Order>();
            Flag = false;
        }

        #endregion

        #region Public Properties

        public bool Flag
        {
            get;
            set;
        }

        public List<Order> orders
        {
            get;
            set;
        }

        #endregion

        public void Update()
        {
            System.Threading.Thread.Sleep(3000);

            orders = null;
            orders = JsonUtil.GetOrderList(requestURL);

            if (orders != null)
            {
                Flag = true;
            }
        }
    

    }
}
