using System;

namespace ShopWebsite.Data.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        ShopWebsiteContext Init();
    }
}
