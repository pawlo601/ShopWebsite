using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces.UserInterfaces
{
    public interface IIndividualClientRespository
    {
        IndividualClient AddNewIndividualClient(IndividualClient entity, out TransactionalInformation transaction);

        void UpdateIndividualClient(IndividualClient entity, out TransactionalInformation transaction);

        void DeleteIndividualClient(Expression<Func<IndividualClient, bool>> where,
            out TransactionalInformation transaction);

        IndividualClient GetIndividualClient(Expression<Func<IndividualClient, bool>> where,
            out TransactionalInformation transaction);

        IndividualClient GetIndividualClientById(int id, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsById(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByEmail(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByPhoneNumber(Expression<Func<IndividualClient, bool>> where,
            int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<CustomerDiscount> GetAllIndividualClientDiscounts(int id, out TransactionalInformation transaction);

        IList<Order> GetAllIndividualClientOrders(int id, out TransactionalInformation transaction);

        IDictionary<string, Address> GetAddressesOfIndividualClient(int id, out TransactionalInformation transaction);
    }
}