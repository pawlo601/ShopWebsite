using System;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;

namespace ShopWebsite.Data.Services.Implementations
{
    public class DatabaseService: IDatabaseService
    {
        private readonly IProductRepository _productRepository;
        public readonly IUnitOfWork UnitOfWork;

        public DatabaseService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            UnitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public void SavaAllProductsToXml()
        {
            throw new NotImplementedException();
        }

        public void SaveAllOrdersToXml()
        {
            throw new NotImplementedException();
        }

        public void DropAllTables()
        {
            throw new NotImplementedException();
        }

        public void DeleteAllProducts()
        {
            throw new NotImplementedException();
        }

        public void DeleteAllOrders()
        {
            throw new NotImplementedException();
        }

        public void LoadProductsFromXml()
        {
            throw new NotImplementedException();
        }

        public void LoadOrdersFromXml()
        {
            throw new NotImplementedException();
        }
    }
}
