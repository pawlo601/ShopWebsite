using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IDiscountService
    {
        Discount GetDiscount(int id, out TransactionalInformation transaction);

        Discount CreateDiscount(Discount discount, out TransactionalInformation transaction);

        void DeleteDiscount(Discount discount, out TransactionalInformation transaction);

        void DeleteDiscount(Expression<Func<Discount, bool>> where, out TransactionalInformation transaction);

        void UpdateDiscount(Discount discount, out TransactionalInformation transaction);

        Discount GetDiscount(Expression<Func<Discount, bool>> where, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsById(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByName(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByIsForProduct(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByIsForCustomer(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByIsForOrder(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByIsPercentage(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByValue(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByTimeOfStartDiscount(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Discount> GetAllDiscountsByTimeOfEndDiscount(Expression<Func<Discount, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}