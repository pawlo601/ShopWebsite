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
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Repositories.Implementations.UserRepoImplementations
{
    public class UserRepository : RepositoryBase<User>, IUserRespository
    {//todo lazy/eager loading and how?
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

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
                    ReturnMessage = new List<string> { "Uaktualniono baze danych." }
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
                    ReturnMessage = new List<string> { $"All items({count}) have been removed." }
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
                var item = _dbSet.OfType<Company>().Where(where).FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
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
                var item = _dbSet.OfType<Company>().FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

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
                    ReturnMessage = new List<string> { "Uaktualniono baze danych." }
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
                    ReturnMessage = new List<string> { $"All items({count}) have been removed." }
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
                var item = _dbSet.OfType<Employee>().Where(where).FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
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
                var item = _dbSet.OfType<Employee>().FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
                };
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

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
                    ReturnMessage = new List<string> { "Uaktualniono baze danych." }
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
                    ReturnMessage = new List<string> { $"All items({count}) have been removed." }
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
                var item = _dbSet.OfType<IndividualClient>().Where(where).FirstOrDefault();
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
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
                var item = _dbSet.OfType<IndividualClient>().FirstOrDefault(a => a.GetId() == id);
                transaction = new TransactionalInformation
                {
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string> { item == null ? "Nie znaleziono czukanej danej." : "Znaleziono szukana dana." }
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
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.CompanyName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.CompanyName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByRegon(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Regon)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Regon)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesById(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByEmail(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Company> GetAllCompaniesByPhoneNumber(Expression<Func<Company, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Company> items =
                    ifDesc
                        ? _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Company>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Company>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Company>();
            }
        }

        public IList<Employee> GetAllEmployeesByPosition(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Position)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Position)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByName(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesBySurname(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByBirtday(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesById(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Include(x => x.Information)
                            .Include(x => x.ContactAddress)
                            .Include(x => x.ResidentialAddress)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Include(x => x.Information)
                            .Include(x => x.ContactAddress)
                            .Include(x => x.ResidentialAddress)
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByEmail(Expression<Func<Employee, bool>> @where, int currentPageNumber,
            int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<Employee> GetAllEmployeesByPhoneNumber(Expression<Func<Employee, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<Employee> items =
                    ifDesc
                        ? _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<Employee>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<Employee>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<Employee>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Name)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Surname)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Information.Birthday)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsById(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }

        public IList<IndividualClient> GetAllIndividualClientsByEmail(Expression<Func<IndividualClient, bool>> @where,
            int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<IndividualClient> items =
                    ifDesc
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.Email)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
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
                        ? _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet.OfType<IndividualClient>()
                            .Where(@where)
                            .OrderByDescending(arg => arg.PhoneNumber)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                var a = _dbSet.OfType<IndividualClient>().Where(@where).Count();
                transaction = new TransactionalInformation
                {
                    TotalRows = a,
                    ReturnStatus = true,
                    ReturnMessage =
                        new List<string>
                        {
                            a != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                        }
                };
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<IndividualClient>();
            }
        }
    }
}