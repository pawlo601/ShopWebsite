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
    {
        private readonly IStatusRespository _statusRespository;

        public StatusService(IStatusRespository statusRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _statusRespository = statusRepository;
        }

        public Status GetStatus(int id, out TransactionalInformation transaction)
        {
            return _statusRespository.GetEntityById(id, out transaction);
        }

        public Status CreateStatus(Status status, out TransactionalInformation transaction)
        {
            return _statusRespository.AddNewEntity(status, out transaction);
        }

        public void DeleteStatus(Status status, out TransactionalInformation transaction)
        {
            _statusRespository.DeleteEntity(status1 => status1.Id == status.Id, out transaction);
        }

        public void DeleteStatus(Expression<Func<Status, bool>> @where, out TransactionalInformation transaction)
        {
            _statusRespository.DeleteEntity(@where, out transaction);
        }

        public void UpdateStatus(Status status, out TransactionalInformation transaction)
        {
            _statusRespository.UpdateEntity(status, out transaction);
        }

        public Status GetStatus(Expression<Func<Status, bool>> @where, out TransactionalInformation transaction)
        {
            return _statusRespository.GetEntity(where, out transaction);
        }

        public IList<Status> GetAllStatusesById(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _statusRespository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Status> GetAllStatusesByName(Expression<Func<Status, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _statusRespository.GetAllEntitiesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }
    }
}