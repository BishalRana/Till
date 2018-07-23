using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.DrinkTypeInvoice
{
    public class ZeroCokeInvoice : IDrinkInvoice
    {
        public ZeroCokeInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, DrinkEnum.ZeroCoke.ToString()))
            {
                items.Add(new Item
                {
                    itemName = DrinkEnum.ZeroCoke.ToString(),
                    price = DrinkPrice.ZeroCoke,
                    qty = 1,
                    totalCost = DrinkPrice.ZeroCoke
                });
            }
            else
            {
                Item zeroCoke = items.First(s => s.itemName == DrinkEnum.ZeroCoke.ToString());
                zeroCoke.qty = zeroCoke.qty + 1;
                zeroCoke.totalCost = zeroCoke.price * zeroCoke.qty;

            }       
        }

        public void RemoveFood(List<Item> items)
        {
            Item zeroCoke = items.First(s => s.itemName == DrinkEnum.ZeroCoke.ToString());

            if (zeroCoke.qty == 1)
            {
                items.Remove(zeroCoke);
            }
            else if (zeroCoke.qty > 1)
            {
                zeroCoke.qty = zeroCoke.qty - 1;
                zeroCoke.totalCost = zeroCoke.totalCost - zeroCoke.price;
            }      
        }
    }
}
