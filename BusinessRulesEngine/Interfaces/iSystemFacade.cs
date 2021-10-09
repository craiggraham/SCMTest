using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* An interface to a builder class to return instances of the concrete classes used in the system 
 * Members are self explanatory!
 */
namespace BusinessRulesEngine.Interfaces
{
    public interface iSystemFacade
    {
       
        iPerson getPerson(String email, String name, String address);

        iMembershipManager GetMembershipManager();

        iOrder GetOrder(iPerson customer, IAgent agent);

        iMembership GetMembership(iPerson owner);

        iPurchasable GetPurchasable(PurchasableTypeEnum ItemType, String ItemName);

        iEmailManager GetEmailManager();

        iCommissionManager GetCommissionManager();

        iPackingSlipManager GetPackingSlipManager();

        List<iPurchasableStrategy> GetPurchasableStrategies();
    }
}
