using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Baskets.Basket
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();


        public int? DiscountAmount { get; set; } = null;
        public int AppliedDiscountonTotalPrice()
        {
            if (Items.Count > 0)
            {
                int totalPrice = Items.Sum(p => p.Price * p.Quantity);
                totalPrice -= DiscountAmount.GetValueOrDefault();
                return totalPrice; 
            }
            return 0;
        }

        public int NotAppliedDiscountonTotalPrice()
        {
            if (Items.Count > 0)
            {
                int totalPrice = Items.Sum(p => p.Price * p.Quantity);
                return totalPrice;
            }
            return 0;
        }
    }

}
