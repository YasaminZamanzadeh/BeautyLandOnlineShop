using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Items;

namespace BeautyLand.Domain.Order
{
    [AudiTable]
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Item Item { get; set; }
        public int ItemId { get; private set; }
        public string Image { get; private set; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(string name, int itemId, string image, int price, int quantity)
        {
            Name = name;
            ItemId = itemId;
            Image = image;
            Price = price;
            Quantity = quantity;
        }
        public OrderItem(string name, string image, int price)
        {
            Name = name;
            Image = image;
            Price = price;
        }
        public OrderItem()
        {

        }
    }
}
