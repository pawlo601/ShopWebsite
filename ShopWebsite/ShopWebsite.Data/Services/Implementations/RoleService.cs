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
    public class RoleService : MainService, IRoleService
    {//todo implements RoleService
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _roleRepository = roleRepository;
        }

        public Role GetRole(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Role CreateRole(Role role, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(Role role, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(Expression<Func<Role, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(Role role, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Role GetRole(Expression<Func<Role, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Role> GetAllRolesById(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Role> GetAllRolesByName(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}