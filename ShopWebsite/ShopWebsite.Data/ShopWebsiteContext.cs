﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;


namespace ShopWebsite.Data
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class ShopWebsiteContext : DbContext
    {
        public DbSet<Currency> Curriencies { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }   
              
        public ShopWebsiteContext() : base(ShopWebsite.Configuration.Configuration.ConnectionString)
        {
            if(ShopWebsite.Configuration.Configuration.ReloadDatabase)
                Database.Initialize(true); //is to innitialize every time app runs
        }

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
