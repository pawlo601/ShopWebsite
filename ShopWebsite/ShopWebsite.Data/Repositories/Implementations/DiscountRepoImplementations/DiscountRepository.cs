using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.DiscountInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Data.Repositories.Implementations.DiscountRepoImplementations
{
    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IList<Discount> GetAllEntitiesById(Expression<Func<Discount, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByName(Expression<Func<Discount, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByIsForProduct(Expression<Func<Discount, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.IsForProduct)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.IsForProduct)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByIsForCustomer(Expression<Func<Discount, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.IsForCustomer)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.IsForCustomer)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByIsForOrder(Expression<Func<Discount, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.IsForOrder)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.IsForOrder)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByIsPercentage(Expression<Func<Discount, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.IsPercentage)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.IsPercentage)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByValue(Expression<Func<Discount, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Value)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Value)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByTimeOfStartDiscount(Expression<Func<Discount, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.StartDiscount)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.StartDiscount)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }

        public IList<Discount> GetAllEntitiesByTimeOfEndDiscount(Expression<Func<Discount, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Discount> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.EndDiscount)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.EndDiscount)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Discount>();
            }
        }
    }
}
