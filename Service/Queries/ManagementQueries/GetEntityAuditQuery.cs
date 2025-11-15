using Application.Commons;
using Application.Dto_s.Audting;
using Application.Dto_s.ManagementDto_s;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Queries.ManagementQueries
{
    public class GetEntityAuditQuery : IRequest<PagedResult<AuditGetDto>>
    {
        public Guid _entityId { get; }
        public int _pageNumber { get; }
        public int _pageSize { get; }

        public GetEntityAuditQuery(Guid entityId, int pageNumber , int pageSize)
        {
            _entityId = entityId;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
    }
}

