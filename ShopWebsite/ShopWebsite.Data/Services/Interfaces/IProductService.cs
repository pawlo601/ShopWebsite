using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id, out TransactionalInformation transaction);

        Product CreateProduct(Product product, out TransactionalInformation transaction);

        void DeleteProduct(Product product, out TransactionalInformation transaction);

        void DeleteProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);

        void UpdateProduct(Product product, out TransactionalInformation transaction);

        Product GetProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);

        IList<Product> GetAllProducts(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize, Expression<Func<Product, IComparable>> sortExpression, bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}
