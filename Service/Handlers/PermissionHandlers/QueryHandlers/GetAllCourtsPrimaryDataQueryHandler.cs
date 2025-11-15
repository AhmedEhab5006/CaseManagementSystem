using Application.Commons;
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
    public class GetAllCourtsPrimaryDataQueryHandler(IManagementService _managementService) : IRequestHandler<GetAllCourtsPrimaryDataQuery, PagedResult<CourtPrimaryDataReadDto>>
    {
        public async Task<PagedResult<CourtPrimaryDataReadDto>> Handle(GetAllCourtsPrimaryDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetAllCourtsPrimaryDataAsync(request._pageNumber, request._pageSize);
            return result;
        }
    }
}

