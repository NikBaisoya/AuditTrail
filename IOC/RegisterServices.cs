using AuditTrail.API.BusinessObject.IService;
using AuditTrail.API.BusinessObject.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AuditTrail.API.BusinessObject.IOC
{
    public static class RegisterServices
    {
        public static  IServiceCollection RegisterService(this IServiceCollection serviceCollection)
        {

            return serviceCollection
                .AddSingleton(typeof(IAuditTrailService), typeof(AuditTrailService));
        }

    }
}
