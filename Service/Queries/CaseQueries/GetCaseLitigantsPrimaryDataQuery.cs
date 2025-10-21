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
    public class GetCaseLitigantsPrimaryDataQuery : IRequest<PagedResult<LitigantReadDto>>
    {
        public Guid _caseId { get; }
        public int _pageNumber { get; }
        public int _pageSize { get; }

        public GetCaseLitigantsPrimaryDataQuery(Guid caseId ,  int pageNumber , int pageSize)
        {
            _caseId = caseId;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
    }
}
