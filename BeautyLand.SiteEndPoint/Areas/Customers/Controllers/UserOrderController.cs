using BeautyLand.Application.Services.Site.Orders.GetOrder;
using BeautyLand.Application.Services.Site.Payments;
using BeautyLand.Application.Services.Site.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class UserOrderController : Controller
    {
        private readonly IUserAddressService _userAddressService;
        public UserOrderController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        public IActionResult SuccessedPayment(string userId)
        {
            return View(_userAddressService.GetUserAddresse(userId));
        }

        public IActionResult FailedPayment(string userId)
        {
            return View(_userAddressService.GetUserAddresse(userId));
        }
    }
}
