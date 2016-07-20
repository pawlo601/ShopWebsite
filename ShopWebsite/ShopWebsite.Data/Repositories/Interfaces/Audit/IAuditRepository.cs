using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities;
using AuditN = ShopWebsite.Model.Entities.Audit.Audit;

namespace ShopWebsite.Data.Repositories.Interfaces.Audit
{
    public interface IAuditRepository : IRepository<AuditN>
    {
        void SaveChanges();

        IList<AuditN> GetAllAuditsById(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
           bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByAddressIP(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByUserName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsBySessionId(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByURLAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByAction(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByPropertyName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);

        IList<AuditN> GetAllAuditsByTimeAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize,
            bool ifDesc, out TransactionalInformation transaction);
    }
}