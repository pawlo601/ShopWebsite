﻿using ShopWebsite.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.DataBaseContexts;

namespace ShopWebsite.Data.Infrastructure.Implementations
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IValidatableObject, IIntroduceable
    {
        protected ShopWebsiteContext _dataContext;

        protected readonly IDbSet<T> _dbSet;
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
                LoggingException.LogException(
                    "RepositoryBase",
                    "AddNewEntity",
                    entity.ToString(),
                    string.Empty,
                    string.Empty,
                    "Error in adding entity.",
                    exc);
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
            return entity;
        }

        public virtual void DeleteEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            try
            {
                IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
                // ReSharper disable once NotAccessedvariables
                int count = 0;
                foreach (T obj in objects)
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
                LoggingException.LogException(
                    "RepositoryBase",
                    "DeleteEntity",
                    where.ToString(),
                    string.Empty,
                    string.Empty,
                    "Error in removal entity.",
                    exc);
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }

        public virtual T GetEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            try
            {
                T item = _dbSet.Where(where).FirstOrDefault();
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
                LoggingException.LogException(
                    "RepositoryBase",
                    "GetEntity",
                    where.ToString(),
                    string.Empty,
                    string.Empty,
                    "Error in getting entity.",
                    exc);
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public T GetEntityById(int id, out TransactionalInformation transaction)
        {
            try
            {
                T item = _dbSet.FirstOrDefault(a => a.GetId() == id);
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
                LoggingException.LogException(
                    "RepositoryBase",
                    "GetEntityById",
                    "id: " + id,
                    string.Empty,
                    string.Empty,
                    "Error in getting entity by id.",
                    exc);
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
                return null;
            }
        }

        public virtual void UpdateEntity(T entity, out TransactionalInformation transaction)
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
                LoggingException.LogException(
                    "RepositoryBase",
                    "UpdateEntity",
                    entity.ToString(),
                    string.Empty,
                    string.Empty,
                    "Error in updating entity.",
                    exc);
                Validation.BuildTransactionalInformationFromException(exc, out transaction);
            }
        }
    }
}
