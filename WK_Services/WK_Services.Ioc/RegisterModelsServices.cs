

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WK_Clients.Data.Repository;
using WK_Clients.Domain.CommandHandlers.ClientCommandHandlers;
using WK_Contacts.Data.Repository;
using WK_Contacts.Domain.CommandHandlers.ContactCommandHandlers;
using WK_Services.Application.Interfaces;
using WK_Services.Application.Services;
using WK_Services.Data.Repository;
using WK_Services.Domain.CommandHandlers.OrderCommandHandlers;
using WK_Services.Domain.CommandHandlers.ServiceCommandHandlers;
using WK_Services.Domain.Commands.ClientCommands;
using WK_Services.Domain.Commands.ContactCommands;
using WK_Services.Domain.Commands.OrderCommands;
using WK_Services.Domain.Commands.ServiceCommands;
using WK_Services.Domain.IRepository;

namespace WK_Services.Ioc
{
    public class RegisterModelsServices
    {
        public static void RegisterModelServices(IServiceCollection services)
        {

            #region Service
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IRequestHandler<CreateServiceCommand, bool>, CreateServiceCommandHandlers>();
            services.AddScoped<IRequestHandler<UpdateServiceCommand, bool>, UpdateServiceCommandHandlers>();
            #endregion

            #region Client
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IRequestHandler<CreateClientCommand, bool>, CreateClientCommandHandlers>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, bool>, UpdateClientCommandHandlers>();
            #endregion

            #region Contact
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IRequestHandler<CreateContactCommand, bool>, CreateContactCommandHandlers>();
            services.AddScoped<IRequestHandler<UpdateContactCommand, bool>, UpdateContactCommandHandlers>();
            #endregion

            #region User
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Order
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandlers>();
            #endregion

        }
    }
}
