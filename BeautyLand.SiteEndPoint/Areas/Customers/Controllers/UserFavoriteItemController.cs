using BeautyLand.Application.Services.Site.Favorites.GetFavorites;
using BeautyLand.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class UserFavoriteItemController : Controller
    {
        private readonly IFavoritesService _favoritesService;
        private readonly UserManager<User> _userManager;
        public UserFavoriteItemController(IFavoritesService favoritesService, UserManager<User> userManager)
        {
            _favoritesService = favoritesService;
            _userManager = userManager;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 20)
        {
            var user = _userManager.GetUserAsync(User).Result;
           var model = _favoritesService.Index(user.Id, pageNumber, pageSize);
            return View(model);
        }

        public IActionResult Create(int itemId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _favoritesService.Create(user.Id, itemId);
            return RedirectToAction("Index");
        }
    }
}
