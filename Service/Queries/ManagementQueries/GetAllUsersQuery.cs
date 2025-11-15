using Application.Commons;
using Application.Dto_s.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ManagementQueries
{
    public class GetAllUsersQuery : IRequest<PagedResult<UserReadDto>>  
    {
        public int _pageSize { get;  }
        public int _pageNumber { get; }

        public GetAllUsersQuery(int pageSize , int pageNumber)
        {
            _pageSize = pageSize;
            _pageNumber = pageNumber;
        }
    }
}

