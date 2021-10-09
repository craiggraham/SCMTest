using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* Interface to something that can generate packing slips 
     * Real system we'd probably want to produce a single packing
     * slip per order to both the customer and, for relevant items,
     * the royalty department but that's a layer of complexity not
     * called for here.
     */

    interface iPackingSlipManager
    {
        /* Generate a packing slip for either the customer or for the 
         * royalty department.
         * item and person are self explanatory. When desination=0 this packing
         * slip is for the customer. When it is 1, it is for the royalty department.
         */
        void GeneratePackingSlip(iPurchasable item, iPerson customer, int destination);
    }
}
