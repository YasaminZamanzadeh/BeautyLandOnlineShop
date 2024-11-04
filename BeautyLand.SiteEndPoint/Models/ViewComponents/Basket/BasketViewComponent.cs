using BeautyLand.Application.Services.Site.Baskets.Basket;
using BeautyLand.SiteEndPoint.Claims.UserClaim;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Models.ViewComponents.Baskets
{
    public class BasketViewComponent : ViewComponent
    {
      
            private readonly IBasketService _basketService;
            public BasketViewComponent(IBasketService basketService)
            {
                this._basketService = basketService;
            }
            private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext?.User;
            public IViewComponentResult Invoke()
            {
                BasketDto basket = null;
                if (User.Identity.IsAuthenticated)
                {
                    basket = _basketService.GetBasket(UserClaim.GetUserId(userClaimsPrincipal));
                }
                else
                {
                    string basketCookieName = "BasketId";
                    if (Request.Cookies.ContainsKey(basketCookieName))
                    {
                        var buyerId = Request.Cookies[basketCookieName];
                        basket = _basketService.GetorSetBasket(buyerId);
                    }

                }
                return View(viewName: "BasketComponent", model: basket);
            }
        }
    }