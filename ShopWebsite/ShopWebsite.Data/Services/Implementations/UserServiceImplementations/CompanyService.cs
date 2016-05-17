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
    public class CompanyService : MainService, ICompanyService
    {
        private readonly IUserRespository _userRepository;

        public CompanyService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public Company GetMan(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetCompanyById(id, out transaction);
        }

        public Company CreateMan(Company man, out TransactionalInformation transaction)
        {
            return _userRepository.AddNewCompany(man, out transaction);
        }

        public void DeleteMan(Company man, out TransactionalInformation transaction)
        {
            _userRepository.DeleteCompany(company => company.Id == man.Id, out transaction);
        }

        public void DeleteMan(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            _userRepository.DeleteCompany(where, out transaction);
        }

        public void UpdateMan(Company man, out TransactionalInformation transaction)
        {
            _userRepository.UpdateCompany(man, out transaction);
        }

        public Company GetMan(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            return _userRepository.GetCompany(where, out transaction);
        }

        public IList<Company> GetAllMenById(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAllCompaniesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Company> GetAllMenByEmail(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAllCompaniesByEmail(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Company> GetAllMenByPhoneNumber(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAllCompaniesByPhoneNumber(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Company> GetAllCompaniesByName(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAllCompaniesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _userRepository.GetAllCompaniesByRegon(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }
    }
}