using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.LawyerDto_s;
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
        Task<PagedResult<CaseReadDto>> GetMyCurrentlyWoringCases(string lawyerId, int pageNumber, int pageSize);
        public Task<CaseReAssignmentValidation> SendCaseReAssignmentRequest(CaseReAssignmentRequestDto dto);
        public Task<DeleteAndUpdateValidatation> AcceptCaseAssignment(Guid CaseId , string acceptedBy);
        public Task<PagedResult<CaseReAssignmentRequestsReadDto>> GetMyReAssignmentRequests(string Id , int pageNumber, int pageSize);
        public Task<DeleteAndUpdateValidatation> RevokeReAssignmentRequests(Guid requestId, string assignerId, DeleteDto delete);
        public Task<DeleteAndUpdateValidatation> CloseCase(Guid caseId , CloseCaseDto close);
    }
}
