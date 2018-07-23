using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.SushiTypeInvoice
{
    public class RainBowSetInvoice : IShushiInvoice
    {
        public RainBowSetInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, SushiEnum.RainBowSet.ToString()))
            {
                items.Add(new Item
                {
                    itemName = SushiEnum.RainBowSet.ToString(),
                    price = SushiPrice.RainBowSet,
                    qty = 1,
                    totalCost = SushiPrice.RainBowSet
                });
            }
            else
            {
                Item rainBowSet = items.First(s => s.itemName == SushiEnum.RainBowSet.ToString());
                rainBowSet.qty = rainBowSet.qty + 1;
                rainBowSet.totalCost = rainBowSet.price * rainBowSet.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item rainBowSet = items.First(s => s.itemName == SushiEnum.RainBowSet.ToString());

            if (rainBowSet.qty == 1)
            {
                items.Remove(rainBowSet);
            }
            else if (rainBowSet.qty > 1)
            {
                rainBowSet.qty = rainBowSet.qty - 1;
                rainBowSet.totalCost = rainBowSet.totalCost - rainBowSet.price;
            }
        }
    }
}
