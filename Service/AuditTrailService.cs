using AuditTrail.API.BusinessDomainModel;
using AuditTrail.API.BusinessDomainModel.Enum;
using AuditTrail.API.BusinessDomainModel.Models;
using AuditTrail.API.BusinessObject.IService;
using System.Net;
using System.Reflection;

namespace AuditTrail.API.BusinessObject.Service
{
    public class AuditTrailService : IAuditTrailService
    {
        public static RequestResponse _response;
        private readonly List<AuditEntry> _auditStore = new();
        public RequestResponse GenerateAuditLog(AuditRequest request)
        {
            var entry = new AuditEntry
            {
                EntityName = request.EntityName,
                UserId = request.UserId,
                Timestamp = DateTime.UtcNow,
                Action = request.Action
            };

            try
            {
                if (request.Action == AuditAction.Updated && request.Before != null && request.After != null)
                {
                    var beforeProps = request.Before.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var afterProps = request.After.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);


                    foreach (var prop in beforeProps)
                    {
                        var afterProp = afterProps.FirstOrDefault(p => p.Name == prop.Name);
                        if (afterProp == null) continue;

                        var beforeValue = prop.GetValue(request.Before);
                        var afterValue = afterProp.GetValue(request.After);

                        if (!Equals(beforeValue, afterValue))
                        {
                            entry.Changes[prop.Name] = new PropertyChange
                            {
                                Before = beforeValue,
                                After = afterValue
                            };
                        }
                    }
                }
                else if (request.Action == AuditAction.Created && request.After != null)
                {
                    var props = request.After.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);


                    foreach (var prop in props)
                    {
                        var afterValue = prop.GetValue(request.After);
                        entry.Changes[prop.Name] = new PropertyChange
                        {
                            Before = null,
                            After = afterValue
                        };
                    }
                }
                else if (request.Action == AuditAction.Deleted && request.Before != null)
                {
                    var props = request.Before.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    foreach (var prop in props)
                    {
                        var beforeValue = prop.GetValue(request.Before);
                        entry.Changes[prop.Name] = new PropertyChange
                        {
                            Before = beforeValue,
                            After = null
                        };
                    }
                }
                _auditStore.Add(entry);

                _response = new RequestResponse()
                {
                    Data = entry,
                    StatusMessage = "Success",
                    StatusCode = HttpStatusCode.OK

                };

            }
            catch (Exception ex)
            {

                _response = new RequestResponse()
                {
                    Data = null,
                    StatusMessage = ex.Message.ToString(),
                    StatusCode = HttpStatusCode.InternalServerError

                };
            }
  
            return _response;
        }

        public List<AuditEntry> AuditLogsGet()
        {
            return this._auditStore;
        }
    }
}
