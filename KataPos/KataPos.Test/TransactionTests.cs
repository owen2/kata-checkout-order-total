using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPos;
using System.Collections.Generic;

namespace KataPos.Test
{
    [TestClass]
    public class TransactionTests
    {
        readonly Dictionary<string, CatalogEntry> _testCatalog = new Dictionary<string, CatalogEntry>
        {
            ["dog-food"] = new CatalogEntry { Barcode = "dog-food", Price = 20m },
            ["pear"] = new CatalogEntry { Barcode = "pear", Price = 1.25m },
            ["steak"] = new CatalogEntry { Barcode = "steak", Price = 10m },
        };

        [TestMethod]
        public void EmptyTransactionHasNoValue()
        {
            var transaction = new Order();
            Assert.AreEqual(0, transaction.PreTaxTotal);
        }

        [TestMethod]
        public void AddingAndItemAddsValue()
        {
            var transaction = new Order { Catalog = _testCatalog };
            transaction.Scan("dog-food");
            Assert.AreNotEqual(0, transaction.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingDogFoodCostsTwenty()
        {
            var transaction = new Order { Catalog = _testCatalog };
            transaction.Scan("dog-food");
            Assert.AreEqual(20, transaction.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingMultiplePearsCostsFive()
        {
            var transaction = new Order { Catalog = _testCatalog };
            for (int i = 0; i < 4; i++)
            {
                transaction.Scan("pear");
            }
            Assert.AreEqual(5m, transaction.PreTaxTotal);
        }

        [TestMethod]
        public void ScanningAndUnscanningAnItemShouldHaveZeroValue()
        {
            var transaction = new Order { Catalog = _testCatalog };
            transaction.Scan("steak");
            transaction.UnScan("steak");
            Assert.AreEqual(0m, transaction.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingSteakUsesWeightToCalculateValue()
        {
            var transaction = new Order { Catalog = _testCatalog };
            transaction.Scan("steak", .5m);
            Assert.AreEqual(5m, transaction.PreTaxTotal);
        }
    }
}
