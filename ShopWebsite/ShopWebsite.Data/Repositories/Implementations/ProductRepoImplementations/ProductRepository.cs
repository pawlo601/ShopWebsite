using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.ProductInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Implementations.ProductRepoImplementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
//todo correct namespace in repo and service
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IList<ProductDiscount> GetAllDiscountsOfProduct(int id, out TransactionalInformation transaction)
        {
            try
            {
                List<ProductDiscount> t =
                    _dbSet
                        .Include(f => f.ProductDiscounts.Select(g => g.Discount))
                        .FirstOrDefault(a => a.Id == id)
                        .ProductDiscounts;
                int c = t.Count;
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(c);
                return t;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<ProductDiscount>();
            }
        }

        public Cost GetCostOfProduct(int id, out TransactionalInformation transaction)
        {
            try
            {
                Cost t =
                    _dbSet
                        .Include(a => a.Cost)
                        .Include(a => a.Cost.Prices.Select(b => b.Currency))
                        .FirstOrDefault(a => a.Id == id)
                        .Cost;
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(1);
                return t;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new Cost();
            }
        }

        public IList<Product> GetAllEntitiesById(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
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
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByName(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
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
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByDescription(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Description)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderBy(arg => arg.Description)
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
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByDiscount(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Discount)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderBy(arg => arg.Discount)
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
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByQuantityValue(Expression<Func<Product, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Quantity.Value)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderBy(arg => arg.Quantity.Value)
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
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByCostValue(Expression<Func<Product, bool>> @where, int currentPageNumber,
            int pageSize, Currency currency, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                        ? _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .Where(g => g.Cost.Prices.Any(f => f.Currency.Equals(currency)))
                            .OrderByDescending(arg => arg.Cost.Prices.First(w => w.Currency.Equals(currency)).Value)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Include(p => p.Quantity)
                            .Include(p => p.Quantity.Unit)
                            .Where(@where)
                            .OrderBy(arg => arg.Quantity.Value)
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
                return new List<Product>();
            }
        }
    }
}
