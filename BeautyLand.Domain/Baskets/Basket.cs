using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Baskets
{
    [AudiTable]
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; private set; }

        private readonly List<BasketItem> _basketItems = new List<BasketItem>();
        public IReadOnlyList<BasketItem> BasketItems => _basketItems.AsReadOnly();

        public int? DiscountAmount { get; private set; } = null;
        public Discount? Discount { get; private set; } = null;
        public int? DiscountId { get; set; } = null;


        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }
        public void AddBasketItem(int price, int quantity, int itemId)
        {
            if (!BasketItems.Any(p => p.ItemId == itemId))
            {

                _basketItems.Add(new BasketItem(price, quantity, itemId));
                return;
            }
            var basketItem = _basketItems.FirstOrDefault(p => p.ItemId == itemId);
            basketItem.AddQuantity(quantity);
        }
        public int AppliedDiscountonTotalPrice()
        {
            int totalPrice = _basketItems.Sum(p => p.Price * p.Quantity);
            totalPrice -= Discount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }
        public int NotAppliedDiscountonTotalPrice()
        {
            int totalPrice = _basketItems.Sum(p => p.Price * p.Quantity);
            return totalPrice;
        }

        public void ApplyDiscount(Discount discount)
        {
            Discount = discount;
            DiscountId = discount?.Id;
            DiscountAmount = discount?.GetDiscountAmount(NotAppliedDiscountonTotalPrice());
            
        }

        public void DeleteDiscount( )
        {
            Discount = null;
            DiscountId = null;
            DiscountAmount = 0;

        }
    }
}
