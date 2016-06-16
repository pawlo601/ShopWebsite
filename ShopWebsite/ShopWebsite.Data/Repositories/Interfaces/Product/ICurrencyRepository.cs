using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        IList<Currency> GetAllEntitiesById(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllEntitiesByName(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllEntitiesByShortcut(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllEntitiesByExchange(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

    }
}