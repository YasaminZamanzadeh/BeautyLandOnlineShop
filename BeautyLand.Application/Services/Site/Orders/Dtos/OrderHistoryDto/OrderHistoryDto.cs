using BeautyLand.Domain.Order;
using System;

namespace BeautyLand.Application.Services.Site.Orders.GetOrderDetail
{
    public class OrderHistoryDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
