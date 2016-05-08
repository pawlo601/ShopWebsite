using ShopWebsite.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Implementations
{
    public class ProductService : MainService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product, out TransactionalInformation transaction)
        {
            return _productRepository.AddNewEntity(product, out transaction);
        }

        public void DeleteProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction)
        {
            _productRepository.DeleteEntity(where, out transaction);
        }

        public void DeleteProduct(Product product, out TransactionalInformation transaction)
        {
            _productRepository.DeleteEntity(product1 => product.Id == product1.Id, out transaction);
        }

        public Product GetProduct(int id, out TransactionalInformation transaction)
        {
            return _productRepository.GetEntityById(id, out transaction);
        }

        public Product GetProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction)
        {
            return _productRepository.GetEntity(where, out transaction);
        }

        public IList<Product> GetAllProducts(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, Expression<Func<Product, IComparable>> sortExpression, bool ifDesc, out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntities(where, currentPageNumber, pageSize, sortExpression, ifDesc,
                out transaction);
        }

        public void UpdateProduct(Product product, out TransactionalInformation transaction)
        {
            _productRepository.UpdateEntity(product, out transaction);
        }
    }
}
