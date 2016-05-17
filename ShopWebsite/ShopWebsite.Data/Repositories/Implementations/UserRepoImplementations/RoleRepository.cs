using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.UserInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations.UserRepoImplementations
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IList<Role> GetAllEntitiesById(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Role> items =
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
                return new List<Role>();
            }
        }

        public IList<Role> GetAllEntitiesByName(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Role> items =
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
                return new List<Role>();
            }
        }
    }
}
