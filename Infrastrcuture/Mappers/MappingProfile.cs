using Application.Dto_s;
using AutoMapper;
using Infrastrcuture.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Mapping Entites into DTO's
            
            
            //Mapping Found Application User Entity to the DTO
            CreateMap<ApplicationUser, ApplicationUserReadDto>();


            #endregion

            #region Mapping DTO's To Entites


            //Mapping UserDTO to User Entity
            CreateMap<ApplicationUserReadDto, ApplicationUser>()
                        .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));

            #endregion

        }
    }
}
