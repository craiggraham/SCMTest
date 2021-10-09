using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* Interface to something that handles the payment of commission to agents. 
     */

    public interface iCommissionManager
    {
        /* Trigger the payment of commission on this item. 
         * Exactly how this works isn't specified. I assume it's a model where a person
         * takes a phone call and places the order- this is the agent. So the order interface
         * would have to expose details of who this is and then the object this interface
         * represents can obtain that from the order.
         * Here, although I'm passing iOrder to the method to show how it'd work, there's no 
         * point adding the agent to the order and making new interfaces and objects to represent 
         * this because it adds little.
         */

        void PayCommision(iPurchasable item, iOrder order);
    }
}
