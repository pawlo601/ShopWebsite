using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IProductService
    {
        Cost GetCostOfProduct(int id, out TransactionalInformation transaction);

        IList<ProductDiscount> GetAllDiscountsOfProduct(int id, out TransactionalInformation transaction);

        Product GetProduct(int id, out TransactionalInformation transaction);

        Product CreateProduct(Product product, out TransactionalInformation transaction);

        void DeleteProduct(Product product, out TransactionalInformation transaction);

        void DeleteProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);

        void UpdateProduct(Product product, out TransactionalInformation transaction);

        Product GetProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);

        IList<Product> GetAllProductsById(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllProductsByName(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllProductsByDescription(Expression<Func<Product, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllProductsByDiscount(Expression<Func<Product, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllProductsByQuantityValue(Expression<Func<Product, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllProductsByCostValue(Expression<Func<Product, bool>> where, int currentPageNumber,
            int pageSize, Currency currency, bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}
