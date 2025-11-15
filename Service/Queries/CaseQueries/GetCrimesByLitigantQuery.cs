using Application.Dto_s.CaseDtos;
using Application.Commons;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Queries.CaseQueries
{
    public class GetCrimesByLitigantQuery : IRequest<PagedResult<CrimeReadDto>>
    {
        public Guid CaseId { get; set; }
        public Guid LitigantId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetCrimesByLitigantQuery(Guid caseId, Guid litigantId, int pageNumber = 1, int pageSize = 10)
        {
            CaseId = caseId;
            LitigantId = litigantId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
