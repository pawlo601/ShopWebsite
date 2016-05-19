using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces
{
    public interface IIndividualClientService : IManService<IndividualClient>
    {
        IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<CustomerDiscount> GetAllIndividualClientDiscounts(int id, out TransactionalInformation transaction);

        IList<Order> GetAllIndividualClientOrders(int id, out TransactionalInformation transaction);

        IDictionary<string, Address> GetAddressesOfIndividualClient(int id, out TransactionalInformation transaction);
    }
}