using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPos
{
    public class BuyNGetLesserPercentOffSpecial : ISpecial
    {
        public string Barcode { get; set; }
        public int TriggerQuantity { get; set; }
        public decimal TriggerWeight { get; set; }
        public decimal PercentOff { get; set; }
        public int DiscountedQuantity { get; set; } = 1;

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            var applicableItems = items.OfType<ItemWithWeight>().Where(item => item.Barcode == Barcode).OrderBy(item => item.Value).ToList();

            var aboveTriggerCount = applicableItems.Count(item => item.Weight >= TriggerWeight);
            var groupCount = applicableItems.Count / (DiscountedQuantity + TriggerQuantity);

            return -applicableItems.Take(Math.Min(groupCount,aboveTriggerCount)*DiscountedQuantity).Sum(item => item.Value) * PercentOff;
        }
    }
}
