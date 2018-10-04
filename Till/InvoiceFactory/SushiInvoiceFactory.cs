using System;
using Till.Data;
using Till.InvoiceInterface;
using Till.SushiTypeInvoice;

namespace Till.InvoiceFactory
{
    public class SushiInvoiceFactory
    {
        public SushiInvoiceFactory()
        {
        }

        //method to create sushi typed invoice like HarmonySet,
        public IShushiInvoice createSushuInvoiceType(string itemName)
        {
            IShushiInvoice sushiType;
            SushiEnum sushiEnum;
            if (Enum.TryParse<SushiEnum>(itemName, out sushiEnum))
            {
                switch (sushiEnum)
                {
                    case SushiEnum.HarmonySet:
                        sushiType = new HarmonySetInvoice();
                        break;
                    case SushiEnum.ChumakiSet:
                        sushiType = new ChumakiSetInvoice();
                        break;
                    case SushiEnum.MixedMakiSet:
                        sushiType = new MixedMakiSetInvoice();
                        break;
                    case SushiEnum.RainBowSet:
                        sushiType = new RainBowSetInvoice();
                        break;
                    default:
                        sushiType = null;
                        break;
                }

                return sushiType;
            }
            return null;
        }
    }
}
