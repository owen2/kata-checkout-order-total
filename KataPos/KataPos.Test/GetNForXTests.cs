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
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m });

            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");

            Assert.AreEqual(3 * 1.25m, order.PreTaxTotal);
        }

        [TestMethod]
        public void FiveForFive()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
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
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new GetNForXSpecial { Barcode = "pear", TriggerQuantity = 5, BundlePrice = 5m });

            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");
            order.Scan("pear");

            Assert.AreEqual(5m + 1.25m, order.PreTaxTotal);
        }
    }
}
