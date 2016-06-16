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
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _roleRepository = roleRepository;
        }

        public Role GetRole(int id, out TransactionalInformation transaction)
        {
            return _roleRepository.GetEntityById(id, out transaction);
        }

        public Role CreateRole(Role role, out TransactionalInformation transaction)
        {
            return _roleRepository.AddNewEntity(role, out transaction);
        }

        public void DeleteRole(Role role, out TransactionalInformation transaction)
        {
            _roleRepository.DeleteEntity(role1 => role.Id == role1.Id, out transaction);
        }

        public void DeleteRole(Expression<Func<Role, bool>> @where, out TransactionalInformation transaction)
        {
            _roleRepository.DeleteEntity(where, out transaction);
        }

        public void UpdateRole(Role role, out TransactionalInformation transaction)
        {
            _roleRepository.UpdateEntity(role, out transaction);
        }

        public Role GetRole(Expression<Func<Role, bool>> @where, out TransactionalInformation transaction)
        {
            return _roleRepository.GetEntity(where, out transaction);
        }

        public IList<Role> GetAllRolesById(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            return _roleRepository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Role> GetAllRolesByName(Expression<Func<Role, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction)
        {
            return _roleRepository.GetAllEntitiesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }
    }
}