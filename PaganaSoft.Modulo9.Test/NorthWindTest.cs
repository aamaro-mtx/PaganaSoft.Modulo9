using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWindData.Data;

namespace PaganaSoft.Modulo9.Test
{
    [TestClass]
    public class NorthWindTest
    {
        [TestMethod]
        public void TestCategories()
        {
            var repository = new NorthWindRepository();
            Assert.IsNotNull(repository.GetCategories());
        }

        [TestMethod]
        public void TestProducts()
        {
            var repository = new NorthWindRepository();
            Assert.AreEqual(repository.GetProductsByCategory(1).Count, 12);
        }

        [TestMethod]
        public void TestGetOrderByProduct()
        {
            var repository = new NorthWindRepository();
            Assert.AreEqual(repository.GetOrdersByProduct(11).Count, 38);
        }

        [TestMethod]
        public void TestGetQuantityByOrder()
        {
            var repository = new NorthWindRepository();
            Assert.AreEqual(repository.GetQuantityByOrder(10248, 11), 12);
        }
}
}
