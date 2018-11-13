using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataPos.Test
{
    [TestClass]
    public class GetNForXTests
    {
        [TestMethod]
        public void FiveForFiveDoesntApply()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m });

            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");

            Assert.AreEqual(3 * 1.25m, order.PreTaxTotal);
        }

        [TestMethod]
        public void FiveForFive()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m });

            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");

            Assert.AreEqual(5m, order.PreTaxTotal);
        }

        [TestMethod]
        public void FiveForFiveTooMany()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m });

            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");

            Assert.AreEqual(5m + 1.25m, order.PreTaxTotal);
        }

        [TestMethod]
        public void FiveForFiveLimitTwenty()
        {
            Order order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m, Limit = 20 });

            for (int i = 0; i < 25; i++)
            {
                order.Scan("pear");
            }

            Assert.AreEqual((5m * 4m) + (5m * 1.25m), order.PreTaxTotal);
        }
    }
}
