namespace assignment5.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void SetOrderIdTest()
        {
            int OrderId = 123;
            DateTime OrderDate = DateTime.Now;
            Order order = new Order(OrderId, "ORD123", OrderDate);
            Assert.AreEqual(OrderId, order.OrderId, "The OrderId property was not set correctly.");
        }

        [TestMethod()]
        public void SetOrderNumberTest()
        {
            string OrderNumber = "ORD123";
            Order order = new Order(1, OrderNumber, DateTime.Now);
            Assert.AreEqual(OrderNumber, order.OrderNumber, "The OrderNumber property was not set correctly.");
        }

        [TestMethod()]
        public void SetOrderDateTest()
        {
            DateTime OrderDate = DateTime.Now;
            Order order = new Order(1, "ORD123", OrderDate);
            Assert.AreEqual(OrderDate, order.OrderDate, "The OrderDate property was not set correctly.");
        }

        [TestMethod()]
        public void OrderEqualsTest()
        {
            //正常，返回true
            int orderId = 123;
            Order order1 = new Order(orderId, "ORD123", DateTime.Now);
            Order order2 = new Order(orderId, "ORD123", DateTime.Now);
            bool areEqual = order1.Equals(order2);
            Assert.IsTrue(areEqual, "The Equals method should return true for orders with the same OrderId.");
        }

        [TestMethod()]
        public void OrderEqualsTest1()
        {
            //不相同，返回false
            Order order1 = new Order(1, "ORD001", DateTime.Now);
            Order order2 = new Order(2, "ORD002", DateTime.Now);
            bool areEqual = order1.Equals(order2);
            Assert.IsFalse(areEqual, "The Equals method should return false for orders with different OrderIds.");
        }

        [TestMethod()]
        public void OrderEqualsNullTest()
        {
            //其中一个为null。返回false
            Order order = new Order(1, "ORD001", DateTime.Now);
            bool areEqual = order.Equals(null);
            Assert.IsFalse(areEqual, "The Equals method should return false when compared to null.");
        }

        [TestMethod()]
        public void OrderEqualsNonOrderObjectTest()
        {
            //其中一个不是Order类型的实例
            Order order = new Order(1, "ORD001", DateTime.Now);
            object nonOrderObject = new object();
            bool areEqual = order.Equals(nonOrderObject);
            Assert.IsFalse(areEqual, "The Equals method should return false when compared to a non-Order object.");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Order order = new Order(1, "ORD001", DateTime.Now);
            List<OrderDetails> details1 = new List<OrderDetails>
            {
                new OrderDetails(101, "草莓", 2, 10.00m),
                new OrderDetails(102, "奶茶", 1, 12.00m)
            };
            order.Details.AddRange(details1);
            string result = order.ToString();
            string expected = $"Order Number: ORD001, Date: 2024-04-09, Total Amount: 32.00";
            Assert.AreEqual(expected, result, "The ToString method did not return the expected string representation.");
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Order order1 = new Order(1, "ORD001", DateTime.Now);
            Order order2 = new Order(2, "ORD002", DateTime.Now);
            int hash1 = order1.GetHashCode();
            int hash2 = order2.GetHashCode();
            Assert.AreNotEqual(hash1, hash2, "GetHashCode should return different values for orders with different OrderIds.");
        }
    }
}