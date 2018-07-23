using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.BentoTypeInvoice
{
    public class ChickenTeriyakiInvoice:IBentoInvoice
    {
        public ChickenTeriyakiInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            try
            {
                if (!UtilityService.CheckItemExists(items, BentoEnum.ChickenTeriyaki.ToString()))
                {
                    items.Add(new Item
                    {
                        itemName = BentoEnum.ChickenTeriyaki.ToString(),
                        price = BentoPrice.ChickenTeriyaki,
                        qty = 1,
                        totalCost = BentoPrice.ChickenTeriyaki
                    });
                }
                else
                {
                    Item chickenTeriyaki = items.First(s => s.itemName == BentoEnum.ChickenTeriyaki.ToString());
                    chickenTeriyaki.qty = chickenTeriyaki.qty + 1;
                    chickenTeriyaki.totalCost = chickenTeriyaki.price * chickenTeriyaki.qty;

                }
            }
            catch (NullReferenceException nre)
            {
                Debug.WriteLine(nre.Message);
            }
                   
           
        }

        public void RemoveFood(List<Item> items)
        {
           
            Item chickenTeriyaki = items.First(s => s.itemName == BentoEnum.ChickenTeriyaki.ToString());

            if (chickenTeriyaki.qty == 1)
            {
                items.Remove(chickenTeriyaki);
            }
            else if (chickenTeriyaki.qty > 1)
            {
                chickenTeriyaki.qty = chickenTeriyaki.qty - 1;
                chickenTeriyaki.totalCost = chickenTeriyaki.totalCost - chickenTeriyaki.price;
            }
        }
    }
}
