using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Till.Data;
using Till.FoodService;
using Till.InvoiceFactory;
using Till.MainInvoice;
using Till.ServiceInterface;
using Till.WebControl;
using static Till.FoodService.Service;
using static Till.FoodService.Service.ServiceFactory;

namespace Till
{

    public partial class Default : System.Web.UI.Page
    {
        public static string serviceName = "EATIN";

        public int Se { get; private set; }

        Service service;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["bentoList"] == null)
                {
                    List<string> bentos = new List<string>()
                     {
                        BentoEnum.ChickenCurry.ToString(),
                        BentoEnum.ChickenTeriyaki.ToString(),
                        BentoEnum.CurrySauce.ToString(),
                        BentoEnum.PorkBulagi.ToString(),
                        BentoEnum.SpicyChicken.ToString()
                     };
                    Session["bentoList"] = bentos;
                }


                BentoList.DataSource = from i in (List<string>)Session["bentoList"]
                                       select new ListItem()
                                       {
                                           Text = i,
                                           Value = i
                                       };
                BentoList.DataBind();

                if (Session["sushiList"] == null)
                {
                    List<string> sushis = new List<string>()
                         {
                            SushiEnum.ChumakiSet.ToString(),
                            SushiEnum.HarmonySet.ToString(),
                            SushiEnum.MixedMakiSet.ToString(),
                            SushiEnum.RainBowSet.ToString()
                         };
                    Session["sushiList"] = sushis;
                }


                SushiList.DataSource = from i in (List<string>)Session["sushiList"]
                                       select new ListItem()
                                       {
                                           Text = i,
                                           Value = i
                                       };
                SushiList.DataBind();



                if (Session["drinkList"] == null)
                {
                    List<string> drinks = new List<string>()
                    {
                        DrinkEnum.Coke.ToString(),
                        DrinkEnum.ZeroCoke.ToString(),
                        DrinkEnum.StillWater.ToString(),
                        DrinkEnum.Fanta.ToString()
                    };

                    Session["drinkList"] = drinks;
                }

                if (Session["drinkList"] != null)
                {
                    DrinkList.DataSource = from i in (List<string>)Session["drinkList"]
                                           select new ListItem()
                                           {
                                               Text = i,
                                               Value = i
                                           };
                    DrinkList.DataBind();
                }


                if (Session["pageIndex"] != null && !string.IsNullOrEmpty(Session["pageIndex"].ToString()))
                {
                    purchasedFoodView.PageIndex = (int)Session["pageIndex"];
                }

                if (Session["selectedItem"] != null && !string.IsNullOrEmpty(Session["selectedItem"].ToString()))
                {
                    DrinkList.SelectedIndex = DrinkList.Items.IndexOf(DrinkList.Items.FindByText(Session["selectedItem"].ToString()));
                }

                if (Session["items"] == null)
                {
                    Debug.WriteLine("Session is null");
                    Session["items"] = new List<Item>();
                }

                if (Session["serviceType"] == null)
                {
                    ServiceType.Text = ServiceEnum.EATIN.ToString();
                    serviceName = ServiceEnum.EATIN.ToString();
                }
                else
                {
                    ServiceType.Text = Session["serviceType"].ToString();
                }

                ttlCost.Text = "£" + Invoice.CalculateTotalCost((List<Item>)Session["items"]).ToString();
                purchasedFoodView.DataSource = (List<Item>)Session["items"];
                purchasedFoodView.DataBind();

            }
        }


        //this method get called on page render
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in purchasedFoodView.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    r.ToolTip = "Click to reduce product quantity";
                    r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(purchasedFoodView, "Select$" + r.RowIndex, true);
                }
            }

            base.Render(writer);
        }


        //this method gets called during pagination
        protected void invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Session["pageIndex"] = e.NewPageIndex;
            Response.Redirect("Default.aspx");
        }

        //this method gets called when the row is selected, retrieving the cell 0 value
        protected void invoice_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string itemName = purchasedFoodView.SelectedRow.Cells[0].Text;
            Invoice invoice = new Invoice(new InvoiceIndustry().createInvoiceType(itemName));
            invoice.DeductInItem(Get_Service(),(List<Item>)Session["items"], itemName);
            invoice.RemoveFood((List<Item>)Session["items"]);           
            Custom_GridView(itemName);
        }

        public void Checkout_Click(object sender, EventArgs e)
        {
            Session["items"] = null;
            Session["selectedItem"] = null;
            Session["pageIndex"] = null;
            Session["serviceType"] = null;
            Response.Redirect("Default.aspx");
        }

        //this method gets called on clicking add bento button
        protected void Bento_Click(object sender, EventArgs e)
        {
            Bill(BentoList.SelectedValue);
        }

        //this methid gets called on clicking add sushi button
        protected void Sushi_Click(object sender, EventArgs e)
        {
            Bill(SushiList.SelectedValue);
        }

        //this method gets called on clicking add drink button
        protected void Drink_Click(object sender, EventArgs e)
        {
            Bill(DrinkList.SelectedValue);
        }

        //this method gets called to add items in the invoice
        public void Bill(string itemName)
        {
            Invoice invoice = new Invoice(new InvoiceIndustry().createInvoiceType(itemName));
            Session["selectedItem"] = itemName;
            invoice.AddFood((List<Item>)Session["items"]);
            invoice.ChargeInItem(Get_Service(),(List<Item>)Session["items"], itemName);
            Custom_GridView(itemName);
        }

        //to customize the page number in web page
        public void Custom_GridView(string itemName)
        {
            UICustom custom = new UICustom(purchasedFoodView);
            custom.SetItemPageNumber((List<Item>)Session["items"],itemName);
            custom.SetColorToItem((List<Item>)Session["items"],itemName);
            Response.Redirect("Default.aspx");
        }

        protected void EatIn_Click(object sender, EventArgs e)
        {
            ServiceType.Text = "EAT IN";
            Session["serviceType"] = ServiceEnum.EATIN.ToString();
            serviceName = ServiceEnum.EATIN.ToString();
            Service_Type();
        }


        protected void Takeaway_Click(object sender, EventArgs e)
        {
            Session["serviceType"] =  "TAKEWAY";
            serviceName = ServiceEnum.TAKEWAY.ToString();
            Service_Type();
        }

        protected void Service_Type()
        {
            service = Get_Service();
            new Invoice().ChargeInAllItems((List<Item>)Session["items"],service);
            Response.Redirect("Default.aspx");
        }

        protected Service Get_Service()
        {
            return new ServiceFactory().createSerivceType(serviceName);
        }


       
    }

}
