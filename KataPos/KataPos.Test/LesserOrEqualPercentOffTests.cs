using System;
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
            //order.Promotions.Add(new BuyNGetLesserPercentOff("steak", 2, 1m));
        }
    }
}
