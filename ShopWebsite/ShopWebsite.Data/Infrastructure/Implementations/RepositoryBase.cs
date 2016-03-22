using ShopWebsite.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using ShopWebsite.Data.Common;
using ShopWebsite.Model;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IValidatableObject
    {
        private ShopWebsiteContext dataContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory { get; private set; }
        protected ShopWebsiteContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual T AddNewEntity(T entity, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                bool validateAllProperties = false;
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(
                    entity,
                    new ValidationContext(entity, null, null),
                    results,
                    validateAllProperties);
                dbSet.Add(entity);
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
                IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                    dbSet.Remove(obj);
            }
            catch(Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public virtual void DeleteEntity(T entity, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                dbSet.Remove(entity);
                transaction.ReturnStatus = true;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, Expression<Func<T, int>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            totalRows = 0;
            transaction = new TransactionalInformation();
            try
            {
                List<T> items;
                if (ifDesc)
                     items = dbSet.Where(where).OrderByDescending(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                else
                    items = dbSet.Where(where).OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                totalRows = dbSet.Where(where).Count();
                transaction.ReturnStatus = true;
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<T>();
            }
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, Expression<Func<T, string>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            totalRows = 0;
            transaction = new TransactionalInformation();
            try
            {
                List<T> items;
                if (ifDesc)
                    items = dbSet.Where(where).OrderByDescending(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                else
                    items = dbSet.Where(where).OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                totalRows = dbSet.Where(where).Count();
                transaction.ReturnStatus = true;
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<T>();
            }
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, Expression<Func<T, decimal>> sortExpression, bool ifDesc, out int totalRows, out TransactionalInformation transaction)
        {
            totalRows = 0;
            transaction = new TransactionalInformation();
            try
            {
                List<T> items;
                if (ifDesc)
                    items = dbSet.Where(where).OrderByDescending(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                else
                    items = dbSet.Where(where).OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
                totalRows = dbSet.Where(where).Count();
                transaction.ReturnStatus = true;
                return items;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return new List<T>();
            }
        }

        public virtual T GetById(int id, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                T item = dbSet.Find(id);
                if (item != null)
                {
                    transaction.ReturnStatus = true;
                }
                else
                {
                    transaction.ReturnStatus = false;
                }
                return item;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public virtual T GetIf(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                T item = dbSet.Where(where).FirstOrDefault<T>();
                if (item != null)
                {
                    transaction.ReturnStatus = true;
                }
                else
                {
                    transaction.ReturnStatus = false;
                }
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
                dbSet.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
                transaction.ReturnStatus = true;
            }
            catch (Exception exc)
            {
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }
    }
}
