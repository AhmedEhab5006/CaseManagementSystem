using Application.Dto_s.CaseDtos;
using AutoMapper;
using Domain.Entites;
using Domain.Enums;

namespace Infrastrcuture.Mappers
{
    public class LawyerMappingProfile : Profile
    {
        public LawyerMappingProfile()
        {
            #region Case Entity to CaseReadDto Mapping

            CreateMap<Case, CaseReadDto>()
                .ForMember(dest => dest.CourtName, opt => opt.MapFrom(src => src.court != null ? src.court.nameAR : string.Empty))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.CourtGrade, opt => opt.MapFrom(src => src.court != null && src.court.courtGrade != null ? src.court.courtGrade.nameAR : string.Empty))
                .ForMember(dest => dest.CaseTitle, opt => opt.MapFrom(src => src.caseTopic != null ? src.caseTopic.topicName : string.Empty))
                .ForMember(dest => dest.CaseType, opt => opt.MapFrom(src => src.caseType != null ? src.caseType.typeName : string.Empty))
                .ForMember(dest => dest.CaseNumber, opt => opt.MapFrom(src => src.caseNumber))
                .ForMember(dest => dest.CaseDate, opt => opt.MapFrom(src => src.caseDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status));

            #endregion

            #region CaseReAssignmentRequest Entity Mapping

            CreateMap<CaseReAssignmentRequestDto, CaseReAssignmentRequest>()
                .ForMember(dest => dest.id, opt => opt.Ignore())
                .ForMember(dest => dest.createdAt, opt => opt.Ignore())
                .ForMember(dest => dest.updatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.isDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.rowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.deletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.deletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.deletionReason, opt => opt.Ignore())
                .ForMember(dest => dest.versionNo, opt => opt.Ignore())
                .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.createdBy))
                .ForMember(dest => dest.AssignerId, opt => opt.MapFrom(src => src.AssignerId))
                .ForMember(dest => dest.AssigneeId, opt => opt.MapFrom(src => src.AssigneeId))
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.CaseId))
                .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => CaseReAssignmentRequestStates.Pending));

            #endregion
        }
    }
}

