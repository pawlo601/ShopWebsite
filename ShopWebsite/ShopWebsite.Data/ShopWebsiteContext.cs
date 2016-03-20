using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Data
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class ShopWebsiteContext: DbContext
    {
        private static string cs = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=dat13;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ShopWebsiteContext() : base(cs) { }

        public DbSet<Product> Products { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
