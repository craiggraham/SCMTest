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
        public static MembershipManager membershipManager;
        public static Person person;
        public static Person person2;

        /* Initialise the test environment.
         * We don't just create implicitly because we want each test to start
         * with a clean slate.
         */
        public static void Init()
        {
            membershipManager = new MembershipManager();
            person = new Person("a@b.c", "A Person", "An Address");
            person2 = new Person("a2@b.c", "Another Person", "Another Address");

        }

    }
}
