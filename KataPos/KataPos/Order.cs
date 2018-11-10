using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPos
{
    public class Order
    {
        public IList<Item> Items { get; } = new List<Item>();

        public decimal PreTaxTotal => Items.Sum(i => i.Value) + Promotions.Sum(promo=> promo.CalculateDiscount(Items));
        public Dictionary<string, CatalogEntry> Catalog { get; set; } = new Dictionary<string, CatalogEntry>();
        public IList<ISpecial> Promotions { get; set; } = new List<ISpecial>();

        public void Scan(string barcode)
        {
            if (Catalog.ContainsKey(barcode))
                Items.Add(new IndividualItem(Catalog[barcode]));
            else
                throw new Exception($"No item matching barcode ${barcode} was found.");
        }

        public void UnScan(string barcode)
        {
            if (!Catalog.ContainsKey(barcode)) return;

            var item = Items.LastOrDefault(i => i.Barcode == barcode);
            Items.Remove(item);
        }

        public void Scan(string barcode, decimal weight)
        {
            if (Catalog.ContainsKey(barcode))
                Items.Add(new ItemByWeight(Catalog[barcode], weight));
        }
    }
}
