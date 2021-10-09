using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.Test_implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngineTests.Test_implementations;
using BusinessRulesEngine.Interfaces;

namespace BusinessRulesEngine.Test_implementations.Tests
{
    [TestClass()]
    public class MembershipManagerTests
    {
        [TestMethod()]
        public void MembershipManagerTest()
        {
            TE.Init();

            //We should be able to add the person the first time
            int r = TE.membershipManager.addMembership(TE.person);
            Assert.AreEqual(0, r, "Inital add membership returned unexpected response");

            //The second time it should fail
            r = TE.membershipManager.addMembership(TE.person);
            Assert.AreEqual(1, r, "Second add membership returned unexpected response");

            //Should be able to get that membership
            iMembership m = TE.membershipManager.GetMembershipForPerson(TE.person);
            Assert.IsNotNull(m, "Membership not returned");

            //Membership should not be upgraded
            Assert.IsFalse(m.UpgradedMembership, "Membership is upgraded when it shouldn't be");

            //Should be able to upgrade the membership
            r = TE.membershipManager.upgradeMembership(TE.person);

            Assert.AreEqual(0, r, "Membership upgrade failed");

            //Now we should be able to see it's upgraded (slight cheat re-using the object)
            Assert.IsTrue(m.UpgradedMembership, "Membership is not upgraded when it should be");

            //And we shouldn't be able to upgrade again
            r = TE.membershipManager.upgradeMembership(TE.person);
            Assert.AreEqual(1, r, "Second upgrade wasn't blocked");

            //We shouldn't be able to upgrade someone who has no membership
            r = TE.membershipManager.upgradeMembership(TE.person2);
            Assert.AreEqual(2, r, "No error on upgrading a membership that doesn't exist");

        }
    }
}