using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces
{
    public interface IEmployeeService : IManService<Employee>
    {
        IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}