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
    public class UserOrderHistoryController : Controller
    {
        private readonly IOrderHistoryService _orderDetailService;
        private readonly UserManager<User> _userManager;
        public UserOrderHistoryController(IOrderHistoryService orderDetailService, UserManager<User> userManager)
        {
            _orderDetailService = orderDetailService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var orderDetail = _orderDetailService.Execute(user.Id);
            return View(orderDetail);
        }
    }
}
