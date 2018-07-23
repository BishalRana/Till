using System;
using System.Collections.Generic;
using System.Linq;
using Till.Data;

namespace Till.Utility
{
    public class UtilityService
    {
        public static bool CheckItemExists(List<Item> items, string itemName)
        {
            return items.Any(item => item.itemName == itemName);
        }

        public static Item FindItem(List<Item> items, string itemName)
        {
            return items.First(s => s.itemName == itemName);
        }

        public static int FindIndex(List<Item> items, string itemName)
        {
            return items.FindIndex(s => s.itemName == itemName);
        }
    }
}
