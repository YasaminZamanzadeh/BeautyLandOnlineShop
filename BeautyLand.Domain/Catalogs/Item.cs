using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Brands;
using BeautyLand.Domain.Catalogs.Features;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Order;
using System.Collections.Generic;


namespace BeautyLand.Domain.Catalogs.Items
{
    [AudiTable]
    public class Item
    {
        private int _price = 0;
        private int? _oldPrice = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price
        {
            get { return GetPice(); }
            set { _price = value; }
        }

        private int GetPice()
        {
            var discount = GetPereferredDiscount(Discounts, _price);
            
            if (discount != null)
            {
                var discountAmount = discount.GetDiscountAmount(_price);
                var newPrice = _price - discountAmount;
                _oldPrice = _price;
                DiscountPercentage = (discountAmount * 100) / _price;
                return newPrice;
            }

            return _price;
        }

        private Discount GetPereferredDiscount(ICollection<Discount> discounts, int price)
        {
            Discount preferredDiscount = null;
            decimal? maximumDiscount = null;

            if (discounts !=null)
            {
                foreach (var item in discounts)
                {
                    var currentDiscount = item.GetDiscountAmount(price);
                    if (currentDiscount != decimal.Zero)
                    {
                        if (!maximumDiscount.HasValue || currentDiscount> maximumDiscount)
                        {
                            maximumDiscount = currentDiscount;
                            preferredDiscount = item;
                        }
                    }
                }
            }
            return preferredDiscount;
        }

        public int? OldPrice
        {
            get { return _oldPrice; }
            set { OldPrice = value; }
        }
        public int? DiscountPercentage { get; set; }
        public Type.Type Type { get; set; }
        public int TypeId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public int Viwes { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<Images.Image> Images { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Favorites.Favorites> Favorites { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
