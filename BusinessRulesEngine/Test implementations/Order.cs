﻿using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* Simple class to implement iOrder for testing. */
    class Order : iOrder
    {
        iPerson customer;
        List<iPurchasable> items;

        public Order(iPerson customer)
        {
            items = new List<iPurchasable>();
        }

        public iPerson Customer {get {return customer;} }


        public List<iPurchasable> Items { get { return items; } }
    }
}