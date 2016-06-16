using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations
{
    class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IList<Permission> GetAllEntitiesById(Expression<Func<Permission, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Permission> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Permission>();
            }
        }

        public IList<Permission> GetAllEntitiesByDescription(Expression<Func<Permission, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Permission> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Description)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Description)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Permission>();
            }
        }
    }
}
