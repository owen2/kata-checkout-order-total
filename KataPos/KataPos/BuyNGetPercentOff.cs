using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPos
{
    public class BuyNGetPercentOff : ISpecial
    {

        public string Barcode { get; set; }

        public int TriggerQuantity { get; set; }

        public decimal PercentOff { get; set; }

        public int? Limit { get; set; }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            var applicableItems = items.OfType<IndividualItem>().Where(item => item.Barcode == Barcode);

            if (!applicableItems.Any())
                return 0m;

            var price = applicableItems.First().EachesPrice;
            var count = applicableItems.Count();
            if (Limit.HasValue)
                count = Math.Min(count, Limit.Value);

            var discountedItems = count / (TriggerQuantity + 1);
            return -discountedItems * price * PercentOff;
        }
    }
}
