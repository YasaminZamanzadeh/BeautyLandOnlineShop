using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Catalogs.Brands
{
    [AudiTable]
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //public ICollection<Discount> Discounts { get; set; }

    }
}
