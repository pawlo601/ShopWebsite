using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.ProductInterfaces;
using ShopWebsite.Data.Services.Interfaces.ProductServiceInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Implementations.ProductServiceImplementations
{
    public class ProductService : MainService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
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

        public IList<Product> GetAllProductsById(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Product> GetAllProductsByName(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Product> GetAllProductsByDescription(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesByDescription(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Product> GetAllProductsByDiscount(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesByDiscount(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Product> GetAllProductsByQuantityValue(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesByQuantityValue(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Product> GetAllProductsByCostValue(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, Currency currency, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _productRepository.GetAllEntitiesByCostValue(where, currentPageNumber, pageSize, currency, ifDesc,
                out transaction);
        }

        public void UpdateProduct(Product product, out TransactionalInformation transaction)
        {
            _productRepository.UpdateEntity(product, out transaction);
        }


    }
}
