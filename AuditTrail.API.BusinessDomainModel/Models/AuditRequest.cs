using AuditTrail.API.BusinessDomainModel.Enum;

namespace AuditTrail.API.BusinessDomainModel.Models
{
    public class AuditRequest
    {
        public Users? Before { get; set; }
        public Users? After { get; set; }
        public AuditAction Action { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
