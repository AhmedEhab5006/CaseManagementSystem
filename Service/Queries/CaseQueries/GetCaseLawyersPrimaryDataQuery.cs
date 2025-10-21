using Application.Commons;
using Application.Dto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CaseQueries
{
    public class GetCaseLawyersPrimaryDataQuery : IRequest<PagedResult<LawyerReadDto>>
    {
        public Guid _caseId { get;  }
        public int _pageNumber { get;  }
        public int _pageSize { get;  }

        public GetCaseLawyersPrimaryDataQuery(Guid caseId, int pageNumber, int pageSize)
        {
            _caseId = caseId;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
    }
}
