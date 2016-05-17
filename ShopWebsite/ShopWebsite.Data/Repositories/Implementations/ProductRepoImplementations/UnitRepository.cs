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
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {//ok
        public UnitRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IList<Unit> GetAllEntitiesById(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, 
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Unit> items =
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
                return new List<Unit>();
            }
        }

        public IList<Unit> GetAllEntitiesByName(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, 
            bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Unit> items =
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
                return new List<Unit>();
            }
        }

        public IList<Unit> GetAllEntitiesByShortcut(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Unit> items =
                    ifDesc
                    ? _dbSet.Where(@where).OrderByDescending(arg => arg.Shortcut).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList()
                    : _dbSet.Where(@where).OrderBy(arg => arg.Shortcut).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
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
                return new List<Unit>();
            }
        }
    }
}
