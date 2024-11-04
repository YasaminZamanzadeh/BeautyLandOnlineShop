using BeautyLand.Application.Services.Site.User;
using BeautyLand.Application.Services.Site.UserAddress;
using BeautyLand.SiteEndPoint.Claims.UserClaim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class UserAddressController : Controller
    {
        private readonly IUserAddressService _userAddressGetAddressService;
        public UserAddressController(IUserAddressService userAddressGetAddressService)
        {
            _userAddressGetAddressService = userAddressGetAddressService;
        }
        public IActionResult Index()
        {
            var model = _userAddressGetAddressService.GetUserAddresse(UserClaim.GetUserId(User));
            return View(model);
        }
        public IActionResult CreateUserAddress()
        {

            return View(new NewUserAddressDto());
        }
        [HttpPost]
        public IActionResult CreateUserAddress(NewUserAddressDto newUserAddress)
        {
            var userId = UserClaim.GetUserId(User);
            newUserAddress.UserId = userId;
            _userAddressGetAddressService.CreateUserAddress(newUserAddress);
            return RedirectToAction(nameof(Index));
        }
    }
}
