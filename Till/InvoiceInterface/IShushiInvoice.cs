﻿using System;
using System.Collections.Generic;
using Till.Data;

namespace Till.InvoiceInterface
{
    public interface IShushiInvoice
    {
        void RemoveFood(List<Item> items);
        void AddFoods(List<Item> items);
    }
}
