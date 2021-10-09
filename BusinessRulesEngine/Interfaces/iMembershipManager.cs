using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Interface to a component to manage memberships.
 * 
 */
namespace BusinessRulesEngine.Interfaces
{
    public interface iMembershipManager
    {
        // Add a new membership for the specified person.
        // Returns 0 on success, 1 if a membershp already exists.
        int addMembership(iPerson customer);

        //Upgrades an existing membership for the specified person
        //Returns 0 on success, 1 if the membership is already upgraded,
        //2 if there is no existing membership to upgrade.
        int upgradeMembership(iPerson customer);

        //Returns any present membership information for this person.
        iMembership GetMembershipForPerson(iPerson customer);

    }
}
