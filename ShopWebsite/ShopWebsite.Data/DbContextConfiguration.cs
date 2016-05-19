using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ShopWebsite.Data
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            //SetDatabaseInitializer(new DropCreateDatabaseAlways<WebSiteDatabase>());// drop all table and information
            SetDatabaseInitializer(new MyInitizlizer()); //drop table and add start values
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
