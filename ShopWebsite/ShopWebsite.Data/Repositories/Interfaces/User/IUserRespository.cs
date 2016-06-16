using System.Collections.Generic;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IUserRespository : ICompanyRespository, IEmployeeRespository, IIndividualClientRespository
    {
        IList<Password> GetAllUserPasswords(int id, out TransactionalInformation transaction);

        IList<Role> GetAllRoles(int id, out TransactionalInformation transaction);

        IList<Permission> GetAllPermissions(int id, out TransactionalInformation transaction);
    }
}