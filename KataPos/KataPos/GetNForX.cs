using System;
using System.Collections.Generic;
using System.Linq;

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
            var applicableItems = items.OfType<IndividualItem>().Where(item => item.Barcode == Barcode);

            if (!applicableItems.Any()) return 0;

            var eachesPrice = applicableItems.First().EachesPrice;

            var count = applicableItems.Count();

            var bundles = count / TriggerQuantity;

            var extras = count % TriggerQuantity;

            return (-eachesPrice * bundles * TriggerQuantity) + (bundles * BundlePrice); 
        }
    }
}
