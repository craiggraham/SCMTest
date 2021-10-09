using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* Simple test implementation of iCommissionManager */
    public class CommissionManager : iCommissionManager
    {
        public List<iPurchasable> items = new();

        public void PayCommision(iPurchasable item, iOrder order)
        {
            items.Add(item);
        }
    }
}
