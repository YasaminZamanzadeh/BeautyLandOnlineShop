namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto
{
    public class ItemGetCatalogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

    }
}
