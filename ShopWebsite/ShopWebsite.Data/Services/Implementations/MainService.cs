using ShopWebsite.Data.Infrastructure.Interfaces;

namespace ShopWebsite.Data.Services.Implementations
{
    public abstract class MainService
    {
        public readonly IUnitOfWork UnitOfWork;

        protected MainService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void SaveProduct()
        {
            UnitOfWork.Commit();
        }
    }
}