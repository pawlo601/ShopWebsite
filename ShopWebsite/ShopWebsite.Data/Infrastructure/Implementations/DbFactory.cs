using ShopWebsite.Data.Infrastructure.Interfaces;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public class DbFactory : Disposable, IDbFactory
    {
        ShopWebsiteContext _dbContext;
        public ShopWebsiteContext Init()
        {
            return _dbContext ?? (_dbContext = new ShopWebsiteContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
