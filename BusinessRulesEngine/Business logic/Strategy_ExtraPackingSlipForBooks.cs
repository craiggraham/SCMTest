using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the test
    * "If the payment is for a book, create a duplicate packing slip for the royalty department."
    */
    public class Strategy_ExtraPackingSlipForBooks : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager,
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.Book:
                    //Generate a packing slip for the roalty department. A packing slip will be made 
                    //for the customer by Strategy_PackingSlipForPhysicalProduct.
                    //No individual unit test because it's trivial and makes sense to test only with the
                    //other rules.
                    packingSlipManager.GeneratePackingSlip(item, order.Customer, 1);
                    break;
            }
        }
    }
}
