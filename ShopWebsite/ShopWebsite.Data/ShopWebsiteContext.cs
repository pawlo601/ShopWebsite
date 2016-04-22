﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShopWebsite.Data.Common;
using ShopWebsite.Model.Entities.Customer;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class ShopWebsiteContext : DbContext
    {
        public ShopWebsiteContext() : base(GetDataFromXml.ConnectionString)
        {
            if(GetDataFromXml.ReloadDatabase)
                Database.Initialize(true); //is to innitialize every time app runs
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

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
