using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataPos.Test
{
    [TestClass]
    public class MarkdownTests
    {
        [TestMethod]
        public void MarkdownGeneratesNegativeValue()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new Markdown("pear", .25m));
            order.Scan("pear");
            Assert.AreEqual(1m, order.PreTaxTotal);
        }

        [TestMethod]
        public void MarkdownGeneratesNegativeValueOnItemByWeight()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new Markdown("steak", 1m));
            order.Scan("steak", 2m);
            Assert.AreEqual(18m, order.PreTaxTotal);
        }

        [TestMethod]
        public void MultipleMarkdownsAreOkay()
        {
            var order = new Order { Catalog = TestCatalog.Catalog };
            order.Promotions.Add(new Markdown("pear", .25m));
            order.Promotions.Add(new Markdown("steak", 1m));
            order.Scan("steak", 2m);
            order.Scan("pear");
            Assert.AreEqual(19m, order.PreTaxTotal);
        }
    }
}
