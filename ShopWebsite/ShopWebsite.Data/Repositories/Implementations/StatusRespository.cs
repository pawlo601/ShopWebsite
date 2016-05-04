using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class StatusRespository : RepositoryBase<Status>, IStatusRespository
    {
        public StatusRespository(IDbFactory dbFactory): base(dbFactory) { }
    }
}
