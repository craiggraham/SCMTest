using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    /* Simple class to implement iMembership for testing. */
    class Membership : iMembership
    {
        iPerson _Owner;
        bool _membershipIsUpgraded;

        public iPerson Owner { get { return _Owner; } }

        public bool UpgradedMembership {
            get { return _membershipIsUpgraded; }
            set { _membershipIsUpgraded = true; }
        }

        public Membership(iPerson Owner)
        {
            _Owner = Owner;
        }
    }
}
