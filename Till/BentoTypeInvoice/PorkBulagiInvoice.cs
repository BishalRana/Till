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
            if (!UtilityService.CheckItemExists(items, BentoEnum.PorkBulgogi.ToString()))
            {
                items.Add(new Item
                {
                    itemName = BentoEnum.PorkBulgogi.ToString(),
                    price = BentoPrice.PorkBulgogi,
                    qty = 1,
                    totalCost = BentoPrice.PorkBulgogi
                });
            }
            else
            {
                Item porkBulgogi = items.First(s => s.itemName == BentoEnum.PorkBulgogi.ToString());
                porkBulgogi.qty = porkBulgogi.qty + 1;
                porkBulgogi.totalCost = porkBulgogi.price * porkBulgogi.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item porkBulgogi = items.First(s => s.itemName == BentoEnum.PorkBulgogi.ToString());

            if (porkBulgogi.qty == 1)
            {
                items.Remove(porkBulgogi);
            }
            else if (porkBulgogi.qty > 1)
            {
                porkBulgogi.qty = porkBulgogi.qty - 1;
                porkBulgogi.totalCost = porkBulgogi.totalCost - porkBulgogi.price;
            }
        }
    }
}
