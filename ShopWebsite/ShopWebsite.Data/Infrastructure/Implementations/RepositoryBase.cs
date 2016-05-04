using ShopWebsite.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using ShopWebsite.Data.Common;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IValidatableObject
    {
        private ShopWebsiteContext _dataContext;
        private readonly IDbSet<T> _dbSet;
        protected IDbFactory DbFactory { get; }
        protected ShopWebsiteContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public virtual T AddNewEntity(T entity, out TransactionalInformation transaction)
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

        public virtual void DeleteEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
                foreach (T obj in objects)
                    _dbSet.Remove(obj);
            }
            catch(Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public virtual IEnumerable<T> GetAllEntities(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, Expression<Func<T, IComparable>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            totalRows = 0;
            transaction = new TransactionalInformation();
            try
            {
                List<T> items = ifDesc ? _dbSet.Where(@where).OrderByDescending(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList() : _dbSet.Where(@where).OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                totalRows = _dbSet.Where(where).Count();
                transaction.ReturnStatus = true;
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<T>();
            }
        }

        public virtual T GetEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                T item = _dbSet.Where(where).FirstOrDefault();
                transaction.ReturnStatus = item != null;
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public virtual void UpdateEntity(T entity, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _dbSet.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                transaction.ReturnStatus = true;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }
    }
}
