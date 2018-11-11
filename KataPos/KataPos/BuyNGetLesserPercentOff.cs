using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPos
{
    public class BuyNGetLesserPercentOff : ISpecial
    {
        public string Barcode { get; set; }
        public decimal TriggerWeight { get; set; }
        public decimal PercentOff { get; set; }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            var applicableItems = items.OfType<ItemByWeight>().Where(item => item.Barcode == Barcode).OrderBy(item => item.Value).ToList();

            var aboveTriggerCount = applicableItems.Count(item => item.Weight >= TriggerWeight);
            var totalCount = applicableItems.Count();

            return -applicableItems.Take(Math.Min(totalCount / 2, aboveTriggerCount)).Sum(item => item.Value);
        }
    }
}
