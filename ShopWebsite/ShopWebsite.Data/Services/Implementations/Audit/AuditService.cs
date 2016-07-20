using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Data.Repositories.Interfaces.Audit;
using ShopWebsite.Data.Services.Interfaces.Audit;
using ShopWebsite.Model.Entities;
using AuditN = ShopWebsite.Model.Entities.Audit.Audit;

namespace ShopWebsite.Data.Services.Implementations.Audit
{//todo: log all exception in services
    public class AuditService : MainService, IAuditService
    {
        private readonly IAuditRepository _auditRepository;

        public AuditService(IAuditRepository auditRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _auditRepository = auditRepository;
        }

        public AuditN AddNewAudit(AuditN entity, out TransactionalInformation transaction)
        {
            var a= _auditRepository.AddNewEntity(entity, out transaction);
            _auditRepository.SaveChanges();
            return a;
        }

        public AuditN GetAudit(Expression<Func<AuditN, bool>> @where, out TransactionalInformation transaction)
        {
            return _auditRepository.GetEntity(where, out transaction);
        }

        public IList<AuditN> GetAllAuditsById(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsById(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<AuditN> GetAllAuditsByAddressIP(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByAddressIP(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<AuditN> GetAllAuditsByUserName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByUserName(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<AuditN> GetAllAuditsBySessionId(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsBySessionId(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<AuditN> GetAllAuditsByURLAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByURLAccessed(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<AuditN> GetAllAuditsByAction(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByAction(where, currentPageNumber, pageSize, ifDesc, out transaction);
        }

        public IList<AuditN> GetAllAuditsByPropertyName(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByPropertyName(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }

        public IList<AuditN> GetAllAuditsByTimeAccessed(Expression<Func<AuditN, bool>> @where, int currentPageNumber, int pageSize, bool ifDesc,
            out TransactionalInformation transaction)
        {
            return _auditRepository.GetAllAuditsByTimeAccessed(where, currentPageNumber, pageSize, ifDesc,
                out transaction);
        }
    }
}