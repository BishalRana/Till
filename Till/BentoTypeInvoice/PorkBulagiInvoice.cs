using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.BentoTypeInvoice
{
    public class PorkBulagiInvoice : IBentoInvoice
    {
        public PorkBulagiInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, BentoEnum.PorkBulagi.ToString()))
            {
                items.Add(new Item
                {
                    itemName = BentoEnum.PorkBulagi.ToString(),
                    price = BentoPrice.PorkBulagi,
                    qty = 1,
                    totalCost = BentoPrice.PorkBulagi
                });
            }
            else
            {
                Item porkBulagi = items.First(s => s.itemName == BentoEnum.PorkBulagi.ToString());
                porkBulagi.qty = porkBulagi.qty + 1;
                porkBulagi.totalCost = porkBulagi.price * porkBulagi.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item porkBulagi = items.First(s => s.itemName == BentoEnum.PorkBulagi.ToString());

            if (porkBulagi.qty == 1)
            {
                items.Remove(porkBulagi);
            }
            else if (porkBulagi.qty > 1)
            {
                porkBulagi.qty = porkBulagi.qty - 1;
                porkBulagi.totalCost = porkBulagi.totalCost - porkBulagi.price;
            }
        }
    }
}
