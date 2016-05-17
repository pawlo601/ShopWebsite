using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Interfaces.ProductInterfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetAllEntitiesById(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllEntitiesByName(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllEntitiesByDescription(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllEntitiesByDiscount(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllEntitiesByQuantityValue(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Product> GetAllEntitiesByCostValue(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize,
            Currency currency, bool ifDesc, out TransactionalInformation transaction);

    }
}
