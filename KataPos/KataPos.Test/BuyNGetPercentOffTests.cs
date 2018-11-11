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
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogfoodDoesntGiveAwayFreeDogfood()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetOneDogFoodHalfOff()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 2, PercentOff = .5m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m + 20m + 10m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoDogFoodsGetOneDogFoodHalfOffOneExtra()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
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
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 3, PercentOff = .5m });

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(60m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogFoodGetOneDogFoodFreeLimitTwo()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
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
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m});

            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(40m, order.PreTaxTotal);
        }

        [TestMethod]
        public void UnscanDoesntGiveAwayFreeDogfood()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOffSpecial { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });

            order.Scan("dog-food");
            order.Scan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);

            order.UnScan("dog-food");

            Assert.AreEqual(20m, order.PreTaxTotal);
        }
    }
}
