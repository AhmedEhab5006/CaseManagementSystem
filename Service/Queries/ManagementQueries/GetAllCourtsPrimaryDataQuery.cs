using Application.Commons;
using Application.Dto_s.CourtDto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ManagementQueries
{
    public class GetAllCourtsPrimaryDataQuery : IRequest<PagedResult<CourtPrimaryDataReadDto>>
    {
        public int _pageSize { get; }
        public int _pageNumber { get; }

        public GetAllCourtsPrimaryDataQuery(int pageSize, int pageNumber)
        {
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }
    }
}

