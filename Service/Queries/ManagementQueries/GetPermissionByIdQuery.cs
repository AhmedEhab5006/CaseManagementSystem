using Application.Dto_s.ManagementDto_s;
using MediatR;
using System;

namespace Application.Queries.ManagementQueries
{
    public class GetPermissionByIdQuery : IRequest<PermissionPrimaryDataReadDto?>
    {
        public Guid _permissionId { get; }

        public GetPermissionByIdQuery(Guid permissionId)
        {
            _permissionId = permissionId;
        }
    }
}

