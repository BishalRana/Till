using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.BentoTypeInvoice
{
    public class SpicyChickenInvoice : IBentoInvoice
    {
        public SpicyChickenInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, BentoEnum.SpicyChicken.ToString()))
            {
                items.Add(new Item
                {
                    itemName = BentoEnum.SpicyChicken.ToString(),
                    price = BentoPrice.SpicyChicken,
                    qty = 1,
                    totalCost = BentoPrice.SpicyChicken
                });
            }
            else
            {
                Item spicyChicken = items.First(s => s.itemName == BentoEnum.SpicyChicken.ToString());
                spicyChicken.qty = spicyChicken.qty + 1;
                spicyChicken.totalCost = spicyChicken.price * spicyChicken.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item spicyChicken = items.First(s => s.itemName == BentoEnum.SpicyChicken.ToString());

            if (spicyChicken.qty == 1)
            {
                items.Remove(spicyChicken);
            }
            else if (spicyChicken.qty > 1)
            {
                spicyChicken.qty = spicyChicken.qty - 1;
                spicyChicken.totalCost = spicyChicken.totalCost - spicyChicken.price;
            }
        }
    }
}
