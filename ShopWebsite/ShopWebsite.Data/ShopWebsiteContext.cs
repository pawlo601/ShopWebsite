using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ShopWebsite.Data
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class ShopWebsiteContext : DbContext
    {
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
