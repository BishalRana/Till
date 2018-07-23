using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.BentoTypeInvoice
{
    public class CurrySauceInvoice : IBentoInvoice
    {
        public CurrySauceInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, BentoEnum.CurrySauce.ToString()))
            {
                items.Add(new Item
                {
                    itemName = BentoEnum.CurrySauce.ToString(),
                    price = BentoPrice.CurrySauce,
                    qty = 1,
                    totalCost = BentoPrice.CurrySauce
                });
            }
            else
            {
                Item currySauce = items.First(s => s.itemName == BentoEnum.CurrySauce.ToString());
                currySauce.qty = currySauce.qty + 1;
                currySauce.totalCost = currySauce.price * currySauce.qty;

            }
        }

        public void RemoveFood(List<Item> items)
        {
            Item currySauce = items.First(s => s.itemName == BentoEnum.CurrySauce.ToString());

            if (currySauce.qty == 1)
            {
                items.Remove(currySauce);
            }
            else if (currySauce.qty > 1)
            {
                currySauce.qty = currySauce.qty - 1;
                currySauce.totalCost = currySauce.totalCost - currySauce.price;
            }
        }
    }
}
