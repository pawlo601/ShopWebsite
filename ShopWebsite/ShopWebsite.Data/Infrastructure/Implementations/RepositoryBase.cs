using ShopWebsite.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebsite.Model.Entities;
using System.Linq.Expressions;
using System.Data.Entity;
using ShopWebsite.Data.Common;

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
            throw new NotImplementedException();
        }

        public virtual void DeleteEntity(T entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAllIf(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public virtual T GetIf(Expression<Func<T, bool>> where, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateEntity(T entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
