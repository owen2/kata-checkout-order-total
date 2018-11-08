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
            ["carrot"] = new Item(),
            ["dog-food"] = new Item(),
            ["pear"] = new Item(),
            ["steak"] = new Item(),
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
            var transaction = new Transaction() { Catalog = _testCatalog };
            transaction.Scan("dog-food");
            Assert.AreNotEqual(0, transaction.TotalValue);
        }
    }
}
