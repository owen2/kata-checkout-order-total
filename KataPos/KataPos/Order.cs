using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPos
{
    public class Order
    {
        public IList<Item> Items { get; } = new List<Item>();

        public decimal PreTaxTotal => Items.Sum(i => i.EachesPrice);
        public Dictionary<string, Item> Catalog { get; set; } = new Dictionary<string, Item>();

        public void Scan(string barcode)
        {
            if (Catalog.ContainsKey(barcode))
                Items.Add(Catalog[barcode]);
            else
                throw new Exception($"No item matching barcode ${barcode} was found.");
        }

        public void UnScan(string barcode)
        {
            if (!Catalog.ContainsKey(barcode)) return;

            var item = Catalog[barcode];
            Items.Remove(item);
        }

        public void Scan(string barcode, decimal weight)
        {
            Scan(barcode);
        }
    }
}
