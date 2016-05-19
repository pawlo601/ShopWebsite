using System.Collections.Generic;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces.UserInterfaces
{
    public interface IUserRespository : ICompanyRespository, IEmployeeRespository, IIndividualClientRespository
    {
        IList<Password> GetAllUserPasswords(int id, out TransactionalInformation transaction);

        IList<UserHasRole> GetAllUserRoles(int id, out TransactionalInformation transaction);
    }
}