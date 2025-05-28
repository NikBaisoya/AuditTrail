using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuditTrail.API.BusinessDomainModel
{
    public class RequestResponse
    {
        public object? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    
        public string StatusMessage { get; set; }
    }
}
