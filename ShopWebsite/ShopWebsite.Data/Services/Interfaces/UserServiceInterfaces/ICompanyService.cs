using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces
{
    public interface ICompanyService : IManService<Company>
    {
        IList<Company> GetAllCompaniesByName(Expression<Func<Company, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IDictionary<string, Address> GetAddressesOfCompany(int id, out TransactionalInformation transaction);

        IList<Order> GetAllCompanyOrders(int id, out TransactionalInformation transaction);

        IList<CustomerDiscount> GetAllCompanyDiscounts(int id, out TransactionalInformation transaction);
    }
}