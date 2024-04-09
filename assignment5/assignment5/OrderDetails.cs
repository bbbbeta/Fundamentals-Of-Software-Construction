using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    //每个 OrderDetails 对象代表订单中的一个商品项，包含商品的ID、名称、数量和单价。
    public class OrderDetails
    {
        public int ProductId { get; set; }//商品id
        public string ProductName { get; set; }//商品名
        public int Quantity
        {
            get { return quantity; }
            set
            {
                // 验证输入的数量是否大于等于 0
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be negative.");
                }
                quantity = value;
            }
        }

        private int quantity;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                // 验证输入的单价是否大于等于 0
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Unit price cannot be negative.");
                }
                unitPrice = value;
            }
        }
        private decimal unitPrice;
        public decimal TotalAmount => Quantity * UnitPrice;
        public OrderDetails(int productId, string productName, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        public override bool Equals(object obj) //判断重复订单
        {
            if (obj is OrderDetails other)
            {
                return ProductId == other.ProductId && Quantity == other.Quantity && UnitPrice == other.UnitPrice;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{ProductName} (Quantity: {Quantity}, Unit Price: {UnitPrice}, Total: {TotalAmount})";
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + ProductId.GetHashCode();
            hash = hash * 23 + Quantity.GetHashCode();
            hash = hash * 23 + UnitPrice.GetHashCode();
            return hash;
        }
    }
}
