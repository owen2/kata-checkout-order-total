using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPos;
using System.Collections.Generic;

namespace KataPos.Test
{
    [TestClass]
    public class TransactionTests
    {
        readonly Dictionary<string, Item> _testCatalog = new Dictionary<string, Item>
        {
            ["dog-food"] = new Item { EachesPrice = 20m },
            ["pear"] = new Item { EachesPrice = 1.25m },
            ["steak"] = new Item { EachesPrice = 10.99m },
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
            var transaction = new Order{Catalog = _testCatalog};
            transaction.Scan("steak");
            transaction.UnScan("steak");
            Assert.AreEqual(0m, transaction.PreTaxTotal);
        }
    }
}
