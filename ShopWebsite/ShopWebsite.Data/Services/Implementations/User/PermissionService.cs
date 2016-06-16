using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Implementations
{
    public class PermissionService : MainService, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _permissionRepository = permissionRepository;
        }

        public Permission GetPermission(int id, out TransactionalInformation transaction)
        {
            return _permissionRepository.GetEntityById(id, out transaction);
        }

        public Permission CreatePermission(Permission permission, out TransactionalInformation transaction)
        {
            return _permissionRepository.AddNewEntity(permission, out transaction);
        }

        public void DeletePermission(Permission permission, out TransactionalInformation transaction)
        {
            _permissionRepository.DeleteEntity(permission1 => permission1.Id == permission.Id, out transaction);
        }

        public void DeletePermission(Expression<Func<Permission, bool>> @where, out TransactionalInformation transaction)
        {
            _permissionRepository.DeleteEntity(@where, out transaction);
        }

        public void UpdatePermission(Permission permission, out TransactionalInformation transaction)
        {
            _permissionRepository.UpdateEntity(permission, out transaction);
        }

        public Permission GetPermission(Expression<Func<Permission, bool>> @where, out TransactionalInformation transaction)
        {
            return _permissionRepository.GetEntity(where, out transaction);
        }

        public IList<Permission> GetAllPermissionsById(Expression<Func<Permission, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _permissionRepository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Permission> GetAllPermissionsByDescription(Expression<Func<Permission, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _permissionRepository.GetAllEntitiesByDescription(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }
    }
}
