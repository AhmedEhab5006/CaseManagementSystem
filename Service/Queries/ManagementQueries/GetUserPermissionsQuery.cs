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
    public class GetUserPermissionsQuery : IRequest<PagedResult<PermissionPrimaryDataReadDto>>
    {
        public string _userId { get; }
        public int _pageSize { get; }
        public int _pageNumber { get; }

        public GetUserPermissionsQuery(string userId, int pageSize, int pageNumber)
        {
            _userId = userId;
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }
    }
}

