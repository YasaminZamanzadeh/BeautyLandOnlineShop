namespace BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto
{
    public class FilteringDetailItemDto
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public int? TypeId { get; set; }
        public int[] BrandId { get; set; }
        public bool AvailableStock { get; set; }
        public string Term { get; set; }
        public SortType SortType { get; set; }
    }


    public enum SortType
    {
        /// <summary>
        /// بدونه مرتب سازی
        /// </summary>
        None = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروش‌ ترین
        /// </summary>
        BestSelling = 2,
        /// <summary>
        /// محبوب‌ترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        ///  ‌جدیدترین
        /// </summary>
        Newest = 4,
        /// <summary>
        /// ارزان‌ترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گران‌ترین
        /// </summary>
        MostExpensive = 6,
    }


}
