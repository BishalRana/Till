using System;
using Till.Data;

namespace Till.FoodService
{
    public  abstract partial class Service
    {

        private Service()
        {
            
        }

        //add extra cost
        public abstract void Charge(Item item);

        //deducting the total charge service
        public abstract void DeductCharge(Item item);

        public partial class ServiceTypeFactory
        {
            
        }

    }
}
