using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Items;

namespace BeautyLand.Domain.Baskets
{
    [AudiTable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        public Item Item { get; private set; }
        public int ItemId { get; private set; }
        public Basket Basket { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem(int price, int quantity, int itemId)
        {
            Price = price;
            SetQuantity(quantity);
            ItemId = itemId;
        }
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
