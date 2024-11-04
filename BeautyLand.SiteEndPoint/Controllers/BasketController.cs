using BeautyLand.Application.Services.Site.Discounts.GetDiscount;
using BeautyLand.Application.Services.Site.Baskets.Basket;
using BeautyLand.Application.Services.Site.Orders.GetOrder;
using BeautyLand.Application.Services.Site.Payments;
using BeautyLand.Application.Services.Site.User;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Users;
using BeautyLand.SiteEndPoint.Claims.UserClaim;
using BeautyLand.SiteEndPoint.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly SignInManager<User> _signInManager;
        private string _guestUserId = null;
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IDiscountService _discountService;
        private readonly UserManager<User> _userManager;


        public BasketController(IBasketService basketService, SignInManager<User> signInManager, IUserAddressService userAddressService, IOrderService orderService, IPaymentService paymentService, IDiscountService discountService, UserManager<User> userManager)
        {
            _basketService = basketService;
            _signInManager = signInManager;
            _userAddressService = userAddressService;
            _orderService = orderService;
            _paymentService = paymentService;
            _discountService = discountService;
            _userManager = userManager;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = CreateGetorSetBasket();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost ]
        public IActionResult Index(int itemId, int quantity = 1)
        {
            var basket = CreateGetorSetBasket();
            _basketService.CreateBasketItem(basket.Id, itemId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteBasketItem(int itemId)
        {
            _basketService.DeleteBasketItem(itemId);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateGetorSetQuantities(int itemId, int quantity)
        {

            return Json(_basketService.GetorSetQuantities(itemId, quantity));
        }


        private BasketDto CreateGetorSetBasket()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userId = UserClaim.GetUserId(User);
                return _basketService.GetorSetBasket(userId);
            }
            else
            {
                CreatSetGuestUserCookies();
                return _basketService.GetorSetBasket(_guestUserId);
            }
        }
        private void CreatSetGuestUserCookies()
        {
            string cookieName = "BasketId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                _guestUserId = Request.Cookies[cookieName];
            }
            if (_guestUserId != null)
                return;
            _guestUserId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(1);
            Response.Cookies.Append(cookieName, _guestUserId, cookieOptions);
        }

        public IActionResult Payment()
        {
            PaymentViewModel model = new PaymentViewModel();
            string userId = UserClaim.GetUserId(User);
            model.Basket = _basketService.GetBasket(userId);
            model.UserAddresses = _userAddressService.GetUserAddresse(userId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Payment(int address, PaymentMethod paymentMethod)
        {
            var userId = UserClaim.GetUserId(User);
            var basket = _basketService.GetBasket(userId);
            int orderId = _orderService.CreateOrder(basket.Id, address, paymentMethod);
            if (paymentMethod == PaymentMethod.OnlinePayment)
            {
                //ثبت  پرداخت
                var payment = _paymentService.CreateSetPaymentOrder(orderId);
                // ارسال به درگاه پرداخت
                return RedirectToAction("Index", "Pay", new { paymentId = payment.Id });
            }
            else
            {
                // برو به صفحه سفارشات من
                return RedirectToAction("Index", "orders", new { area = "Customers" });

            }

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ApplyDiscount(string discountCode, int basketId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var discount = _discountService.IsDiscountValid(discountCode, user);
            if (discount.IsSuccess)
            {
                _discountService.ApplyDiscountinBasket(discountCode, basketId);
            }
            else
            {
                TempData["InvalidMessage"] = String.Join(Environment.NewLine, discount.Messages.Select(a => String.Join(",", a)));
            }
            return RedirectToAction("Index");

        }

        [AllowAnonymous]
        public IActionResult DeleteDiscount(int basketId)
        {
            _discountService.DeleteDiscountinBasket(basketId);
            return RedirectToAction("Index");

        }

    }
}
