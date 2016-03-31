using ShopWebsite.Data.Infrastructure.Interfaces;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ShopWebsiteContext _dbContext;
        public ShopWebsiteContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
