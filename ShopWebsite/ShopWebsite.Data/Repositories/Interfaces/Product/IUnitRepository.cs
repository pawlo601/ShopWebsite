using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IUnitRepository : IRepository<Unit>
    {
        IList<Unit> GetAllEntitiesById(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Unit> GetAllEntitiesByName(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Unit> GetAllEntitiesByShortcut(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}
