using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Test_implementations;

namespace BusinessRulesEngine.Business_logic
{
    /* A class to implement iPurchasableStrategy and do the test
    * "If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip."
    * 
    * This shows a design problem- we have to have a dependency in here on a class that will have to change 
    * in production- SystemFacade. To fix this we should really have iSystemFacade as another parameter to ApplyStrategy.
    * However it's already getting messy and in doing that refactoring I'd introduce another object "Context" that would store
    * all our class instances in one place. There doesn't seem much point actually doing that for this now.
    * 
    * Also, in reality we'd need some kind of items catalog so we can refer to the First Aid video by something
    * better than a title- this breaks if at some point a second video is produced called "First Aid" since 
    * it's a very generic name.
    */
    public class Strategy_AddFirstAidVideo : iPurchasableStrategy
    {
        public void ApplyStrategy(iPurchasable item, iOrder order, iMembershipManager membershipManager,
            iCommissionManager commissionManager, iPackingSlipManager packingSlipManager, iEmailManager emailManager)
        {
            switch (item.ItemType)
            {
                case PurchasableTypeEnum.Video:
                    if(item.ItemName=="Learning to Ski")
                    {
                        iSystemFacade f = new SystemFacade();

                        iPurchasable fav = f.GetPurchasable(PurchasableTypeEnum.Video, "First Aid");
                        order.Items.Add(fav);
                    }
                    break;
            }
        }
    }
}
