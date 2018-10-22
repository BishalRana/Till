using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
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
                PageLoadAttributeInitialization();
            }
        }

        protected void PageLoadAttributeInitialization()
        {
            if (Session["bentoList"] == null)
            {
                List<string> bentos = new List<string>()
                     {
                        BentoEnum.ChickenCurry.ToString(),
                        BentoEnum.ChickenTeriyaki.ToString(),
                        BentoEnum.CurrySauce.ToString(),
                        BentoEnum.PorkBulgogi.ToString()
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
                List<Item> listItems = new List<Item>();
                Session["items"] = listItems;
            }

            if (Session["serviceType"] == null)
            {
                ServiceType.Text = ServiceEnum.EATIN.ToString();
                serviceName = ServiceEnum.EATIN.ToString();
                serviceImg.Src = "/images/eatin.jpg";
            }
            else
            {
                ServiceType.Text = Session["serviceType"].ToString();
                serviceImg.Src = Session["serviceImage"].ToString();
            }

            ttlCost.Text = "£" + Invoice.CalculateTotalCost((List<Item>)Session["items"]).ToString();
            Session["totalCost"] = ttlCost.Text;
            Session["serviceType"] = ServiceType.Text;
            Session["serviceImage"] = serviceImg.Src;
            purchasedFoodView.DataSource = (List<Item>)Session["items"];
            purchasedFoodView.DataBind();

        }

        //this method gets called during pagination
        protected void invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Session["pageIndex"] = e.NewPageIndex;
            Response.Redirect("Default.aspx");
        }


        //this method gets called on clicking add item or remove item button in a row
        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {

            try
            {
                // Retrieve the row index stored in the 
                // CommandArgument property
                int index = Convert.ToInt32(e.CommandArgument);
                Console.WriteLine("Index " + index);
                GridViewRow row = purchasedFoodView.Rows[index];

                if (e.CommandName == "RemoveItem")
                {

                    // Retrieve the row that contains the button 
                    // from the Rows collection.
                    string itemName = row.Cells[0].Text;

                    Invoice invoice = new Invoice(new InvoiceIndustry().createInvoiceType(itemName));
                    invoice.DeductInItem(Get_Service(), (List<Item>)Session["items"], itemName);
                    invoice.RemoveFood((List<Item>)Session["items"]);
                    Custom_GridView(itemName);
                }

                if (e.CommandName == "AddItem")
                {

                    string itemName = row.Cells[0].Text;
                    Bill(itemName);
                }

                if (e.CommandName == "ItemInfo")
                {
                    string itemName = row.Cells[0].Text;
                    Server.Transfer("/Info.aspx?itemName=" + itemName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message "+ex.Message);
            }
        }


        public void Checkout_Click(object sender, EventArgs e)
        {
            Server.Transfer("/Bill.aspx");
        }

        //this method gets called on clicking add bento button
        protected void Bento_Click(object sender, EventArgs e)
        {  try
            {
                Bill(BentoList.SelectedValue);
            }
            catch(Exception )
            {
                PageLoadAttributeInitialization();
            }
        }

        //this methid gets called on clicking add sushi button
        protected void Sushi_Click(object sender, EventArgs e)
        {
            try
            {
                Bill(SushiList.SelectedValue);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Message "+ex.Message);
                PageLoadAttributeInitialization();
            }
        }

        //this method gets called on clicking add drink button
        protected void Drink_Click(object sender, EventArgs e)
        {
            try
            {
                Bill(DrinkList.SelectedValue);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message "+ex.Message);
                PageLoadAttributeInitialization();
            }
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
            Session["serviceImage"] = "/images/eatin.jpg";
            serviceName = ServiceEnum.EATIN.ToString();
            Service_Type();
        }


        protected void Takeaway_Click(object sender, EventArgs e)
        {
            Session["serviceType"] =  "TAKEWAY";
            Session["serviceImage"] = "/images/takeway.jpg";
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
