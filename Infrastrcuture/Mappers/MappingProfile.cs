using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using AutoMapper;
using Domain.Entites;
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

            #region Case Entity Mapping

            // Mapping CaseAddDto to Case Entity
            CreateMap<CaseAddDto, Case>()
                .ForMember(dest => dest.id, opt => opt.Ignore()) // Ignore ID as it will be generated
                .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy)) // Map from DTO
                .ForMember(dest => dest.createdAt, opt => opt.Ignore()) // Will be set by service layer
                .ForMember(dest => dest.updatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.updatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.isDeleted, opt => opt.MapFrom(src => false)) // Default to not deleted
                .ForMember(dest => dest.rowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.deletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.deletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.deletionReason, opt => opt.Ignore())
                .ForMember(dest => dest.versionNo, opt => opt.MapFrom(src => 1)) // Initial version
                .ForMember(dest => dest.approved, opt => opt.MapFrom(src => false)) // Default to not approved
                .ForMember(dest => dest.court, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.caseType, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.caseTopic, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.CourtGrade, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.caseDocuments, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.assignments, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.claims, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.events, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.taskItems, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.hearings, opt => opt.Ignore()) // Collection navigation property
                .ForMember(dest => dest.CaseLitigants, opt => opt.Ignore()); // Collection navigation property

            // Mapping Case Entity to CaseAddDto
            CreateMap<Case, CaseAddDto>();

            #endregion

        }
    }
}
