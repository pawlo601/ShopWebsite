using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShopWebsite.Data.ContextConfigurations;
using ShopWebsite.Model.Entities.Audit;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.DataBaseContexts
{
    [DbConfigurationType(typeof(ShopWebsiteContextConfiguration))]
    public class ShopWebsiteContext : DbContext
    {
        public DbSet<Currency> Curriencies { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Audit> Audits { get; set; }

        public ShopWebsiteContext() : base(ShopWebsite.Configuration.Configuration.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("Link_Permissions_Roles", "User").MapLeftKey("permission_id").MapRightKey("role_id"));
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("Link_Users_Roles", "User").MapLeftKey("user_id").MapRightKey("role_id"));
        }
    }
}
