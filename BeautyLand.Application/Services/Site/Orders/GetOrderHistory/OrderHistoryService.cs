using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Domain.Order;
using BeautyLand.Subscription.ExceptionExtentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Orders.GetOrderDetail
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly ISQLDatabaseService _context;
        public OrderHistoryService(ISQLDatabaseService context)
        {
            _context = context;
        }
        public List<OrderHistoryDto> Execute(string userId)
        {
            // When I intend to use shadow property and set it for the desired property, which will be read of it, We have to utilize these command 
            //var order = _context.Orders.FirstOrDefault();
            //var createDate = _context.Entry(order).Property("CreateDate").CurrentValue.ToString();
            var order = _context.Orders
                .Include(p=> p.Discount)
                 .Include(p => p.OrderItems)
                 .Where(p => p.UserId == userId)
                 .OrderByDescending(p => p.Id)
                 .Select(p => new OrderHistoryDto
                 { 
                 Id = p.Id,
                 Price = p.AppliedDiscountonTotalPrice(),
                 Quantity = p.Quantity,
                 OrderStatus = p.OrderStatus,
                 PaymentStatus = p.PaymentStatus,
                 CreateDate = p.OrderDate
                 }).ToList();

            if (order == null)
            {
                throw new NotFoundExceptionExtention<List<OrderHistoryDto>, string>(order, userId);
            }
            return order;
        }
    }

}
