using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IMainDiscountRepository
    {
        Discount AddNewEntity(Discount entity, out TransactionalInformation transaction);
        void UpdateEntity(Discount entity, out TransactionalInformation transaction);
        void DeleteEntity(Expression<Func<ProductDiscount, bool>> where, out TransactionalInformation transaction);
        void DeleteEntity(Expression<Func<OrderDiscount, bool>> where, out TransactionalInformation transaction);
        void DeleteEntity(Expression<Func<CustomerDiscount, bool>> where, out TransactionalInformation transaction);
        ProductDiscount GetEntity(Expression<Func<ProductDiscount, bool>> where, out TransactionalInformation transaction);
        OrderDiscount GetEntity(Expression<Func<OrderDiscount, bool>> where, out TransactionalInformation transaction);
        CustomerDiscount GetEntity(Expression<Func<CustomerDiscount, bool>> where, out TransactionalInformation transaction);
        IEnumerable<ProductDiscount> GetAllEntities(Expression<Func<ProductDiscount, bool>> where, int currentPageNumber, int pageSize, Expression<Func<ProductDiscount, IComparable>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction);
        IEnumerable<OrderDiscount> GetAllEntities(Expression<Func<OrderDiscount, bool>> where, int currentPageNumber, int pageSize, Expression<Func<OrderDiscount, IComparable>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction);
        IEnumerable<CustomerDiscount> GetAllEntities(Expression<Func<CustomerDiscount, bool>> where, int currentPageNumber, int pageSize, Expression<Func<CustomerDiscount, IComparable>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction);
    }
}