using BusinessRulesEngine.Business_logic;
using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* A class to implement iSystemFacade for testing and provide a 
     * single point of dependency between the engine and the 
     * environment-dependent implementation should the system be developed
     * further
     */

    public class SystemFacade : iSystemFacade
    {
        public iCommissionManager GetCommissionManager()
        {
            throw new NotImplementedException();
        }

        public iEmailManager GetEmailManager()
        {
            return new EmailManager();
        }

        public iMembership GetMembership(iPerson owner)
        {
            return new Membership(owner);
        }

        public iMembershipManager GetMembershipManager()
        {
            return new MembershipManager();
        }

        public iOrder GetOrder(iPerson customer, IAgent agent)
        {
            //Our test order class doesn't do anything with agent
            return new Order(customer); 
        }

        public iPackingSlipManager GetPackingSlipManager()
        {
            throw new NotImplementedException();
        }

        public iPerson getPerson(string email, string name, string address)
        {
            return new Person(email, name, address);
        }

        public iPurchasable GetPurchasable(PurchasableTypeEnum itemType, string itemName)
        {
            return new Purchasable(itemType, itemName);
        }

        public List<iPurchasableStrategy> GetPurchasableStrategies()
        {
            List<iPurchasableStrategy> l = new();


            l.Add(new Strategy_PackingSlipForPhysicalProduct());
            return l;
        }
    }
}
