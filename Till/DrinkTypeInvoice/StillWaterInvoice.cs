using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.DrinkTypeInvoice
{
    public class StillWaterInvoice : IDrinkInvoice
    {
        public StillWaterInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            if (!UtilityService.CheckItemExists(items, DrinkEnum.StillWater.ToString()))
            {
                items.Add(new Item
                {
                    itemName = DrinkEnum.StillWater.ToString(),
                    price = DrinkPrice.StillWater,
                    qty = 1,
                    totalCost = DrinkPrice.StillWater
                });
            }
            else
            {
                Item stillWater = items.First(s => s.itemName == DrinkEnum.StillWater.ToString());
                stillWater.qty = stillWater.qty + 1;
                stillWater.totalCost = stillWater.price * stillWater.qty;

            }       
        }

        public void RemoveFood(List<Item> items)
        {
            Item stillWater = items.First(s => s.itemName == DrinkEnum.StillWater.ToString());

            if (stillWater.qty == 1)
            {
                items.Remove(stillWater);
            }
            else if (stillWater.qty > 1)
            {
                stillWater.qty = stillWater.qty - 1;
                stillWater.totalCost = stillWater.totalCost - stillWater.price;
            }           
        }
    }
}
