using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Test_implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngineTests.Test_implementations
{
    /* Class to provide a basic environment in which to run tests, rather
     * than duplicate setup code. Short for Test Environment.
     */

    public static class TE
    {
        public static iSystemFacade f = new SystemFacade();
        public static iMembershipManager membershipManager;
        public static iCommissionManager commissionManager;
        public static iEmailManager emailManager;
        public static iPackingSlipManager packingSlipManager;
        public static iPerson person;
        public static iPerson person2;
        public static iPurchasable item_book = f.GetPurchasable(PurchasableTypeEnum.Book, "A Book");
        public static iPurchasable item_physicalnonbook = f.GetPurchasable(PurchasableTypeEnum.PhysicalNonBook, "Not A Book");

        /* Initialise the test environment.
         * We don't just create implicitly because we want each test to start
         * with a clean slate.
         */
        public static void Init()
        {
            membershipManager = f.GetMembershipManager();
            commissionManager = f.GetCommissionManager();
            emailManager = f.GetEmailManager();
            packingSlipManager = f.GetPackingSlipManager();
            person = f.getPerson("a@b.c", "A Person", "An Address");
            person2 = f.getPerson("a2@b.c", "Another Person", "Another Address");


        }

    }
}
