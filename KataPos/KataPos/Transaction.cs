using System;
using System.Collections.Generic;

namespace KataPos
{
    public class Transaction
    {
        public IList<Item> Items { get; } = new List<Item>();

        public int TotalValue { get; set; }
        public Dictionary<string, Item> Catalog { get; set; } = new Dictionary<string, Item>();

        public void Scan(string barcode)
        {
            if (Catalog.ContainsKey(barcode))
                Items.Add(Catalog[barcode]);
            else
                throw new Exception($"No item matching barcode ${barcode} was found.");
        }
    }
}
