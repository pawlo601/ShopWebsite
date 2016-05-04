using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {//ok
        public ProductRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}
