using System;
using Till.Data;

namespace Till.FoodService
{

    public partial class Service
    {
        public partial class ServiceFactory
        {
            class Takeaway : Service
            {
                public Takeaway()
                {
                }

                //charing the takeway service
                public override void Charge(Item item)
                {
                    if (ServiceCharge.Takeway > 0.0)
                    {
                        item.totalCost = Math.Round((((ServiceCharge.Takeway / 100) * item.price) + item.price) * item.qty,2);
                    }
                    else
                    {
                        item.totalCost = Math.Round(item.price * item.qty,2);
                    }

                }

                public override void DeductCharge(Item item)
                {
                    if (ServiceCharge.Takeway > 0.0)
                    {
                        item.totalCost = Math.Round(item.totalCost - ((ServiceCharge.Takeway / 100) * item.price),2);
                    }
                }
            }
        }
    }


}
