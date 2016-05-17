using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces.UserInterfaces
{
    public interface IUserRespository : ICompanyRespository, IEmployeeRespository, IIndividualClientRespository
    {
    }
}