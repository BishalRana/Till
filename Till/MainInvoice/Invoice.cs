using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using Till.Data;
using Till.FoodService;
using Till.InvoiceInterface;
using Till.ServiceInterface;

namespace Till.MainInvoice
{
    public class Invoice
    {
        public IInvoice invoiceType;
        public Invoice()
        {
            

        }

        public Invoice(IInvoice invoiceType)
        {
            this.invoiceType = invoiceType;
        }

        public void AddFood(List<Item> items)
        {
            invoiceType.AddFoods(items);
        }

        public void RemoveFood(List<Item> items)
        {
            invoiceType.RemoveFood(items);
        }

        public static double CalculateTotalCost(List<Item> items)
        {
            double total = 0.0;
            foreach(Item item in items)
            {
                total = total + item.totalCost;
            }

            return total;
        }


        public void ChargeInAllItems(List<Item> items,Service service)
        {

            foreach (Item item in items)
            {
                service.Charge(item);
            }
        }

        public void ChargeInItem(Service service, List<Item> items,string itemName)
        {
            Item item = items.First(s => s.itemName == itemName);
            service.Charge(item);
        }

        public void DeductInAllItems(List<Item> items,Service service)
        {
            foreach (Item item in items)
            {
                service.DeductCharge(item);
            }

        }

        public void DeductInItem(Service service,List<Item>items, string itemName)
        {

            Item item = items.First(s => s.itemName == itemName);
            service.DeductCharge(item);
        }

    }

}
