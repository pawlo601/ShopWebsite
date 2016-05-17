using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IIndividualClientService : IManService<IndividualClient>
    {
        IList<IndividualClient> GetAllIndividualClientsByName(Expression<Func<IndividualClient, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsBySurname(Expression<Func<IndividualClient, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<IndividualClient> GetAllIndividualClientsByBirtday(Expression<Func<IndividualClient, bool>> where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}