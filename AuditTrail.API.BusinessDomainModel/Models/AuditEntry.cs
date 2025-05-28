using AuditTrail.API.BusinessDomainModel.Enum;

namespace AuditTrail.API.BusinessDomainModel.Models
{
    public class AuditEntry
    {
        public string EntityName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public AuditAction Action { get; set; }
        public Dictionary<string, PropertyChange> Changes { get; set; }  = new();
    }
}
