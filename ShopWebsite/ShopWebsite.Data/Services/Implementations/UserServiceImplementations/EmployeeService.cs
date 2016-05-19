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
    public class EmployeeService : MainService, IEmployeeService
    {
        private readonly IUserRespository _userRepository;

        public EmployeeService(IUserRespository userRespository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRespository;
        }

        public Employee GetMan(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetEmployeeById(id, out transaction);
        }

        public Employee CreateMan(Employee man, out TransactionalInformation transaction)
        {
            return _userRepository.AddNewEmployee(man, out transaction);
        }

        public void DeleteMan(Employee man, out TransactionalInformation transaction)
        {
            _userRepository.DeleteEmployee(employee => employee.Id == man.Id, out transaction);
        }

        public void DeleteMan(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            _userRepository.DeleteEmployee(where, out transaction);
        }

        public void UpdateMan(Employee man, out TransactionalInformation transaction)
        {
            _userRepository.UpdateEmployee(man, out transaction);
        }

        public Employee GetMan(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            return _userRepository.GetEmployee(where, out transaction);
        }

        public IList<Employee> GetAllMenById(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Employee> GetAllMenByEmail(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesByEmail(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Employee> GetAllMenByPhoneNumber(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesByPhoneNumber(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesByPosition(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesBySurname(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            return _userRepository.GetAllEmployeesByBirtday(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IDictionary<string, Address> GetAddressesOfEmployee(int id, out TransactionalInformation transaction)
        {
            return _userRepository.GetAddressesOfEmployee(id, out transaction);
        }
    }
}