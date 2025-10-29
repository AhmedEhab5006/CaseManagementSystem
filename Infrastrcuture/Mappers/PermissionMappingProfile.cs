using Application.Dto_s;
using Application.Dto_s.ManagementDto_s;
using AutoMapper;
using Domain.Entites.Permissions;
using Infrastrcuture.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Mappers
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            #region Mapping Permission Entity and Permission Add Dto

            CreateMap<PermissionDto, Permission>()
                  .ForMember(dest => dest.createdAt, opt => opt.MapFrom(src => DateTime.Now))
                  .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy))
                  .ForMember(dest => dest.versionNo, opt => opt.MapFrom(src => 1))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Name != null ? src.Name : "لا يوجد"));


            #endregion

            #region Mapping Permission Assignment

            CreateMap<PermissionAssignmentDto, RolePermission>()
                  .ForMember(dest => dest.createdAt, opt => opt.MapFrom(src => DateTime.Now))
                  .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy))
                  .ForMember(dest => dest.versionNo, opt => opt.MapFrom(src => 1))
                  .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.permissionId))
                  .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.assignedId));


            CreateMap<PermissionAssignmentDto, UserPermission>()
               .ForMember(dest => dest.createdAt, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy))
               .ForMember(dest => dest.versionNo, opt => opt.MapFrom(src => 1))
               .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.permissionId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.assignedId));


            #endregion

            #region Mapping Permission Primary Data Read Dto

            CreateMap<Permission, PermissionPrimaryDataReadDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description != null ? src.Description : "لا يوجد وصف"))
                    .ForMember(dest => dest.numberOfAssignedUsers, opt => opt.MapFrom(src => src.UserPermissions.Count()))
                    .ForMember(dest => dest.numberOfAssignedRoles, opt => opt.MapFrom(src => src.RolePermissions.Count()));


            #endregion

        }
    }
}
