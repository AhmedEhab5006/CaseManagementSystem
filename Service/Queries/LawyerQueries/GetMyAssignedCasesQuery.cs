using Application.Commons;
using Application.Dto_s.CaseDtos;
using MediatR;

namespace Application.Queries.LawyerQueries
{
    public class GetMyAssignedCasesQuery : IRequest<PagedResult<CaseReadDto>>
    {
        public string LawyerId { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public GetMyAssignedCasesQuery(string lawyerId, int pageNumber, int pageSize)
        {
            LawyerId = lawyerId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
