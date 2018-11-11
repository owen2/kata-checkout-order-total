using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataPos.Test
{
    [TestClass]
    public class BuyNGetPercentOffTests
    {
        [TestMethod]
        public void BuyOneDogfoodGetOneDogfoodFree()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogfoodDoesntGiveAwayFreeDogfood()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetOneDogFoodHalfOff()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 2, PercentOff = .5m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m + 20m + 10m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetOneDogFoodHalfOffOneExtra()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 2, PercentOff = .5m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m + 20m + 10m + 20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyThreeDogFoodsGetOneDogFoodHalfOffDoesntApply()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 3, PercentOff = .5m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(60m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogFoodGetOneDogFoodFreeLimitTwo()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m, Limit = 2 });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(60m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogFoodGetOneDogFoodFreeNoLimit()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(40m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetTwoDogFoodsHalfOff()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 2, PercentOff = .5m, DiscountQuantity = 2 });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m + 20m + 10m + 10m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetTwoDogFoodsHalfOffPlusAnExtra()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 2, PercentOff = .5m, DiscountQuantity = 2 });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m + 20m + 10m + 10m + 20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void UnscanDoesntGiveAwayFreeDogfood()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);

            order.UnScan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }
    }
}
