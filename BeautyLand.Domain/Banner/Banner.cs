using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Banner
{
   public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public BannerPosition BannerPosition { get; set; }

    }

    public enum BannerPosition
    {
        /// <summary>
        /// اسلایدر
        /// </summary>
        [Display(Name ="اسلایدر")]
        Slider = 0,
        /// <summary>
        /// سطر اول
        /// </summary>
        [Display(Name = "سطر اول")]
        TheFirstRow = 1,
        /// <summary>
        /// سطر دوم
        /// </summary>
        [Display(Name ="سطر دوم")]
        TheSecondRow =2,
        /// <summary>
        /// سطر سوم
        /// </summary>
        [Display(Name ="سطر سوم")]
        TheThirdRow =3,
        /// <summary>
        /// سطر چهارم
        /// </summary>
        [Display(Name ="سطر چهارم")]
        TheFourthRow = 4,
        /// <summary>
        /// سطر پنجم
        /// </summary>
        [Display(Name = "سطر پنجم")]
        TheFifthRow =5,
    }
}
