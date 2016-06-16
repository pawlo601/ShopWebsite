using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Implementations
{
    public class IndividualClientService : MainService, IIndividualClientService
    {
        private readonly IUserRespository _userRepository;

        public IndividualClientService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public IndividualClient GetMan(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetIndividualClientById(id, out transaction);
        }

        public IndividualClient CreateMan(IndividualClient man, out TransactionalInformation transaction)
        {
            return _userRepository.AddNewIndividualClient(man, out transaction);
        }

        public void DeleteMan(IndividualClient man, out TransactionalInformation transaction)
        {
            _userRepository.DeleteIndividualClient(client => client.Id == man.Id, out transaction);
        }

        public void DeleteMan(Expression<Func<IndividualClient, bool>> @where, out TransactionalInformation transaction)
        {
            _userRepository.DeleteIndividualClient(where, out transaction);
        }

        public void UpdateMan(IndividualClient man, out TransactionalInformation transaction)
        {
            _userRepository.UpdateIndividualClient(man, out transaction);
        }

        public IndividualClient GetMan(Expression<Func<IndividualClient, bool>> @where,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetIndividualClient(where, out transaction);
        }


        public IList<IndividualClient> GetAllMenById(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsById(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<IndividualClient> GetAllMenByEmail(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsByEmail(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<IndividualClient> GetAllMenByPhoneNumber(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsByPhoneNumber(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsByName(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsBySurname(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientsByBirtday(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<CustomerDiscount> GetAllIndividualClientDiscounts(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientDiscounts(id, out transaction);
        }

        public IList<Order> GetAllIndividualClientOrders(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllIndividualClientOrders(id, out transaction);
        }

        public IDictionary<string, Address> GetAddressesOfIndividualClient(int id,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAddressesOfIndividualClient(id, out transaction);
        }
    }
}