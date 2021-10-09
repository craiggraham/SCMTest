using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Test_implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine
{
    /* The actual top level business rules engine.
     * This has the linkage via SystemFacade to all the concrete classes.
     * Barring a few design problems which I've documented, along with how to fix.
     */

    public class Engine
    {
        /* Working environment */
        iCommissionManager commissionManager;
        iEmailManager emailManager;
        iMembershipManager membershipManager;
        iPackingSlipManager packingSlipManager;


        /* For testing
         * For classes where they don't have internal state that it makes sense to have in the interface, 
         * we need to cast our test classes to the concrete types to get at the test data.
         */
        public List<iPurchasable>  test_CommissionManagerList
        {
            get
            {
                CommissionManager cm = (CommissionManager)commissionManager;
                return cm.items;
            }
        }

        public List<iPurchasable> test_PackingSlipManagerList
        {
            get
            {
                PackingSlipManager psm = (PackingSlipManager)packingSlipManager;
                return psm.items;
            }
        }

        public List<String> test_emailManagerList
        {
            get
            {
                EmailManager em = (EmailManager)emailManager;
                return em.Messages;
            }
        }


        /* Iterates through all the items in an order, for each item 
         * execute all the business rules- including any items added
         * as a result of the business rules.
         */
        public void ProcessOrder(iOrder order)
        {
            int index = 0;
            iSystemFacade f = new SystemFacade();
            commissionManager = f.GetCommissionManager();
            emailManager = f.GetEmailManager();
            membershipManager = f.GetMembershipManager();
            packingSlipManager = f.GetPackingSlipManager();

            List<iPurchasableStrategy> rules = f.GetPurchasableStrategies();

            do
            {
                ProcessItem(order, index, rules);

            } while (++index < order.Items.Count);

        }

        private void ProcessItem(iOrder order, int index, List<iPurchasableStrategy> rules)
        {
            iPurchasable item = order.Items[index];
            foreach(iPurchasableStrategy s in rules)
            {
                s.ApplyStrategy(item, order, membershipManager, commissionManager, packingSlipManager, emailManager);
            }
        }
    }
}
