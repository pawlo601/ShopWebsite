using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class MainDiscountRepository: IMainDiscountRepository
    {
        private ShopWebsiteContext _dataContext;
        private readonly IDbSet<MainDiscount> _dbSet;
        protected IDbFactory DbFactory { get; }
        protected ShopWebsiteContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        protected MainDiscountRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<MainDiscount>();
        }

        public Discount AddNewEntity(Discount entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Discount entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<ProductDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<OrderDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<CustomerDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public ProductDiscount GetEntity(Expression<Func<ProductDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public OrderDiscount GetEntity(Expression<Func<OrderDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public CustomerDiscount GetEntity(Expression<Func<CustomerDiscount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDiscount> GetAllEntities(Expression<Func<ProductDiscount, bool>> @where, int currentPageNumber, int pageSize, Expression<Func<ProductDiscount, IComparable>> sortExpression,
            bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDiscount> GetAllEntities(Expression<Func<OrderDiscount, bool>> @where, int currentPageNumber, int pageSize, Expression<Func<OrderDiscount, IComparable>> sortExpression,
            bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDiscount> GetAllEntities(Expression<Func<CustomerDiscount, bool>> @where, int currentPageNumber, int pageSize, Expression<Func<CustomerDiscount, IComparable>> sortExpression,
            bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
