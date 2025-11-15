using Application.Dto_s;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.ManagementQueries
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleReadDto>>
    {
    }
}

