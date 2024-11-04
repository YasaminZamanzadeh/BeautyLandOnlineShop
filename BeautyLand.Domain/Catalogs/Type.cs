using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Catalogs.Type
{
    [AudiTable]
    public class Type
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Type Parent { get; set; }
        public int? ParentId { get; set; }
        public List<Type> Child { get; set; }
       // public ICollection<Discount> Discounts { get; set; }

    }
}
