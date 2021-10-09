using BusinessRulesEngine.Interfaces;
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
        List<iPurchasable> items;

        public Order(iPerson customer)
        {
            items = new List<iPurchasable>();
            this.Customer = customer;
        }

        public iPerson Customer { get; }


        public List<iPurchasable> Items { get { return items; } }
    }
}
