using BeautyLand.Application.Services.Site.Orders.GetOrderDetail;
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
    public class UserOrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserManager<User> _userManager;
        public UserOrderDetailController(IOrderDetailService orderDetailService, UserManager<User> userManager)
        {
            _orderDetailService = orderDetailService;
            _userManager = userManager;
        }
        public IActionResult Index(int orderHistoryId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var model = _orderDetailService.Execute(user, orderHistoryId);
            return View(model);
        }
    }
}
