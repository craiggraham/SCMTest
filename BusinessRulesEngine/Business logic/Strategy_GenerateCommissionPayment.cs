using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Interfaces;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the test
    * "If the payment is for a physical product or a book, generate a commission payment to the agent."
    * The agent would in a real system be passed though in the Order but I've not implemented that.
    */
    class Strategy_GenerateCommissionPayment : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager,
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.Video:
                case PurchasableTypeEnum.Book:
                case PurchasableTypeEnum.PhysicalNonBook:
                    commissionManager.PayCommision(item, order);
                    break;
            }
        }
    }
}
