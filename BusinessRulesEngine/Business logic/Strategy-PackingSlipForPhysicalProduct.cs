using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the first test,
     * "If the payment is for a physical product, generate a packing slip for shipping."
     * 
     * A book is also a physical object so needs a packing slip.
     */
    public class Strategy_PackingSlipForPhysicalProduct : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager, 
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.PhysicalNonBook:
                case PurchasableTypeEnum.Book:
                case PurchasableTypeEnum.Video:
                    //Generate a packing slip for the customer
                    packingSlipManager.GeneratePackingSlip(item, order.Customer, 0);
                    break;
            }
        }
    }
}
