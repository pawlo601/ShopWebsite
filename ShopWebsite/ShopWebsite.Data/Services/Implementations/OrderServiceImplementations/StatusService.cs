using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.OrderInterfaces;
using ShopWebsite.Data.Services.Interfaces.OrderServiceInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Services.Implementations.OrderServiceImplementations
{
    public class StatusService : MainService, IStatusService
    {//todo implements StatusService
        private readonly IStatusRespository _statusRespository;

        public StatusService(IStatusRespository statusRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _statusRespository = statusRepository;
        }

        public Status GetStatus(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Status CreateStatus(Status status, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteStatus(Status status, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteStatus(Expression<Func<Status, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(Status status, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Status GetStatus(Expression<Func<Status, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Status> GetAllStatusesById(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Status> GetAllStatusesByName(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}