using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.LawyerService
{
    public interface ILawyerService
    {
        public Task<LawyerReadDto?> GetLawyerPrimaryDataById(string id);
        public Task<IEnumerable<CaseDropDownMenuGetDto?>> GetLawyersForDropDownMenuAsync();
        Task<PagedResult<CaseReadDto>> GetMyAssignedCases(string lawyerId, int pageNumber, int pageSize);
        public Task<CaseReAssignmentValidation> SendCaseReAssignmentRequest(CaseReAssignmentRequestDto dto);
    }
}
