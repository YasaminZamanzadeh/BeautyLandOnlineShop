using BeautyLand.Application.Services.Administrator.Discounts.Dtos.ItemDto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Administrator.Discounts.GetDiscount
{
    public interface IDiscountService
    {
        void GetDiscount(DiscountDto discount);
      //  List<UserDto> GetUser (string term);
      //  List<BrandDto> GetBrand (string term);
      //  List<TypeDto> GetType(string term);
        List<ItemDto> GetItem(string term);

    }
}

