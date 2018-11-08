using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPos
{
    public class Transaction
    {
        public IList<Item> Items { get; } = new List<Item>();

        public decimal TotalValue => Items.Sum(i => i.Value);
        public Dictionary<string, Item> Catalog { get; set; } = new Dictionary<string, Item>();

        public void Scan(string barcode)
        {
            if (Catalog.ContainsKey(barcode))
                Items.Add(Catalog[barcode]);
            else
                throw new Exception($"No item matching barcode ${barcode} was found.");
        }

        public void UnScan(string v)
        {
            throw new NotImplementedException();
        }
    }
}
