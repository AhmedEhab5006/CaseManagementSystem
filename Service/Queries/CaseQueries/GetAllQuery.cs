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
    public class GetAllQuery : IRequest<PagedResult<CaseReadDto>>
    {
        public int _pageNumber { get; set; }
        public int _pageSize { get; set; }

        public GetAllQuery(int pageNumber , int pageSize)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
    }
}
