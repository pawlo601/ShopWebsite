using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Data.Services.Interfaces.ProductServiceInterfaces
{
    public interface ICurrencyService
    {
        Currency GetCurrency(int id, out TransactionalInformation transaction);

        Currency CreateCurrency(Currency currency, out TransactionalInformation transaction);

        void DeleteCurrency(Currency currency, out TransactionalInformation transaction);

        void DeleteCurrency(Expression<Func<Currency, bool>> where, out TransactionalInformation transaction);

        void UpdateCurrency(Currency currency, out TransactionalInformation transaction);

        Currency GetCurrency(Expression<Func<Currency, bool>> where, out TransactionalInformation transaction);

        IList<Currency> GetAllCurrenciesById(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllCurrenciesByName(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllCurrenciesByShortcut(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<Currency> GetAllCurrenciesByExchange(Expression<Func<Currency, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        void SaveProduct();
    }
}