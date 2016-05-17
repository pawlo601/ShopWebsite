using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.DiscountInterfaces;
using ShopWebsite.Data.Services.Interfaces.DiscountServiceInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Services.Implementations.DiscountServiceImplementations
{
    public class DiscountService : MainService, IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _discountRepository = discountRepository;
        }

        public Discount GetDiscount(int id, out TransactionalInformation transaction)
        {
            return _discountRepository.GetEntityById(id, out transaction);
        }

        public Discount CreateDiscount(Discount discount, out TransactionalInformation transaction)
        {
            return _discountRepository.AddNewEntity(discount, out transaction);
        }

        public void DeleteDiscount(Discount discount, out TransactionalInformation transaction)
        {
            _discountRepository.DeleteEntity(discount1 => discount1.Id == discount.Id, out transaction);
        }

        public void DeleteDiscount(Expression<Func<Discount, bool>> @where, out TransactionalInformation transaction)
        {
            _discountRepository.DeleteEntity(where, out transaction);
        }

        public void UpdateDiscount(Discount discount, out TransactionalInformation transaction)
        {
            _discountRepository.UpdateEntity(discount, out transaction);
        }

        public Discount GetDiscount(Expression<Func<Discount, bool>> @where, out TransactionalInformation transaction)
        {
            return _discountRepository.GetEntity(where, out transaction);
        }

        public IList<Discount> GetAllDiscountsById(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Discount> GetAllDiscountsByName(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Discount> GetAllDiscountsByIsForProduct(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByIsForProduct(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Discount> GetAllDiscountsByIsForCustomer(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByIsForCustomer(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Discount> GetAllDiscountsByIsForOrder(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByIsForOrder(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Discount> GetAllDiscountsByIsPercentage(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByIsPercentage(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Discount> GetAllDiscountsByValue(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByValue(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Discount> GetAllDiscountsByTimeOfStartDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByTimeOfStartDiscount(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Discount> GetAllDiscountsByTimeOfEndDiscount(Expression<Func<Discount, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _discountRepository.GetAllEntitiesByTimeOfEndDiscount(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }
    }
}