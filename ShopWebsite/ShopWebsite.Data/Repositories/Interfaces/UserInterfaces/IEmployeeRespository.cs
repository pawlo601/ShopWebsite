using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Interfaces.UserInterfaces
{
    public interface IEmployeeRespository
    {
        Employee AddNewEmployee(Employee entity, out TransactionalInformation transaction);

        void UpdateEmployee(Employee entity, out TransactionalInformation transaction);

        void DeleteEmployee(Expression<Func<Employee, bool>> where, out TransactionalInformation transaction);

        Employee GetEmployee(Expression<Func<Employee, bool>> where, out TransactionalInformation transaction);

        Employee GetEmployeeById(int id, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesById(Expression<Func<Employee, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByEmail(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByPhoneNumber(Expression<Func<Employee, bool>> where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction);

        IDictionary<string, Address> GetAddressesOfEmployee(int id, out TransactionalInformation transaction);
    }
}