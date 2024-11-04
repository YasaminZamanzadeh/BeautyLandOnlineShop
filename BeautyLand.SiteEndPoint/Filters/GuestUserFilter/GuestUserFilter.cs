using BeautyLand.Application.Services.Site.GuestUsers.GuestUserProfile;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace BeautyLand.SiteEndPoint.Filters.GuestUserFilter
{
    public class GuestUserFilter : IActionFilter
    {
        private readonly IGuestUserService _guestUserProfileService;
        public GuestUserFilter(IGuestUserService guestUserProfileService)
        {
            _guestUserProfileService = guestUserProfileService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var clientId = context.HttpContext.Request.Cookies["GuestUserId"];
            var ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var action = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controller = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var sourceUrl = context.HttpContext.Request.Headers["Referer"].ToString();
            var activeUrl = context.HttpContext.Request.Path;
            var request = context.HttpContext.Request;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            var parser = Parser.GetDefault();
            var clientDetail = parser.Parse(userAgent); 
            
            _guestUserProfileService.Execute(new GuestUserDto
            {
                System = new GuestUserSystemDto
                {
                    Family = clientDetail.Device.Family,
                    Model = clientDetail.Device.Model,
                    IsSpider = clientDetail.Device.IsSpider,
                },

                Browser = new GuestUserSystemProfileDto
                {
                    Family = clientDetail.UA.Family,
                    Version = $"{clientDetail.UA.Major}.{clientDetail.UA.Minor}.{clientDetail.UA.Patch}"
                },

                OperatingSystem = new GuestUserSystemProfileDto
                {
                    Family = clientDetail.OS.Family,
                    Version = $"{clientDetail.OS.Major}.{clientDetail.OS.Minor}.{clientDetail.OS.Patch}"
                },

                GuestUserId = clientId,
                Ip = ip,
                HttpMethod = request.Method,
                HttpProtocol = request.Protocol,
                Path = $"{controller}/{action}",
                ActiveUrl = activeUrl,
                SourceUrl = sourceUrl,
                CreateDate = DateTime.Now

            });
        }
    }
}