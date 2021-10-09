using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* Interface to an object representing a membership. We don't need Owner
     * to be writable because we can specify that at creation, but we do
     * need UpgradedMembership writable because otherwise we'd have to 
     * destroy the old object and create the new from scratch when it's 
     * upgraded.
     * 
     * In a real system there'd be at least an expiry date in here as well.
     */

    interface iMembership
    {
        iPerson Owner { get; }
        bool UpgradedMembership { get; set; }
    }
}
