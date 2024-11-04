using BeautyLand.Application.Services.Site.Baskets.Basket;
using BeautyLand.Application.Services.Site.UserAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Models.ViewModels
{
    public class PaymentViewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; }

    }
}
