using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Data.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class, IValidatableObject
    {
        T AddNewEntity(T entity, out TransactionalInformation transaction);
        void UpdateEntity(T entity, out TransactionalInformation transaction);
        void DeleteEntity(T entity, out TransactionalInformation transaction);
        void DeleteEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction);
        T GetById(int id, out TransactionalInformation transaction);
        T GetIf(Expression<Func<T, bool>> where, out TransactionalInformation transaction);
        IEnumerable<T> GetAll(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction);
        IEnumerable<T> GetAllIf(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction);
    }
}
