using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Favorites
{
    [AudiTable]
   public class Favorites
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
