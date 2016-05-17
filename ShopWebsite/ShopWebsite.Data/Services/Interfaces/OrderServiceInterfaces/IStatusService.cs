using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Services.Interfaces.OrderServiceInterfaces
{
    public interface IStatusService
    {
        Status GetStatus(int id, out TransactionalInformation transaction);

        Status CreateStatus(Status status, out TransactionalInformation transaction);

        void DeleteStatus(Status status, out TransactionalInformation transaction);

        void DeleteStatus(Expression<Func<Status, bool>> where, out TransactionalInformation transaction);

        void UpdateStatus(Status status, out TransactionalInformation transaction);

        Status GetStatus(Expression<Func<Status, bool>> where, out TransactionalInformation transaction);

        IList<Status> GetAllStatusesById(Expression<Func<Status, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Status> GetAllStatusesByName(Expression<Func<Status, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}