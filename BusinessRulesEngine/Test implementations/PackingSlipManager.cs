using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* Simple test implementation of iCommissionManager */
    public class PackingSlipManager : iPackingSlipManager
    {
        public List<iPurchasable> items = new();

        public void GeneratePackingSlip(iPurchasable item, iPerson customer, int destination)
        {
            items.Add(item);
        }
    }
}
