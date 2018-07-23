using System;
using Till.Data;

namespace Till.FoodService
{
    
    public partial class Service
    {
        public partial class ServiceFactory
        {
            class EatIn : Service
            {
               

                //charging due to eatin service 
                public override void Charge(Item item)
                {
                    item.totalCost = Math.Round((((ServiceCharge.EatIn / 100) * item.price) + item.price) * item.qty,2);
                }
                //deducting the total charge service
                public  override void DeductCharge(Item item)
                {
                    item.totalCost = Math.Round(item.totalCost - ((ServiceCharge.EatIn / 100) * item.price),2);
                }
            }
        }
    }

   
}
