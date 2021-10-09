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
     */
    class Strategy_PackingSlipForPhysicalProduct : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager, 
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager)
        {
            throw new NotImplementedException();
        }
    }
}
