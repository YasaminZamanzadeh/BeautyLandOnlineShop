using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto
{
    public class DetailItemDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
        public int? OldPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string, FeatureItemDto>> Features { get; set; }
        public List<SimilarItemsDto> SimilarItem { get; set; }

    }

}
