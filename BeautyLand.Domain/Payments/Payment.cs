using BeautyLand.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Payments
{
    [AudiTable]
   public class Payment
    {
        public Guid Id { get; set; }
        public int Amount { get; private set; }
        public bool IsPay { get; private set; } = false;
        public string Authority { get; set; } 
        public long RefId { get; set; } = 0;
        public Order.Order Order { get; set; }
        public int OrderId { get; set; }
        public DateTime? PayDate { get; set; } = null;

        public Payment(int amount, int orderId )
        {
            Amount = amount;
            OrderId = orderId;
        }

        public void Paid(string authority, long refId)
        {
            IsPay = true;
            Authority = authority;
            RefId = refId;
            PayDate = DateTime.Now;
        }
    
    }
}
