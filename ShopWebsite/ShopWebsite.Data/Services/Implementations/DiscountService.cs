using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Services.Implementations
{
    public class DiscountService : MainService, IDiscountService
    {//todo implements DiscountService
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _discountRepository = discountRepository;
        }

        public Discount GetDiscount(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Discount CreateDiscount(Discount discount, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscount(Discount discount, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscount(Expression<Func<Discount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateDiscount(Discount discount, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Discount GetDiscount(Expression<Func<Discount, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsById(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByName(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByIsForProduct(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByIsForCustomer(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByIsForOrder(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByIsPercentage(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByValue(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByTimeOfStartDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Discount> GetAllDiscountsByTimeOfEndDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}