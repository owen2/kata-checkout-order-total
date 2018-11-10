using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPos
{
    public class Markdown : IPromotion
    {
        public string Barcode { get; set; }
        public decimal Amount { get; set; }

        public Markdown(string barcode, decimal amount)
        {
            Barcode = barcode;
            Amount = amount;
        }

        public decimal CalculateDiscount(IEnumerable<Item> items)
        {
            var discount = 0m;
            discount += -Amount * items.OfType<IndividualItem>().Count(item => item.Barcode == Barcode);
            discount += -Amount * items.OfType<ItemByWeight>().Where(item => item.Barcode == Barcode).Sum(item => item.Weight);
            return discount;
        }
    }
}
