using Application.Commons;
using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.LawyerQueries
{
    public class GetCurrentCasesQuery : IRequest<PagedResult<CaseReadDto>>
    {
        public string LawyerId { get; }
    public int PageNumber { get; }
    public int PageSize { get; }

    public GetCurrentCasesQuery(string lawyerId, int pageNumber, int pageSize)
    {
        LawyerId = lawyerId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

    }

