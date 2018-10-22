using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Till.Data;

namespace Till
{

    public partial class Bill : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.PreviousPage != null)
            {
                try
                {
                    var obj = from i in (List<Item>)Session["items"]
                              select new { name = i.itemName, price = i.price, amount = i.totalCost, quantity = i.qty };


                    TableHeaderRow tableHeaderRow = new TableHeaderRow();
                    tableBill.Rows.Add(tableHeaderRow);

                    TableHeaderCell tableHeaderCell1 = new TableHeaderCell();
                    tableHeaderCell1.Text = "Name";
                    tableHeaderRow.Cells.Add(tableHeaderCell1);

                    TableHeaderCell tableHeaderCell2 = new TableHeaderCell();
                    tableHeaderCell2.Text = "Price";
                    tableHeaderRow.Cells.Add(tableHeaderCell2);

                    TableHeaderCell tableHeaderCell3 = new TableHeaderCell();
                    tableHeaderCell3.Text = "Quantity";
                    tableHeaderRow.Cells.Add(tableHeaderCell3);

                    TableHeaderCell tableHeaderCell4 = new TableHeaderCell();
                    tableHeaderCell4.Text = "Amount";
                    tableHeaderRow.Cells.Add(tableHeaderCell4);


                    foreach (var item in obj)
                    {
                        TableRow tableRow = new TableRow();
                        tableBill.Rows.Add(tableRow);

                        TableCell tableCell1 = new TableCell();
                        tableCell1.Text = item.name;
                        tableRow.Cells.Add(tableCell1);

                        TableCell tableCell2 = new TableCell();
                        tableCell2.Text = item.price.ToString();
                        tableRow.Cells.Add(tableCell2);

                        TableCell tableCell3 = new TableCell();
                        tableCell3.Text = item.quantity.ToString();
                        tableRow.Cells.Add(tableCell3);

                        TableCell tableCell4 = new TableCell();
                        tableCell4.Text = item.amount.ToString();
                        tableRow.Cells.Add(tableCell4);

                    }
                    TableFooterRow tableFooterRow = new TableFooterRow();
                    tableBill.Rows.Add(tableFooterRow);
                    TableCell tableCellFooter1 = new TableCell();
                    tableCellFooter1.Text = "";
                    tableFooterRow.Cells.Add(tableCellFooter1);

                    TableCell tableCellFooter2 = new TableCell();
                    tableCellFooter2.Text = "";
                    tableFooterRow.Cells.Add(tableCellFooter2);

                    TableCell tableCellFooter3 = new TableCell();
                    tableCellFooter3.Text = "Total Cost";
                    tableFooterRow.Cells.Add(tableCellFooter3);

                    TableCell tableCellFooter4 = new TableCell();
                    tableCellFooter4.Text = Session["totalCost"].ToString();
                    tableFooterRow.Cells.Add(tableCellFooter4);

                    service.Text = Session["serviceType"].ToString();

                    Session["items"] = null;
                    Session["selectedItem"] = null;
                    Session["pageIndex"] = null;
                    Session["serviceType"] = null;
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Message "+ex.Message);
                }

            }
        }

        protected void Send(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

    }
}
