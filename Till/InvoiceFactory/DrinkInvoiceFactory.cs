using System;
using Till.Data;
using Till.DrinkTypeInvoice;
using Till.InvoiceInterface;

namespace Till.InvoiceFactory
{
    public class DrinkInvoiceFactory
    {
        public DrinkInvoiceFactory()
        {
        }

        //method to create hotfood typed invoice like chickenteriyaki,
        public IDrinkInvoice createDrinkInvoiceType(string itemName)
        {
            IDrinkInvoice drinkType;
            DrinkEnum drinkEnum;
            if (Enum.TryParse<DrinkEnum>(itemName, out drinkEnum))
            {
                switch (drinkEnum)
                {
                    case DrinkEnum.Coke:
                        drinkType = new CokeInvoice();
                        break;
                    case DrinkEnum.ZeroCoke:
                        drinkType = new ZeroCokeInvoice();
                        break;
                    case DrinkEnum.Fanta:
                        drinkType = new FantaInvoice();
                        break;
                    case DrinkEnum.StillWater:
                        drinkType = new StillWaterInvoice();
                        break;
                    default:
                        drinkType = null;
                        break;
                }

                return drinkType;
            }
            return null;
        }
    }
}
