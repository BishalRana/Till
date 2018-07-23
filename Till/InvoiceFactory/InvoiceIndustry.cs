using System;
using Till.BentoTypeInvoice;
using Till.Data;
using Till.DrinkTypeInvoice;
using Till.InvoiceInterface;
using Till.SushiTypeInvoice;

namespace Till.InvoiceFactory
{
    public class InvoiceIndustry
    {
        public InvoiceIndustry()
        {
        }

        //creating invoice of different types like hotFood,drink,sushi
        public IInvoice createInvoiceType(string itemName)
        {
            BentoEnum hotFoodEnum;
            DrinkEnum drinkEnum;
            SushiEnum sushiEnum;

            if (Enum.TryParse<BentoEnum>(itemName, out hotFoodEnum))
            {
                return new BentoInvoice(itemName);
            }
            else if (Enum.TryParse<DrinkEnum>(itemName, out drinkEnum))
            {

                return new DrinkInvoice(itemName);
            }
            else if (Enum.TryParse<SushiEnum>(itemName, out sushiEnum))
            {
                return new SushiInvoice(itemName);

            }

            return null;
        }
    }
}
