using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.UserInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations.UserRepoImplementations
{
    public class UserRepository : RepositoryBase<User>, IUserRespository
    {
//todo finish Include in all methods return something-in all files
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        #region Company

        public Company AddNewCompany(Company entity, out TransactionalInformation transaction)
        {
            try
            {
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(
                    entity,
                    new ValidationContext(entity, null, null),
                    results,
                    true);
                _dbSet.Add(entity);
                Validation.TransformValidationResultsToTransactionalInformation(results, out transaction);
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
            return entity;
        }

        public void UpdateCompany(Company entity, out TransactionalInformation transaction)
        {
            try
            {
                _dbSet.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {"Uaktualniono baze danych."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public void DeleteCompany(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            try
            {
                IEnumerable<Company> objects = _dbSet.OfType<Company>().Where(where).AsEnumerable();
                // ReSharper disable once NotAccessedVariable
                var count = 0;
                foreach (var obj in objects)
                {
                    _dbSet.Remove(obj);
                    count++;
                }
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {$"All items({count}) have been removed."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public Company GetCompany(Expression<Func<Company, bool>> @where, out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<Company>()
                    .Include(b => b.Information)
                    .Where(where)
                    .FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public Company GetCompanyById(int id, out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<Company>()
                    .Include(b => b.Information)
                    .FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public IList<Company> GetAllCompaniesByName(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.CompanyName)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.CompanyName)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Regon)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Regon)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesById(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByEmail(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByPhoneNumber(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Company>()
                            .Include(s => s.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IDictionary<string, Address> GetAddressesOfCompany(int id, out TransactionalInformation transaction)
        {
            try
            {
                Address ct =
                    _dbSet
                        .OfType<Company>()
                        .Include(a => a.ContactAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ContactAddress;
                Address rt =
                    _dbSet
                        .OfType<Company>()
                        .Include(a => a.ResidentialAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ResidentialAddress;
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(2);
                return new Dictionary<string, Address>() {{"ContactAddress", ct}, {"ResidentialAddress", rt}};
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new Dictionary<string, Address>();
            }
        }

        public IList<Order> GetAllCompanyOrders(int id, out TransactionalInformation transaction)
        {
//todo finish implementation 3
            transaction = null;
            return new List<Order>();
        }

        public IList<CustomerDiscount> GetAllCompanyDiscounts(int id, out TransactionalInformation transaction)
        {
//todo finish implementation 4
            transaction = null;
            return new List<CustomerDiscount>();
        }

        #endregion

        #region Employee

        public Employee AddNewEmployee(Employee entity, out TransactionalInformation transaction)
        {
            try
            {
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(
                    entity,
                    new ValidationContext(entity, null, null),
                    results,
                    true);
                _dbSet.Add(entity);
                Validation.TransformValidationResultsToTransactionalInformation(results, out transaction);
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
            return entity;
        }

        public void UpdateEmployee(Employee entity, out TransactionalInformation transaction)
        {
            try
            {
                _dbSet.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {"Uaktualniono baze danych."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public void DeleteEmployee(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            try
            {
                IEnumerable<Employee> objects = _dbSet.OfType<Employee>().Where(where).AsEnumerable();
                // ReSharper disable once NotAccessedVariable
                var count = 0;
                foreach (var obj in objects)
                {
                    _dbSet.Remove(obj);
                    count++;
                }
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {$"All items({count}) have been removed."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public Employee GetEmployee(Expression<Func<Employee, bool>> @where, out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<Employee>()
                    .Include(b => b.Information)
                    .Where(where)
                    .FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public Employee GetEmployeeById(int id, out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<Employee>()
                    .Include(b => b.Information)
                    .FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Position)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Position)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesById(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByEmail(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByPhoneNumber(Expression<Func<Employee, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<Employee>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IDictionary<string, Address> GetAddressesOfEmployee(int id, out TransactionalInformation transaction)
        {
            try
            {
                Address ct =
                    _dbSet
                        .OfType<Employee>()
                        .Include(a => a.ContactAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ContactAddress;
                Address rt =
                    _dbSet
                        .OfType<Employee>()
                        .Include(a => a.ResidentialAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ResidentialAddress;
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(2);
                return new Dictionary<string, Address>() {{"ContactAddress", ct}, {"ResidentialAddress", rt}};
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new Dictionary<string, Address>();
            }
        }

        #endregion

        #region IndividualClient

        public IndividualClient AddNewIndividualClient(IndividualClient entity, out TransactionalInformation transaction)
        {
            try
            {
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(
                    entity,
                    new ValidationContext(entity, null, null),
                    results,
                    true);
                _dbSet.Add(entity);
                Validation.TransformValidationResultsToTransactionalInformation(results, out transaction);
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
            return entity;
        }

        public void UpdateIndividualClient(IndividualClient entity, out TransactionalInformation transaction)
        {
            try
            {
                _dbSet.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {"Uaktualniono baze danych."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public void DeleteIndividualClient(Expression<Func<IndividualClient, bool>> @where,
            out TransactionalInformation transaction)
        {
            try
            {
                IEnumerable<IndividualClient> objects = _dbSet.OfType<IndividualClient>().Where(where).AsEnumerable();
                // ReSharper disable once NotAccessedVariable
                var count = 0;
                foreach (var obj in objects)
                {
                    _dbSet.Remove(obj);
                    count++;
                }
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage = new List<string> {$"All items({count}) have been removed."}
                };
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public IndividualClient GetIndividualClient(Expression<Func<IndividualClient, bool>> @where,
            out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<IndividualClient>()
                    .Include(a => a.Information)
                    .Where(where).FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public IndividualClient GetIndividualClientById(int id, out TransactionalInformation transaction)
        {
            try
            {
                var item = _dbSet
                    .OfType<IndividualClient>()
                    .Include(a => a.Information)
                    .FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> {item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana."}
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsById(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByEmail(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc, out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByPhoneNumber(
            Expression<Func<IndividualClient, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .OfType<IndividualClient>()
                            .Include(b => b.Information)
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1)*pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IDictionary<string, Address> GetAddressesOfIndividualClient(int id,
            out TransactionalInformation transaction)
        {
            try
            {
                Address ct =
                    _dbSet
                        .OfType<IndividualClient>()
                        .Include(a => a.ContactAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ContactAddress;
                Address rt =
                    _dbSet
                        .OfType<IndividualClient>()
                        .Include(a => a.ResidentialAddress)
                        .FirstOrDefault(a => a.Id == id)
                        .ResidentialAddress;
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(2);
                return new Dictionary<string, Address>() {{"ContactAddress", ct}, {"ResidentialAddress", rt}};
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new Dictionary<string, Address>();
            }
        }

        public IList<Order> GetAllIndividualClientOrders(int id, out TransactionalInformation transaction)
        {
            //todo finish implementation 2
            transaction = null;
            return new List<Order>();
        }

        public IList<CustomerDiscount> GetAllIndividualClientDiscounts(int id, out TransactionalInformation transaction)
        {
            //todo finish implementation 5
            transaction = null;
            return new List<CustomerDiscount>();
        }

        #endregion

        public IList<Password> GetAllUserPasswords(int id, out TransactionalInformation transaction)
        {
//todo finish implementation 6
            transaction = null;
            return new List<Password>();
        }

        public IList<UserHasRole> GetAllUserRoles(int id, out TransactionalInformation transaction)
        {
//todo finish implementation 1
            transaction = null;
            return new List<UserHasRole>();
        }
    }
}