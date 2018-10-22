using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Till.Data;

namespace Till
{

    public partial class Info : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.PreviousPage != null)
                {

                    string sendItem = Request.QueryString["ItemName"];
                    Console.WriteLine("SendItem " + sendItem);
                    XmlDocument xml = new XmlDocument();
                    xml.Load("ItemsFeature.xml");

                    string item = "'" + sendItem + "'";
                    Console.WriteLine("Item " + item);
                    XmlElement elt = xml.SelectSingleNode("//item[@Type=" + item + "]") as XmlElement;
                    if (elt != null)
                    {
                        itemName.Text = elt["name"].InnerText;
                        descInfo.InnerText = elt["description"].InnerText;
                        ingredients.Text = elt["ingredients"].InnerText;
                        itmImage.Src = elt["image"].InnerText;
                    }

                }  
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message " + ex.Message);
            }           
        }
        
        protected void Send(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");


        }
     }
}


