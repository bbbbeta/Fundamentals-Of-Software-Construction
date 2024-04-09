using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5.Tests
{
    [TestClass]
    public class OrderDetailsTests
    {
        [TestMethod]
        public void QuantityTest_NegativeValue()
        {
            OrderDetails orderDetails = new OrderDetails(1, "Test Product", 0, 10.00m);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => orderDetails.Quantity = -1);
        }

        [TestMethod]
        public void UnitPriceTest_NegativeValue()
        {
            OrderDetails orderDetails = new OrderDetails(1, "Test Product", 1, 0.00m);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => orderDetails.UnitPrice = -1.00m);
        }

        [TestMethod]
        public void EqualsTest()
        {
            OrderDetails details1 = new OrderDetails(1, "Product A", 2, 50.00m);
            OrderDetails details2 = new OrderDetails(1, "Product A", 2, 50.00m);
            bool areEqual = details1.Equals(details2);
            Assert.IsTrue(areEqual, "The Equals method should return true for OrderDetails with the same properties.");
        }

        [TestMethod]
        public void ToStringTest()
        {
            OrderDetails orderDetails = new OrderDetails(1, "Product A", 2, 50.00m);
            string result = orderDetails.ToString();
            string expected = "Product A (Quantity: 2, Unit Price: 50.00, Total: 100.00)";
            Assert.AreEqual(expected, result, "The ToString method did not return the expected string representation.");
        }
    }
}