using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Order
    {
        public int OrderId { get; private set; }//订单id
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> Details { get;set; } = new List<OrderDetails>();//订单明细存放在List中
        public decimal TotalAmount
        {
            get
            {
                // 确保 Details 集合已经被初始化
                if (Details == null)
                {
                    Details = new List<OrderDetails>();
                }
                // 使用 LINQ 的 Sum 方法计算所有 OrderDetails 对象的 TotalAmount 总和
                return Details.Sum(x => x.TotalAmount);
            }
        }

        public Order(int orderId, string orderNumber, DateTime orderDate)
        {
            OrderId = orderId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        public override bool Equals(object obj)
        {
            if (obj is Order other)
            {
                return OrderId == other.OrderId;//订单号唯一
            }
            return false;
        }

        public override string ToString()
        {
            return $"Order Number: {OrderNumber}, Date: {OrderDate.ToShortDateString()}, Total Amount: {TotalAmount}";
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }
    }
}
