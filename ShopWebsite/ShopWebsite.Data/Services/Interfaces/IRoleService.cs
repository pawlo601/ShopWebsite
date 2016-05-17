using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IRoleService
    {
        Role GetRole(int id, out TransactionalInformation transaction);

        Role CreateRole(Role role, out TransactionalInformation transaction);

        void DeleteRole(Role role, out TransactionalInformation transaction);

        void DeleteRole(Expression<Func<Role, bool>> where, out TransactionalInformation transaction);

        void UpdateRole(Role role, out TransactionalInformation transaction);

        Role GetRole(Expression<Func<Role, bool>> where, out TransactionalInformation transaction);

        IList<Role> GetAllRolesById(Expression<Func<Role, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Role> GetAllRolesByName(Expression<Func<Role, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}