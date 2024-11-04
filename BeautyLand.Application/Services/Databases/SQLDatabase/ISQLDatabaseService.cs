using BeautyLand.Domain.Banner;
using BeautyLand.Domain.Baskets;
using BeautyLand.Domain.Catalogs.Brands;
using BeautyLand.Domain.Catalogs.Features;
using BeautyLand.Domain.Catalogs.Images;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Domain.Catalogs.Type;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Favorites;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Payments;
using BeautyLand.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace BeautyLand.Application.Services.Databases.SQLDatabase
{
   public interface ISQLDatabaseService
    {
         DbSet<Brand> Brands { get; set; }
         DbSet<Type> Types { get; set; }
         DbSet<Image> Images { get; set; }
         DbSet<Feature> Features { get; set; }
         DbSet<Item> Items { get; set; }
         DbSet<Basket> Baskets { get; set; }
         DbSet<BasketItem> BasketItems { get; set; }
         DbSet<UserAddress> UserAddresses { get; set; }
         DbSet<Order> Orders { get; set; }
         DbSet<OrderItem> OrderItems { get; set; }
         DbSet<Payment> Payments { get; set; }
         DbSet<Discount> Discounts { get; set; }
         DbSet<DiscountHistory> DiscountHistories { get; set; }
        DbSet<Favorites> Favorites { get; set; }
         DbSet<Banner> Banners { get; set; }

        int SaveChanges();
        EntityEntry Entry([NotNullAttribute] object entity);
    }
}
