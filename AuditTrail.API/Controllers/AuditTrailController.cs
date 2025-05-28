using AuditTrail.API.BusinessDomainModel.Models;
using AuditTrail.API.BusinessObject.IService;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditTrailController : ControllerBase
    {
        private readonly IAuditTrailService _auditTrailService;

        public AuditTrailController( IAuditTrailService auditTrailService)
        {
            _auditTrailService = auditTrailService;
        }


        [HttpPost]
        [Route("LogChangesUpdate")]
      public IActionResult LogChangesUpdate([FromBody] AuditRequest auditRequest)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Model State");

            }
            var response = this._auditTrailService.GenerateAuditLog(auditRequest);

            return Ok(response);

        }
        [HttpGet("AuditLogsGet")]
        public IActionResult AuditLogsGet()
        {
            var response = this._auditTrailService.AuditLogsGet();

            return Ok(response);
        }
    }
}
