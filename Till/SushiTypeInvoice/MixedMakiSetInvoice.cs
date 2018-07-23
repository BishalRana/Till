using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.SushiTypeInvoice
{
    public class MixedMakiSetInvoice : IShushiInvoice
    {
        public MixedMakiSetInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, SushiEnum.MixedMakiSet.ToString()))
            {
                items.Add(new Item
                {
                    itemName = SushiEnum.MixedMakiSet.ToString(),
                    price = SushiPrice.MixedMakiSet,
                    qty = 1,
                    totalCost = SushiPrice.MixedMakiSet
                });
            }
            else
            {
                Item mixedMaki = items.First(s => s.itemName == SushiEnum.MixedMakiSet.ToString());
                mixedMaki.qty = mixedMaki.qty + 1;
                mixedMaki.totalCost = mixedMaki.price * mixedMaki.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item mixedMaki = items.First(s => s.itemName == SushiEnum.MixedMakiSet.ToString());

            if (mixedMaki.qty == 1)
            {
                items.Remove(mixedMaki);
            }
            else if (mixedMaki.qty > 1)
            {
                mixedMaki.qty = mixedMaki.qty - 1;
                mixedMaki.totalCost = mixedMaki.totalCost - mixedMaki.price;
            }
        }
    }
}
