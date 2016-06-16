using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IPermissionService
    {
        Permission GetPermission(int id, out TransactionalInformation transaction);

        Permission CreatePermission(Permission permission, out TransactionalInformation transaction);

        void DeletePermission(Permission permission, out TransactionalInformation transaction);

        void DeletePermission(Expression<Func<Permission, bool>> where, out TransactionalInformation transaction);

        void UpdatePermission(Permission permission, out TransactionalInformation transaction);

        Permission GetPermission(Expression<Func<Permission, bool>> where, out TransactionalInformation transaction);

        IList<Permission> GetAllPermissionsById(Expression<Func<Permission, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Permission> GetAllPermissionsByDescription(Expression<Func<Permission, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}