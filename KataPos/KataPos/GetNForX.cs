using System;
using System.Collections.Generic;

namespace KataPos
{
    public class GetNForX : ISpecial
    {
        private string Barcode;
        private int TriggerQuantity;
        private decimal BundlePrice;

        public GetNForX(string barcode, int triggerQuantity, decimal bundlePrice)
        {
            Barcode = barcode;
            TriggerQuantity = triggerQuantity;
            BundlePrice = bundlePrice;
        }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
