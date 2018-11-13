using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPos
{
    public class GetNForXSpecial : ISpecial
    {
        public string Barcode { get; set; }
        public int TriggerQuantity { get; set; }
        public decimal BundlePrice { get; set; }
        public int? Limit { get; set; }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            IEnumerable<IndividualItem> applicableItems = items.OfType<IndividualItem>().Where(item => item.Barcode == Barcode);

            if (!applicableItems.Any()) return 0;

            decimal eachesPrice = applicableItems.First().EachesPrice;

            int count = applicableItems.Count();

            int bundles = Math.Min(count, Limit ?? count) / TriggerQuantity;

            return (-eachesPrice * bundles * TriggerQuantity) + (bundles * BundlePrice);
        }
    }
}
