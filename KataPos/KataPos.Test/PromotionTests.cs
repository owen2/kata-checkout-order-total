using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataPos.Test
{
    [TestClass]
    public class PromotionTests
    {
        [TestMethod]
        public void MarkdownGeneratesNegativeValue()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new Markdown("pear", .25m));
            order.Scan("pear");
            Assert.AreEqual(1m, order.PreTaxTotal);
        }
    }
}
