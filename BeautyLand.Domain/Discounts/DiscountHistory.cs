using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Discounts
{
   public class DiscountHistory
    {
        public int Id { get; set; }
        public virtual Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public virtual Order.Order Order { get; set; }
        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
