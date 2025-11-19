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
    public class GetClosedCasesQuery : IRequest<PagedResult<CaseReadDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetClosedCasesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
