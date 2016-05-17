using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRespository
    {//todo implements UserRepository
        public UserRepository(IDbFactory dbFactory): base(dbFactory) { }

        public Company AddNewEntity(Company entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Company entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Company GetEntity(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Employee AddNewEntity(Employee entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Employee entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public Employee GetEntity(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IndividualClient AddNewEntity(IndividualClient entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(IndividualClient entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Expression<Func<IndividualClient, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IndividualClient GetEntity(Expression<Func<IndividualClient, bool>> @where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        IndividualClient IRepository<IndividualClient>.GetEntityById(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        Employee IRepository<Employee>.GetEntityById(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        Company IRepository<Company>.GetEntityById(int id, out TransactionalInformation transaction)
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

        public IList<Company> GetAllCompaniesById(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllCompaniesByEmail(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetAllCompaniesByPhoneNumber(Expression<Func<Company, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
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

        public IList<Employee> GetAllEmployeesById(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesByEmail(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAllEmployeesByPhoneNumber(Expression<Func<Employee, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
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

        public IList<IndividualClient> GetAllIndividualClientsById(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllIndividualClientsByEmail(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetAllIndividualClientsByPhoneNumber(Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
