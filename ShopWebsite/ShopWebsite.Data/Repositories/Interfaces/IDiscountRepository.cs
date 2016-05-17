using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IList<Discount> GetAllEntitiesById(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByName(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByIsForProduct(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByIsForCustomer(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByIsForOrder(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByIsPercentage(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByValue(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByTimeOfStartDiscount(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllEntitiesByTimeOfEndDiscount(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}