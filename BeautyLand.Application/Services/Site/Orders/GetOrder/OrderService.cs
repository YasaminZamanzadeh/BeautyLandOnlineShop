using AutoMapper;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Site.Discounts.GetDiscountHistory;
using BeautyLand.Domain.Baskets;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Users;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Orders.GetOrder
{
    public class OrderService : IOrderService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        private readonly IURIComposerService _uriComposerService;
        private readonly IDiscountHistoryService _discountHistoryService;
        public OrderService(ISQLDatabaseService context, IMapper mapper, IURIComposerService uriComposerService, IDiscountHistoryService discountHistoryService)
        {
            _context = context;
            _mapper = mapper;
            _uriComposerService = uriComposerService;
            _discountHistoryService = discountHistoryService;
        }
        public int CreateOrder(int basketId, int addressId, PaymentMethod paymentMethod)
        {
            var basket = _context.Baskets
                .Include(p => p.Discount)
                .Include(p => p.BasketItems)
                .SingleOrDefault(p => p.Id == basketId);

            if (basket == null)
            {
                throw new NotFoundExceptionExtention<Basket, int>(basket, basketId);
            }

            int[] itemIds = basket.BasketItems.Select(p => p.ItemId).ToArray();

            var items = _context.Items
                .Include(p => p.Images)
                .Where(p => itemIds.Contains(p.Id))
                .ToList();

            var itemsDictionary = items.ToDictionary(p => p.Id);

            var orderItems = basket.BasketItems.Select(p =>
            {
                if (itemsDictionary.TryGetValue(p.ItemId, out var item))
                {
                    return new OrderItem(
                        item.Name,
                        item.Id,
                        _uriComposerService.Execute(item.Images?.FirstOrDefault()?.Source ?? ""),
                        item.Price,
                        p.Quantity);
                }
                return null;
            }).Where(p=> p != null).ToList();

            int quantity = _context.Orders.Count(p => p.Quantity == 0);
            var userAddress = _context.UserAddresses.SingleOrDefault(p => p.Id == addressId);

            if (userAddress == null)
            {
                throw new NotFoundExceptionExtention<Domain.Users.UserAddress, int>(userAddress, addressId);
            }

            var address = _mapper.Map<Address>(userAddress);
            var order = new Order(basket.BuyerId, address, quantity, orderItems, paymentMethod, basket.Discount);
            order.AddQuantity(quantity);
            _context.Orders.Add(order);
            _context.Baskets.Remove(basket);
            _context.SaveChanges();
            if (basket.DiscountAmount != null)
            {
                _discountHistoryService.CreateDiscountHistory(basket.Discount.Id, order.Id);
            }
            return order.Id;
        }
    }
}
