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
            ["dog-food"] = new Item { Value = 20m },
            ["pear"] = new Item { Value = 1.25m },
            ["steak"] = new Item { Value = 10.99m },
        };

        [TestMethod]
        public void EmptyTransactionHasNoValue()
        {
            var transaction = new Transaction();
            Assert.AreEqual(0, transaction.TotalValue);
        }

        [TestMethod]
        public void AddingAndItemAddsValue()
        {
            var transaction = new Transaction { Catalog = _testCatalog };
            transaction.Scan("dog-food");
            Assert.AreNotEqual(0, transaction.TotalValue);
        }

        [TestMethod]
        public void BuyingDogFoodCostsTwenty()
        {
            var transaction = new Transaction { Catalog = _testCatalog };
            transaction.Scan("dog-food");
            Assert.AreEqual(20, transaction.TotalValue);
        }

        [TestMethod]
        public void BuyingMultiplePearsCostsFive()
        {
            var transaction = new Transaction { Catalog = _testCatalog };
            for (int i = 0; i < 4; i++)
            {
                transaction.Scan("pear");
            }
            Assert.AreEqual(5m, transaction.TotalValue);
        }
    }
}
