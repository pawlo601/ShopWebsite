using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRespository
    {
        public UserRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}
