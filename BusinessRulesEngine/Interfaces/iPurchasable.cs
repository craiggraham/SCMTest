using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* Bare bones requirement for a Purchasable. 
     * In reality there'd be at least a price and, so 
     * we're not having to do string comparisons all the time,
     * a numeric SKU.
     *
     */

    public interface iPurchasable
    {
        PurchasableTypeEnum ItemType { get; set; }
        String ItemName { get; set; }
    }
}
