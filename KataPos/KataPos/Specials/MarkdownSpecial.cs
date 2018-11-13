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

        public MarkdownSpecial(string barcode, decimal amount, int? limit=null)
        {
            Barcode = barcode;
            Amount = amount;
            Limit = limit;
        }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            var discount = 0m;
            discount += -Amount * items.OfType<IndividualItem>().Count(item => item.Barcode == Barcode);
            discount += -Amount * items.OfType<ItemWithWeight>().Where(item => item.Barcode == Barcode).Sum(item => item.Weight);
            return discount;
        }
    }
}
