using Application.Commons;
using Application.Dto_s.ManagementDto_s;
using MediatR;
using System;

namespace Application.Queries.ManagementQueries
{
    public class GetCaseReAssignmentRequestsQuery : IRequest<PagedResult<CaseReAssignmentRequestGetDto>>
    {
        public int _pageSize { get; }
        public int _pageNumber { get; }

        public GetCaseReAssignmentRequestsQuery(int pageSize, int pageNumber)
        {
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }
    }
}

