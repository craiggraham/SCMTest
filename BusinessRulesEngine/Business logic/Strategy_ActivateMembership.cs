using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Interfaces;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the test
    * "If the payment is for a membership, activate that membership."
    * 
    * We're not handling any errors back because it's not clear
    * how to- it would need to be decided based on how the system's
    * going to be implemented and how we do rollback of steps we've
    * already carried out.
    */
    public class Strategy_ActivateMembership : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager,
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.Membership:
                    // Add (and hence activate) the membership.
                    // Two points- we're not handling any errors back because it's not clear 
                    membershipManager.addMembership(order.Customer);
                    break;
            }
        }
    }
}
