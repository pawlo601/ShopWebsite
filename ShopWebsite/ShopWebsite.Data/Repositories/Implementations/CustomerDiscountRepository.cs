using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class CustomerDiscountRepository : RepositoryBase<CustomerDiscount>, ICustomerDiscountRepository
    {//ok
        public CustomerDiscountRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}