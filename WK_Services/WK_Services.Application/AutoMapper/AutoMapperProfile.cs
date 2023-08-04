using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WK_Services.Application.ViewModels;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.Models;

namespace WK_Services.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
 

            CreateMap<ClientVM, Client>()
                .ReverseMap();

            CreateMap<OrderVM, Order>();
            CreateMap<Contact, ContactVM>()
                .ForMember(dest => dest.Email , src=> src.MapFrom(src=> src.User.Email))
                .ForMember(dest => dest.UserName, src=> src.MapFrom(src=> src.User.UserName))
                .ForMember(dest => dest.Name , src=> src.MapFrom(src=> src.User.Name))
                ;
 
              CreateMap<CreateContactVM, Contact>()
                
                ;
 
              CreateMap<Order, OrderTableVM>()
                   .ForMember(dest => dest.OrderType, src => src.MapFrom(src => src.Type.ToString()))
                   .ForMember(dest => dest.ServiceName, src => src.MapFrom(src => src.Service.Name))
                   .ForMember(dest => dest.ClientName, src => src.MapFrom(src => src.Client.Name))
                   .ForMember(dest => dest.DeliveryDate, src => src.MapFrom(src => src.RequestedDeliveryDate!=null? src.RequestedDeliveryDate.Value.ToString("dd MMM yyyy"): ""))
                ;
 
             
             
              
        }
       

    }
}

