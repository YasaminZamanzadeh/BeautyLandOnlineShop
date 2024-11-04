using BeautyLand.Domain.Users;
using System;
using System.Collections.Generic;

namespace BeautyLand.Application.Services.Administrator.Discounts.GetDiscount
{
    public class DiscountDto
    {
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public bool UseAmount { get; set; }
        public int DiscountAmount { get; set; }
        public bool UseCouponCode { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountTypeId { get; set; }
        public int DiscountLimitationTypeId { get; set; }
        public int LimitationTime { get; set; } = 0;
      //  public List<User> Users { get; set; } 
       // public List<int> Brands { get; set; } 
       // public List<int> Types { get; set; } 
        public List<int> Items { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

