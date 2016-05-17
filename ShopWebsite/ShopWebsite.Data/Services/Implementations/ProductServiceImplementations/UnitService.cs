using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.ProductInterfaces;
using ShopWebsite.Data.Services.Interfaces.ProductServiceInterfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Implementations.ProductServiceImplementations
{
    public class UnitService : MainService, IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitRepository = unitRepository;
        }

        public Unit GetUnit(int id, out TransactionalInformation transaction)
        {
            return _unitRepository.GetEntityById(id, out transaction);
        }

        public Unit CreateUnit(Unit unit, out TransactionalInformation transaction)
        {
            return _unitRepository.AddNewEntity(unit, out transaction);
        }

        public void DeleteUnit(Unit unit, out TransactionalInformation transaction)
        {
            _unitRepository.DeleteEntity(unit1 => unit1.Id == unit.Id, out transaction);
        }

        public void DeleteUnit(Expression<Func<Unit, bool>> @where, out TransactionalInformation transaction)
        {
            _unitRepository.DeleteEntity(@where, out transaction);
        }

        public void UpdateUnit(Unit unit, out TransactionalInformation transaction)
        {
            _unitRepository.UpdateEntity(unit, out transaction);
        }

        public Unit GetUnit(Expression<Func<Unit, bool>> @where, out TransactionalInformation transaction)
        {
            return _unitRepository.GetEntity(@where, out transaction);
        }

        public IList<Unit> GetAllUnitsById(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _unitRepository.GetAllEntitiesById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Unit> GetAllUnitsByName(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _unitRepository.GetAllEntitiesByName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<Unit> GetAllUnitsByShortcut(Expression<Func<Unit, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _unitRepository.GetAllEntitiesByShortcut(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }
    }
}
