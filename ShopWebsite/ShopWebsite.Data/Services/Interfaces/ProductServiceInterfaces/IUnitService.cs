using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Interfaces.ProductServiceInterfaces
{
    public interface IUnitService
    {
        Unit GetUnit(int id, out TransactionalInformation transaction);

        Unit CreateUnit(Unit unit, out TransactionalInformation transaction);

        void DeleteUnit(Unit unit, out TransactionalInformation transaction);

        void DeleteUnit(Expression<Func<Unit, bool>> where, out TransactionalInformation transaction);

        void UpdateUnit(Unit unit, out TransactionalInformation transaction);

        Unit GetUnit(Expression<Func<Unit, bool>> where, out TransactionalInformation transaction);

        IList<Unit> GetAllUnitsById(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Unit> GetAllUnitsByName(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Unit> GetAllUnitsByShortcut(Expression<Func<Unit, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}