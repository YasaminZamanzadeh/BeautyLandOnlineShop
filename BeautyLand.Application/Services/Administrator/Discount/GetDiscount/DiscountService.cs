using BeautyLand.Application.Services.Administrator.Discounts.Dtos.ItemDto;
using BeautyLand.Application.Services.Databases.IdentitySQLDatabase;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.Discounts.GetDiscount
{
    public class DiscountService : IDiscountService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IIdentitySQLDatabase _identityContext;
        //private readonly IMapper _mapper;
        public DiscountService(ISQLDatabaseService context, /*IMapper mapper,*/ IIdentitySQLDatabase identityContext)
        {
            _context = context;
            _identityContext = identityContext;
            //_mapper = mapper;

        }
        public void GetDiscount(DiscountDto discount)
        {
            var model = new Domain.Discounts.Discount()
            {
                Name = discount.Name,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                UseCouponCode = discount.UseCouponCode,
                DiscountCode = discount.DiscountCode,
                UseAmount = discount.UseAmount,
                DiscountAmount = discount.DiscountAmount,
                UsePercentage = discount.UsePercentage,
                DiscountPercentage = discount.DiscountPercentage,
                DiscountLimitationTypeId = discount.DiscountLimitationTypeId,
                LimitationTime = discount.LimitationTime,
                DiscountTypeId = discount.DiscountTypeId,
            };

            //if (model.Users != null)
            //{
            //    var users = _identityContext.Users.Where(p => discount.Users == model.Users).ToList();
            //    model.Users = users;
            //}

            //if (model.Brands != null)
            //{
            //    var brands = _context.Brands.Where(p => discount.Brands.Contains(p.Id)).ToList();
            //    model.Brands = brands;
            //}

            //if (model.Types != null)
            //{
            //    var types = _context.Types.Where(p => discount.Types.Contains(p.Id)).ToList();
            //    model.Types = types;
            //}

            if (discount.Items != null)
            {
                var items = _context.Items.Where(p => discount.Items.Contains(p.Id)).ToList();
                model.Items = items;
            }

            _context.Discounts.Add(model);
            _context.SaveChanges();

        }

        public List<ItemDto> GetItem(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var item = _context.Items
                    .Where(p => p.Name.Contains(term))
                    .Select(p => new ItemDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
                return item;
            }
            else
            {
                var item = _context.Items
                 .OrderByDescending(p => p.Id)
                 .Take(20)
                 .Select(p => new ItemDto
                 {
                     Id = p.Id,
                     Name = p.Name
                 }).ToList();
                return item;
            }

        }
        //public List<UserDto> GetUser(string term)
        //{
        //    if (!string.IsNullOrEmpty(term))
        //    {
        //        var types = _identityContext.Users
        //            .Where(p => p.Email.Contains(term))
        //            .Select(p => new UserDto
        //            {
        //                Id = p.Id,
        //                Name = p.UserName
        //            }).ToList();

        //        return types;
        //    }
        //    else
        //    {
        //        var types = _identityContext.Users
        //              .OrderByDescending(p => p.Id)
        //             .Take(20)
        //             .Select(p => new UserDto
        //             {
        //                 Id = p.Id,
        //                 Name = p.UserName
        //             }).ToList();

        //        return types;
        //    }
        //}
        //public List<TypeDto> GetType(string term)
        //{
        //    if (!string.IsNullOrEmpty(term))
        //    {
        //        var type = _context.Types
        //            .Where(p => p.Name.Contains(term))
        //            .Select(p => new TypeDto
        //            {
        //                Id = p.Id,
        //                Name = p.Name
        //            }).ToList();

        //        return type;
        //    }
        //    else
        //    {
        //        var type = _context.Types
        //              .OrderByDescending(p => p.Id)
        //             .Take(20)
        //             .Select(p => new TypeDto
        //             {
        //                 Id = p.Id,
        //                 Name = p.Name
        //             }).ToList();

        //        return type;
        //    }

        //}
        //public List<BrandDto> GetBrand(string term)
        //{
        //    if (!string.IsNullOrEmpty(term))
        //    {
        //        var brands = _context.Brands
        //            .Where(p => p.Name.Contains(term))
        //            .Select(p => new BrandDto
        //            {
        //                Id = p.Id,
        //                Name = p.Name
        //            }).ToList();

        //        return brands;
        //    }
        //    else
        //    {
        //        var brands = _context.Brands
        //              .OrderByDescending(p => p.Id)
        //             .Take(20)
        //             .Select(p => new BrandDto
        //             {
        //                 Id = p.Id,
        //                 Name = p.Name
        //             }).ToList();

        //        return brands;
        //    }
        //}
    }
}
