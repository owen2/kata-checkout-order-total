using System;
using System.Collections.Generic;

namespace KataPos
{
    public class BuyNGetLesserPercentOff : ISpecial
    {
        public BuyNGetLesserPercentOff(string barcode, decimal triggerWeight, decimal percentOff)
        {
            Barcode = barcode;
            TriggerWeight = triggerWeight;
            PercentOff = percentOff;
        }

        public string Barcode { get; set; }
        public decimal TriggerWeight { get; set; }
        public decimal PercentOff { get; set; }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
