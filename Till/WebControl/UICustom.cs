using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Till.Data;
using Till.MainInvoice;

namespace Till.WebControl
{
    public class UICustom
    {
        private GridView gridView;
        public int pageIndex { get; set; }
        public UICustom()
        {

        }
        public UICustom(GridView gridView)
        {
            this.gridView = gridView;
        }

        //showing the page where added item is set
        public void SetItemPageNumber(List<Item> items, string itemName)
        {
            int itemIndex = items.FindIndex(s => s.itemName == itemName);
            if(itemIndex  >= 0)
            {
                Item item = items.Find(s => s.itemName == itemName);
                int numberOfContentPerPage = 0;
                int pageNumber = 0;
                do
                {
                    pageNumber = pageNumber + 1;
                    numberOfContentPerPage = numberOfContentPerPage + gridView.PageSize;

                } while (!(itemIndex < numberOfContentPerPage));

                gridView.SetPageIndex(pageNumber - 1);
                pageIndex = pageNumber - 1;
            }

         
        }

        //set color to added item ,need to be done
        public void SetColorToItem(List<Item> items,string itemName)
        {
            Item item = items.Find(s => s.itemName == itemName);
        }
    }
}
