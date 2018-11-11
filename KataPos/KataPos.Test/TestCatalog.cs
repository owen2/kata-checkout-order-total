using System;
using System.Collections.Generic;

namespace KataPos.Test
{
    public static class TestCatalog
    {
        public static Dictionary<string, CatalogEntry> Catalog { get; } = new Dictionary<string, CatalogEntry>
        {
            ["dog-food"] = new CatalogEntry { Barcode = "dog-food", Price = 20m },
            ["pear"] = new CatalogEntry { Barcode = "pear", Price = 1.25m },
            ["steak"] = new CatalogEntry { Barcode = "steak", Price = 10m },
        };
    }
}
