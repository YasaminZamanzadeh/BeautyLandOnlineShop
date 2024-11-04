using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Banner;
using BeautyLand.Domain.Baskets;
using BeautyLand.Domain.Catalogs.Brands;
using BeautyLand.Domain.Catalogs.Features;
using BeautyLand.Domain.Catalogs.Items;
using BeautyLand.Domain.Discounts;
using BeautyLand.Domain.Favorites;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Payments;
using BeautyLand.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Persistence.Databases.SQLDatabase
{
    public class SQLDatabase : DbContext, ISQLDatabaseService
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Domain.Catalogs.Type.Type> Types { get; set; }
        public DbSet<Domain.Catalogs.Images.Image> Images { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountHistory> DiscountHistories { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Banner> Banners { get; set; }

        
        public SQLDatabase(DbContextOptions<SQLDatabase> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityTypes in modelBuilder.Model.GetEntityTypes())
            {
                if (entityTypes.ClrType.GetCustomAttributes(typeof(AudiTable), true).Length > 0)
                {

                    modelBuilder
                        .Entity(entityTypes.Name)
                        .Property<DateTime?>("CreateDate")
                        .HasDefaultValue(DateTime.Now);


                    modelBuilder
                        .Entity(entityTypes.Name)
                        .Property<DateTime?>("ModifiedDate");

                    modelBuilder
                        .Entity(entityTypes.Name)
                        .Property<DateTime?>("DeleteDate");

                    modelBuilder
                        .Entity(entityTypes.Name)
                        .Property<bool>("IsDeleted")
                        .HasDefaultValue(false);
                }
            }

            //HasQueryFilter method with using of EF to show data which is not deleted in database
            modelBuilder.Entity<Type>().HasQueryFilter(entity => EF.Property<bool>(entity, "IsDeleted") == false);
            modelBuilder.Entity<Basket>().HasQueryFilter(entity => EF.Property<bool>(entity, "IsDeleted") == false);
            modelBuilder.Entity<BasketItem>().HasQueryFilter(entity => EF.Property<bool>(entity, "IsDeleted") == false);


            //OwnsOne method converts all data in this property to own itself property 
            modelBuilder.Entity<Order>().OwnsOne(ownedTypeName => ownedTypeName.Address);


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(entry =>
                entry.State == EntityState.Added ||
                entry.State == EntityState.Modified ||
                entry.State == EntityState.Deleted
            );

            foreach (var item in entries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var createProperty = entityType?.FindProperty("CreateDate");
                    var modifiedProperty = entityType?.FindProperty("ModifiedDate");
                    var deleteProperty = entityType?.FindProperty("DeleteDate");
                    var isDeletedProperty = entityType?.FindProperty("IsDeleted");

                    if (item.State == EntityState.Added && createProperty != null)
                    {
                        item.Property("CreateDate").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified && modifiedProperty != null)
                    {
                        item.Property("ModifiedDate").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Deleted)
                    {

                        if (deleteProperty != null && isDeletedProperty != null)
                        {
                            item.Property("DeleteDate").CurrentValue = DateTime.Now;
                            item.Property("IsDeleted").CurrentValue = true;

                            item.State = EntityState.Modified;
                        }
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}