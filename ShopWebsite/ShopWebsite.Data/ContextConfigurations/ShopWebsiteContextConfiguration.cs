using System.Data.Entity;
using System.Data.Entity.SqlServer;
using ShopWebsite.Data.Initizlizers;

namespace ShopWebsite.Data.ContextConfigurations
{
    public class ShopWebsiteContextConfiguration : DbConfiguration
    {
        public ShopWebsiteContextConfiguration()
        {
            SetDatabaseInitializer(new ShopWebsiteContextInitizlizer()); //drop table and add start values
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
