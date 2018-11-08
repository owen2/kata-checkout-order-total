using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPos;

namespace KataPos.Test
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void EmptyTransactionHasNoValue()
        {
            var transaction = new Transaction();
            Assert.AreEqual(0, transaction.TotalValue);
        }
    }
}
