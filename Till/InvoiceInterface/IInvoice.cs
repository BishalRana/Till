using System;
using System.Collections.Generic;
using Till.Data;

namespace Till.InvoiceInterface
{
    public interface IInvoice
    {
        void RemoveFood(List<Item> items);
        void AddFoods(List<Item> item);
        double TotalFoodCost(List<Item> item);
    }
}
