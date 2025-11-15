using Application.Commons;
using Application.Dto_s.User;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetAllUsersQueryHandler(IManagementService _managementService) : IRequestHandler<GetAllUsersQuery, PagedResult<UserReadDto>>
    {
        public async Task<PagedResult<UserReadDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetAllUsersAsync(request._pageNumber, request._pageSize);
            return result;
        }
    }
}

