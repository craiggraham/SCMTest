using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{

    /* Interface to represent an Order.
     * We only need get here because it makes sense to
     * specify the customer on object creation and we
     * simplify item management by using a List with its
     * own functions to add to and manipulate the contents.
     */
    interface iOrder
    {
        iPerson Customer { get; }

        List<iPurchasable> Items { get; }
    }
}
