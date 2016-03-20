using ShopWebsite.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public class DbFactory : Disposable, IDbFactory
    {
        ShopWebsiteContext dbContext;
        public ShopWebsiteContext Init()
        {
            return dbContext ?? (dbContext = new ShopWebsiteContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
