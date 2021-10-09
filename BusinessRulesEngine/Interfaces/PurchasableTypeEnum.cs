using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* An enumeration listing the different types of items that can be purchased.
 * It's not an interface, but it's very strongly related to iPurchasable so it
 * makes sense to be in here. Arguably it could be inside the iPurchasable file,
 * but that adds to clutter and means that if the enum is changed to add a product
 * type, it's not immediately clear that no other changes have been made to the
 * interface.
 */

namespace BusinessRulesEngine.Interfaces
{
    public enum PurchasableTypeEnum
    {
        Book,
        PhysicalNonBook,
        Membership,
        MembershipUpgrade
    }
}
