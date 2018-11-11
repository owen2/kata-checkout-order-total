﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataPos.Test
{
    [TestClass]
    public class LesserOrEqualPercentOffTests
    {
        [TestMethod]
        public void BuyOneSteakGetTheSmallerOneFree()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 1.9m, PercentOff = 1m, TriggerQuantity = 1 });

            order.Scan("steak", 2m);
            order.Scan("steak", 1m);

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneSteakGetEqualOneFree()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 2m, PercentOff = 1m, TriggerQuantity = 1 });

            order.Scan("steak", 2m);
            order.Scan("steak", 2m);

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneSteakNoFreeSteak()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 2m, PercentOff = 1m, TriggerQuantity=1 });

            order.Scan("steak", 2m);

            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoGetTwoSteaks()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 1m, PercentOff = 1m, TriggerQuantity =2, DiscountedQuantity =2 });

            order.Scan("steak", 1.3m);
            order.Scan("steak", 1.2m);
            order.Scan("steak", 1.1m);
            order.Scan("steak", 1.0m);

            Assert.AreEqual(13m + 12m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyTwoGetTwoSteaksByStackingBuyOneGetOne()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 1m, PercentOff = 1m, TriggerQuantity = 1, DiscountedQuantity = 1 });

            order.Scan("steak", 1.3m);
            order.Scan("steak", 1.2m);
            order.Scan("steak", 1.1m);
            order.Scan("steak", 1.0m);

            Assert.AreEqual(13m + 12m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneSteakGetTheSmallerTwoForHalfOff()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetLesserPercentOffSpecial { Barcode = "steak", TriggerWeight = 1m, PercentOff = .5m, DiscountedQuantity = 2, TriggerQuantity = 1 });

            order.Scan("steak", 1.3m);
            order.Scan("steak", 1.2m);
            order.Scan("steak", 1.1m);

            Assert.AreEqual(13m + 6m + 5.5m, order.PreTaxTotal);
        }

    }
}
