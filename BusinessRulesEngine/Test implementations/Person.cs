using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* Simple class to implement iPerson for testing. */
    class Person : iPerson
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Person(String email, String name, String address)
        {
            this.EmailAddress = email;
            this.Name = name;
            this.Address = address;

        }
    }
}
