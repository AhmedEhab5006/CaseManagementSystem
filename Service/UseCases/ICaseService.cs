using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.Audting;
using Application.Dto_s.CaseDtos;
using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICaseService
    {
        Task<CaseAddServiceValidataion> AddCasePrimaryData(CaseAddDto caseAddDto);
        Task<CaseAssignmentServiceValidatation> AssignCaseToLawyerAsync(IEnumerable<CaseAssignmentDto> caseAssignmentDto);
        Task<bool> AddCaseTopicAsync(CaseTopicAddDto caseTopicDto);
        Task<bool> AddCaseTypeAsync(CaseTypeAddDto caseTypeDto);
        Task<bool> AddCaseLitigantRoleAsync(CaseLitigantRoleDto caseLitigantRoleDto);
        Task<List<Guid>> AddLitigantsRangeAsync(List<LitigantDto> litigantDtos);
        Task<CaseLitigantAddVaildatation> AddCaseLitigantsRangeAsync(List<CaseLtitgantDto> litigantDtos);
        Task<PagedResult<CaseReadDto>> GetAllCasesMainDataAsync(int pageNumber , int sizeOfPage);
        Task<CaseFullDataReadDto?> GetCaseAllDataAsync(Guid caseId);
        Task<PagedResult<LitigantReadDto?>> GetCaseLitigantsAsync(int pageNumber, int pageSize, Guid caseId); 
        Task<LitigantDto?> GetCaseLitigantFullDataAsync(Guid litigantId); 
        Task<PagedResult<LawyerReadDto?>> GetCaseLawyersAsync(Guid caseId , int pageNumber, int pageSize); 
        Task<LawyerFullDataReadDto?> GetCaseLawyersFullDataAsync(string lawyerId); 
        Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCaseTypesForDropDownMenuAsync(); 
        Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCaseTopicsForDropDownMenuAsync(); 
        Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCourtsForDropDownMenuAsync(); 
        Task<IEnumerable<CaseDropDownMenuGetDto>?> GetLitigantsRoleDropDownMenuAsync(); 
        Task<CaseDocumentAddValidation> AddCaseFileAsync(CaseDocumentAddDto caseDocumentAddDto); 
        Task<IEnumerable<CaseDropDownMenuGetDto>> GetAvailableCrimesAsync(); 
        Task<AddCrimeValidations> AddCrimeToLitigantAsync(CrimeAddDto crimeAdd); 
        Task<PagedResult<CrimeReadDto>> GetLitigantCrimesInCase(Guid litigantId , Guid CaseId, int pageNumber, int pageSize); 
        Task<PagedResult<CaseHistoryReadDto>> GetCaseHistory(Guid caseId , int pageNumber , int pageSize); 
      }
}
