using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Domain.Baskets;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Baskets.Basket
{
    public class BasketService : IBasketService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IURIComposerService _uriComposerService;
        public BasketService(ISQLDatabaseService context, IURIComposerService uriComposerService)
        {
            _context = context;
            _uriComposerService = uriComposerService;
        }

        public void CreateBasketItem(int basketId, int itemId, int quantity = 1)
        {
            var basket = _context.Baskets
                .Include(p => p.Discount)
                .FirstOrDefault(p => p.Id == basketId);

            if (basket == null)
            {
                throw new NotFoundExceptionExtention<Domain.Baskets.Basket, int>(basket, basketId);
            }

            var item = _context.Items.Find(itemId);

            if (item == null)
            {
                throw new NotFoundExceptionExtention<Item, int>(item, basketId);
            }

            basket.AddBasketItem(item.Price, quantity, itemId);
            _context.SaveChanges();
        }

        public bool DeleteBasketItem(int itemId)
        {
            var basketItem = _context.BasketItems
                .SingleOrDefault(p => p.Id == itemId);

            if (basketItem == null)
            {
                throw new NotFoundExceptionExtention<Domain.Baskets.BasketItem, int>(basketItem, itemId);
            }

            _context.BasketItems.Remove(basketItem);
            _context.SaveChanges();
            return true;
        }

        public BasketDto GetBasket(string userId)
         {

            var basket = _context.Baskets
                .Include(p => p.BasketItems)
                .ThenInclude(p => p.Item)
                .ThenInclude(p => p.Discounts)
               .Include(p => p.BasketItems)
               .ThenInclude(p => p.Item)
               .ThenInclude(p => p.Images)
               .SingleOrDefault(p => p.BuyerId == userId);

            if (basket == null)
            {
                throw new NotFoundExceptionExtention<Domain.Baskets.Basket, string>(basket, userId);
            }

            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                DiscountAmount = basket.DiscountAmount,
                Items = basket.BasketItems.Select(p => new BasketItemDto
                {
                    Id = p.Id,
                    ItemId = p.ItemId,
                    Name = p.Item.Name,
                    Quantity = p.Quantity,
                    Price =  p.Item.Price,
                    OldPrice = p.Item.OldPrice,
                    DiscountPercentage = p.Item.DiscountPercentage,
                    Image = _uriComposerService.Execute(p?.Item?.Images?.FirstOrDefault()?.Source ?? ""),
                }).ToList(),
            };
        }


        public BasketDto GetorSetBasket(string buyerId)
        {
            var basket = _context.Baskets
                .Include(p => p.BasketItems)
                .ThenInclude(p => p.Item)
                .ThenInclude(p => p.Images)
                .Include(p=> p.BasketItems)
                .ThenInclude(p=> p.Item)
                .ThenInclude(p=> p.Discounts)
                .SingleOrDefault(p => p.BuyerId == buyerId);
            if (basket == null)
            {
                return CreateGuestUserBasket(buyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                DiscountAmount = basket.DiscountAmount,
                Items = basket.BasketItems
                .Select(p => new BasketItemDto
                {
                    Id = p.Id,
                    Name = p.Item.Name,
                    ItemId = p.Item.Id,
                    Image = _uriComposerService.Execute(p?.Item.Images?.FirstOrDefault()?.Source ?? ""),
                    Price = p.Item.Price,
                    Quantity = p.Quantity,
                }).ToList(),
            };
        }

        public bool GetorSetQuantities(int itemId, int quantity)
        {
            var basketItem = _context.BasketItems.SingleOrDefault(p => p.Id == itemId);
            basketItem.SetQuantity(quantity);
            _context.SaveChanges();
            return true;
        }

        public void TransferBasket(string buyerId, string userId)
        {
            var anonymousBasket = _context.Baskets
                 .Include(p => p.BasketItems)
                 .Include(p => p.Discount)
                 .SingleOrDefault(p => p.BuyerId == buyerId);
            if (anonymousBasket == null)
                return;
            var userBasket = _context.Baskets
                 .Include(p => p.Discount)
                .SingleOrDefault(p => p.BuyerId == userId);
            if (userBasket == null)
            {
                userBasket = new Domain.Baskets.Basket(userId);
                _context.Baskets.Add(userBasket);
            }
            foreach (var item in anonymousBasket.BasketItems)
            {
                userBasket.AddBasketItem(item.Price, item.Quantity, item.ItemId);
            }

            if (anonymousBasket.DiscountAmount != null)
            {
                userBasket.ApplyDiscount(anonymousBasket.Discount);
            }
            _context.Baskets.Remove(anonymousBasket);
            _context.SaveChanges();
        }

        private BasketDto CreateGuestUserBasket(string buyerId)
        {
            Domain.Baskets.Basket basket = new Domain.Baskets.Basket(buyerId);
            _context.Baskets.Add(basket);
            _context.SaveChanges();
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
            };
        }
    }

}
