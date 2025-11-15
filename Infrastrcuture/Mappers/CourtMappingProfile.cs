using Application.Dto_s.CourtDto_s;
using AutoMapper;
using Domain.Entites;
using Microsoft.Data.SqlClient;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Mappers
{
    public class CourtMappingProfile : Profile
    {
        public CourtMappingProfile() {
            
            #region Mapping From Court Add Dto to Court Entity
            
            CreateMap<CourtAddDto, Court>()
                .ForMember(dest => dest.id, opt => opt.Ignore())
                .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy)) 
                .ForMember(dest => dest.createdAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.updatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.updatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.isDeleted, opt => opt.MapFrom(src => false)) 
                .ForMember(dest => dest.rowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.deletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.deletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.deletionReason, opt => opt.Ignore())
                .ForMember(dest => dest.versionNo, opt => opt.MapFrom(src => 1)) 
                .ForMember(dest => dest.nameAR, opt => opt.MapFrom(src => src.NameAr))
                .ForMember(dest => dest.nameEN, opt => opt.MapFrom(src => src.NameEn != null ?  src.NameEn : "لا يوجد"))
                .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.courtGradeId, opt => opt.MapFrom(src => src.CourtGradeId))
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true)) 
                .ForMember(dest => dest.courtGrade, opt => opt.Ignore()) 
                .ForMember(dest => dest.Cases, opt => opt.Ignore());

            #endregion

            #region Court Primary Data Read Mapping


            CreateMap<Court, CourtPrimaryDataReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.nameAR))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city))
            .ForMember(dest => dest.CourtGrade, opt => opt.MapFrom(src => src.courtGrade.nameAR))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive ? "نشط" : "غير نشط"));


            #endregion

            #region Court Full Data Read

            CreateMap<Court, CourtFullDataReadDto>()
                .ForMember(dest => dest.CourtId, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.addtionDate, opt => opt.MapFrom(src => src.createdAt.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.RegistererName, opt => opt.MapFrom(src => src.createdBy != null ? src.createdBy : "غير محدد"))
                .ForMember(dest => dest.lastModificationDate, opt => opt.MapFrom(src => src.updatedAt != null ? src.updatedAt.Value.ToString("yyyy-MM-dd") : "لم يتم التعديل بعد"))
                .ForMember(dest => dest.modifier, opt => opt.MapFrom(src => src.updatedBy != null ? src.updatedBy : "لم يتم التعديل بعد"))
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.nameAR))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nameEN) ? src.nameEN : "لا يوجد"))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city != null ? src.city : "لا يوجد"))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive ? "نشط" : "غير نشط"))
                .ForMember(dest => dest.CourtGradeName, opt => opt.MapFrom(src => src.courtGrade != null ? src.courtGrade.nameAR : string.Empty));

            #endregion

        }
    }
}
