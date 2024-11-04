namespace BeautyLand.Application.Services.Site.Baskets.Basket
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OldPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }

}
