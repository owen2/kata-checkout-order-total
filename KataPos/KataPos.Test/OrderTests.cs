using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPos;
using System.Collections.Generic;

namespace KataPos.Test
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void EmptyTransactionHasNoValue()
        {
            var order = new Order();
            Assert.AreEqual(0, order.PreTaxTotal);
        }

        [TestMethod]
        public void AddingAndItemAddsValue()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Scan("dog-food");
            Assert.AreNotEqual(0, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingDogFoodCostsTwenty()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Scan("dog-food");
            Assert.AreEqual(20, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingMultiplePearsCostsFive()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            for (int i = 0; i < 4; i++)
            {
                order.Scan("pear");
            }
            Assert.AreEqual(5m, order.PreTaxTotal);
        }

        [TestMethod]
        public void ScanningAndUnscanningAnItemShouldHaveZeroValue()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Scan("steak");
            order.UnScan("steak");
            Assert.AreEqual(0m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyingSteakUsesWeightToCalculateValue()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Scan("steak", .5m);
            Assert.AreEqual(5m, order.PreTaxTotal);
        }
    }
}
