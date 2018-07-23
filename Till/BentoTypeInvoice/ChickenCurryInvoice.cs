using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Till.Data;
using Till.InvoiceInterface;
using Till.Utility;

namespace Till.BentoTypeInvoice
{
    public class ChickenCurryInvoice : IBentoInvoice
    {
        public ChickenCurryInvoice()
        {
        }

        public void AddFoods(List<Item> items)
        {
            try
            {
                if (!UtilityService.CheckItemExists(items, BentoEnum.ChickenCurry.ToString()))
                {
                    items.Add(new Item
                    {
                        itemName = BentoEnum.ChickenCurry.ToString(),
                        price = BentoPrice.ChickenCurry,
                        qty = 1,
                        totalCost = BentoPrice.ChickenCurry
                    });
                }
                else
                {
                    Item chickenCurry = items.First(s => s.itemName == BentoEnum.ChickenCurry.ToString());
                    chickenCurry.qty = chickenCurry.qty + 1;
                    chickenCurry.totalCost = chickenCurry.price * chickenCurry.qty;

                }
                
            }
            catch (NullReferenceException nre)
            {
                Debug.WriteLine(nre.Message);
            }
            catch (ArgumentNullException ae)
            {
                Debug.WriteLine(ae.Message);
            }                      
        }

        public void RemoveFood(List<Item> items)
        {
            try
            {
                Item chickenCurry = items.First(s => s.itemName == BentoEnum.ChickenCurry.ToString());

                if (chickenCurry.qty == 1)
                {
                    items.Remove(chickenCurry);
                }
                else if (chickenCurry.qty > 1)
                {
                    chickenCurry.qty = chickenCurry.qty - 1;
                    chickenCurry.totalCost = chickenCurry.totalCost - chickenCurry.price;
                }
            }
            catch(NullReferenceException nre)
            {
                Debug.WriteLine(nre.Message);
            }           
            catch (InvalidOperationException ioe)
            {
                Debug.WriteLine(ioe.Message);
            }
            catch (ArgumentNullException ane)
            {
                Debug.WriteLine(ane.Message);
            }

        }
    }
}
