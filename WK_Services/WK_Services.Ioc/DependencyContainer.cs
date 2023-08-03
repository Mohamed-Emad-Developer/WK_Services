

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WK_Services.Application.AutoMapper;
using WK_Services.Bus.Bus;
using WK_Services.Domain.Core.Bus;
 
namespace WK_Services.Ioc
{
    public class DependencyContainer
    {
       
        public static void RegisterServices(IServiceCollection services)
        {
            //MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddMediatR(typeof(DependencyContainer));
           

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
             
            
            AutoMapperConfiguration.RegisterMapping();

            //RegisterModels
            RegisterModelsServices.RegisterModelServices(services);
 



        }
        
    }
}
