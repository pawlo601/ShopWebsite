using System;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.DataBaseContexts;
using ShopWebsite.Data.Infrastructure.Interfaces;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public class DbFactory : Disposable, IDbFactory
    {
        ShopWebsiteContext _dbContext;

        public ShopWebsiteContext Init()
        {
            try
            {
                return _dbContext ?? (_dbContext = new ShopWebsiteContext());
            }
            catch (Exception exc)
            {
                LoggingException.LogException(
                    "DbFactory",
                    "Init",
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    "Error in connection with database",
                    exc);
                return null;
            }
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
