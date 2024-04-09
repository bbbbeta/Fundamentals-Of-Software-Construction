using assignment5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建 OrderService 实例
            OrderService orderService = new OrderService();

            // 创建一些 OrderDetails 对象用于测试
            List<OrderDetails> details1 = new List<OrderDetails>
            {
                new OrderDetails(101, "Product A", 2, 50.00m),
                new OrderDetails(102, "Product B", 1, 100.00m)
            };

            // 创建一个 Order 对象
            Order order1 = new Order(1, "ORD001", DateTime.Now);
            Order order2 = new Order(1, "ORD002", DateTime.Now);
            Order order3 = new Order(3, "ORD003", DateTime.Now);
            order1.Details.AddRange(details1);

            // 打印 Order 对象的信息
            Console.WriteLine("Order1 details:");
            foreach (OrderDetails detail in order1.Details)
            {
                Console.WriteLine(detail);
            }
            Console.WriteLine(order1);

            // 添加订单到 OrderService
            try
            {
                orderService.AddOrder(order1);
                Console.WriteLine("Order1 added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try//order2因id与order1重复，提示An order with the same ID already exists.
            {
                orderService.AddOrder(order2);
                Console.WriteLine("Order2 added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                orderService.AddOrder(order3);
                Console.WriteLine("Order3 added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 查询特定订单号的订单
            List<Order> ordersByNumber = orderService.QueryOrders(o => o.OrderNumber == "ORD001");
            if (ordersByNumber.Count > 0)
            {
                Console.WriteLine("Query by order number ORD001:");
                foreach (var order in ordersByNumber)
                {
                    Console.WriteLine(order);
                }
            }

            // 修改订单信息
            try
            {
                orderService.ModifyOrder(order1.OrderId, "ORD001-Modified", DateTime.Now.AddDays(1));
                Console.WriteLine("Order1 modified successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 删除一个订单
            try
            {
                orderService.DeleteOrder(order1.OrderId);
                Console.WriteLine("Order1 deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 再次查询所有订单，验证修改和删除操作
            Console.WriteLine("All orders after operations:");
            var allOrders = orderService.QueryOrders(o => true);
            foreach (var order in allOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
