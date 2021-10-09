using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{
    public class MembershipManager : iMembershipManager

    {
        List<iMembership> memberships = new List<iMembership>();

        // Add a new membership for the specified person.
        // Returns 0 on success, 1 if a membershp already exists.
        public int addMembership(iPerson customer)
        {
            if (GetMembershipForPerson(customer) != null)
            {
                return 1;
            }
            memberships.Add(new Membership(customer));
            return 0;
        }

        /*
        Returns any present membership information for this person.
        We do the check on name because we know that'll match.
        In a real system we'd want some kind of integer person ID.
        We don't want to do a check to see if the same Person
        object is used because there's no guarantee the same object
        is implementing the interface between populating the list and
        running the query.
        */
        public iMembership GetMembershipForPerson(iPerson customer)
        {
            return memberships.Find(x => x.Owner.Name == customer.Name);
        }

        //Upgrades an existing membership for the specified person
        //Returns 0 on success, 1 if the membership is already upgraded,
        //2 if there is no existing membership to upgrade.
        public int upgradeMembership(iPerson customer)
        {
            iMembership m = GetMembershipForPerson(customer);
            if (m != null)
            {
                if (!m.UpgradedMembership)
                {
                    m.UpgradedMembership = true;
                    return 0;
                }
                else return 1;
            }
            else return 2;
        }
    }
}
