using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces
{
    public interface ICompanyService : IManService<Company>
    {
        IList<Company> GetAllCompaniesByName(Expression<Func<Company, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}