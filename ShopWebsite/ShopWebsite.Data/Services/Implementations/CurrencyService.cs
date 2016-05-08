using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Implementations
{
    public class CurrencyService : MainService, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _currencyRepository = currencyRepository;
        }

        public Currency GetCurrency(int id, out TransactionalInformation transaction)
        {
            return _currencyRepository.GetEntityById(id, out transaction);
        }

        public Currency CreateCurrency(Currency currency, out TransactionalInformation transaction)
        {
            return _currencyRepository.AddNewEntity(currency, out transaction);
        }

        public void DeleteCurrency(Currency currency, out TransactionalInformation transaction)
        {
            _currencyRepository.DeleteEntity(currency1 => currency1.Id == currency.Id, out transaction);
        }

        public void DeleteCurrency(Expression<Func<Currency, bool>> @where, out TransactionalInformation transaction)
        {
            _currencyRepository.DeleteEntity(@where, out transaction);
        }

        public void UpdateCurrency(Currency currency, out TransactionalInformation transaction)
        {
            _currencyRepository.UpdateEntity(currency, out transaction);
        }

        public Currency GetCurrency(Expression<Func<Currency, bool>> @where, out TransactionalInformation transaction)
        {
            return _currencyRepository.GetEntity(where, out transaction);
        }

        public IList<Currency> GetAllCurrencies(Expression<Func<Currency, bool>> @where, int currentPageNumber, int pageSize,
            Expression<Func<Currency, IComparable>> sortExpression, bool ifDesc, out TransactionalInformation transaction)
        {
            return _currencyRepository.GetAllEntities(where, currentPageNumber, pageSize, sortExpression, ifDesc,
                out transaction);
        }
    }
}