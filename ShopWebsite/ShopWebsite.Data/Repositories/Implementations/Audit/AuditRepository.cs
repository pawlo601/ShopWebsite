using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Infrastructure.Implementations;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.Audit;
using ShopWebsite.Model.Entities;
using AuditN = ShopWebsite.Model.Entities.Audit.Audit;

namespace ShopWebsite.Data.Repositories.Implementations.Audit
{
    public class AuditRepository : RepositoryBase<AuditN>, IAuditRepository
    {
        public AuditRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public IList<AuditN> GetAllAuditsById(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Id)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByAddressIP(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.AddressIP)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.AddressIP)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByUserName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.UserName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.UserName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsBySessionId(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.SessionId)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.SessionId)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByURLAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.URLAccessed)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.URLAccessed)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByAction(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.Action)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.Action)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByPropertyName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.PropertyName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.PropertyName)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }

        public IList<AuditN> GetAllAuditsByTimeAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            try
            {
                List<AuditN> items =
                    ifDesc
                        ? _dbSet
                            .Where(@where)
                            .OrderByDescending(arg => arg.TimeAccessed)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()
                        : _dbSet
                            .Where(@where)
                            .OrderBy(arg => arg.TimeAccessed)
                            .Skip((currentPageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
                int a = _dbSet.Where(@where).Count();
                transaction = TransactionalInformation.CreateTransactionInforamtionHowManyResults(a);
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<AuditN>();
            }
        }
    }
}