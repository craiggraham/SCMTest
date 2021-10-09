using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* An interface to a business rule that can be applied to an item */
    public interface iPurchasableStrategy
    {
        /* Applies business logic to a single item of the order.
         * Because business logic can add extra items to the order, we have to be careful of how
         * we iterate through the items list in the engine itself- iterators often don't like the 
         * underlying collection changing while iterating.
         */
        void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager, iCommissionManager commissionManager, iPackingSlipManager packingSlipManager);
    }
}
