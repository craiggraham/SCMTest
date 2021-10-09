using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngineTests.Test_implementations;
using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Test_implementations;

namespace BusinessRulesEngine.Business_logic.Tests
{
    [TestClass()]
    public class Strategy_PackingSlipForPhysicalProductTests
    {
        [TestMethod()]
        public void ApplyStrategyTest()
        {
            TE.Init();
            Strategy_PackingSlipForPhysicalProduct s = new Strategy_PackingSlipForPhysicalProduct();

            //TE doesn't help much afterall because we need a different Order each time.

            iOrder o = TE.f.GetOrder(TE.person, null);
            o.Items.Add(TE.item_physicalnonbook);

            PackingSlipManager psm = new PackingSlipManager(); //needs to be local for the list

            s.ApplyStrategy(TE.item_physicalnonbook, o, TE.membershipManager, TE.commissionManager, psm, TE.emailManager);

            //Packing slip manager should've done one item
            Assert.AreEqual(1, psm.items.Count, "Number of packing slips produced is wrong");

            //Packing slip should be for the item
            Assert.AreEqual(TE.item_physicalnonbook, psm.items[0], "Wrong item for packing list");
        }
    }
}