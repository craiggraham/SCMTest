using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.Test_implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations.Tests
{
    [TestClass()]
    public class EmailManagerTests
    {
        [TestMethod()]

        /* Test that our skeleton email manager is functioning and
         * that our method for verifying that works.
         */

        public void SendEmailTest()
        {
            String email = "a@b.c";
            String message = "Hello World";
            Person p = new Person(email, "", "");
            EmailManager m = new EmailManager();

            m.SendEmail(p, message);

            Assert.AreEqual(1, m.Messages.Count, "Messages sent isn't right");
            Assert.AreEqual(email + message, m.Messages[0], "Message text isn't right");


        }
    }
}