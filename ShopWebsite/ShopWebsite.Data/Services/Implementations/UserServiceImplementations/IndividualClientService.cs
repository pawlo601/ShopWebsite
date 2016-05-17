using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.UserInterfaces;
using ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Implementations.UserServiceImplementations
{
    public class IndividualClientService : MainService, IIndividualClientService
    {//todo implements IndividualClientService
        private readonly IUserRespository _userRepository;

        public IndividualClientService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public IndividualClient GetMan(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IndividualClient CreateMan(IndividualClient man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(IndividualClient man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(Expression<Func<IndividualClient, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(IndividualClient man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IndividualClient GetProduct(Expression<Func<IndividualClient, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllMenById(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllMenByEmail(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllMenByPhoneNumber(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}