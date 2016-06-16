using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class StatusRespository : RepositoryBase<Status>, IStatusRespository
    {
        public StatusRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IList<Status> GetAllEntitiesById(Expression<Func<Status, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Status> items =
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
                return new List<Status>();
            }
        }

        public IList<Status> GetAllEntitiesByName(Expression<Func<Status, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Status> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Name)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Name)
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
                return new List<Status>();
            }
        }
    }
}
