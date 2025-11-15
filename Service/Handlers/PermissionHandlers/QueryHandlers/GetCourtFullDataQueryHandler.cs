using Application.Dto_s.CourtDto_s;
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
    public class GetCourtFullDataQueryHandler(IManagementService _managementService) : IRequestHandler<GetCourtFullDataQuery, CourtFullDataReadDto>
    {
        public async Task<CourtFullDataReadDto> Handle(GetCourtFullDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetAllCourtFullDataAsync(request._courtId);
            return result;
        }
    }
}

