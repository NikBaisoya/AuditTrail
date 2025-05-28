using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.API.BusinessDomainModel.Models
{
    public class PropertyChange
    {
        public object? Before { get; set; }
        public object? After { get; set; }
    }
}
