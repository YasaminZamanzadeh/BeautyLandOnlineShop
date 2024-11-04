using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Application.Services.Site.Discounts.GetDiscountHistory;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Users;
using BeautyLand.Subscription.ExceptionExtentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Discounts.GetDiscount
{
    public class DiscountService : IDiscountService
    {
        private BaseDto CheckDiscountLimitations(Discount discount, Domain.Users.User user)
        {
            switch (discount.DiscountLimitationType)
            {
                case DiscountLimitationType.Unlimited:
                    return new BaseDto(null, true);

                case DiscountLimitationType.NTimeOnly:
                    var discountHistory = _discountHistoryService.GetCatalogDiscountHistory(discount.Id, null, 0, 1).Model.Count();
                    if (discountHistory< discount.LimitationTime)
                    {
                        return new BaseDto(null, true);
                    }
                    else
                    {
                        return new BaseDto(new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل  شده است "}, true);
                    }

                case DiscountLimitationType.NTimeOnlyPerCustomer:

                    if (user != null)
                    {
                        var discountHistoryPerCustomer = _discountHistoryService.GetCatalogDiscountHistory(discount.Id, user.Id, 0, 1).Model.Count();
                        if (discountHistoryPerCustomer < discount.LimitationTime)
                        {
                            return new BaseDto(null, true);
                        }
                        else
                        {
                            return new BaseDto(new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل  شده است " }, true);
                        }
                    }
                    else
                    {
                        return new BaseDto(null, true);
                    }
                    
                default:
                    break;
            }
            return new BaseDto(null, true);

        }
        private readonly ISQLDatabaseService _context;
        private readonly IDiscountHistoryService _discountHistoryService;
        public DiscountService(ISQLDatabaseService context, IDiscountHistoryService discountHistoryService)
        {
            _context = context;
            _discountHistoryService = discountHistoryService;
        }
        public bool ApplyDiscountinBasket(string discountCode, int basketId)
        {
            var basket = _context.Baskets
                 .Include(p => p.BasketItems)
                 .Include(p => p.Discount)
                 .FirstOrDefault(p => p.Id == basketId);

            if (basket == null)
            {
                throw new NotFoundExceptionExtention<Domain.Baskets.Basket, int>(basket, basketId);
            }

            var discount = _context.Discounts
                .Where(p => p.DiscountCode.Equals(discountCode))
                .FirstOrDefault();

            if (discount == null)
            {
                throw new NotFoundExceptionExtention<Domain.Discounts.Discount, string>(discount, discountCode);
            }


            basket.ApplyDiscount(discount);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDiscountinBasket(int basketId)
        {
            var basket = _context.Baskets.Find(basketId);
            if (basket == null)
            {
                throw new NotFoundExceptionExtention<Domain.Baskets.Basket, int>(basket, basketId);
            }

            basket.DeleteDiscount();
            _context.SaveChanges();
            return true;
        }

        public BaseDto IsDiscountValid(string discountCode, Domain.Users.User user)
        {
            var discount = _context.Discounts
                .Where(p => p.DiscountCode.Equals(discountCode))
                .FirstOrDefault();

            if (discount == null)
            {
                return new BaseDto(new List<string> { "کد تخفیف معتبر نمی باشد" }, false);
            }

            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(DateTime.UtcNow) > 0)
                {
                    return new BaseDto(new List<string> { "زمان استفاده از این کد تخفیف فرا نرسیده است" }, false);

                }

                if (discount.StartDate.HasValue)
                {
                    var endDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                    if (startDate.CompareTo(DateTime.UtcNow) < 0)
                    {
                        return new BaseDto(new List<string> { "زمان استفاده از این کد تخفیف به پایان رسیده است " }, false);
                    }
                }

            }
            var discountLimitations = CheckDiscountLimitations(discount, user);
            if (discountLimitations.IsSuccess == false)
            {
                return discountLimitations;
            }

            return new BaseDto(null, true);
        }
    }
}
