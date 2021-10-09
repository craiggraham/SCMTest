using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    // Simple class to implement iPurchasable for testing
    class Purchasable : iPurchasable
    {
        public PurchasableTypeEnum ItemType { get; set; }
        public String ItemName { get; set; }

        public Purchasable(PurchasableTypeEnum ItemType, String ItemName)
        {
            this.ItemName = ItemName;
            this.ItemType = ItemType;
        }

    }
}
