using AutoMapper;
using BeautyLand.Application.Services.Administrator.Banner.GetBanner;
using BeautyLand.Application.Services.Administrator.Catalogs.Items;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.GetBrands;
using BeautyLand.Application.Services.Administrator.Catalogs.Items.GetTypes;
using BeautyLand.Application.Services.Administrator.Catalogs.Types;
using BeautyLand.Application.Services.Administrator.Discounts.GetDiscount;
using BeautyLand.Application.Services.Administrator.GuestUsers.GuestUserReport;
using BeautyLand.Application.Services.Databases.IdentitySQLDatabase;
using BeautyLand.Application.Services.Databases.MongoDatabase;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Infrastructure.Configurations.Caches.DistributedCache;
using BeautyLand.Infrastructure.Configurations.Databases.IdentitySQLDatabase;
using BeautyLand.Infrastructure.Configurations.Databases.SQLDatabase;
using BeautyLand.Infrastructure.Configurations.Mappers.DiscountMappers;
using BeautyLand.Infrastructure.Configurations.Mappers.ItemMappers;
using BeautyLand.Infrastructure.Configurations.Mappers.TypeMappers;
using BeautyLand.Infrastructure.Services.Catalogs.Items;
using BeautyLand.Persistence.Databases.MongoDatabase;
using BeautyLand.Subscription.Services.Catalogs.Items.GetImages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BeautyLand.AdministratorEndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllers();

            //MongoDatabase
            services.AddTransient(typeof(IMongoDatabaseService<>), typeof(MongoDatabase<>));

            //SQLDatabase
            services.AddTransient<ISQLDatabaseService, Persistence.Databases.SQLDatabase.SQLDatabase>();
            services.AddTransient<IIdentitySQLDatabase, Persistence.Databases.IdentitySQLDatabase.IdentitySQLDatabase>();
            services.AddSQLDatabaseConfig(Configuration);
            services.AddIdentitySQLDatabaseConfige(Configuration);


            //Caching
            services.AddDistributedCacheConfige(Configuration);

            //Services
            services.AddTransient<IGuestUserReportService, GuestUserReportService>();
            services.AddTransient<ITypeService, TypeService>(); 
			services.AddTransient<IItemService, ItemService>();
			services.AddTransient<ITypeGetCatalogService, TypeGetCatalogService>();
			services.AddTransient<IBrandGetCatalogService, BrandGetCatalogService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IURIComposerService, URIComposerService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IBannerService, BannerService>();

            

            //AutoMappers
            services.AddAutoMapper(typeof(TypeMapper));
			services.AddAutoMapper(typeof(ItemMapper));
            services.AddAutoMapper(typeof(DiscountMapper));


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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
