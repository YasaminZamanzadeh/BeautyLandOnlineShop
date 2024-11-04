using System.Collections.Generic;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Items.Dtos.ItemDto
{
    public class ItemDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public List<ItemFeatureDto> Features { get; set; }
        public List<ImageGetCatalogDto> Images { get; set; }

    }

}
