using BeautyLand.Application.Services.Dtos.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Discounts.GetDiscount
{
    public interface IDiscountService
    {
        bool ApplyDiscountinBasket(string discountCode, int basketId);
        bool DeleteDiscountinBasket(int basketId);
        BaseDto IsDiscountValid(string discountCode, Domain.Users.User user);
    }
}
