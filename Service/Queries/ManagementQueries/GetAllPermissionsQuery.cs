using Application.Commons;
using Application.Dto_s.ManagementDto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ManagementQueries
{
    public class GetAllPermissionsQuery : IRequest<PagedResult<PermissionPrimaryDataReadDto>>  
    {
        public int _pageSize { get;  }
        public int _pageNumber { get; }

        public GetAllPermissionsQuery(int pageSize , int pageNumber)
        {
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }
    }
}
