using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Catalogs.Features
{
    [AudiTable]
    public class Feature
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
