using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPos
{
    public class MarkdownSpecial : ISpecial
    {
        public string Barcode { get; set; }
        public decimal Amount { get; set; }
        public int? Limit { get; private set; }

        public MarkdownSpecial(string barcode, decimal amount, int? limit = null)
        {
            Barcode = barcode;
            Amount = amount;
            Limit = limit;
        }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            decimal discount = 0m;
            List<Item> applicableItems = items
                .Where(item => item.Barcode == Barcode)
                .OrderBy(item => item.Value).ToList();

            int discountedItemCount = Math.Min(Limit ?? applicableItems.Count, applicableItems.Count);
            discount += -Amount * applicableItems
                .Where(item => item.Barcode == Barcode)
                .Take(discountedItemCount)
                .Sum(item => item is ItemWithWeight ? (item as ItemWithWeight).Weight : 1);

            return discount;
        }
    }
}
