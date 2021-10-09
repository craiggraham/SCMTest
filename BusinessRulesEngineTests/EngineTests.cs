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

        [TestMethod()]
        public void ProcessOrderTest_PackingSlipForPhysicalItem()
        {
            Init();

            o.Items.Add(f.GetPurchasable(PurchasableTypeEnum.PhysicalNonBook, "Not a book"));
            e.ProcessOrder(o);

            //This should have produced a packing list
            Assert.AreEqual(1, e.test_PackingSlipManagerList.Count, "Number of generated packing slips is not 1");

        }
    }
}