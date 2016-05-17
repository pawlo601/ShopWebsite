using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.ProductInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Implementations.ProductRepoImplementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory) { }


        public IList<Product> GetAllEntitiesById(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Id).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Id).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByName(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Name).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Name).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByDescription(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Description).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Description).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByDiscount(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Discount).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Discount).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByQuantityValue(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Quantity.Value).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Quantity.Value).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Product>();
            }
        }

        public IList<Product> GetAllEntitiesByCostValue(Expression<Func<Product, bool>> @where, int currentPageNumber, int pageSize,
            Currency currency, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Product> items =
                    ifDesc
                    ? _dbSet.Where(@where).Where(g => g.Cost.Prices.Any(f => f.Currency.Equals(currency))).OrderByDescending(arg => arg.Cost.Prices.First(w => w.Currency.Equals(currency)).Value).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Quantity.Value).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage = new List<string> { a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie." }
                };
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
