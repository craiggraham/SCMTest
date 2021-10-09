using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Interfaces;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the test
    * "If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade."
    * 
    */
    public class Strategy_EmailAboutMembership : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager,
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.Membership:
                    emailManager.SendEmail(order.Customer, "Your membership has been activated.");
                    break;

                case PurchasableTypeEnum.MembershipUpgrade:
                    emailManager.SendEmail(order.Customer, "Your membership has been upgraded.");
                    break;
            }
        }
    }
}
