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
    public class EmployeeService : MainService, IEmployeeService
    {//todo implements EmployeeService
        private readonly IUserRespository _userRepository;

        public EmployeeService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public Employee GetMan(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Employee CreateMan(Employee man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(Employee man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteMan(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee man, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Employee GetProduct(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllMenById(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllMenByEmail(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllMenByPhoneNumber(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}