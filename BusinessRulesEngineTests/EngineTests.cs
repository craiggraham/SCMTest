using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Test_implementations;
using BusinessRulesEngine.Interfaces;

namespace BusinessRulesEngine.Tests
{
    [TestClass()]
    public class EngineTests
    {
        iSystemFacade f;
        iPerson p;
        iOrder o;
        Engine e;

        void Init()
        {
            f = new SystemFacade();
            p = f.getPerson("a@b.c", "A Person", "An Address");
            o = f.GetOrder(p, null);
            e = new Engine();
        }

        //Test "If the payment is for a physical product, generate a packing slip for shipping."
        [TestMethod()]
        public void ProcessOrderTest_PackingSlipForPhysicalItem()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.PhysicalNonBook, "Not a book"));
            e.ProcessOrder(o);

            //This should have produced a packing list
            Assert.AreEqual(1, e.test_PackingSlipManagerList.Count, "Number of generated packing slips is not 1 for a general item");

            //This should also have proessed commission
            Assert.AreEqual(1, e.test_CommissionManagerList.Count, "Number of commission calls is not 1 for a general item");

            //Repeat the test for a video
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.Video, "A video"));
            e.ProcessOrder(o);

            //This should have produced a packing list
            Assert.AreEqual(1, e.test_PackingSlipManagerList.Count, "Number of generated packing slips is not 1 for a video");

            //This should also have proessed commission
            Assert.AreEqual(1, e.test_CommissionManagerList.Count, "Number of commission calls is not 1 for a video");

        }

        //Test "If the payment is for a book, create a duplicate packing slip for the royalty department."
        [TestMethod()]
        public void ProcessOrderTest_ExtraPackingSlipForBook()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.Book, "A book"));
            e.ProcessOrder(o);

            //This should have produced a packing list
            Assert.AreEqual(2, e.test_PackingSlipManagerList.Count, "Number of generated packing slips is not 2 for a book");

            //This should also have processed commission
            Assert.AreEqual(1, e.test_CommissionManagerList.Count, "Number of commission calls is not 1 for a book");

        }

        //Test "If the payment is for a membership, activate that membership."
        [TestMethod()]
        public void ProcessOrderTest_ActivateMembership()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.Membership, ""));
            e.ProcessOrder(o);

            //Should now be able to get a member record

            Assert.IsNotNull(e.membershipManager.GetMembershipForPerson(o.Customer), "Membership not created");

            //Should have also emailed the user

            Assert.AreEqual(1, e.test_emailManagerList.Count, "Email not generated");

        }


        //Test "If the payment is an upgrade to a membership, apply the upgrade."
        [TestMethod()]
        public void ProcessOrderTest_UpgradeMembership()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.Membership, ""));
            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.MembershipUpgrade, ""));
            e.ProcessOrder(o);

            //Should now be able to get a member record

            Assert.IsNotNull(e.membershipManager.GetMembershipForPerson(o.Customer), "Membership not created");

            //Should be upgraded
            Assert.IsTrue(e.membershipManager.GetMembershipForPerson(o.Customer).UpgradedMembership, "Membership not upgraded");

            //Should have also emailed the user- twice because we first joined then upgraded.

            Assert.AreEqual(2, e.test_emailManagerList.Count, "Email not generated");

        }

        //Test "If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip "
        [TestMethod()]
        public void ProcessOrderTest_AddFirstAidVideo()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.Video, "Learning to Ski"));
            e.ProcessOrder(o);

            //This should have produced a packing list for two items
            Assert.AreEqual(2, e.test_PackingSlipManagerList.Count, "Number of generated packing slips is not 2 for Learning to Ski");

            //This should also have proessed commission- twice
            Assert.AreEqual(2, e.test_CommissionManagerList.Count, "Number of commission calls is not 2 for Learning to Ski");

        }


    }
}