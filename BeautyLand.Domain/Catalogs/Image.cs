using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Catalogs.Images
{
    [AudiTable]
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
