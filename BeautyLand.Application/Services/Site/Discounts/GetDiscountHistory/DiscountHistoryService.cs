using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Order;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Paginations;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Discounts.GetDiscountHistory
{
    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly ISQLDatabaseService _context;
        public DiscountHistoryService(ISQLDatabaseService context)
        {
            _context = context;
        }
        public void CreateDiscountHistory(int discountId, int orderId)
        {
            var discount = _context.Discounts
                .Find(discountId);

            if (discount == null)
            {
                throw new NotFoundExceptionExtention<Discount, int>(discount, discountId);
            }


            var order = _context.Orders
               .Find(orderId);

            if (order == null)
            {
                throw new NotFoundExceptionExtention<Order, int>(order, orderId);
            }

            DiscountHistory discountHistory = new DiscountHistory
            {

                Discount = discount,
                DiscountId = discount.Id,
                Order = order,
                OrderId = order.Id,
                CreateDate = DateTime.Now,
            };

            _context.DiscountHistories.Add(discountHistory);
            _context.SaveChanges();
        }

        public PaginationDto<DiscountHistory> GetCatalogDiscountHistory(int? discountId, string? userId, int pageIndex, int pageSize)
        {
            var discountHistory = _context.DiscountHistories.AsQueryable();
            if (discountId.HasValue && discountId.Value>0)
            {
                discountHistory = discountHistory.Where(p => p.DiscountId == discountId.Value);
            }

            if (!string.IsNullOrEmpty(userId))
            {
                discountHistory = discountHistory.Where(p => p.Order != null && p.Order.UserId == userId);
            }

            discountHistory = discountHistory.OrderByDescending(p => p.CreateDate);
            var model = discountHistory.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginationDto<DiscountHistory>(pageIndex, pageSize, rowCount, model);


        }

        public DiscountHistory GetDiscountHistory(int discountHistoryId)
        {
            if (discountHistoryId == 0)
            {
                return null;
            }

            var discountHistory = _context.DiscountHistories.Find(discountHistoryId);
            return discountHistory;
        }
    }
}
