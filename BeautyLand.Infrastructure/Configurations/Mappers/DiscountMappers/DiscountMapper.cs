using AutoMapper;
using BeautyLand.Application.Services.Administrator.Discounts.GetDiscount;
using BeautyLand.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.DiscountMappers
{
  public class DiscountMapper: Profile
    {
        public DiscountMapper()
        {
            CreateMap<Discount, DiscountDto>()
                .ReverseMap();
        }
    }
}
