using System;
using ShopWebsite.Data.DataBaseContexts;

namespace ShopWebsite.Data.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        ShopWebsiteContext Init();
    }
}
