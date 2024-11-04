using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Paginations;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Favorites.GetFavorites
{
    public class FavoritesService : IFavoritesService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IURIComposerService _uriComposerService;
        public FavoritesService(ISQLDatabaseService context, IURIComposerService uriComposerService)
        {
            _context = context;
            _uriComposerService = uriComposerService;
        }
        public void Create(string userId, int itemId)
        {
            var item = _context.Items.Find(itemId);

            if (item == null)
            {
                throw new NotFoundExceptionExtention<Item, int>(item, itemId);
            }

            Domain.Favorites.Favorites favorites = new Domain.Favorites.Favorites
            {
                UserId = userId,
                Item = item
            };
            _context.Favorites.Add(favorites);
            _context.SaveChanges();
        }

        public PaginationDto<FavoriteItemDto> Index(string userId, int pageIndex = 1, int pageSize = 20, int totalPage = 100)
        {
            var item = _context.Items
                .Include(p => p.Images)
                .Include(p => p.Discounts)
                .Include(p => p.Favorites)
                .Where(p => p.Favorites.Any(p => p.UserId == userId))
                .OrderByDescending(p=> p.Id)
                .AsQueryable();

            if (item == null)
            {
                throw new NotFoundExceptionExtention<IQueryable<Item>, string>(item, userId);
            }

            int rowCount = 0;
            var favorites = item
                .Select(p => new FavoriteItemDto
                {
                Id = p.Id,
                Name = p.Name,
                Image =_uriComposerService.Execute(p.Images.FirstOrDefault().Source),
                AvailableStock = p.AvailableStock,
                Price = p.Price,
                Rate = 4
                })
                .PagedResult(pageIndex, pageSize, out rowCount)
                .ToList();

            return new PaginationDto<FavoriteItemDto>(pageIndex, pageSize, rowCount, favorites);
        }
    }
}
