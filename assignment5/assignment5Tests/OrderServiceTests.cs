using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            Order order = new Order(1, "ORD001", DateTime.Now);
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.orders.Any(o => o.OrderId == order.OrderId));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrderTest_RepeatedAddition()
        {
            OrderService orderService = new OrderService();
            Order order = new Order(1, "ORD001", DateTime.Now);
            orderService.AddOrder(order);
            orderService.AddOrder(order);
        }

        [TestMethod]
        public void DeleteOrder_SuccessfullyDeletesOrder()
        {
            OrderService orderService = new OrderService();
            Order order = new Order(1, "ORD001", DateTime.Now);
            orderService.AddOrder(order);
            orderService.DeleteOrder(order.OrderId);
            Assert.IsFalse(orderService.orders.Any(o => o.OrderId == order.OrderId));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteOrder_ThrowsExceptionWhenOrderDoesNotExist()
        {
            var orderService = new OrderService();
            orderService.DeleteOrder(1);
        }

        [TestMethod]
        public void ModifyOrder_UpdatesOrderDetails()
        {
            var orderService = new OrderService();
            var order = new Order(1, "ORD001", DateTime.Now);
            orderService.AddOrder(order);
            orderService.ModifyOrder(order.OrderId, "ORD001-Modified", DateTime.Now.AddDays(1));
            var modifiedOrder = orderService.orders.Single();
            Assert.AreEqual("ORD001-Modified", modifiedOrder.OrderNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyOrder_ThrowsExceptionWhenOrderDoesNotExist()
        {
            OrderService orderService = new OrderService();
            orderService.ModifyOrder(1, "ORD001-Modified", DateTime.Now.AddDays(1));
        }

        [TestMethod]
        public void QueryOrders_ReturnsCorrectOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> ordersToAdd = new List<Order>
        {
            new Order(1, "ORD001", DateTime.Now.AddDays(-3)),
            new Order(2, "ORD002", DateTime.Now.AddDays(-1)),
            new Order(3, "ORD003", DateTime.Now.AddDays(2))
        };
            foreach (var order in ordersToAdd)
            {
                orderService.AddOrder(order);
            }

            var queryResult = orderService.QueryOrders(o => o.OrderDate > DateTime.Now.AddDays(-2));
            Assert.AreEqual(2, queryResult.Count);
            Assert.IsTrue(queryResult.All(o => o.OrderDate > DateTime.Now.AddDays(-2)));
        }

        [TestMethod]
        public void SortOrdersByOrderNumber_ReturnsSortedList()
        {
            OrderService orderService = new OrderService();
            List<Order> ordersToAdd = new List<Order>
    {
        new Order(3, "ORD003", DateTime.Now),
        new Order(1, "ORD001", DateTime.Now),
        new Order(2, "ORD002", DateTime.Now)
    };
            foreach (var order in ordersToAdd)
            {
                orderService.AddOrder(order);
            }
            var sortedOrders = orderService.SortOrdersByOrderNumber();
            Assert.AreEqual("ORD001", sortedOrders[0].OrderNumber);
            Assert.AreEqual("ORD002", sortedOrders[1].OrderNumber); 
            Assert.AreEqual("ORD003", sortedOrders[2].OrderNumber); 
        }
    }
}