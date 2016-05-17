using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.OrderInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Repositories.Implementations.OrderRepoImplementations
{
    public class StatusRespository : RepositoryBase<Status>, IStatusRespository
    {//todo implements StatusRespository
        public StatusRespository(IDbFactory dbFactory): base(dbFactory) { }

        public IList<Status> GetAllEntitiesById(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Status> GetAllEntitiesByName(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
