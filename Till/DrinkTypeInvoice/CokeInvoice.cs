using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.DrinkTypeInvoice
{
    public class CokeInvoice : IDrinkInvoice
    {
        public CokeInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, DrinkEnum.Coke.ToString()))
            {
                items.Add(new Item
                {
                    itemName = DrinkEnum.Coke.ToString(),
                    price = DrinkPrice.Coke,
                    qty = 1,
                    totalCost = DrinkPrice.Coke
                });
            }
            else
            {
                Item coke = items.First(s => s.itemName == DrinkEnum.Coke.ToString());
                coke.qty = coke.qty + 1;
                coke.totalCost = coke.price * coke.qty;

            }       
        }

        public void RemoveFood(List<Item> items)
        {
            Item coke = items.First(s => s.itemName == DrinkEnum.Coke.ToString());

            if (coke.qty == 1)
            {
                items.Remove(coke);
            }
            else if (coke.qty > 1)
            {
                coke.qty = coke.qty - 1;
                coke.totalCost = coke.totalCost - coke.price;
            }        
        }
    }
}
