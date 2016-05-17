using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;

namespace ShopWebsite.Data.Services.Interfaces.UserServiceInterfaces
{
    public interface IManService<T>
    {
        T GetMan(int id, out TransactionalInformation transaction);

        T CreateMan(T man, out TransactionalInformation transaction);

        void DeleteMan(T man, out TransactionalInformation transaction);

        void DeleteMan(Expression<Func<T, bool>> where, out TransactionalInformation transaction);

        void UpdateMan(T man, out TransactionalInformation transaction);

        T GetMan(Expression<Func<T, bool>> where, out TransactionalInformation transaction);

        IList<T> GetAllMenById(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<T> GetAllMenByEmail(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<T> GetAllMenByPhoneNumber(Expression<Func<T, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}