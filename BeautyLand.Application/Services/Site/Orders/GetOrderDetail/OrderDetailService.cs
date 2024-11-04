using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Domain.Order;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Orders.GetOrderDetail
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IURIComposerService _uriComposerService;
        public OrderDetailService(ISQLDatabaseService context, IURIComposerService uriComposerServic)
        {
            _context = context;
            _uriComposerService = uriComposerServic;
        }
        public List<OrderDetailDto> Execute(Domain.Users.User user, int orderHistoryId)
        {
            var order = _context.Orders
                .Include(p => p.OrderItems)
                .ThenInclude(p => p.Item)
                .ThenInclude(p => p.Images)
                .FirstOrDefault(p => p.UserId == user.Id && p.Id == orderHistoryId);


            if (order == null)
            {
                throw new NotFoundExceptionExtention<Order, int>(order, orderHistoryId);
            }

            var orderDetail = new OrderDetailDto
            {
                Id = order.Id,
                PhoneNumber = user.PhoneNumber,
                Price = order.AppliedDiscountonTotalPrice(),
                OrderStatus = order.OrderStatus,
                Address = order.Address,
                OrderItems = order.OrderItems?.Select(p => new OrderItemDto
                {
                    Id = p.Id,
                    ItemId = p.ItemId,
                    Name = p.Item?.Name, 
                    Price = p.Item?.Price ?? 0,
                    Image = p.Item?.Images.FirstOrDefault()?.Source != null ? _uriComposerService.Execute(p.Item.Images.FirstOrDefault().Source) : null 
                }).ToList() ?? new List<OrderItemDto>() 
            };

            return new List<OrderDetailDto> { orderDetail };
        }
    }
}
