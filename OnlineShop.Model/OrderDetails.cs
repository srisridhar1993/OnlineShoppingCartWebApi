using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class Order
    {
        public IEnumerable<OrderDetails> OrderDetail { get; set; }
        public IEnumerable<OrderMaster> OrderMasters { get; set; }
    }

    public class OrderMaster
    {
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public long CustomerId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public long ShippingAddressId { get; set; }
        public string ShippingAddress { get; set; }
        public long BillingAddressId { get; set; }
        public string BillingAddress { get; set; }
        public decimal Amount { get; set; }
        public string OrderDate { get; set; }

    }
    public class OrderDetails
    {
        public long OrderId { get; set; }
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
    }
    public class SearchOrder
    {
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string MobileNo { get; set; }
    }
}
