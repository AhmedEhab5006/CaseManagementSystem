using Application.Commons;
using Application.Dto_s.CaseDtos;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICaseService
    {
        Task<CaseAddServiceValidataion> AddCasePrimaryData(CaseAddDto caseAddDto);
        Task<CaseAssignmentServiceValidatation> AssignCaseToLawyerAsync(CaseAssignmentDto caseAssignmentDto);
        Task<bool> AddCaseTopicAsync(CaseTopicAddDto caseTopicDto);
        Task<bool> AddCaseTypeAsync(CaseTypeAddDto caseTypeDto);
        Task<bool> AddCaseLitigantRoleAsync(CaseLitigantRoleDto caseLitigantRoleDto);
        Task<bool> AddLitigantAsync(LitigantDto litigantDto);
        Task<CaseLitigantAddVaildatation> AddCaseLitigantAsync(CaseLtitgantDto litigantDto);
        Task<PagedResult<CaseReadDto>> GetAllCasesMainDataAsync(int pageNumber , int sizeOfPage);
        Task<CaseFullDataReadDto?> GetCaseAllDataAsync(Guid caseId);
        Task<PagedResult<LitigantReadDto?>> GetCaseLitigantsAsync(int pageNumber, int pageSize, Guid caseId); 
        Task<LitigantDto?> GetCaseLitigantFullDataAsync(Guid litigantId); 
      }
}
