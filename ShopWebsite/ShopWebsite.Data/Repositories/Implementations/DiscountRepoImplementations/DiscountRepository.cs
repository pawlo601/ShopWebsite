using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.DiscountInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Implementations.DiscountRepoImplementations
{
    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {//todo implements DiscountRepository
        public DiscountRepository(IDbFactory dbFactory): base(dbFactory) { }

        public IList<Discount> GetAllEntitiesById(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByName(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByIsForProduct(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByIsForCustomer(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByIsForOrder(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByIsPercentage(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByValue(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByTimeOfStartDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllEntitiesByTimeOfEndDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
