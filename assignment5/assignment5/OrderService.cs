using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class OrderService
    {
        //List存储所有订单
        public List<Order> orders = new List<Order>();

        // 添加一个新的订单到系统中
        // 如果订单ID已存在，则抛出ArgumentException异常
        public void AddOrder(Order order)
        {
            if (orders.Any(o => o.OrderId == order.OrderId))
            {
                throw new ArgumentException("An order with the same ID already exists.");
            }
            orders.Add(order);
        }

        // 根据订单ID删除一个订单
        // 如果指定的订单不存在，则抛出ArgumentException异常
        public void DeleteOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }
            orders.Remove(order);
        }

        // 修改指定订单的信息
        // 如果指定的订单不存在，则抛出ArgumentException异常
        public void ModifyOrder(int orderId, string newOrderNumber, DateTime newOrderDate)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }
            order.OrderNumber = newOrderNumber;
            order.OrderDate = newOrderDate;
        }

        // 根据给定的条件查询订单
        // predicate 是一个 Func<Order, bool> 委托，用于定义查询条件
        // 查询结果按照订单总金额进行排序
        public List<Order> QueryOrders(Func<Order, bool> predicate)
        {
            return orders.AsQueryable().Where(predicate).OrderBy(o => o.TotalAmount).ToList();
        }

        // 对所有订单按照订单编号进行排序
        public List<Order> SortOrdersByOrderNumber()
        {
            return orders.OrderBy(o => o.OrderNumber).ToList();
        }

    }
}
