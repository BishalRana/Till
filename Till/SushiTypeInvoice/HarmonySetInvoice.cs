using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.SushiTypeInvoice
{
    public class HarmonySetInvoice : IShushiInvoice
    {
        public HarmonySetInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, SushiEnum.HarmonySet.ToString()))
            {
                items.Add(new Item
                {
                    itemName = SushiEnum.HarmonySet.ToString(),
                    price = SushiPrice.HarmonySet,
                    qty = 1,
                    totalCost = SushiPrice.HarmonySet
                });
            }
            else
            {
                Item harmonySet = items.First(s => s.itemName == SushiEnum.HarmonySet.ToString());
                harmonySet.qty = harmonySet.qty + 1;
                harmonySet.totalCost = harmonySet.price * harmonySet.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item harmonySet = items.First(s => s.itemName == SushiEnum.HarmonySet.ToString());

            if (harmonySet.qty == 1)
            {
                items.Remove(harmonySet);
            }
            else if (harmonySet.qty > 1)
            {
                harmonySet.qty = harmonySet.qty - 1;
                harmonySet.totalCost = harmonySet.totalCost - harmonySet.price;
            }
        }
    }


}
