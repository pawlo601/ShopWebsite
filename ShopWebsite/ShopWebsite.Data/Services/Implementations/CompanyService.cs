using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Implementations
{
    public class CompanyService : MainService, ICompanyService
    {//todo implements CompanyService
        private readonly IUserRespository _userRepository;

        public CompanyService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public Company GetMan(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Company CreateMan(Company man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(Company man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(Company man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Company GetProduct(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllMenById(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllMenByEmail(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllMenByPhoneNumber(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllCompaniesByName(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}