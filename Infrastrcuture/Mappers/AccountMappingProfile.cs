using Application.Dto_s;
using Application.Dto_s.AccountDto_s;
using AutoMapper;
using Infrastrcuture.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Mappers
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile() {

            #region Mapping From Account Entity to AccountReadDto

            CreateMap<ApplicationUser, AccountReadDto>()
                     .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.displayName != null ?
                                                                        src.displayName : "غير متاح"))

                     .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                     .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ApplicationUserImagePath))
                     .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.isActive))
                     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                     .ForMember(dest => dest.JoinDate, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd")))
                     ;



            #endregion
        }
    }
}
