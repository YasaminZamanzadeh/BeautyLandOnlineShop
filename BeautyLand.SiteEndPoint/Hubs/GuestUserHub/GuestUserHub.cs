using BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserOnline;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Hubs.GuestUserHub
{
    public class GuestUserHub:Hub
    {
        private readonly IGuestUserOnlineService _guestUserOnlineService;
        public GuestUserHub(IGuestUserOnlineService guestUserOnlineService)
        {
            _guestUserOnlineService = guestUserOnlineService;
        }
        public override Task OnConnectedAsync()
        {
            var guestUserId = Context.GetHttpContext().Request.Cookies["GuestUserId"];
            _guestUserOnlineService.Connected(guestUserId);
            var countConnection = _guestUserOnlineService.Count();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var guestUserId = Context.GetHttpContext().Request.Cookies["GuestUserId"];
            _guestUserOnlineService.Disconnected(guestUserId);
            var countDisconnection = _guestUserOnlineService.Count();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
