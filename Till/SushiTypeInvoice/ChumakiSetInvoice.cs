using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.SushiTypeInvoice
{
    public class ChumakiSetInvoice : IShushiInvoice
    {
        public ChumakiSetInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, SushiEnum.ChumakiSet.ToString()))
            {
                items.Add(new Item
                {
                    itemName = SushiEnum.ChumakiSet.ToString(),
                    price = SushiPrice.ChumakiSet,
                    qty = 1,
                    totalCost = SushiPrice.ChumakiSet
                });
            }
            else
            {
                Item chumakiSet = items.First(s => s.itemName == SushiEnum.ChumakiSet.ToString());
                chumakiSet.qty = chumakiSet.qty + 1;
                chumakiSet.totalCost = chumakiSet.price * chumakiSet.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item chumakiSet = items.First(s => s.itemName == SushiEnum.ChumakiSet.ToString());

            if (chumakiSet.qty == 1)
            {
                items.Remove(chumakiSet);
            }
            else if (chumakiSet.qty > 1)
            {
                chumakiSet.qty = chumakiSet.qty - 1;
                chumakiSet.totalCost = chumakiSet.totalCost - chumakiSet.price;
            }
        }
    }
}
