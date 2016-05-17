using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces.UserInterfaces
{
    public interface IUserRespository : IRepository<Company>, IRepository<Employee>, IRepository<IndividualClient>, ICompanyRespository, IEmployeeRespository, IIndividualClientRespository
    {
    }
}