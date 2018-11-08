using System;
using System.Collections.Generic;

namespace KataPos
{
    public class Transaction
    {
        public int TotalValue { get; set; }
        public Dictionary<string, Item> Catalog { get; set; } = new Dictionary<string, Item>();

        public void Scan(string v)
        {
            throw new NotImplementedException();
        }
    }
}
