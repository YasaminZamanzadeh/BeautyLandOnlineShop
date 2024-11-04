using BeautyLand.Application.Services.Dtos.PaginationDto;

namespace BeautyLand.Application.Services.Site.Favorites.GetFavorites
{
    public interface IFavoritesService
    {
        void Create(string userId, int itemId);
        PaginationDto<FavoriteItemDto> Index(string userId, int pageIndex = 1, int pageSize = 20, int totalPage =100);

    }
}
