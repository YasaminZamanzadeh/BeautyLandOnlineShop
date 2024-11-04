using BeautyLand.Application.Services.Site.Catalogs.Dtos.ItemDto;

namespace BeautyLand.Application.Services.Site.Catalogs.Items.GetDetails
{
    public interface IItemDetailService
    {
        DetailItemDto Execute(int id);
    }
}
