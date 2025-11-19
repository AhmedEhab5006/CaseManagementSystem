using Application.Commons;
using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CaseQueries
{
    public class GetAttachmentsQuery : IRequest<PagedResult<CaseAttachmentsReadDto>>
    {
        public Guid CaseId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAttachmentsQuery(Guid caseId, int pageNumber, int pageSize)
        {
            CaseId = caseId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
