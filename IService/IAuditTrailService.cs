using AuditTrail.API.BusinessDomainModel;
using AuditTrail.API.BusinessDomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.API.BusinessObject.IService
{
    public interface IAuditTrailService
    {
        RequestResponse GenerateAuditLog(AuditRequest request);

        List<AuditEntry> AuditLogsGet();

    }
}
