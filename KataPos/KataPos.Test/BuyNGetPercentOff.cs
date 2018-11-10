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
            order.Promotions.Add(new BuyNGetPercentOff { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });
            order.Scan("dog-food");
            order.Scan("dog-food");
            Assert.AreEqual(20m, order.PreTaxTotal);
        }

        [TestMethod]
        public void BuyOneDogfoodDoesntGiveAwayFreeDogfood()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new BuyNGetPercentOff { Barcode = "dog-food", TriggerQuantity = 1, PercentOff = 1m });
            order.Scan("dog-food");
            Assert.AreEqual(20m, order.PreTaxTotal);
        }
    }
}
