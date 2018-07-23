using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.DrinkTypeInvoice
{
    public class FantaInvoice : IDrinkInvoice
    {
        public FantaInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, DrinkEnum.Fanta.ToString()))
            {
                items.Add(new Item
                {
                    itemName = DrinkEnum.Fanta.ToString(),
                    price = DrinkPrice.Fanta,
                    qty = 1,
                    totalCost = DrinkPrice.Fanta
                });
            }
            else
            {
                Item fanta = items.First(s => s.itemName == DrinkEnum.Fanta.ToString());
                fanta.qty = fanta.qty + 1;
                fanta.totalCost = fanta.price * fanta.qty;

            }       
        }

        public void RemoveFood(List<Item> items)
        {
            Item fanta = items.First(s => s.itemName == DrinkEnum.Fanta.ToString());

            if (fanta.qty == 1)
            {
                items.Remove(fanta);
            }
            else if (fanta.qty > 1)
            {
                fanta.qty = fanta.qty - 1;
                fanta.totalCost = fanta.totalCost - fanta.price;
            }      
        }
    }
}
