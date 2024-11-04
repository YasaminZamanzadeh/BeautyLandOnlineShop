using BeautyLand.Application.Services.Site.Baskets.Basket;
using BeautyLand.Domain.Users;
using BeautyLand.SiteEndPoint.Models.ViewModels.SigninViewModel;
using BeautyLand.SiteEndPoint.Models.ViewModels.SignupViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketService _basketService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IBasketService basketService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketService = basketService;
        }
        public IActionResult Signin(string returnUrl = "/")
        {

            return View(new SigninViewModel
            {
                ReturnUrl = returnUrl,
            });
        }
        [HttpPost]
        public IActionResult Signin(SigninViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
            {
                return View(model);
            }
            _signInManager.SignOutAsync();

            var result = _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true).Result;

            if (result.Succeeded)
            {
               TransferUserBasket(user.Id);
                return Redirect(model.ReturnUrl);
                
            }

            if (result.IsLockedOut)
            {

            }
            if (result.RequiresTwoFactor)
            {

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User
            {
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                PhoneNumber = model.Phone

            };
            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                var signedupUser = _userManager.FindByNameAsync(user.Email).Result;
                TransferUserBasket(signedupUser.Id);
                _signInManager.SignInAsync(user, true).Wait();
                return View(nameof(Profile));
            }
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return View(model);
        }
        public IActionResult Signout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            return View();
        }
        private void TransferUserBasket(string userId)
        {
            string cookieName = "BasketId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                var anonymousId = Request.Cookies[cookieName];
                _basketService.TransferBasket(anonymousId, userId);
                Response.Cookies.Delete(anonymousId);
            }

        }
    }
}