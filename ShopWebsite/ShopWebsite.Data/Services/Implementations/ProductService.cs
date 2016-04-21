using ShopWebsite.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public readonly IUnitOfWork UnitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            UnitOfWork = unitOfWork;
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
            _productRepository.DeleteEntity(product, out transaction);
        }

        public IEnumerable<Product> GetAllProducts(int currentPageNumber, int pageSize, string sortExpression, bool ifDesc, string filter, out int totalRows, out TransactionalInformation transaction)
        {
            Expression<Func<Product, bool>> filterExpression;
            if (filter.Equals(""))
            {
                filterExpression = a => true;
            }
            else
            {
                filterExpression = a =>
                    a.Id.ToString().Contains(filter) ||
                    a.Name.Contains(filter) ||
                    a.Description.Contains(filter);

            }
            if (sortExpression.Equals("name") || sortExpression.Equals("description"))
            {
                Expression<Func<Product, string>> sortExpressionFunc = a => a.Name;
                if (sortExpression.Equals("description"))
                {
                    sortExpressionFunc = a => a.Description;
                }
                return _productRepository.GetAll(filterExpression, currentPageNumber, pageSize, sortExpressionFunc, ifDesc, out totalRows, out transaction);
            }
            //else if (sortExpression.Equals("quantity") || sortExpression.Equals("price"))
            //{
            //    Expression<Func<Product, decimal>> sortExpressionFunc = a => a.QuantityPerUnit;
            //    if (sortExpression.Equals("price"))
            //    {
            //        sortExpressionFunc = a => a.PricePerUnit;
            //    }
            //    return _productRepository.GetAll(filterExpression, currentPageNumber, pageSize, sortExpressionFunc, ifDesc, out totalRows, out transaction);
            //}
            else
            {
                Expression<Func<Product, int>> sortExpressionFunc = a => a.Id;
                return _productRepository.GetAll(filterExpression, currentPageNumber, pageSize, sortExpressionFunc, ifDesc, out totalRows, out transaction);
            }
        }

        public Product GetProduct(int id, out TransactionalInformation transaction)
        {
            return _productRepository.GetById(id, out transaction);
        }

        public Product GetIf(Expression<Func<Product, bool>> where, out TransactionalInformation transaction)
        {
            return _productRepository.GetIf(where, out transaction);
        }

        public void SaveProduct()
        {
            UnitOfWork.Commit();
        }

        public void UpdateEntity(Product entity, out TransactionalInformation transaction)
        {
            _productRepository.UpdateEntity(entity, out transaction);
        }
    }
}
