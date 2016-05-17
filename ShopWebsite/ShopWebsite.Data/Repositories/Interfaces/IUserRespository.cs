using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IUserRespository : IRepository<Company>, IRepository<Employee>, IRepository<IndividualClient>, ICompanyRespository, IEmployeeRespository, IIndividualClientRespository
    {
    }
}