using BeautyLand.Domain.Order;
using BeautyLand.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Orders.GetOrderDetail
{
    public interface IOrderDetailService
    {
        List<OrderDetailDto> Execute(Domain.Users.User user, int orderHistoryId);
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int Price { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Address Address { get; set; }

    }

    public class OrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
