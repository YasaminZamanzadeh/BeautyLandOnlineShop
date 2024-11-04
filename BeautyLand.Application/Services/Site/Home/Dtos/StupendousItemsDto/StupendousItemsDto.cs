using System;

namespace BeautyLand.Application.Services.Site.Home.GetHome
{
    public class StupendousItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OldPrice { get; set; }
        public int MyProperty { get; set; }
        public string Image { get; set; }
        public int? DiscountPercentage { get; set; }
        //public int? DiscountAmount { get; set; }

        //public int AppliedDiscountonTotalPrice()
        //{
        //    if (DiscountPercentage > 20)
        //    {
        //        var discountPercentage = 1.0 - (DiscountPercentage / 100.0);
        //        Price = (int)(Price * discountPercentage);
        //        return Price;
        //    }
        //    else if (DiscountAmount < Price)
        //    {
        //        Price -= DiscountAmount;
        //        return Price;
        //    }

        //    return Price;
        //}

        //public int NotAppliedDiscountonTotalPrice()
        //{
        //    if (OldPrice > 0)
        //    {
        //        return OldPrice;
        //    }
        //    return OldPrice;
        //}

    }
}
