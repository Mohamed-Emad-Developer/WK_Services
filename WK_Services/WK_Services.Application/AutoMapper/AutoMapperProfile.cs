using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WK_Services.Domain.Core.Bus;
using WK_Services.Domain.Models.User;

namespace WK_Services.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
 
            CreateMap<IdentityResult, IdentityResultViewModel>();
            CreateMap<IdentityError, ErrorRequestViewModel>();
 
             
             
              
        }
       

    }
}

