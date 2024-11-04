using BeautyLand.Application.Services.Databases.MongoDatabase;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Infrastructure.Configurations.Databases.IdentitySQLDatabase;
using BeautyLand.Infrastructure.Configurations.Databases.SQLDatabase;
using BeautyLand.Persistence.Databases.MongoDatabase;
using BeautyLand.SiteEndPoint.Filters.GuestUserFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using BeautyLand.SiteEndPoint.Middlewares;
using BeautyLand.Application.Services.Site.GuestUsers.GuestUserProfile;
using BeautyLand.Infrastructure.Configurations.Mappers.GuestUsers;
using AutoMapper;
using BeautyLand.SiteEndPoint.Hubs.GuestUserHub;
using BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserOnline;
using BeautyLand.Infrastructure.Configurations.Mappers.TypeMappers;
using BeautyLand.Application.Services.Site.Catalogs.Types;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using BeautyLand.Application.Services.Site.Catalogs.Items.GetDetails;
using BeautyLand.Application.Services.Site.Baskets.Basket;
using BeautyLand.Infrastructure.Configurations.Mappers.UserAddressMappers;
using BeautyLand.Application.Services.Site.User;
using BeautyLand.Application.Services.Site.Catalogs.Items;
using BeautyLand.Application.Services.Site.Orders.GetOrder;
using BeautyLand.Application.Services.Site.Payments;
using BeautyLand.Application.Services.Databases.IdentitySQLDatabase;
using BeautyLand.Application.Services.Site.Discounts.GetDiscount;
using BeautyLand.Application.Services.Site.Discounts.GetDiscountHistory;
using BeautyLand.Application.Services.Site.Favorites.GetFavorites;
using BeautyLand.Application.Services.Site.Catalogs;
using BeautyLand.Infrastructure.Configurations.Mappers.BrandMappers;
using BeautyLand.Application.Services.Site.Orders.GetOrderDetail;
using BeautyLand.Application.Services.Site.Home.GetHome;
using BeautyLand.SiteEndPoint.Middlewares.NotFoundExceptionHandler;
using BeautyLand.Infrastructure.Configurations.Caches.DistributedCache;

namespace BeautyLand.SiteEndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(configureOptions =>
            {
                configureOptions.Filters.Add<GuestUserFilter>();
            });

            services.AddAuthorization();
            //MongoDatabase
            services.AddTransient(typeof(IMongoDatabaseService<>), typeof(MongoDatabase<>));

            //SQLDatabase
            services.AddTransient<ISQLDatabaseService, Persistence.Databases.SQLDatabase.SQLDatabase>();
            services.AddTransient<IIdentitySQLDatabase, Persistence.Databases.IdentitySQLDatabase.IdentitySQLDatabase>();
            services.AddSQLDatabaseConfig(Configuration);
            services.AddIdentitySQLDatabaseConfige(Configuration);

            ////Caching
            services.AddDistributedCacheConfige(Configuration);


            //Services
            services.AddTransient<IGuestUserService, GuestUserService>();
            services.AddTransient<IGuestUserOnlineService, GuestUserOnlineService>();
            services.AddSignalR();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IURIComposerService, URIComposerService>();
            services.AddTransient<IItemGetCatalogService, ItemGetCatalogService>();
            services.AddTransient<IItemDetailService, ItemDetailService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<IFavoritesService, FavoritesService>();
            services.AddTransient<IBrandGetCatalogService, BrandGetCatalogService>();
            services.AddTransient<IOrderHistoryService, OrderHistoryService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IHomeService, HomeService >();

            //AutoMappers
            services.AddAutoMapper(typeof(GuestUserMapper));
            services.AddAutoMapper(typeof(TypeMapper));
            services.AddAutoMapper(typeof(UserAddressMapper));
            services.AddAutoMapper(typeof(BrandMapper));


            services.ConfigureApplicationCookie(configureOptions =>
            {
                configureOptions.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                configureOptions.SlidingExpiration = true;
                configureOptions.LoginPath = "/Account/Signin";
                configureOptions.AccessDeniedPath = "/Account/AccessDenied";
                configureOptions.LogoutPath = "/Account/Signout";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseNotFoundExceptionMiddleware();
            app.UseGuestUserMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<GuestUserHub>("/GuestUserOnline");
            });
        }
    }
}
