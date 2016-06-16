using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IList<Permission> GetAllEntitiesById(Expression<Func<Permission, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Permission> GetAllEntitiesByDescription(Expression<Func<Permission, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}