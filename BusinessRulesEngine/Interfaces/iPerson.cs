using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* An interface to an object representing a person.
 * Field names are self explanatory. We use the (almost) simplest case
 * of single strings for the name and the address rather than subdividing
 * into smaller components because there isn't a need to in this spec.
 */

namespace BusinessRulesEngine.Interfaces
{
     public interface iPerson
    {
        string EmailAddress { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
}
