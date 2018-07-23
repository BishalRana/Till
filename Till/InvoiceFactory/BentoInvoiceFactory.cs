using System;
using Till.BentoTypeInvoice;
using Till.Data;
using Till.InvoiceInterface;

namespace Till.InvoiceFactory
{
    //factory to create hotfood invoice object based on name
    public class BentoInvoiceFactory
    {
        
        public BentoInvoiceFactory()
        {
            
        }

        //method to create hotfood typed invoice like chickenteriyaki,
        public IBentoInvoice createBentoInvoiceType(string itemName)
        {
            IBentoInvoice bentoType;
            BentoEnum bentoEnum;
            if (Enum.TryParse<BentoEnum>(itemName, out bentoEnum))
            {
                switch (bentoEnum)
                {
                    case BentoEnum.ChickenTeriyaki:
                        bentoType = new ChickenTeriyakiInvoice();
                        break;
                    case BentoEnum.CurrySauce:
                        bentoType = new CurrySauceInvoice();
                        break;
                    case BentoEnum.ChickenCurry:
                        bentoType = new ChickenCurryInvoice();
                        break;
                    case BentoEnum.SpicyChicken:
                        bentoType = new SpicyChickenInvoice();
                        break;
                    case BentoEnum.PorkBulagi:
                        bentoType = new PorkBulagiInvoice();
                        break;
                    default:
                        bentoType = null;
                        break;
                }

                return bentoType;
            }
            return null;
        }
    }
}
