namespace BeautyLand.Application.Services.Site.Catalogs.Items.Dtos.ItemDto
{
    public class ItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }

}
