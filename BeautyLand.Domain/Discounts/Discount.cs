using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Catalogs.Brands;
using BeautyLand.Domain.Catalogs.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Discounts
{
    [AudiTable]
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int  DiscountPercentage { get; set; }
        public bool UseAmount { get; set; }
        public int DiscountAmount { get; set; }
        public bool UseCouponCode { get; set; }
        public string DiscountCode { get; set; }
       [NotMapped]
        public DiscountType DiscountType
        {
            get => (DiscountType)this.DiscountTypeId;
            set => this.DiscountTypeId = (int)value;
        }
        public int DiscountTypeId { get; set; }
        [NotMapped]
        public DiscountLimitationType DiscountLimitationType
        {
            get => (DiscountLimitationType)this.DiscountLimitationTypeId;
            set => this.DiscountLimitationTypeId = (int)value;
        }
        public int DiscountLimitationTypeId { get; set; }
        public int LimitationTime { get; set; }
       // public ICollection<Users.User> Users { get; set; }
       // public ICollection<Brand> Brands { get; set; }
       // public ICollection<Catalogs.Type.Type> Types { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int GetDiscountAmount(int amount)
        {
            var result = 0;
            if (UsePercentage)
            {
                result = ((amount) * (DiscountPercentage) / 100);
            }
            else
            {
                result = DiscountAmount;
            }

            return result;
        }


    }
    /// <summary>
    ///    نوع تخفیف
    /// </summary>
    public enum DiscountType
    {
        [Display(Name = "تخفیف برای کاربر")]
        UserAssigned = 1,
        [Display(Name = "تخفیف برای برند")]
        BrandAssigned = 2,
        [Display(Name = "تخفیف برای دسته بندی")]
        TypeAssigned = 3,
        [Display(Name = "تخفیف برای محصولات")]
        ItemAssigned = 4,

    }
    /// <summary>
    ///  محدودیت تعداد استفاده
    /// </summary>
    public enum DiscountLimitationType
    {
        /// <summary>
        /// بدونه محدودیت تعداد
        /// </summary>
        [Display(Name = "بدونه محدودیت تعداد")]
        Unlimited = 1,
        /// <summary>
        /// فقط N بار
        /// </summary>
        [Display(Name = "فقط N بار")]
        NTimeOnly = 2,
        /// <summary>
        /// N بار به ازای هر مشتری
        /// </summary>
        [Display(Name = "N بار به ازای هر مشتری")]
        NTimeOnlyPerCustomer = 3,
    }
}
