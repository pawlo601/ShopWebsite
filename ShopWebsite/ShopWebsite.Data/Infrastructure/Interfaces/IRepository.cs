﻿using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ShopWebsite.Data.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class, IValidatableObject
    {
        T AddNewEntity(T entity, out TransactionalInformation transaction);

        void UpdateEntity(T entity, out TransactionalInformation transaction);

        void DeleteEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction);

        T GetEntity(Expression<Func<T, bool>> where, out TransactionalInformation transaction);

        T GetEntityById(int id, out TransactionalInformation transaction);
    }
}
